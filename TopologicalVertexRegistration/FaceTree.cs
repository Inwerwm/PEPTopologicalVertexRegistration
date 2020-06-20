using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TopologicalVertexRegistration
{
    class FaceTree
    {
        public int Count { get; private set; }
        public FaceNode Root { get; private set; }
        public ReadOnlyCollection<FaceNode> FaceNodes { get; }
        private List<FaceNode> UnalignedNodes { get; }

        public FaceTree(IEnumerable<IPXFace> faces, IPXFace root)
        {
            if (!faces.Contains(root))
                throw new ArgumentException("root面はfacesコンテナ内に存在していなければなりません。");

            UnalignedNodes = faces.Select(f => new FaceNode(f)).ToList();
            FaceNodes = new ReadOnlyCollection<FaceNode>(UnalignedNodes);
            Root = new FaceNode(root);
        }

        private void SetNeighborRecurcive(FaceNode node)
        {


        }
    }

    class FaceNode : IEquatable<FaceNode>
    {
        public IPXFace Face { get; set; }
        private List<PXEdge> edges;
        internal List<PXEdge> Edges
        {
            get
            {
                if (edges == null)
                    edges = PXEdge.FromFace(Face);
                return edges;
            }
        }
        public bool Flag { get; set; } = false;
        public bool IsBorder { get => Neighbor.Any(n => n == null); }

        public FaceNode Parent { get; set; }
        public List<FaceNode> Neighbor { get; } = new List<FaceNode>();

        public FaceNode(IPXFace face)
        {
            Face = face;
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
}
