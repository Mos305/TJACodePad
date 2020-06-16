using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TJACodePad.Models;

namespace TJACodePad.Forms
{
    public partial class FrmSetting : Form
    {
        #region フィールド

        private FrmMain frmMain;
        private Config edittingConfig;
        private Editor editor;

        #endregion



        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="frmMain">メイン画面</param>
        public FrmSetting(FrmMain frmMain)
        {
            InitializeComponent();

            // 初期設定
            this.editor = new Editor(this.AzkTemplate);
            this.editor.SetKeywordHighlighter();

            this.edittingConfig = new Config();

            // メイン画面の参照を格納
            this.frmMain = frmMain;
        }

        #endregion



        #region イベント

        /// <summary>
        /// フォームロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSetting_Load(object sender, EventArgs e)
        {
            // 現時点での設定状態を読み込み
            if (File.Exists(this.frmMain.CONFIG_PATH))
            {
                this.edittingConfig = this.edittingConfig.Read(this.frmMain.CONFIG_PATH);
            }

            // フォームに設定情報をロード
            this.AzkTemplate.Text = this.edittingConfig.Template;

            this.LblPlayerPath.Text = this.edittingConfig.PlayerPath;

            this.LsvTools.Items.Clear();    // リストビューを初期化
            foreach(Apps app in this.edittingConfig.Apps)
            {
                string[] item = { app.Name, app.Path };
                this.LsvTools.Items.Add(new ListViewItem(item));
                Utils.AutoSetListViewWidth(this.LsvTools);   // リストビューの幅を自動調整
            }
        }

        /// <summary>
        /// 「参照」ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlayerPath_Click(object sender, EventArgs e)
        {
            // インスタンス化
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "exeファイル(*.exe)|*.exe";        // [ファイルの種類]を指定
            ofd.RestoreDirectory = true;    // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

            // ダイアログを表示
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // パスをラベルに表示
                this.LblPlayerPath.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// 「アプリケーションを登録」ボタンをクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegistApp_Click(object sender, EventArgs e)
        {
            // インスタンス化
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "exeファイル(*.exe)|*.exe";        // [ファイルの種類]を指定
            ofd.RestoreDirectory = true;    // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

            // ダイアログを表示
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // リストビューに追加
                string[] item = { Path.GetFileName(ofd.FileName), ofd.FileName };
                this.LsvTools.Items.Add(new ListViewItem(item));
                Utils.AutoSetListViewWidth(this.LsvTools);   // リストビューの幅を自動調整
            }
        }

        /// <summary>
        /// 「フォルダを登録」ボタンをクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegistFolder_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            fbd.SelectedPath = @"C:\Windows";

            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                // リストビューに追加
                string[] item = { Path.GetFileName(fbd.SelectedPath), fbd.SelectedPath };
                this.LsvTools.Items.Add(new ListViewItem(item));
                Utils.AutoSetListViewWidth(this.LsvTools);   // リストビューの幅を自動調整
            }
        }

        /// <summary>
        /// 「削除」ボタンをクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveApp_Click(object sender, EventArgs e)
        {
            // 選択されているアイテムが存在するか確認
            if (this.LsvTools.SelectedIndices.Count == 0)
            {
                MessageBox.Show("アイテムが選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 選択されているリストを取得しリストビューから削除する
            foreach (ListViewItem item in this.LsvTools.SelectedItems)
            {
                this.LsvTools.Items.Remove(item);
            }
        }

        /// <summary>
        /// 「OK」ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            // 変更を反映
            this.frmMain.Config.Template = this.AzkTemplate.Text;

            this.frmMain.Config.PlayerPath = this.LblPlayerPath.Text;

            this.frmMain.Config.Apps = new List<Apps>();
            foreach (ListViewItem item in this.LsvTools.Items)
            {
                Apps apps = new Apps();
                apps.Name = item.Text;
                apps.Path = item.SubItems[1].Text;
                this.frmMain.Config.Apps.Add(apps);
            }

            // メイン画面のツールのコンボボックスに追加
            this.frmMain.AddToolStripComboBox(this.frmMain._TsmTool_OtherTools);
            

            // 設定書き出し
            this.frmMain.Config.Write(this.frmMain.CONFIG_PATH, this.frmMain.Config);

            // フォームを閉じる
            this.Close();
        }

        /// <summary>
        /// 「キャンセル」ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // フォームを閉じる
            this.Close();
        }


        #endregion

        #region メソッド




        #endregion

        
    }
}
