namespace TJACodePad.Forms
{
    partial class FrmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearch));
            this.TxtFind = new System.Windows.Forms.TextBox();
            this.TxtReplace = new System.Windows.Forms.TextBox();
            this.BtnFindNext = new System.Windows.Forms.Button();
            this.BtnReplaceAll = new System.Windows.Forms.Button();
            this.BtnReplace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtFind
            // 
            this.TxtFind.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFind.Location = new System.Drawing.Point(12, 12);
            this.TxtFind.Name = "TxtFind";
            this.TxtFind.Size = new System.Drawing.Size(300, 31);
            this.TxtFind.TabIndex = 0;
            // 
            // TxtReplace
            // 
            this.TxtReplace.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReplace.Location = new System.Drawing.Point(12, 49);
            this.TxtReplace.Name = "TxtReplace";
            this.TxtReplace.Size = new System.Drawing.Size(300, 31);
            this.TxtReplace.TabIndex = 3;
            // 
            // BtnFindNext
            // 
            this.BtnFindNext.Image = ((System.Drawing.Image)(resources.GetObject("BtnFindNext.Image")));
            this.BtnFindNext.Location = new System.Drawing.Point(318, 12);
            this.BtnFindNext.Name = "BtnFindNext";
            this.BtnFindNext.Size = new System.Drawing.Size(31, 31);
            this.BtnFindNext.TabIndex = 2;
            this.BtnFindNext.UseVisualStyleBackColor = true;
            this.BtnFindNext.Click += new System.EventHandler(this.BtnFindNext_Click);
            // 
            // BtnReplaceAll
            // 
            this.BtnReplaceAll.Image = ((System.Drawing.Image)(resources.GetObject("BtnReplaceAll.Image")));
            this.BtnReplaceAll.Location = new System.Drawing.Point(355, 49);
            this.BtnReplaceAll.Name = "BtnReplaceAll";
            this.BtnReplaceAll.Size = new System.Drawing.Size(31, 31);
            this.BtnReplaceAll.TabIndex = 5;
            this.BtnReplaceAll.UseVisualStyleBackColor = true;
            this.BtnReplaceAll.Click += new System.EventHandler(this.BtnReplaceAll_Click);
            // 
            // BtnReplace
            // 
            this.BtnReplace.Image = ((System.Drawing.Image)(resources.GetObject("BtnReplace.Image")));
            this.BtnReplace.Location = new System.Drawing.Point(318, 49);
            this.BtnReplace.Name = "BtnReplace";
            this.BtnReplace.Size = new System.Drawing.Size(31, 31);
            this.BtnReplace.TabIndex = 4;
            this.BtnReplace.UseVisualStyleBackColor = true;
            this.BtnReplace.Click += new System.EventHandler(this.BtnReplace_Click);
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 89);
            this.Controls.Add(this.BtnReplaceAll);
            this.Controls.Add(this.BtnReplace);
            this.Controls.Add(this.BtnFindNext);
            this.Controls.Add(this.TxtReplace);
            this.Controls.Add(this.TxtFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSearch";
            this.Text = "検索と置換";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtFind;
        private System.Windows.Forms.TextBox TxtReplace;
        private System.Windows.Forms.Button BtnFindNext;
        private System.Windows.Forms.Button BtnReplaceAll;
        private System.Windows.Forms.Button BtnReplace;
    }
}