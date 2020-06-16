using Sgry.Azuki.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TJACodePad.Models;

namespace TJACodePad.Forms
{
    public partial class FrmMoveLine : Form
    {
        #region フィールド

        private AzukiControl azuki;
        private Regex regex = new Regex(@"[^0-9]");

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="azuki">AzukiControl</param>
        public FrmMoveLine(AzukiControl azuki)
        {
            InitializeComponent();

            this.azuki = azuki;
        }

        #endregion

        #region イベント

        /// <summary>
        /// フォームロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMoveLine_Load(object sender, EventArgs e)
        {
            // 行数の上限をラベルに表示
            this.LblLineNo.Text = "行番号（1 - " + this.azuki.LineCount + "）：";
        }

        /// <summary>
        /// 行番号入力時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtLineNo_TextChanged(object sender, EventArgs e)
        {
            // 入力フィルタ
            Utils.Filter(this.TxtLineNo, this.regex);
        }

        /// <summary>
        /// 「行へ移動」ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMove_Click(object sender, EventArgs e)
        {
            int lineNo = int.Parse(this.TxtLineNo.Text);

            // 指定行へカーソルを移動
            if (0 < lineNo && lineNo < this.azuki.LineCount)
            {
                this.azuki.Document.SetCaretIndex(lineNo - 1, 0);
            }
        }

        #endregion


    }
}
