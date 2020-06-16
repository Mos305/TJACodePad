namespace TJACodePad.Forms
{
    partial class FrmSetting
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
            Sgry.Azuki.FontInfo fontInfo8 = new Sgry.Azuki.FontInfo();
            this.TbcOption = new System.Windows.Forms.TabControl();
            this.TbpTemplate = new System.Windows.Forms.TabPage();
            this.AzkTemplate = new Sgry.Azuki.WinForms.AzukiControl();
            this.TbpTools = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LsvTools = new System.Windows.Forms.ListView();
            this.ColAppName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnRemoveApp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnPlayerPath = new System.Windows.Forms.Button();
            this.LblPlayerPath = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnRegistApp = new System.Windows.Forms.Button();
            this.BtnRegistFolder = new System.Windows.Forms.Button();
            this.TbcOption.SuspendLayout();
            this.TbpTemplate.SuspendLayout();
            this.TbpTools.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbcOption
            // 
            this.TbcOption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbcOption.Controls.Add(this.TbpTemplate);
            this.TbcOption.Controls.Add(this.TbpTools);
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
            this.AzkTemplate.Font = new System.Drawing.Font("Cascadia Code", 12F);
            fontInfo8.Name = "Cascadia Code";
            fontInfo8.Size = 12;
            fontInfo8.Style = System.Drawing.FontStyle.Regular;
            this.AzkTemplate.FontInfo = fontInfo8;
            this.AzkTemplate.ForeColor = System.Drawing.Color.White;
            this.AzkTemplate.Location = new System.Drawing.Point(6, 6);
            this.AzkTemplate.Name = "AzkTemplate";
            this.AzkTemplate.ScrollPos = new System.Drawing.Point(0, 0);
            this.AzkTemplate.ShowsHRuler = true;
            this.AzkTemplate.Size = new System.Drawing.Size(756, 349);
            this.AzkTemplate.TabIndex = 0;
            this.AzkTemplate.ViewWidth = 4164;
            // 
            // TbpTools
            // 
            this.TbpTools.Controls.Add(this.groupBox2);
            this.TbpTools.Controls.Add(this.groupBox1);
            this.TbpTools.Location = new System.Drawing.Point(4, 25);
            this.TbpTools.Name = "TbpTools";
            this.TbpTools.Padding = new System.Windows.Forms.Padding(3);
            this.TbpTools.Size = new System.Drawing.Size(768, 361);
            this.TbpTools.TabIndex = 1;
            this.TbpTools.Text = "ツール";
            this.TbpTools.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnRegistFolder);
            this.groupBox2.Controls.Add(this.BtnRegistApp);
            this.groupBox2.Controls.Add(this.LsvTools);
            this.groupBox2.Controls.Add(this.BtnRemoveApp);
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 290);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "外部ツール";
            // 
            // LsvTools
            // 
            this.LsvTools.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColAppName,
            this.ColPath});
            this.LsvTools.FullRowSelect = true;
            this.LsvTools.HideSelection = false;
            this.LsvTools.Location = new System.Drawing.Point(6, 57);
            this.LsvTools.MultiSelect = false;
            this.LsvTools.Name = "LsvTools";
            this.LsvTools.Size = new System.Drawing.Size(744, 227);
            this.LsvTools.TabIndex = 3;
            this.LsvTools.UseCompatibleStateImageBehavior = false;
            this.LsvTools.View = System.Windows.Forms.View.Details;
            // 
            // ColAppName
            // 
            this.ColAppName.Text = "アプリケーション名";
            // 
            // ColPath
            // 
            this.ColPath.Text = "パス";
            // 
            // BtnRemoveApp
            // 
            this.BtnRemoveApp.Location = new System.Drawing.Point(630, 21);
            this.BtnRemoveApp.Name = "BtnRemoveApp";
            this.BtnRemoveApp.Size = new System.Drawing.Size(120, 30);
            this.BtnRemoveApp.TabIndex = 2;
            this.BtnRemoveApp.Text = "削除";
            this.BtnRemoveApp.UseVisualStyleBackColor = true;
            this.BtnRemoveApp.Click += new System.EventHandler(this.BtnRemoveApp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnPlayerPath);
            this.groupBox1.Controls.Add(this.LblPlayerPath);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 53);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "太鼓さん次郎のパス";
            // 
            // BtnPlayerPath
            // 
            this.BtnPlayerPath.Location = new System.Drawing.Point(680, 14);
            this.BtnPlayerPath.Name = "BtnPlayerPath";
            this.BtnPlayerPath.Size = new System.Drawing.Size(70, 30);
            this.BtnPlayerPath.TabIndex = 8;
            this.BtnPlayerPath.Text = "参照...";
            this.BtnPlayerPath.UseVisualStyleBackColor = true;
            this.BtnPlayerPath.Click += new System.EventHandler(this.BtnPlayerPath_Click);
            // 
            // LblPlayerPath
            // 
            this.LblPlayerPath.BackColor = System.Drawing.Color.LightGray;
            this.LblPlayerPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPlayerPath.Location = new System.Drawing.Point(6, 18);
            this.LblPlayerPath.Name = "LblPlayerPath";
            this.LblPlayerPath.Size = new System.Drawing.Size(668, 23);
            this.LblPlayerPath.TabIndex = 6;
            this.LblPlayerPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(668, 408);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(120, 30);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(542, 408);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(120, 30);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnRegistApp
            // 
            this.BtnRegistApp.Location = new System.Drawing.Point(6, 21);
            this.BtnRegistApp.Name = "BtnRegistApp";
            this.BtnRegistApp.Size = new System.Drawing.Size(170, 30);
            this.BtnRegistApp.TabIndex = 0;
            this.BtnRegistApp.Text = "アプリケーションを登録...";
            this.BtnRegistApp.UseVisualStyleBackColor = true;
            this.BtnRegistApp.Click += new System.EventHandler(this.BtnRegistApp_Click);
            // 
            // BtnRegistFolder
            // 
            this.BtnRegistFolder.Location = new System.Drawing.Point(182, 21);
            this.BtnRegistFolder.Name = "BtnRegistFolder";
            this.BtnRegistFolder.Size = new System.Drawing.Size(120, 30);
            this.BtnRegistFolder.TabIndex = 1;
            this.BtnRegistFolder.Text = "フォルダを登録...";
            this.BtnRegistFolder.UseVisualStyleBackColor = true;
            this.BtnRegistFolder.Click += new System.EventHandler(this.BtnRegistFolder_Click);
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TbcOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSetting";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.TbcOption.ResumeLayout(false);
            this.TbpTemplate.ResumeLayout(false);
            this.TbpTools.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbcOption;
        private System.Windows.Forms.TabPage TbpTemplate;
        private Sgry.Azuki.WinForms.AzukiControl AzkTemplate;
        private System.Windows.Forms.TabPage TbpTools;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnRemoveApp;
        private System.Windows.Forms.ListView LsvTools;
        private System.Windows.Forms.ColumnHeader ColAppName;
        private System.Windows.Forms.ColumnHeader ColPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnPlayerPath;
        private System.Windows.Forms.Label LblPlayerPath;
        private System.Windows.Forms.Button BtnRegistFolder;
        private System.Windows.Forms.Button BtnRegistApp;
    }
}