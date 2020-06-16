namespace TJACodePad.Forms
{
    partial class FrmCobine
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
            this.TxtInput1 = new System.Windows.Forms.TextBox();
            this.GrbPriority = new System.Windows.Forms.GroupBox();
            this.RdoInput2 = new System.Windows.Forms.RadioButton();
            this.RdoInput1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtInput2 = new System.Windows.Forms.TextBox();
            this.TxtCombine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCombine = new System.Windows.Forms.Button();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.GrbPriority.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtInput1
            // 
            this.TxtInput1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInput1.Location = new System.Drawing.Point(78, 34);
            this.TxtInput1.Name = "TxtInput1";
            this.TxtInput1.Size = new System.Drawing.Size(595, 31);
            this.TxtInput1.TabIndex = 1;
            this.TxtInput1.TextChanged += new System.EventHandler(this.TxtInput1_TextChanged);
            // 
            // GrbPriority
            // 
            this.GrbPriority.Controls.Add(this.RdoInput2);
            this.GrbPriority.Controls.Add(this.RdoInput1);
            this.GrbPriority.Location = new System.Drawing.Point(12, 12);
            this.GrbPriority.Name = "GrbPriority";
            this.GrbPriority.Size = new System.Drawing.Size(60, 128);
            this.GrbPriority.TabIndex = 0;
            this.GrbPriority.TabStop = false;
            this.GrbPriority.Text = "優先";
            // 
            // RdoInput2
            // 
            this.RdoInput2.AutoSize = true;
            this.RdoInput2.Location = new System.Drawing.Point(22, 93);
            this.RdoInput2.Name = "RdoInput2";
            this.RdoInput2.Size = new System.Drawing.Size(17, 16);
            this.RdoInput2.TabIndex = 3;
            this.RdoInput2.UseVisualStyleBackColor = true;
            // 
            // RdoInput1
            // 
            this.RdoInput1.AutoSize = true;
            this.RdoInput1.Checked = true;
            this.RdoInput1.Location = new System.Drawing.Point(22, 33);
            this.RdoInput1.Name = "RdoInput1";
            this.RdoInput1.Size = new System.Drawing.Size(17, 16);
            this.RdoInput1.TabIndex = 2;
            this.RdoInput1.TabStop = true;
            this.RdoInput1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(78, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "×";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtInput2
            // 
            this.TxtInput2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInput2.Location = new System.Drawing.Point(78, 94);
            this.TxtInput2.Name = "TxtInput2";
            this.TxtInput2.Size = new System.Drawing.Size(595, 31);
            this.TxtInput2.TabIndex = 2;
            this.TxtInput2.TextChanged += new System.EventHandler(this.TxtInput2_TextChanged);
            // 
            // TxtCombine
            // 
            this.TxtCombine.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCombine.Location = new System.Drawing.Point(78, 154);
            this.TxtCombine.Name = "TxtCombine";
            this.TxtCombine.Size = new System.Drawing.Size(595, 31);
            this.TxtCombine.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(78, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(595, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "||";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCombine
            // 
            this.BtnCombine.Location = new System.Drawing.Point(679, 154);
            this.BtnCombine.Name = "BtnCombine";
            this.BtnCombine.Size = new System.Drawing.Size(100, 31);
            this.BtnCombine.TabIndex = 4;
            this.BtnCombine.Text = "譜面を合成";
            this.BtnCombine.UseVisualStyleBackColor = true;
            this.BtnCombine.Click += new System.EventHandler(this.BtnCombine_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.Location = new System.Drawing.Point(679, 191);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(100, 31);
            this.BtnCopy.TabIndex = 6;
            this.BtnCopy.Text = "コピー";
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // FrmCobine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 231);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.BtnCombine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtCombine);
            this.Controls.Add(this.TxtInput2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GrbPriority);
            this.Controls.Add(this.TxtInput1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCobine";
            this.Text = "譜面を合成";
            this.GrbPriority.ResumeLayout(false);
            this.GrbPriority.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtInput1;
        private System.Windows.Forms.GroupBox GrbPriority;
        private System.Windows.Forms.RadioButton RdoInput2;
        private System.Windows.Forms.RadioButton RdoInput1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtInput2;
        private System.Windows.Forms.TextBox TxtCombine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCombine;
        private System.Windows.Forms.Button BtnCopy;
    }
}