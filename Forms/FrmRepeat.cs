﻿using Sgry.Azuki.WinForms;
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
    public partial class FrmRepeat : Form
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
        public FrmRepeat(AzukiControl azuki)
        {
            InitializeComponent();

            this.azuki = azuki;
        }

        #endregion



        #region イベント

        /// <summary>
        /// 「繰り返し回数」テキストボックス入力時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtRepeatCount_TextChanged(object sender, EventArgs e)
        {
            // 入力フィルタ
            Utils.Filter(this.TxtRepeatCount, this.regex);

        }

        /// <summary>
        /// 「リピート」ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRepeat_Click(object sender, EventArgs e)
        {
            string text = "";
            int count = int.Parse(this.TxtRepeatCount.Text);

            // テキストを作成
            for (int i = 0; i < count; i++)
            {
                text += this.TxtStr.Text + Environment.NewLine;
            }

            // エディタに反映
            this.azuki.Document.Replace(text, this.azuki.CaretIndex, this.azuki.CaretIndex);
            
        }

        #endregion

        
    }
}
