﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private const string VERSION = "0.5";
        private const string UPDATE = "2020/6/16";
        
        private const string APPNAME = "TJA Code Pad";

        private const string DEF_FILENAME = "NewFile.tja";
        private const string DEF_FILTER = "TJAファイル(*.tja)|*.tja|すべてのファイル(*.*)|*.*";

        public readonly string CONFIG_PATH = Directory.GetCurrentDirectory() + "\\Config.xml";

        #endregion



        #region フィールド

        // ファイルパス
        private string filePath = DEF_FILENAME;
        // セーブフラグ
        private bool isSaved = true;
        // ネームドフラグ
        private bool isNamed = false;

        // エディタクラス
        private Editor editor;
        // 設定クラス
        private Config config;

        // 各種フォーム
        private FrmSetting frmSetting = null;
        private FrmRepeat frmRepeat = null;
        private FrmCobine frmCobine = null;
        private FrmMoveLine frmMoveLine = null;
        private FrmSearch frmSearch = null;

        #endregion



        #region コンストラクタ

        public FrmMain()
        {
            InitializeComponent();

            // インスタンス化
            this.editor = new Editor(this.AzkCode);
            this.config = new Config();

            // バージョンとアップデート日を更新
            this.TsmVersion.Text = "Ver. " + VERSION;
            this.TsmVersion_Update.Text = "Update: " + UPDATE;
        }

        #endregion



        #region アクセサ

        public Config Config
        {
            set => this.config = value;
            get => this.config;
        }

        public ToolStripComboBox _TsmTool_OtherTools
        {
            set => this.TsmTool_OtherTools = value;
            get => this.TsmTool_OtherTools;
        }

        #endregion



        #region イベント

        #region - ロード・クローズ

        /// <summary>
        /// フォームロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 設定ファイル読み込み
            if (File.Exists(CONFIG_PATH))
            {
                this.config = this.config.Read(CONFIG_PATH);
            }

            // ツールのコンボボックスに追加
            this.AddToolStripComboBox(this.TsmTool_OtherTools);
            
        }

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
                    StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("Shift-JIS"));
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
                this.frmSetting = new FrmSetting(this);
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

        /// <summary>
        /// 検索と置換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_Search_Click(object sender, EventArgs e)
        {
            // 検索・置換画面を開く
            if (this.IsFormOpened(this.frmSearch))
            {
                this.frmSearch = new FrmSearch(this.AzkCode);
                this.frmSearch.Show();
            }
        }

        /// <summary>
        /// 行の移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_Move_Click(object sender, EventArgs e)
        {
            // 行移動画面を開く
            if (this.IsFormOpened(this.frmMoveLine))
            {
                this.frmMoveLine = new FrmMoveLine(this.AzkCode);
                this.frmMoveLine.Show();
            }
        }

        // ------------------------------------------------------------------

        /// <summary>
        /// コメントアウト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_Comment_Click(object sender, EventArgs e)
        {
            int beginIndex, endIndex;
            int beginLine, endLine;
            int beginCol, endCol;
            int commentBegin;
            string oldText = "";
            string newText = "";

            // 選択開始・終了位置を取得
            this.AzkCode.Document.GetSelection(out beginIndex, out endIndex);

            // 選択開始位置・終了位置の行番号と列番号を取得
            this.AzkCode.Document.GetLineColumnIndexFromCharIndex(beginIndex, out beginLine, out beginCol);
            this.AzkCode.Document.GetLineColumnIndexFromCharIndex(endIndex, out endLine, out endCol);
            if (endLine > 0 && endCol == 0) endLine--;  // 終了位置が行頭の場合は1行前の末尾を選択終了位置とする

            // コメントアウト開始位置を取得
            commentBegin = this.AzkCode.Document.GetCharIndexFromLineColumnIndex(beginLine, 0);

            // "//"を挿入
            for (int i = beginLine; i < endLine; i++)
            {
                oldText += this.AzkCode.Document.GetLineContent(i) + Environment.NewLine;
                newText += "//" + this.AzkCode.Document.GetLineContent(i) + Environment.NewLine;
            }
            oldText += this.AzkCode.Document.GetLineContent(endLine);
            newText += "//" + this.AzkCode.Document.GetLineContent(endLine);

            // コメントアウト
            this.AzkCode.Document.Replace(newText, commentBegin, commentBegin + oldText.Length);
            
        }

        /// <summary>
        /// コメント解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_UnComment_Click(object sender, EventArgs e)
        {
            int beginIndex, endIndex;
            int beginLine, endLine;
            int beginCol, endCol;
            int commentBegin;
            string oldText = "";
            string newText = "";

            // 選択開始・終了位置を取得
            this.AzkCode.Document.GetSelection(out beginIndex, out endIndex);

            // 選択開始位置・終了位置の行番号と列番号を取得
            this.AzkCode.Document.GetLineColumnIndexFromCharIndex(beginIndex, out beginLine, out beginCol);
            this.AzkCode.Document.GetLineColumnIndexFromCharIndex(endIndex, out endLine, out endCol);
            if (endLine > 0 && endCol == 0) endLine--;  // 終了位置が行頭の場合は1行前の末尾を選択終了位置とする

            // コメント解除開始位置を取得
            commentBegin = this.AzkCode.Document.GetCharIndexFromLineColumnIndex(beginLine, 0);

            // "//"を削除
            for (int i = beginLine; i < endLine; i++)
            {
                oldText += this.AzkCode.Document.GetLineContent(i) + Environment.NewLine;
                newText += this.AzkCode.Document.GetLineContent(i).Substring("//".Length) + Environment.NewLine;
            }
            oldText += this.AzkCode.Document.GetLineContent(endLine);
            newText += this.AzkCode.Document.GetLineContent(endLine).Substring("//".Length);

            // コメント解除
            this.AzkCode.Document.Replace(newText, commentBegin, commentBegin + oldText.Length);
        }

        // ------------------------------------------------------------------

        /// <summary>
        /// 0埋め
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_Fill0_Click(object sender, EventArgs e)
        {
            // 0埋め
            this.editor.Fill("0");
        }

        /// <summary>
        /// 00埋め
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_Fill00_Click(object sender, EventArgs e)
        {
            // 00埋め
            this.editor.Fill("00");
        }

        /// <summary>
        /// 1文字詰め
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_RemoveBy1_Click(object sender, EventArgs e)
        {
            // 1文字詰め
            this.editor.Remove(1);
        }

        /// <summary>
        /// 2文字詰め
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_RemoveBy2_Click(object sender, EventArgs e)
        {
            // 2文字詰め
            this.editor.Remove(2);
        }

        // ------------------------------------------------------------------

        /// <summary>
        /// リピート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_Repeat_Click(object sender, EventArgs e)
        {
            // リピート画面を開く
            if (this.IsFormOpened(this.frmRepeat))
            {
                this.frmRepeat = new FrmRepeat(this.AzkCode);
                this.frmRepeat.Show();
            }
        }

        /// <summary>
        /// 譜面を合成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmEdit_Combine_Click(object sender, EventArgs e)
        {
            // 譜面合成画面を開く
            if (this.IsFormOpened(this.frmCobine))
            {
                this.frmCobine = new FrmCobine();
                this.frmCobine.Show();
            }
        }

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

        /// <summary>
        /// 譜面を再生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmTool_Play_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("\"" + this.config.PlayerPath + "\"", "\"" + this.filePath + "\"");
            }
            catch
            {
                MessageBox.Show("パスが正しくありません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 譜面のフォルダを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmTool_OpenFolder_Click(object sender, EventArgs e)
        {
            this.ExecApp(Path.GetDirectoryName(this.filePath));
        }

        //---------------------------------------------------------------

        /// <summary>
        /// 次を開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmTool_OtherTools_Open_Click(object sender, EventArgs e)
        {
            this.ExecApp(this.config.Apps.Find(x => x.Name == (string)this.TsmTool_OtherTools.SelectedItem).Path);
        }

        #endregion



        #region -- [ヘルプ]

        /// <summary>
        /// GitHub
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmHelp_Help_Click(object sender, EventArgs e)
        {
            // GitHubリポジトリを開く
            Process.Start("https://github.com/Mos305/TJACodePad");
        }

        #endregion

        #endregion



        #region - エディタ

        /// <summary>
        /// キャレットが移動されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AzkCode_CaretMoved(object sender, EventArgs e)
        {
            int line, col;
            int begin, end;

            // 現在のカーソル位置を表示
            this.AzkCode.Document.GetLineColumnIndexFromCharIndex(this.AzkCode.CaretIndex, out line, out col);
            this.TssRow.Text = (line + 1).ToString();
            this.TssCol.Text = (col + 1).ToString();

            // 選択中のテキストの文字数を表示
            this.AzkCode.GetSelection(out begin, out end);
            if (end - begin > 0)
            {
                // 選択時は表示
                this.TssSelectionCharaLength_label.Visible = true;
                this.TssSelectionCharaLength.Visible = true;
                this.TssSelectionCharaLength.Text = (end - begin).ToString();
            }
            else
            {
                // それ以外の時は非表示
                this.TssSelectionCharaLength_label.Visible = false;
                this.TssSelectionCharaLength.Visible = false;
            }
            
        }

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

        #region - システム

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
        /// フォームが既に開かれているかどうかを判定する関数
        /// </summary>
        /// <param name="form">フォーム</param>
        /// <returns>フォームが既に開かれているかどうか</returns>
        private bool IsFormOpened(Form form)
        {
            return form == null || form.IsDisposed;
        }

        /// <summary>
        /// ToolStripComboBoxにアイテムを追加する関数
        /// </summary>
        /// <param name="comboBox">ToolStripComboBox</param>
        public void AddToolStripComboBox(ToolStripComboBox comboBox)
        {
            // コンボボックスにアイテムを追加
            this.TsmTool_OtherTools.Items.Clear();
            foreach (Apps apps in this.Config.Apps)
            {
                this.TsmTool_OtherTools.Items.Add(apps.Name);
            }

            // アイテムが0件の場合、非活性化
            if (this.TsmTool_OtherTools.Items.Count > 0)
            {
                this.TsmTool_OtherTools_Open.Enabled = true;
                this.TsmTool_OtherTools.Enabled = true;
                this.TsmTool_OtherTools.SelectedIndex = 0;
            }
            else
            {
                this.TsmTool_OtherTools_Open.Enabled = false;
                this.TsmTool_OtherTools.Enabled = false;
            }
        }

        /// <summary>
        /// 外部アプリケーションを実行する関数
        /// </summary>
        /// <param name="path">外部アプリケーションのパス</param>
        private void ExecApp(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch
            {
                MessageBox.Show("パスが正しくありません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region - ファイル入出力

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
                    StreamWriter sw = new StreamWriter(stream, Encoding.GetEncoding("Shift-JIS"));
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





        #endregion

        #endregion

        
    }
}
