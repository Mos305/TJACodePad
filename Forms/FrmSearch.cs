using Sgry.Azuki;
using Sgry.Azuki.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TJACodePad.Forms
{
    public partial class FrmSearch : Form
    {
        #region フィールド

        private AzukiControl azuki;

        #endregion

        #region コンストラクタ

        public FrmSearch(AzukiControl azuki)
        {
            InitializeComponent();

            this.azuki = azuki;
        }

        #endregion

        #region イベント

        /// <summary>
        /// 次を検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFindNext_Click(object sender, EventArgs e)
        {
            // 検索
            this.ShowSearchResult(this.Find(this.TxtFind.Text));
            
        }

        /// <summary>
        /// 置換して次へ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReplace_Click(object sender, EventArgs e)
        {
            // 対象が見つかった場合は置換
            if(this.ShowSearchResult(this.Find(this.TxtFind.Text)))
            {
                this.azuki.Document.Replace(this.TxtReplace.Text);
            }
        }

        /// <summary>
        /// すべて置換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReplaceAll_Click(object sender, EventArgs e)
        {
            // すべて置換
            this.azuki.Document.SetCaretIndex(0, 0);
            while (this.azuki.CaretIndex < this.azuki.Text.Length - 1)
            {
                if (this.ShowSearchResult(this.Find(this.TxtFind.Text)))
                {
                    this.azuki.Document.Replace(this.TxtReplace.Text);
                }
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 検索関数
        /// </summary>
        /// <param name="text">検索文字列</param>
        /// <returns>検索結果</returns>
        private SearchResult Find(string text)
        {
            return this.azuki.Document.FindNext(text, this.azuki.CaretIndex);
        }

        /// <summary>
        /// 検索結果を表示する関数
        /// </summary>
        /// <param name="searchResult">検索結果</param>
        /// <returns>対象が見つかったかどうか</returns>
        private bool ShowSearchResult(SearchResult searchResult)
        {
            if (searchResult == null)
            {
                // 検索結果が見つからなかった場合、メッセージボックスを表示
                MessageBox.Show("見つかりませんでした。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // カーソルをエディタの末尾に移動
                int line, column;
                this.azuki.Document.GetLineColumnIndexFromCharIndex(this.azuki.Text.Length, out line, out column);
                this.azuki.Document.SetCaretIndex(line, column);
                return false;
            }
            else
            {
                this.azuki.SetSelection(searchResult.Begin, searchResult.End);
                return true;
            }
        }




        #endregion

        
    }
}
