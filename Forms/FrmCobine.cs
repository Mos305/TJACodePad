using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TJACodePad.Models;

namespace TJACodePad.Forms
{
    public partial class FrmCobine : Form
    {
        #region フィールド

        private Regex regex = new Regex(@"[^0-9,]");

        #endregion



        #region コンストラクタ

        public FrmCobine()
        {
            InitializeComponent();
        }

        #endregion



        #region イベント

        /// <summary>
        /// テキストボックス１へ入力時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtInput1_TextChanged(object sender, EventArgs e)
        {
            // 入力フィルタ
            Utils.Filter(this.TxtInput1, this.regex);
        }

        /// <summary>
        /// テキストボックス２へ入力時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtInput2_TextChanged(object sender, EventArgs e)
        {
            // 入力フィルタ
            Utils.Filter(this.TxtInput2, this.regex);
        }

        /// <summary>
        /// 「譜面を合成」ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCombine_Click(object sender, EventArgs e)
        {
            string[] score = new string[]
            {
                this.TxtInput1.Text,
                this.TxtInput2.Text
            };
            int[] scoreLen = new int[]
            {
                score[0].IndexOf(","),
                score[1].IndexOf(",")
            };
            int lcm;
            string[] scoreFilled = new string[2];
            int priority;
            string scoreConbined = "";
            
            // ","が無かった場合処理終了
            if (scoreLen[0] < 0 || scoreLen[1] < 0) return;

            // 譜面長の最小公倍数を求める
            lcm = Utils.Lcm(Math.Max(scoreLen[0], scoreLen[1]), Math.Min(scoreLen[0], scoreLen[1]));

            // 譜面長を合わせる
            if (scoreLen[0] != scoreLen[1])
            {
                for(int i = 0; i < 2; i++)
                {
                    if(lcm / scoreLen[i] != 1)
                    {
                        scoreFilled[i] = this.Fill0(score[i], scoreLen[i], "0".PadLeft(lcm / scoreLen[i] - 1, '0'));
                    }
                    else
                    {
                        scoreFilled[i] = score[i];
                    }
                }
            }
            else
            {
                scoreFilled[0] = score[0];
                scoreFilled[1] = score[1];
            }

            // 優先度を取得
            if (this.RdoInput1.Checked) priority = 0;
            else priority = 1;

            // 譜面を合成
            for (int i = 0; i < lcm; i++)
            {
                char cbn = scoreFilled[priority][i];
                if (scoreFilled[priority][i] == '0' && scoreFilled[(priority + 1) % 2][i] != '0') cbn = scoreFilled[(priority + 1) % 2][i];
                scoreConbined += cbn;
            }

            // テキストボックスに出力
            this.TxtCombine.Text = scoreConbined + ",";
        }

        /// <summary>
        /// 「コピー」ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            // クリップボードに合成した譜面をセット
            Clipboard.SetText(this.TxtCombine.Text);
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 0埋め関数
        /// </summary>
        /// <param name="score">譜面</param>
        /// <param name="scoreLen">譜面の長さ</param>
        /// <param name="zeros">埋める0の数</param>
        /// <returns>0埋めした譜面</returns>
        private string Fill0(string score, int scoreLen, string zeros)
        {
            string scoreFilled = "";
            
            for (int i = 0; i < scoreLen; i++)
            {
                scoreFilled += score[i] + zeros;
            }

            return scoreFilled;
        }

        #endregion
    }
}
