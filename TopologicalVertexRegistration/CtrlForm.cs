using PEPlugin;
using PEPlugin.Pmx;
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
        IPERunArgs args;
        IPXPmx pmx;

        public CtrlForm(IPERunArgs input)
        {
            InitializeComponent();
            args = input;
            Format();
        }

        public void Format()
        {
            pmx = args.Host.Connector.Pmx.GetCurrentState();
        }

        public int[] GetSelectedFaceIndices()
        {
            var selectedFaceIndices = args.Host.Connector.View.PmxView.GetSelectedFaceIndices();
            foreach (var i in selectedFaceIndices)
            {
                MessageBox.Show($"{i}{Environment.NewLine}");
            }
            return selectedFaceIndices.Where((id, count) => count % 3 == 0).ToArray();
        }

        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void buttonGetSourceFace_Click(object sender, EventArgs e)
        {
            var selectedFaceIndices = args.Host.Connector.View.PmxView.GetSelectedFaceIndices();
            textBoxSourceFaceNum.Text = selectedFaceIndices.Length.ToString();
        }
    }
}