namespace TJACodePad.Forms
{
    partial class FrmRepeat
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
            this.TxtStr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRepeatCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnRepeat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtStr
            // 
            this.TxtStr.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStr.Location = new System.Drawing.Point(12, 42);
            this.TxtStr.Name = "TxtStr";
            this.TxtStr.Size = new System.Drawing.Size(300, 31);
            this.TxtStr.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "文字列：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "×";
            // 
            // TxtRepeatCount
            // 
            this.TxtRepeatCount.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRepeatCount.Location = new System.Drawing.Point(346, 42);
            this.TxtRepeatCount.Name = "TxtRepeatCount";
            this.TxtRepeatCount.Size = new System.Drawing.Size(92, 31);
            this.TxtRepeatCount.TabIndex = 3;
            this.TxtRepeatCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "繰り返し回数：";
            // 
            // BtnRepeat
            // 
            this.BtnRepeat.Location = new System.Drawing.Point(444, 42);
            this.BtnRepeat.Name = "BtnRepeat";
            this.BtnRepeat.Size = new System.Drawing.Size(80, 31);
            this.BtnRepeat.TabIndex = 5;
            this.BtnRepeat.Text = "リピート";
            this.BtnRepeat.UseVisualStyleBackColor = true;
            // 
            // FrmRepeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 87);
            this.Controls.Add(this.BtnRepeat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtRepeatCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtStr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRepeat";
            this.Text = "リピート";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtStr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtRepeatCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnRepeat;
    }
}