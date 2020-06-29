using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TopologicalVertexRegistration
{
    class FaceTree
    {
        public int Count { get; private set; }
        public FaceNode Root { get; private set; }
        public List<FaceNode> FaceNodes { get; }
        public int Surplus { get => FaceNodes.Count(n => !n.Flag); }

        public FaceTree(IEnumerable<IPXFace> faces, IPXFace root)
        {
            if (!faces.Contains(root))
                throw new ArgumentException("root面はfaces内に存在していなければなりません。");

            FaceNodes = faces.Where(f => f != root).Select((f, i) => new FaceNode(f, i)).ToList();
            Root = new FaceNode(root, -1);

            SetNeighborRecurcive(Root, null);
            FlagReset();
        }

        public FaceTree(IEnumerable<IPXFace> faces, IPXFace root, IList<IPXVertex> vertices)
        {
            if (!faces.Contains(root))
                throw new ArgumentException("root面はfaces内に存在していなければなりません。");

            FaceNodes = faces.Where(f => f != root).Select((f, i) => new FaceNode(f, i, vertices)).ToList();
            Root = new FaceNode(root, -1, vertices);

            SetNeighborRecurcive(Root, null);
            FlagReset();
        }

        private void SetNeighborRecurcive(FaceNode node, FaceNode parent)
        {
            node.Parent = parent;
            foreach (var e in node.Edges)
            {
                var edgeShareNodes = FaceNodes.Where(n => n.Edges.Contains(e) && n != node).ToList();
                if (edgeShareNodes.Count < 0)
                {
                    continue;
                }
                node.Neighbor.AddRange(edgeShareNodes);
                e.Nodes.AddRange(edgeShareNodes);
                if (e.Nodes.Count > 2)
                    throw new FaceBrunchException();
            }
            node.Neighbor = node.Neighbor.Distinct().ToList();
            if (node.Neighbor.Count > 3)
                throw new FaceBrunchException();
            node.Flag = true;
            foreach (var n in node.Neighbor.Where(n => !n.Flag))
            {
                SetNeighborRecurcive(n, node);
            }
        }

        public void FlagReset()
        {
            FlagResetRecurcive(Root);
        }

        private void FlagResetRecurcive(FaceNode node)
        {
            node.Flag = false;
            foreach (var n in node.Neighbor)
            {
                if (n.Flag)
                    FlagResetRecurcive(n);
            }
        }
    }

    class FaceNode : IEquatable<FaceNode>
    {
        public IPXFace Face { get; }
        public List<PXEdge> Edges { get; }
        public bool Flag { get; set; } = false;
        public bool IsBorder { get => Neighbor.Any(n => n == null); }

        public FaceNode Parent { get; set; }
        public List<FaceNode> Neighbor { get; set; } = new List<FaceNode>();

        public int ID { get; set; }
        public string Name { get; }

        public FaceNode(IPXFace face, int id = -1)
        {
            Face = face;
            Edges = new List<PXEdge>(PXEdge.FromFace(Face));
            foreach (PXEdge e in Edges)
            {
                e.Nodes.Add(this);
            }
            ID = id;
        }

        public FaceNode(IPXFace face, int id, IList<IPXVertex> vs)
        {
            Face = face;
            Edges = new List<PXEdge>(PXEdge.FromFace(Face, id, vs.IndexOf(face.Vertex1), vs.IndexOf(face.Vertex2), vs.IndexOf(face.Vertex3)));
            foreach (PXEdge e in Edges)
            {
                e.Nodes.Add(this);
            }
            ID = id;
            Name = $"{ID}_{vs.IndexOf(face.Vertex1)}-{vs.IndexOf(face.Vertex2)}-{vs.IndexOf(face.Vertex3)}";
        }

        public PXEdge GetEdge(IPXVertex v1, IPXVertex v2)
        {
            PXEdge edge = Edges.FindAll(e => e.Vertices.Contains(v1)).Find(e => e.Vertices.Contains(v2));
            if (edge == null)
                throw new ArgumentException("この面に指定された頂点を含む辺は存在しません。");
            return edge;
        }


        public bool Equals(FaceNode other) => Face == other.Face;
        public override bool Equals(object obj) => obj is FaceNode node && Equals(node);

        public override int GetHashCode()
        {
            return Face.GetHashCode();
        }
    }

    class PXEdge : IEquatable<PXEdge>
    {
        public IPXVertex Vertex1 { get; set; }
        public IPXVertex Vertex2 { get; set; }
        public List<IPXVertex> Vertices { get => new List<IPXVertex> { Vertex1, Vertex2 }; }
        public (IPXVertex, IPXVertex) Pair { get => (Vertex1, Vertex2); }

        public List<FaceNode> Nodes { get; } = new List<FaceNode>();
        public List<IPXFace> Faces { get => Nodes.Select(n => n.Face).ToList(); }

        public string Name { get; set; }

        public bool Flag { get; set; } = false;

        public PXEdge(IPXVertex vertex1, IPXVertex vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }


        public static List<PXEdge> FromFace(IPXFace f) => new List<PXEdge> { new PXEdge(f.Vertex1, f.Vertex2), new PXEdge(f.Vertex2, f.Vertex3), new PXEdge(f.Vertex3, f.Vertex1) };

        public static List<PXEdge> FromFace(IPXFace f, int faceID, int vID1, int vID2, int vID3)
        {
            var es = FromFace(f);
            es[0].Name = $"{faceID}_{vID1}-{vID2}";
            es[1].Name = $"{faceID}_{vID2}-{vID3}";
            es[2].Name = $"{faceID}_{vID3}-{vID1}";
            return es;
        }

        public bool Equals(PXEdge other) => Vertices.Contains(other.Vertex1) && Vertices.Contains(other.Vertex2);
        public override bool Equals(object obj) => obj is PXEdge edge && Equals(edge);

        public override int GetHashCode()
        {
            return (Vertex1.GetHashCode() + Vertex2.GetHashCode()) / 2;
        }
    }

    [Serializable()]
    public class FaceBrunchException : Exception
    {
        public FaceBrunchException()
        {
        }

        public FaceBrunchException(string message)
            : base(message)
        {
        }

        public FaceBrunchException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected FaceBrunchException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}
