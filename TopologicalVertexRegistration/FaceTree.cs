using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace TopologicalVertexRegistration
{
    class FaceTree
    {
        public int Count { get; private set; }
        public FaceNode Root { get; private set; }
        public ReadOnlyCollection<FaceNode> FaceNodes { get; }
        private List<FaceNode> UnalignedNodes { get; }
        public int Surplus { get => UnalignedNodes.Count; }

        public FaceTree(IEnumerable<IPXFace> faces, IPXFace root)
        {
            if (!faces.Contains(root))
                throw new ArgumentException("root面はfacesコンテナ内に存在していなければなりません。");

            UnalignedNodes = faces.Select(f => new FaceNode(f)).ToList();
            FaceNodes = new ReadOnlyCollection<FaceNode>(UnalignedNodes);
            Root = new FaceNode(root);

            SetNeighborRecurcive(Root, null);
            FlagReset();
        }

        private void SetNeighborRecurcive(FaceNode node, FaceNode parent)
        {
            node.Parent = parent;
            foreach (var e in node.Edges)
            {
                var edgeShareNodes = FaceNodes.Where(n =>n.Edges.Contains(e) && n != node).ToList();
                if (!edgeShareNodes.Any())
                {
                    continue;
                }
                node.Neighbor.AddRange(edgeShareNodes);
                e.Nodes.AddRange(edgeShareNodes);
                if(e.Nodes.Count>2)
                    throw new FaceBrunchException();
            }
            if (node.Neighbor.Count > 3)
                throw new FaceBrunchException();
            UnalignedNodes.Remove(node);
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
        public List<FaceNode> Neighbor { get; } = new List<FaceNode>();

        public FaceNode(IPXFace face)
        {
            Face = face;
            Edges = new List<PXEdge>(PXEdge.FromFace(Face));
            foreach (PXEdge e in Edges)
            {
                e.Nodes.Add(this);
            }
        }

        public PXEdge GetEdge(IPXVertex v1,IPXVertex v2)
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

        public bool Flag { get; set; } = false;

        public PXEdge(IPXVertex vertex1, IPXVertex vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }


        public static List<PXEdge> FromFace(IPXFace f) => new List<PXEdge> { new PXEdge(f.Vertex1, f.Vertex2), new PXEdge(f.Vertex2, f.Vertex3), new PXEdge(f.Vertex3, f.Vertex1) };

        public bool Equals(PXEdge other) => Vertex1 == other.Vertex1 && Vertex2 == other.Vertex2;
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
