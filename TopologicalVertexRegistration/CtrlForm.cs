using PEPlugin.Pmx;
using PXCPlugin;
using SelectFaceIncludingVertex;
using System;
using System.Data;
using System.Drawing;
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

        public CtrlForm(IPXCPluginRunArgs args)
        {
            InitializeComponent();
            this.args = args;
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

        private void tableLayoutPanelMain_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 0)
                e.Graphics.DrawLine(Pens.Silver, new Point(e.CellBounds.Right, e.CellBounds.Top), new Point(e.CellBounds.Right, e.CellBounds.Bottom));

            if (e.Row == 0)
            {
                e.Graphics.DrawLine(Pens.Silver, new Point(e.CellBounds.Left, e.CellBounds.Top), new Point(e.CellBounds.Right, e.CellBounds.Top));
                e.Graphics.DrawLine(Pens.Silver, new Point(e.CellBounds.Left, e.CellBounds.Bottom), new Point(e.CellBounds.Right, e.CellBounds.Bottom));
            }
        }

        private void buttonGetSourceFace_Click(object sender, EventArgs e)
        {
            pmx = PXCBridge.GetCurrentPmx(args.Connector);
            SourceFaceIndices = args.Connector.GetSelectedFaceIndices().Select(i => i / 3).ToArray();
            SourceFaceIndices.Distinct();
            textBoxSourceFaceNum.Text = SourceFaceIndices.Length.ToString();
        }

        private void buttonGetTargetFace_Click(object sender, EventArgs e)
        {
            pmx = PXCBridge.GetCurrentPmx(args.Connector);
            TargetFaceIndices = args.Connector.GetSelectedFaceIndices().Select(i => i / 3).ToArray();
            TargetFaceIndices.Distinct();
            textBoxTargetFaceNum.Text = TargetFaceIndices.Length.ToString();
        }

        private void buttonGetSourceCorFace_Click(object sender, EventArgs e)
        {
            pmx = PXCBridge.GetCurrentPmx(args.Connector);
            var FaceIndices = args.Connector.GetSelectedFaceIndices();
            if (!(FaceIndices.Length / 3.0).IsWithin(1, 1))
            {
                MessageBox.Show("対応面は1枚だけ選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SourceCorFaceIndex = FaceIndices[0] / 3;
            textBoxSourceCorFaceID.Text = SourceCorFaceIndex.ToString();
        }

        private void buttonGetTargetCorFace_Click(object sender, EventArgs e)
        {
            pmx = PXCBridge.GetCurrentPmx(args.Connector);
            var FaceIndices = args.Connector.GetSelectedFaceIndices();
            if (!(FaceIndices.Length / 3.0).IsWithin(1, 1))
            {
                MessageBox.Show("対応面は1枚だけ選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TargetCorFaceIndex = FaceIndices[0] / 3;
            textBoxTargetCorFaceID.Text = TargetCorFaceIndex.ToString();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if(SourceFaceIndices.Length < 1 || TargetFaceIndices.Length < 1)
            {
                MessageBox.Show("考慮したい面が選択されていません。");
                return;
            }
            if(SourceCorFaceIndex < 0 || TargetCorFaceIndex < 0)
            {
                MessageBox.Show("対応面が選択されていません。");
                return;
            }

            pmx = PXCBridge.GetCurrentPmx(args.Connector);

            try
            {
                var sourceTree = new FaceTree(SourceFaceIndices.Select(i => GetFace(i)), GetFace(SourceCorFaceIndex));
                var targetTree = new FaceTree(TargetFaceIndices.Select(i => GetFace(i)), GetFace(TargetCorFaceIndex));

                RecursiveRegistration(sourceTree.Root, targetTree.Root);
                PXCBridge.UpdatePmx(args.Connector, pmx);
            }
            catch (Exception ex)
            {
                Utility.ShowException(ex);
            }

        }

        private void RecursiveRegistration(FaceNode source, FaceNode target)
        {
            source.Face.Vertex1.Position = target.Face.Vertex1.Position;
            source.Face.Vertex2.Position = target.Face.Vertex2.Position;
            source.Face.Vertex3.Position = target.Face.Vertex3.Position;

            source.Flag = target.Flag = true;

            for (int i = 0; i < 3; i++)
            {
                if (i >= source.Neighbor.Count || i >= target.Neighbor.Count)
                    break;

                if (!source.Neighbor[i].Flag && !target.Neighbor[i].Flag)
                    RecursiveRegistration(source.Neighbor[i], target.Neighbor[i]);
            }
        }
    }
}
