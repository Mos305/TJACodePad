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
            this.TxtSearchText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnReplace = new System.Windows.Forms.Button();
            this.TxtReplaceText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnReplaceAll = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtSearchText
            // 
            this.TxtSearchText.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearchText.Location = new System.Drawing.Point(135, 12);
            this.TxtSearchText.Name = "TxtSearchText";
            this.TxtSearchText.Size = new System.Drawing.Size(300, 31);
            this.TxtSearchText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "検索する文字列：";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(441, 12);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(130, 31);
            this.BtnSearch.TabIndex = 2;
            this.BtnSearch.Text = "次を検索";
            this.BtnSearch.UseVisualStyleBackColor = true;
            // 
            // BtnReplace
            // 
            this.BtnReplace.Location = new System.Drawing.Point(441, 49);
            this.BtnReplace.Name = "BtnReplace";
            this.BtnReplace.Size = new System.Drawing.Size(130, 31);
            this.BtnReplace.TabIndex = 4;
            this.BtnReplace.Text = "置換して次に";
            this.BtnReplace.UseVisualStyleBackColor = true;
            // 
            // TxtReplaceText
            // 
            this.TxtReplaceText.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReplaceText.Location = new System.Drawing.Point(135, 49);
            this.TxtReplaceText.Name = "TxtReplaceText";
            this.TxtReplaceText.Size = new System.Drawing.Size(300, 31);
            this.TxtReplaceText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "置換後の文字列：";
            // 
            // BtnReplaceAll
            // 
            this.BtnReplaceAll.Location = new System.Drawing.Point(441, 86);
            this.BtnReplaceAll.Name = "BtnReplaceAll";
            this.BtnReplaceAll.Size = new System.Drawing.Size(130, 31);
            this.BtnReplaceAll.TabIndex = 6;
            this.BtnReplaceAll.Text = "すべて置換";
            this.BtnReplaceAll.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(441, 123);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(130, 31);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 166);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnReplaceAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnReplace);
            this.Controls.Add(this.TxtReplaceText);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtSearchText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSearch";
            this.Text = "検索と置換";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtSearchText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnReplace;
        private System.Windows.Forms.TextBox TxtReplaceText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnReplaceAll;
        private System.Windows.Forms.Button BtnCancel;
    }
}