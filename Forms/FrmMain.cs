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
using TJACodePad.Models;

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

        // エディタクラス
        private Editor editor;

        // 各種フォーム
        private FrmSetting frmSetting = null;

        #endregion



        #region コンストラクタ

        public FrmMain()
        {
            InitializeComponent();

            // インスタンス化
            this.editor = new Editor(this.AzkCode);

            // バージョンとアップデート日を更新
            this.TsmVersion.Text = "Ver. " + VERSION;
            this.TsmVersion_Update.Text = "Update: " + UPDATE;
        }

        #endregion



        #region アクセサ

        #endregion



        #region イベント

        #region - ロード

        #endregion

        #region - メニューバー

        #region -- [ファイル]

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



        #region -- [編集]

        #endregion



        #region -- [ヘッダ]

        private void TsmHeader_TITLE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.TITLE + ":");
            
        }

        private void TsmHeader_LEVEL_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.LEVEL + ":");
        }

        private void TsmHeader_BPM_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.BPM + ":");
        }

        private void TsmHeader_WAVE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.WAVE + ":");
        }

        private void TsmHeader_SONGVOL_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SONGVOL + ":");
        }

        private void TsmHeader_SEVOL_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SEVOL + ":");
        }

        private void TsmHeader_OFFSET_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.OFFSET + ":");
        }

        //------------------------------------------------------------------

        private void TsmHeader_BALLOON_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.BALLOON + ":");
        }

        //------------------------------------------------------------------

        private void TsmHeader_COURSE_COURSE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.COURSE + ":");
        }

        private void TsmHeader_COURSE_Easy_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.COURSE_EASY_STR);
        }

        private void TsmHeader_COURSE_Normal_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.COURSE_NORMAL_STR);
        }

        private void TsmHeader_COURSE_Hard_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.COURSE_HARD_STR);
        }

        private void TsmHeader_COURSE_Oni_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.COURSE_ONI_STR);
        }

        private void TsmHeader_COURSE_Edit_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.COURSE_EDIT_STR);
        }

        private void TsmHeader_SCOREMODE_SCOREMODE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SCOREMODE + ":");
        }

        private void TsmHeader_SCOREMODE_0_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SCOREMODE_0.ToString());
        }

        private void TsmHeader_SCOREMODE_1_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SCOREMODE_1.ToString());
        }

        private void TsmHeader_SCOREMODE_2_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SCOREMODE_2.ToString());
        }

        //------------------------------------------------------------------

        private void TsmHeader_STYLE_STYLE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.STYLE + ":");
        }

        private void TsmHeader_STYLE_Single_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.STYLE_SINGLE_STR);
        }

        private void TsmHeader_STYLE_Double_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.STYLE_DOUBLE_STR);
        }

        private void TsmHeader_SIDE_SIDE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SIDE + ":");
        }

        private void TsmHeader_SIDE_Normal_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SIDE_NORMAL_STR);
        }

        private void TsmHeader_SIDE_Ex_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SIDE_EX_STR);
        }

        private void TsmHeader_SIDE_Both_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SIDE_BOTH_STR);
        }

        //------------------------------------------------------------------
        private void TsmHeader_SUBTITLE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.SUBTITLE + ":");
        }

        private void TsmHeader_DEMOSTART_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.DEMOSTART + ":");
        }

        //------------------------------------------------------------------

        private void TsmHeader_GAME_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.GAME + ":");
        }

        private void TsmHeader_LIFE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA.LIFE + ":");
        }

        #endregion



        #region -- [コマンド]

        private void TsmCommand_START_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._START);
        }

        private void TsmCommand_STARTP1_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._START_P1);
        }

        private void TsmCommand_STARTP2_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._START_P2);
        }

        private void TsmCommand_END_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._END);
        }

        // ----------------------------------------------------------------------

        private void TsmCommand_BPMCHANGE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._BPMCHANGE + " ");
        }

        private void TsmCommand_GOGOSTART_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._GOGOSTART);
        }

        private void TsmCommand_GOGOEND_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._GOGOEND);
        }

        private void TsmCommand_MEASURE_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._MEASURE + " ");
        }

        private void TsmCommand_SCROLL_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._SCROLL + " ");
        }

        // ----------------------------------------------------------------------

        private void TsmCommand_DELAY_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._DELAY + " ");
        }

        // ----------------------------------------------------------------------

        private void TsmCommand_SECTION_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._SECTION);
        }

        private void TsmCommand_BRANCHSTART_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._BRANCHSTART + " ");
        }

        private void TsmCommand_BRANCHEND_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._BRANCHEND);
        }

        private void TsmCommand_N_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._N);
        }

        private void TsmCommand_E_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._E);
        }

        private void TsmCommand_M_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._M);
        }

        private void TsmCommand_LEVEL_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._LEVELHOLD);
        }

        // ----------------------------------------------------------------------

        private void TsmCommand_BMSCROLL_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._BMSCROLL);
        }

        private void TsmCommand_HBSCROLL_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._HBSCROLL);
        }

        // ----------------------------------------------------------------------

        private void TsmCommand_BARLINEOFF_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._BARLINEOFF);
        }

        private void TsmCommand_BARLINEON_Click(object sender, EventArgs e)
        {
            this.editor.Insert(TJA._BARLINEON);
        }

        #endregion



        #region -- [ツール]

        #endregion



        #region -- [ヘルプ]

        #endregion

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

                    // 各種更新
                    this.isNamed = true;            // ネームドフラグ
                    this.filePath = sfd.FileName;   // ファイルパス
                    this.isSaved = true;            // 保存フラグ
                    this.changeFormTitle();         // フォームタイトル
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
