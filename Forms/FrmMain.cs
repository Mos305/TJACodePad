using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TJACodePad.Forms;

namespace TJACodePad
{
    public partial class FrmMain : Form
    {
        #region 定数

        private const string VERSION = "0.2";
        private const string UPDATE = "2020/6/15";
        
        private const string APPNAME = "TJA Code Pad";

        private const string DEF_FILENAME = "NewFile.tja";
        private const string DEF_FILTER = "TJAファイル(*.tja)|*.tja|すべてのファイル(*.*)|*.*";

        #endregion



        #region パラメータ

        // ファイルパス
        private string filePath = DEF_FILENAME;
        // セーブフラグ
        private bool isSaved = true;
        // ネームドフラグ
        private bool isNamed = false;

        // 各種フォーム
        private FrmSetting frmSetting = null;

        #endregion



        #region コンストラクタ

        public FrmMain()
        {
            InitializeComponent();

            // バージョンとアップデート日を更新
            this.TsmVersion.Text = "Ver. " + VERSION;
            this.TsmVersion_Update.Text = "Update: " + UPDATE;
        }

        #endregion



        #region アクセサ

        #endregion



        #region イベント

        #region - メニューバー

        /// <summary>
        /// 新規作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmFile_NewFile_Click(object sender, EventArgs e)
        {
            // 保存確認
            if (this.confirmSaved() == DialogResult.No) return;

            this.AzkCode.Text = String.Empty;

            // 各種更新
            this.isNamed = false;           // ネームドフラグ
            this.filePath = DEF_FILENAME;   // ファイルパス
            this.isSaved = true;            // 保存フラグ
            this.changeFormTitle();         // フォームタイトル
        }

        /// <summary>
        /// 開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmFile_Open_Click(object sender, EventArgs e)
        {
            // 保存確認
            if (this.confirmSaved() == DialogResult.No) return;

            // インスタンス化
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = DEF_FILENAME;    // はじめのファイル名を指定
            ofd.Filter = DEF_FILTER;        // [ファイルの種類]を指定
            ofd.FilterIndex = 1;            // [ファイルの種類]ではじめに選択されるものを指定
            ofd.RestoreDirectory = true;    // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

            // ダイアログを表示
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Stream stream = ofd.OpenFile();
                if (stream != null)
                {
                    // ファイルを読み込み
                    StreamReader sr = new StreamReader(stream);
                    this.AzkCode.Text = sr.ReadToEnd();
                    sr.Close();
                    stream.Close();

                    // 各種更新
                    this.isNamed = true;            // ネームドフラグ
                    this.filePath = ofd.FileName;   // ファイルパス
                    this.isSaved = true;            // 保存フラグ
                    this.changeFormTitle();         // フォームタイトル
                }
            }
        }

        /// <summary>
        /// 上書き保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmFile_Save_Click(object sender, EventArgs e)
        {
            if (this.isNamed == true)
            {
                // 上書き保存
                StreamWriter sw = new StreamWriter(this.filePath, false);
                sw.Write(this.AzkCode.Text);
                sw.Close();

                // 各種更新
                this.isSaved = true;        // 保存フラグ
                this.changeFormTitle();     // フォームタイトル
            } else
            {
                // 名前を付けて保存
                this.saveAs();
            }

        }

        /// <summary>
        /// 名前を付けて保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmFile_SaveAs_Click(object sender, EventArgs e)
        {
            // 名前を付けて保存
            this.saveAs();
        }

        //-----------------------------------------------------------------

        /// <summary>
        /// 設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmFile_Setting_Click(object sender, EventArgs e)
        {
            // 設定画面を開く
            if (this.IsFormOpened(this.frmSetting))
            {
                this.frmSetting = new FrmSetting();
                this.frmSetting.Show();
            }
        }

        //-----------------------------------------------------------------

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmFile_Quit_Click(object sender, EventArgs e)
        {
            // 保存確認
            if (this.confirmSaved() == DialogResult.No) return;
            // フォームを閉じる
            this.Close();
        }

        /// <summary>
        /// フォームを閉じようとしたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 保存確認
            if (this.confirmSaved() == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region - エディタ

        /// <summary>
        /// エディタの内容が変更されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AzkCode_TextChanged(object sender, EventArgs e)
        {
            // 各種更新
            this.isSaved = false;       // 保存フラグ
            this.changeFormTitle();     // フォームタイトル
        }

        #endregion

        #endregion



        #region メソッド

        /// <summary>
        /// フォームタイトルを変更する関数
        /// </summary>
        private void changeFormTitle()
        {
            switch (this.isSaved)
            {
                case true:
                    this.Text = APPNAME + " - " + this.filePath;
                    this.StsMain.BackColor = Color.LightGreen;
                    break;

                case false:
                    this.Text = "* " + APPNAME + " - " + this.filePath;
                    this.StsMain.BackColor = Color.FromArgb(255, 128, 128);
                    break;

            }
            
        }

        /// <summary>
        /// 保存確認を行う関数
        /// </summary>
        /// <returns>このまま処理を続行するかどうか</returns>
        private DialogResult confirmSaved()
        {
            if (this.isSaved == false)
            {
                return MessageBox.Show("このファイルは保存されていません！\n\nこのまま処理を続行しますか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else
            {
                return DialogResult.Yes;
            }
        }

        /// <summary>
        /// 名前を付けて保存を行う関数
        /// </summary>
        private void saveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = DEF_FILENAME;    // はじめのファイル名を指定
            sfd.Filter = DEF_FILTER;        // [ファイルの種類]を指定
            sfd.FilterIndex = 1;            // [ファイルの種類]ではじめに選択されるものを指定
            sfd.RestoreDirectory = true;    // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

            // aダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream stream = sfd.OpenFile();
                if (stream != null)
                {
                    // ファイルを書き込む
                    StreamWriter sw = new StreamWriter(stream);
                    sw.Write(this.AzkCode.Text);
                    sw.Close();
                    stream.Close();

                    this.isNamed = true;
                    this.filePath = sfd.FileName;
                    this.isSaved = true;
                    this.changeFormTitle();
                }
            }
        }

        /// <summary>
        /// フォームが既に開かれているかどうかを判定する関数
        /// </summary>
        /// <param name="form">フォーム</param>
        /// <returns>フォームが既に開かれているかどうか</returns>
        private bool IsFormOpened(Form form)
        {
            return form == null || form.IsDisposed;
        }



        #endregion

        
    }
}
