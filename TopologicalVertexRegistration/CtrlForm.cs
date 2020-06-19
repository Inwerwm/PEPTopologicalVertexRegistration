using PEPlugin.Pmx;
using PXCPlugin;
using SelectFaceIncludingVertex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopologicalVertexRegistration
{
    public partial class CtrlForm : Form
    {
        private IPXCPluginRunArgs args;

        private int[] SourceFaceIndices;
        private int[] TargetFaceIndices;
        private int SourceCorFaceIndex;
        private int TargetCorFaceIndex;

        public CtrlForm(IPXCPluginRunArgs args)
        {
            InitializeComponent();
            this.args = args;
            //pmx = PXCBridge.GetCurrentPmx(args.Connector);
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
            SourceFaceIndices = args.Connector.GetSelectedFaceIndices();
            textBoxSourceFaceNum.Text = SourceFaceIndices.Length.ToString();
        }

        private void buttonGetTargetFace_Click(object sender, EventArgs e)
        {
            TargetFaceIndices = args.Connector.GetSelectedFaceIndices();
            textBoxTargetFaceNum.Text = TargetFaceIndices.Length.ToString();
        }

        private void buttonGetSourceCorFace_Click(object sender, EventArgs e)
        {
            var FaceIndices = args.Connector.GetSelectedFaceIndices();
            if (FaceIndices.Length.IsWithin(1,1))
            {
                MessageBox.Show("対応面は1枚だけ選択してください","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            SourceCorFaceIndex = FaceIndices[0];
        }

        private void buttonGetTargetCorFace_Click(object sender, EventArgs e)
        {
            var FaceIndices = args.Connector.GetSelectedFaceIndices();
            if (FaceIndices.Length.IsWithin(1, 1))
            {
                MessageBox.Show("対応面は1枚だけ選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TargetCorFaceIndex = FaceIndices[0];
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {

        }
    }
}
