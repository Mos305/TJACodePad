namespace TJACodePad.Forms
{
    partial class FrmMoveLine
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
            this.LblLineNo = new System.Windows.Forms.Label();
            this.TxtLineNo = new System.Windows.Forms.TextBox();
            this.BtnMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblLineNo
            // 
            this.LblLineNo.AutoSize = true;
            this.LblLineNo.Location = new System.Drawing.Point(12, 9);
            this.LblLineNo.Name = "LblLineNo";
            this.LblLineNo.Size = new System.Drawing.Size(126, 15);
            this.LblLineNo.TabIndex = 0;
            this.LblLineNo.Text = "行番号（1 - 999）：";
            // 
            // TxtLineNo
            // 
            this.TxtLineNo.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLineNo.Location = new System.Drawing.Point(12, 27);
            this.TxtLineNo.Name = "TxtLineNo";
            this.TxtLineNo.Size = new System.Drawing.Size(126, 31);
            this.TxtLineNo.TabIndex = 1;
            this.TxtLineNo.TextChanged += new System.EventHandler(this.TxtLineNo_TextChanged);
            // 
            // BtnMove
            // 
            this.BtnMove.Location = new System.Drawing.Point(144, 27);
            this.BtnMove.Name = "BtnMove";
            this.BtnMove.Size = new System.Drawing.Size(85, 31);
            this.BtnMove.TabIndex = 2;
            this.BtnMove.Text = "行へ移動";
            this.BtnMove.UseVisualStyleBackColor = true;
            this.BtnMove.Click += new System.EventHandler(this.BtnMove_Click);
            // 
            // FrmMoveLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 66);
            this.Controls.Add(this.BtnMove);
            this.Controls.Add(this.TxtLineNo);
            this.Controls.Add(this.LblLineNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMoveLine";
            this.Text = "行の移動";
            this.Load += new System.EventHandler(this.FrmMoveLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblLineNo;
        private System.Windows.Forms.TextBox TxtLineNo;
        private System.Windows.Forms.Button BtnMove;
    }
}