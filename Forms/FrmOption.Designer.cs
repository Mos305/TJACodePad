namespace TJACodePad.Forms
{
    partial class FrmOption
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
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            this.TbcOption = new System.Windows.Forms.TabControl();
            this.TbpTemplate = new System.Windows.Forms.TabPage();
            this.TbpApps = new System.Windows.Forms.TabPage();
            this.AzkTemplate = new Sgry.Azuki.WinForms.AzukiControl();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.LsvApps = new System.Windows.Forms.ListView();
            this.ColAppName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnRemoveApp = new System.Windows.Forms.Button();
            this.BtnAddApp = new System.Windows.Forms.Button();
            this.TbcOption.SuspendLayout();
            this.TbpTemplate.SuspendLayout();
            this.TbpApps.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbcOption
            // 
            this.TbcOption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbcOption.Controls.Add(this.TbpTemplate);
            this.TbcOption.Controls.Add(this.TbpApps);
            this.TbcOption.Location = new System.Drawing.Point(12, 12);
            this.TbcOption.Name = "TbcOption";
            this.TbcOption.SelectedIndex = 0;
            this.TbcOption.Size = new System.Drawing.Size(776, 390);
            this.TbcOption.TabIndex = 0;
            // 
            // TbpTemplate
            // 
            this.TbpTemplate.Controls.Add(this.AzkTemplate);
            this.TbpTemplate.Location = new System.Drawing.Point(4, 25);
            this.TbpTemplate.Name = "TbpTemplate";
            this.TbpTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.TbpTemplate.Size = new System.Drawing.Size(768, 361);
            this.TbpTemplate.TabIndex = 0;
            this.TbpTemplate.Text = "テンプレート";
            this.TbpTemplate.UseVisualStyleBackColor = true;
            // 
            // TbpApps
            // 
            this.TbpApps.Controls.Add(this.BtnRemoveApp);
            this.TbpApps.Controls.Add(this.BtnAddApp);
            this.TbpApps.Controls.Add(this.LsvApps);
            this.TbpApps.Location = new System.Drawing.Point(4, 25);
            this.TbpApps.Name = "TbpApps";
            this.TbpApps.Padding = new System.Windows.Forms.Padding(3);
            this.TbpApps.Size = new System.Drawing.Size(768, 361);
            this.TbpApps.TabIndex = 1;
            this.TbpApps.Text = "外部アプリケーション";
            this.TbpApps.UseVisualStyleBackColor = true;
            // 
            // AzkTemplate
            // 
            this.AzkTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AzkTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AzkTemplate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AzkTemplate.DrawingOption = ((Sgry.Azuki.DrawingOption)((((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsEol) 
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.ShowsHRuler) 
            | Sgry.Azuki.DrawingOption.DrawsEof) 
            | Sgry.Azuki.DrawingOption.ShowsDirtBar) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
            this.AzkTemplate.DrawsEofMark = true;
            this.AzkTemplate.DrawsTab = false;
            this.AzkTemplate.FirstVisibleLine = 0;
            this.AzkTemplate.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fontInfo1.Name = "Cascadia Code";
            fontInfo1.Size = 12;
            fontInfo1.Style = System.Drawing.FontStyle.Regular;
            this.AzkTemplate.FontInfo = fontInfo1;
            this.AzkTemplate.ForeColor = System.Drawing.Color.White;
            this.AzkTemplate.Location = new System.Drawing.Point(6, 6);
            this.AzkTemplate.Name = "AzkTemplate";
            this.AzkTemplate.ScrollPos = new System.Drawing.Point(0, 0);
            this.AzkTemplate.ShowsHRuler = true;
            this.AzkTemplate.Size = new System.Drawing.Size(756, 349);
            this.AzkTemplate.TabIndex = 0;
            this.AzkTemplate.ViewWidth = 4164;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(668, 408);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(120, 30);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(542, 408);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(120, 30);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // LsvApps
            // 
            this.LsvApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColId,
            this.ColAppName,
            this.ColPath});
            this.LsvApps.HideSelection = false;
            this.LsvApps.Location = new System.Drawing.Point(6, 42);
            this.LsvApps.Name = "LsvApps";
            this.LsvApps.Size = new System.Drawing.Size(756, 313);
            this.LsvApps.TabIndex = 0;
            this.LsvApps.UseCompatibleStateImageBehavior = false;
            this.LsvApps.View = System.Windows.Forms.View.Details;
            // 
            // ColAppName
            // 
            this.ColAppName.Text = "アプリケーション名";
            // 
            // ColPath
            // 
            this.ColPath.Text = "パス";
            // 
            // ColId
            // 
            this.ColId.Text = "#";
            // 
            // BtnRemoveApp
            // 
            this.BtnRemoveApp.Location = new System.Drawing.Point(132, 6);
            this.BtnRemoveApp.Name = "BtnRemoveApp";
            this.BtnRemoveApp.Size = new System.Drawing.Size(120, 30);
            this.BtnRemoveApp.TabIndex = 5;
            this.BtnRemoveApp.Text = "削除";
            this.BtnRemoveApp.UseVisualStyleBackColor = true;
            // 
            // BtnAddApp
            // 
            this.BtnAddApp.Location = new System.Drawing.Point(6, 6);
            this.BtnAddApp.Name = "BtnAddApp";
            this.BtnAddApp.Size = new System.Drawing.Size(120, 30);
            this.BtnAddApp.TabIndex = 4;
            this.BtnAddApp.Text = "追加...";
            this.BtnAddApp.UseVisualStyleBackColor = true;
            // 
            // FrmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TbcOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmOption";
            this.Text = "設定";
            this.TbcOption.ResumeLayout(false);
            this.TbpTemplate.ResumeLayout(false);
            this.TbpApps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbcOption;
        private System.Windows.Forms.TabPage TbpTemplate;
        private Sgry.Azuki.WinForms.AzukiControl AzkTemplate;
        private System.Windows.Forms.TabPage TbpApps;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnRemoveApp;
        private System.Windows.Forms.Button BtnAddApp;
        private System.Windows.Forms.ListView LsvApps;
        private System.Windows.Forms.ColumnHeader ColId;
        private System.Windows.Forms.ColumnHeader ColAppName;
        private System.Windows.Forms.ColumnHeader ColPath;
    }
}