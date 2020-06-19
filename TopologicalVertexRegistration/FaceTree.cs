using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologicalVertexRegistration
{
    class FaceTree
    {
        public int Count { get; private set; }
        public FaceNode Root { get; private set; }
        public ReadOnlyCollection<IPXFace> Faces { get;}

        public FaceTree(IEnumerable<IPXFace> faces,IPXFace root)
        {
            if (!faces.Contains(root))
                throw new ArgumentException("root面はfacesコンテナ内に存在していなければなりません。");

            Faces = new ReadOnlyCollection<IPXFace>(faces.ToList());
        }

        private void SetNeighborRecurcive()
    }

    class FaceNode
    {
        public IPXFace Face { get; set; }
        public bool Flag { get; set; }
        public bool IsBorder { get => Neighbor.Any(n => n == null); }
        
        public FaceNode Parent { get; set; }
        public FaceNode[] Neighbor { get; } = new FaceNode[3];
    }
}
