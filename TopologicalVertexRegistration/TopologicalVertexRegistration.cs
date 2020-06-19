using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PXCPlugin;
using PEPlugin.Pmx;

// 登録子 | namespace及びクラス名はサンプルと同一にしてください
namespace PXCPlugin
{
    public class Register : RegisterBase
    {
        public override string[] ClassNames
        {
            get
            {
                // 対象プラグインを namespace からフルネームで記述(複数指定可能)
                return new string[]{
                    "TopologicalVertexRegistration.TopologicalVertexRegistration"
                };
            }
        }
    }
}

namespace TopologicalVertexRegistration
{
    public class TopologicalVertexRegistration : PXCPluginClass
    {
        public override string Name
        {
            get { return "位相幾何的頂点位置合わせ"; }
        }

        public override string Version
        {
            get { return "1.0"; }
        }

        public override string Description
        {
            get { return "頂点を面の構成から同定し位置合わせする"; }
        }

        public override string MenuText
        {
            get { return "位相幾何的頂点位置合わせ"; }
        }

        private CtrlForm ctrlForm = null;

        public override void Run(IPXCPluginRunArgs args)
        {
            base.Run(args);
            try
            {
                if (ctrlForm == null)
                {
                    ctrlForm = new CtrlForm(args);
                    ctrlForm.Visible = true;
                }
                else
                {
                    ctrlForm.Visible = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            if (ctrlForm != null)
            {
                ctrlForm.Close();
            }
        }
    }
}
