using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TJACodePad.Models
{
    /// <summary>
    /// 便利関数クラス
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// 入力フィルタ関数
        /// </summary>
        /// <param name="textBox">テキストボックス</param>
        /// <param name="regex">正規表現</param>
        public static void Filter(TextBox textBox, Regex regex)
        {
            int cursolPos = textBox.SelectionStart;
            textBox.Text = regex.Replace(textBox.Text, "");
            textBox.SelectionStart = cursolPos;
        }

        /// <summary>
        /// 最小公倍数を計算する関数
        /// </summary>
        /// <param name="a">入力（大きい方）</param>
        /// <param name="b">入力（小さい方）</param>
        /// <returns>最小公倍数</returns>
        public static int Lcm(int a, int b)
        {
            return a * b / Gcd(a, b);
        }

        /// <summary>
        /// 最大公約数を計算する関数
        /// </summary>
        /// <param name="a">入力（大きい方）</param>
        /// <param name="b">入力（小さい方）</param>
        /// <returns>最大公約数</returns>
        public static int Gcd(int a, int b)
        {
            if (a < b)
                // 引数を入替えて自分を呼び出す
                return Gcd(b, a);
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }


        /// <summary>
        /// リストビューの列幅を自動調整する関数
        /// </summary>
        /// <param name="listView">リストビュー</param>
        public static void AutoSetListViewWidth(ListView listView)
        {
            foreach (ColumnHeader ch in listView.Columns)
            {
                ch.Width = -1;
            }
        }
    }
}
