using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SelectFaceIncludingVertex
{
    /// <summary>
    /// 便利メソッド集
    /// </summary>
    static class Utility
    {
        public static DialogResult ShowException(Exception ex)
        {
            // Get reference to the dialog type. 
            var dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
            var dialogType = typeof(Form).Assembly.GetType(dialogTypeName);

            // Create dialog instance. 
            var dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());

            // Populate relevant properties on the dialog instance. 
            dialog.Text = "例外発生";
            dialogType.GetProperty("Details").SetValue(dialog, ex.StackTrace, null);
            dialogType.GetProperty("Message").SetValue(dialog, ex.Message, null);

            // Display dialog. 
            return dialog.ShowDialog();
        }

        /// <summary>
        /// 入力頂点のボーン・ウェイトをタプルリストに変換する
        /// </summary>
        /// <param name="vertex">入力頂点</param>
        /// <returns>(ボーン,ウェイト)のタプルリスト</returns>
        public static List<(IPXBone bone, float weight)> GetWeights(IPXVertex vertex)
        {
            var weights = new List<(IPXBone bone, float weight)>();
            weights.Add((vertex.Bone1, vertex.Weight1));
            weights.Add((vertex.Bone2, vertex.Weight2));
            weights.Add((vertex.Bone3, vertex.Weight3));
            weights.Add((vertex.Bone4, vertex.Weight4));
            weights.RemoveAll(w => w.bone == null);
            weights.RemoveAll(w => w.weight == 0.0);
            return weights;
        }

        /// <summary>
        /// タプルリストから頂点にボーン・ウェイト情報を正規化して格納する
        /// </summary>
        /// <param name="weights">(ボーン,ウェイト)タプルのリスト</param>
        /// <param name="vertex">格納する頂点</param>
        public static void SetVertexWeights(List<(IPXBone bone, float weight)> weights, ref IPXVertex vertex)
        {
            //正規化
            var weight = NormalizeWeights(weights);
            ClearVertexWeight(ref vertex);

            //頂点に入力
            vertex.Bone1 = weight[0].bone;
            vertex.Weight1 = weight[0].weight;
            if (weight.Count > 1)
            {
                vertex.Bone2 = weight[1].bone;
                vertex.Weight2 = weight[1].weight;
            }
            if (weight.Count > 2)
            {
                vertex.Bone3 = weight[2].bone;
                vertex.Weight3 = weight[2].weight;
            }
            if (weight.Count > 3)
            {
                vertex.Bone4 = weight[3].bone;
                vertex.Weight4 = weight[3].weight;
            }
        }

        /// <summary>
        /// ウェイトを正規化する
        /// </summary>
        /// <param name="weights">正規化する(ボーン,ウェイト)タプルのリスト</param>
        /// <param name="basis">正規化後の合計</param>
        /// <returns>正規化された(ボーン,ウェイト)タプルのリスト</returns>
        public static List<(IPXBone bone, float weight)> NormalizeWeights(List<(IPXBone bone, float weight)> weights, float basis = 1)
        {
            //weightを基準に降順でソート
            weights.Sort((v, w) => w.weight.CompareTo(v.weight));

            //大きい方から4つまでを残す
            weights.Take(4);

            //正規化
            var sum = weights.Select(w => w.weight).Sum();
            return weights.Select(w => (w.bone, basis * w.weight / sum)).ToList();
        }

        /// <summary>
        /// ウェイトを正規化する
        /// </summary>
        /// <param name="vertex">正規化する頂点</param>
        public static void NormalizeWeights(ref IPXVertex vertex)
        {
            SetVertexWeights(GetWeights(vertex), ref vertex);
        }

        public static void ClearVertexWeight(ref IPXVertex vertex)
        {
            vertex.Bone1 = null;
            vertex.Weight1 = 0;
            vertex.Bone2 = null;
            vertex.Weight2 = 0;
            vertex.Bone3 = null;
            vertex.Weight3 = 0;
            vertex.Bone4 = null;
            vertex.Weight4 = 0;
        }
    }
}
