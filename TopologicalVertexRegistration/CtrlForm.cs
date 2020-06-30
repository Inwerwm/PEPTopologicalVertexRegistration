using PEPlugin.Pmx;
using PXCPlugin;
using SelectFaceIncludingVertex;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TopologicalVertexRegistration
{
    public partial class CtrlForm : Form
    {
        private IPXCPluginRunArgs args;
        private IPXPmx pmx;

        private int[] SourceFaceIndices;
        private int[] TargetFaceIndices;
        private int SourceCorFaceIndex = -1;
        private int TargetCorFaceIndex = -1;
        private int SourceStartEdgeVertex1Index = -1;
        private int SourceStartEdgeVertex2Index = -1;
        private int TargetStartEdgeVertex1Index = -1;
        private int TargetStartEdgeVertex2Index = -1;

        public CtrlForm(IPXCPluginRunArgs args)
        {
            InitializeComponent();
            this.args = args;
        }

        private int[] GetSelectedFaceIndices()
        {
            pmx = PXCBridge.GetCurrentPmx(args.Connector);
            return args.Connector.GetSelectedFaceIndices().Select(i => i / 3).Distinct().ToArray();
        }

        private int GetFaceIndex(IPXFace face, int MaterialIndex)
        {
            int materialCount = 0;
            for (int i = 0; i < MaterialIndex; i++)
            {
                materialCount += pmx.Material[i].Faces.Count;
            }

            int id = pmx.Material[MaterialIndex].Faces.IndexOf(face);
            if (id < 0)
                return -1;
            else
                return materialCount + id;
        }

        private int GetFaceIndex(IPXFace face, out int MaterialIndex)
        {
            int MaterialCount = 0;
            for (MaterialIndex = 0; MaterialIndex < pmx.Material.Count; MaterialCount += pmx.Material[MaterialIndex++].Faces.Count)
            {
                var id = pmx.Material[MaterialIndex].Faces.IndexOf(face);
                if (id != -1)
                {
                    return MaterialCount + id;
                }
            }
            return -1;
        }

        private int GetFaceIndex(IPXFace face)
        {
            int _;
            return GetFaceIndex(face, out _);
        }

        private IPXFace GetFace(int faceIndex)
        {
            int MaterialCount = 0;
            foreach (var m in pmx.Material)
            {
                if (faceIndex < MaterialCount + m.Faces.Count)
                    return m.Faces[faceIndex - MaterialCount];
                MaterialCount += m.Faces.Count;
            }
            return null;
        }

        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void buttonGetSourceFace_Click(object sender, EventArgs e)
        {
            SourceFaceIndices = GetSelectedFaceIndices();
            textBoxSourceFaceNum.Text = SourceFaceIndices.Length.ToString();
        }

        private void buttonGetTargetFace_Click(object sender, EventArgs e)
        {
            TargetFaceIndices = GetSelectedFaceIndices();
            textBoxTargetFaceNum.Text = TargetFaceIndices.Length.ToString();
        }

        private void buttonGetSourceCorFace_Click(object sender, EventArgs e)
        {
            var FaceIndices = GetSelectedFaceIndices();
            if (!FaceIndices.Length.IsWithin(1, 1))
            {
                MessageBox.Show("対応面は1枚だけ選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SourceCorFaceIndex = FaceIndices[0];
            textBoxSourceCorFaceID.Text = SourceCorFaceIndex.ToString();
        }

        private void buttonGetTargetCorFace_Click(object sender, EventArgs e)
        {
            var FaceIndices = GetSelectedFaceIndices();
            if (!FaceIndices.Length.IsWithin(1, 1))
            {
                MessageBox.Show("対応面は1枚だけ選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TargetCorFaceIndex = FaceIndices[0];
            textBoxTargetCorFaceID.Text = TargetCorFaceIndex.ToString();
        }

        private void buttonGetStartSourcePoint_Click(object sender, EventArgs e)
        {
            pmx = PXCBridge.GetCurrentPmx(args.Connector);
            var selectedVertexIndices = args.Connector.GetSelectedVertexIndices();
            if (selectedVertexIndices.Length != 2)
            {
                MessageBox.Show("辺をなす2点を選択してください");
                return;
            }

            SourceStartEdgeVertex1Index = selectedVertexIndices[0];
            SourceStartEdgeVertex2Index = selectedVertexIndices[1];

            textBoxStartSourcePointID1.Text = SourceStartEdgeVertex1Index.ToString();
            textBoxStartSourcePointID2.Text = SourceStartEdgeVertex2Index.ToString();
        }

        private void buttonGetStartTargetPoint_Click(object sender, EventArgs e)
        {
            pmx = PXCBridge.GetCurrentPmx(args.Connector);
            var selectedVertexIndices = args.Connector.GetSelectedVertexIndices();
            if (selectedVertexIndices.Length != 2)
            {
                MessageBox.Show("辺をなす2点を選択してください");
                return;
            }

            TargetStartEdgeVertex1Index = selectedVertexIndices[0];
            TargetStartEdgeVertex2Index = selectedVertexIndices[1];

            textBoxStartTargetPointID1.Text = TargetStartEdgeVertex1Index.ToString();
            textBoxStartTargetPointID2.Text = TargetStartEdgeVertex2Index.ToString();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (SourceFaceIndices.Length < 1 || TargetFaceIndices.Length < 1)
            {
                MessageBox.Show("考慮したい面が選択されていません。");
                return;
            }
            if (SourceCorFaceIndex < 0 || TargetCorFaceIndex < 0)
            {
                MessageBox.Show("対応面が選択されていません。");
                return;
            }


            pmx = PXCBridge.GetCurrentPmx(args.Connector);

            try
            {
                var sourceTree = new FaceTree(SourceFaceIndices.Select(i => GetFace(i)), GetFace(SourceCorFaceIndex), pmx.Vertex);
                var targetTree = new FaceTree(TargetFaceIndices.Select(i => GetFace(i)), GetFace(TargetCorFaceIndex), pmx.Vertex);

                RecursiveRegistration(
                    (sourceTree.Root, sourceTree.Root.GetEdge(pmx.Vertex[SourceStartEdgeVertex1Index], pmx.Vertex[SourceStartEdgeVertex2Index])),
                    (targetTree.Root, targetTree.Root.GetEdge(pmx.Vertex[TargetStartEdgeVertex1Index], pmx.Vertex[TargetStartEdgeVertex2Index]))
                );
                PXCBridge.UpdatePmx(args.Connector, pmx);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("選択面の中に対応面が含まれていません。");
            }
            catch (Exception ex)
            {
                Utility.ShowException(ex);
            }
            MessageBox.Show("完了しました。");
        }

        private void RecursiveRegistration((FaceNode node, PXEdge edge) source, (FaceNode node, PXEdge edge) target)
        {
            source.edge.Vertex1.Position = target.edge.Vertex1.Position;
            source.edge.Vertex2.Position = target.edge.Vertex2.Position;

            source.edge.Flag = target.edge.Flag = true;
            if (source.node == null || target.node == null)
                return;

            (int source, int target) edgeID = (source.node.Edges.IndexOf(source.edge), target.node.Edges.IndexOf(target.edge));
            for (int i = 1; i < 3; i++)
            {
                (PXEdge source, PXEdge target) nextEdge = (source.node.Edges[(edgeID.source + i) % 3], target.node.Edges[(edgeID.target + i) % 3]);
                if (!nextEdge.source.Flag && !nextEdge.target.Flag)
                {
                    (FaceNode source, FaceNode target) nextNode = (nextEdge.source.Nodes.Find(n => n != source.node), nextEdge.target.Nodes.Find(n => n != target.node));
                    RecursiveRegistration((nextNode.source, nextEdge.source), (nextNode.target, nextEdge.target));
                }
            }
        }
    }
}
