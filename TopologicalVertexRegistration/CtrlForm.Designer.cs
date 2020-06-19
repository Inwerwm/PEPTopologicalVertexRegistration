namespace TopologicalVertexRegistration
{
    partial class CtrlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSource = new System.Windows.Forms.Label();
            this.buttonGetSourceFace = new System.Windows.Forms.Button();
            this.textBoxSourceFaceNum = new System.Windows.Forms.TextBox();
            this.buttonGetSourceCorFace = new System.Windows.Forms.Button();
            this.textBoxSourceCorFaceID = new System.Windows.Forms.TextBox();
            this.labelTarget = new System.Windows.Forms.Label();
            this.buttonGetTargetFace = new System.Windows.Forms.Button();
            this.textBoxTargetFaceNum = new System.Windows.Forms.TextBox();
            this.buttonGetTargetCorFace = new System.Windows.Forms.Button();
            this.textBoxTargetCorFaceID = new System.Windows.Forms.TextBox();
            this.labelGetFace = new System.Windows.Forms.Label();
            this.labelGetCorFace = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelSource, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelTarget, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxSourceFaceNum, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxTargetFaceNum, 1, 4);
            this.tableLayoutPanelMain.Controls.Add(this.buttonGetTargetFace, 1, 3);
            this.tableLayoutPanelMain.Controls.Add(this.buttonGetSourceFace, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.buttonGetSourceCorFace, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.buttonGetTargetCorFace, 1, 6);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxSourceCorFaceID, 0, 7);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxTargetCorFaceID, 1, 7);
            this.tableLayoutPanelMain.Controls.Add(this.labelGetFace, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.labelGetCorFace, 0, 5);
            this.tableLayoutPanelMain.Controls.Add(this.buttonRun, 0, 9);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(16, 20);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 10;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(380, 402);
            this.tableLayoutPanelMain.TabIndex = 0;
            this.tableLayoutPanelMain.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanelMain_CellPaint);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelTitle, 2);
            this.labelTitle.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(374, 51);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "位相幾何的頂点位置合わせ";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSource
            // 
            this.labelSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSource.AutoSize = true;
            this.labelSource.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSource.Location = new System.Drawing.Point(3, 55);
            this.labelSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(184, 27);
            this.labelSource.TabIndex = 1;
            this.labelSource.Text = "起源面";
            this.labelSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonGetSourceFace
            // 
            this.buttonGetSourceFace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetSourceFace.Location = new System.Drawing.Point(3, 143);
            this.buttonGetSourceFace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGetSourceFace.Name = "buttonGetSourceFace";
            this.buttonGetSourceFace.Size = new System.Drawing.Size(184, 27);
            this.buttonGetSourceFace.TabIndex = 2;
            this.buttonGetSourceFace.Text = "選択面を取得";
            this.buttonGetSourceFace.UseVisualStyleBackColor = true;
            this.buttonGetSourceFace.Click += new System.EventHandler(this.buttonGetSourceFace_Click);
            // 
            // textBoxSourceFaceNum
            // 
            this.textBoxSourceFaceNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceFaceNum.Location = new System.Drawing.Point(3, 178);
            this.textBoxSourceFaceNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSourceFaceNum.Name = "textBoxSourceFaceNum";
            this.textBoxSourceFaceNum.ReadOnly = true;
            this.textBoxSourceFaceNum.Size = new System.Drawing.Size(184, 27);
            this.textBoxSourceFaceNum.TabIndex = 3;
            this.textBoxSourceFaceNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonGetSourceCorFace
            // 
            this.buttonGetSourceCorFace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetSourceCorFace.Location = new System.Drawing.Point(3, 283);
            this.buttonGetSourceCorFace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGetSourceCorFace.Name = "buttonGetSourceCorFace";
            this.buttonGetSourceCorFace.Size = new System.Drawing.Size(184, 27);
            this.buttonGetSourceCorFace.TabIndex = 2;
            this.buttonGetSourceCorFace.Text = "対応面を取得";
            this.buttonGetSourceCorFace.UseVisualStyleBackColor = true;
            this.buttonGetSourceCorFace.Click += new System.EventHandler(this.buttonGetSourceCorFace_Click);
            // 
            // textBoxSourceCorFaceID
            // 
            this.textBoxSourceCorFaceID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceCorFaceID.Location = new System.Drawing.Point(3, 318);
            this.textBoxSourceCorFaceID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSourceCorFaceID.Name = "textBoxSourceCorFaceID";
            this.textBoxSourceCorFaceID.ReadOnly = true;
            this.textBoxSourceCorFaceID.Size = new System.Drawing.Size(184, 27);
            this.textBoxSourceCorFaceID.TabIndex = 3;
            this.textBoxSourceCorFaceID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTarget
            // 
            this.labelTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTarget.AutoSize = true;
            this.labelTarget.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTarget.Location = new System.Drawing.Point(193, 55);
            this.labelTarget.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(184, 27);
            this.labelTarget.TabIndex = 1;
            this.labelTarget.Text = "対象面";
            this.labelTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonGetTargetFace
            // 
            this.buttonGetTargetFace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetTargetFace.Location = new System.Drawing.Point(193, 143);
            this.buttonGetTargetFace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGetTargetFace.Name = "buttonGetTargetFace";
            this.buttonGetTargetFace.Size = new System.Drawing.Size(184, 27);
            this.buttonGetTargetFace.TabIndex = 2;
            this.buttonGetTargetFace.Text = "選択面を取得";
            this.buttonGetTargetFace.UseVisualStyleBackColor = true;
            this.buttonGetTargetFace.Click += new System.EventHandler(this.buttonGetTargetFace_Click);
            // 
            // textBoxTargetFaceNum
            // 
            this.textBoxTargetFaceNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTargetFaceNum.Location = new System.Drawing.Point(193, 178);
            this.textBoxTargetFaceNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTargetFaceNum.Name = "textBoxTargetFaceNum";
            this.textBoxTargetFaceNum.ReadOnly = true;
            this.textBoxTargetFaceNum.Size = new System.Drawing.Size(184, 27);
            this.textBoxTargetFaceNum.TabIndex = 3;
            this.textBoxTargetFaceNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonGetTargetCorFace
            // 
            this.buttonGetTargetCorFace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetTargetCorFace.Location = new System.Drawing.Point(193, 283);
            this.buttonGetTargetCorFace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGetTargetCorFace.Name = "buttonGetTargetCorFace";
            this.buttonGetTargetCorFace.Size = new System.Drawing.Size(184, 27);
            this.buttonGetTargetCorFace.TabIndex = 2;
            this.buttonGetTargetCorFace.Text = "対応面を取得";
            this.buttonGetTargetCorFace.UseVisualStyleBackColor = true;
            this.buttonGetTargetCorFace.Click += new System.EventHandler(this.buttonGetTargetCorFace_Click);
            // 
            // textBoxTargetCorFaceID
            // 
            this.textBoxTargetCorFaceID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTargetCorFaceID.Location = new System.Drawing.Point(193, 318);
            this.textBoxTargetCorFaceID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTargetCorFaceID.Name = "textBoxTargetCorFaceID";
            this.textBoxTargetCorFaceID.ReadOnly = true;
            this.textBoxTargetCorFaceID.Size = new System.Drawing.Size(184, 27);
            this.textBoxTargetCorFaceID.TabIndex = 3;
            this.textBoxTargetCorFaceID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelGetFace
            // 
            this.labelGetFace.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelGetFace.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelGetFace, 2);
            this.labelGetFace.Location = new System.Drawing.Point(63, 99);
            this.labelGetFace.Margin = new System.Windows.Forms.Padding(0);
            this.labelGetFace.Name = "labelGetFace";
            this.labelGetFace.Size = new System.Drawing.Size(253, 40);
            this.labelGetFace.TabIndex = 4;
            this.labelGetFace.Text = "考慮したい面を選択して取得させる\r\n面数は同じで連続していなければならない";
            this.labelGetFace.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelGetCorFace
            // 
            this.labelGetCorFace.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelGetCorFace.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelGetCorFace, 2);
            this.labelGetCorFace.Location = new System.Drawing.Point(76, 239);
            this.labelGetCorFace.Margin = new System.Windows.Forms.Padding(0);
            this.labelGetCorFace.Name = "labelGetCorFace";
            this.labelGetCorFace.Size = new System.Drawing.Size(227, 40);
            this.labelGetCorFace.TabIndex = 4;
            this.labelGetCorFace.Text = "対応させたい面を選択して取得させる\r\nそれぞれ一枚のみ 変形の起点となる";
            this.labelGetCorFace.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.buttonRun, 2);
            this.buttonRun.Location = new System.Drawing.Point(3, 358);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(374, 40);
            this.buttonRun.TabIndex = 2;
            this.buttonRun.Text = "実行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // CtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 442);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "CtrlForm";
            this.Text = "位相幾何的頂点位置合わせ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Button buttonGetSourceFace;
        private System.Windows.Forms.TextBox textBoxSourceFaceNum;
        private System.Windows.Forms.Button buttonGetSourceCorFace;
        private System.Windows.Forms.TextBox textBoxSourceCorFaceID;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.Button buttonGetTargetFace;
        private System.Windows.Forms.TextBox textBoxTargetFaceNum;
        private System.Windows.Forms.Button buttonGetTargetCorFace;
        private System.Windows.Forms.TextBox textBoxTargetCorFaceID;
        private System.Windows.Forms.Label labelGetFace;
        private System.Windows.Forms.Label labelGetCorFace;
        private System.Windows.Forms.Button buttonRun;
    }
}