using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TopologicalVertexRegistration
{
    public class TopologicalVertexRegistration : PEPluginClass
    {
        public TopologicalVertexRegistration() : base()
        {
        }

        public override string Name
        {
            get
            {
                return "位相幾何的位置合わせ";
            }
        }

        public override string Version
        {
            get
            {
                return "0.0";
            }
        }

        public override string Description
        {
            get
            {
                return "位相幾何的位置合わせ";
            }
        }

        public override IPEPluginOption Option
        {
            get
            {
                // boot時実行, プラグインメニューへの登録, メニュー登録名
                return new PEPluginOption(false, true, "位相幾何的位置合わせ");
            }
        }

        public override void Run(IPERunArgs args)
        {
            try
            {
                if (ctrlForm == null)
                {
                    ctrlForm = new CtrlForm(args);
                    ctrlForm.Visible = true;
                }
                else
                {
                    ctrlForm.Format();
                    ctrlForm.Visible = !ctrlForm.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override void Dispose()
        {
            if (ctrlForm != null)
            {
                ctrlForm.Close();
                ctrlForm = null;
            }
        }

        CtrlForm ctrlForm;
    }
}