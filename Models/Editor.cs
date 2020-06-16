using Sgry.Azuki;
using Sgry.Azuki.Highlighter;
using Sgry.Azuki.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TJACodePad.Models
{
    /// <summary>
    /// エディタクラス
    /// </summary>
    public class Editor
    {
        #region フィールド

        // AzukiControl
        private AzukiControl azuki;

        #endregion



        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="azuki">AzukiControl</param>
        public Editor(AzukiControl azuki)
        {
            this.azuki = azuki;
            this.SetKeywordHighlighter();
        }

        #endregion



        #region アクセサ

        public AzukiControl Azuki
        {
            set => this.azuki = value;
            get => this.azuki;
        }

        #endregion



        #region メソッド

        /// <summary>
        /// キーワードハイライタを設定する関数
        /// </summary>
        public void SetKeywordHighlighter()
        {
            Color backColor = Color.FromArgb(64, 64, 64);

            KeywordHighlighter kh = new KeywordHighlighter();

            kh.HighlightsNumericLiterals = false;
            kh.AddRegex(@"[13]", true, CharClass.Heading1);
            kh.AddRegex(@"[24]", true, CharClass.Heading2);
            kh.AddRegex(@"0", true, CharClass.Heading3);
            kh.AddEnclosure(@"5", @"8", CharClass.Heading4, false);
            kh.AddEnclosure(@"6", @"8", CharClass.Heading4, false);
            kh.AddEnclosure(@"7", @"8", CharClass.Heading5, false);

            kh.AddLineHighlight("//", CharClass.Comment);
            kh.AddLineHighlight("#", CharClass.Keyword2);
            kh.AddLineHighlight(":", CharClass.Keyword3);

            kh.AddKeywordSet(new string[]
            {
                TJA.BALLOON,
                TJA.BPM,
                TJA.COURSE,
                TJA.DEMOSTART,
                TJA.GAME,
                TJA.LEVEL,
                TJA.LIFE,
                TJA.OFFSET,
                TJA.SCOREDIFF,
                TJA.SCOREINIT,
                TJA.SCOREMODE,
                TJA.SEVOL,
                TJA.SIDE,
                TJA.SONGVOL,
                TJA.STYLE,
                TJA.SUBTITLE,
                TJA.TITLE,
                TJA.WAVE
            }, CharClass.Keyword);

            this.azuki.Highlighter = kh;

            this.azuki.ColorScheme.SetColor(CharClass.Heading1, Color.Tomato, backColor);
            this.azuki.ColorScheme.SetColor(CharClass.Heading2, Color.Aqua, backColor);
            this.azuki.ColorScheme.SetColor(CharClass.Heading3, Color.DimGray, backColor);
            this.azuki.ColorScheme.SetColor(CharClass.Heading4, Color.Gold, backColor);
            this.azuki.ColorScheme.SetColor(CharClass.Heading5, Color.Orange, backColor);

            this.azuki.ColorScheme.SetColor(CharClass.Keyword, Color.Aqua, backColor);

            this.azuki.ColorScheme.SetColor(CharClass.Keyword2, Color.LightSalmon, backColor);
            this.azuki.ColorScheme.SetColor(CharClass.Keyword3, Color.White, backColor);

            this.azuki.ColorScheme.SetColor(CharClass.Comment, Color.Lime, backColor);
        }

        /// <summary>
        /// カーソルの位置に文字列を挿入する関数
        /// </summary>
        /// <param name="text"></param>
        public void Insert(string text)
        {
            this.azuki.Document.Replace(text, this.azuki.CaretIndex, this.azuki.CaretIndex);
        }

        /// <summary>
        /// カーソル行に1文字おきに指定文字列を挿入する関数
        /// </summary>
        /// <param name="str">挿入する文字列</param>
        public void Fill(string str)
        {
            int beginLine, beginCol;
            string line;
            string lineFilled = "";

            // カーソル行の内容を取得
            this.azuki.GetLineColumnIndexFromCharIndex(this.azuki.CaretIndex, out beginLine, out beginCol);
            line = this.azuki.Document.GetLineContent(beginLine);
            if (line.IndexOf(",") < 0) return;  // カーソル行が譜面行で無い場合は処理を行わない

            // 1文字おきに指定文字列を挿入
            int i;
            for (i = 0; line[i] != ','; i++)
            {
                lineFilled += line[i] + str;
            }
            lineFilled += line.Substring(i);

            // 挿入後の文字列をエディタに反映
            this.azuki.Document.Replace(lineFilled,
                this.azuki.Document.GetCharIndexFromLineColumnIndex(beginLine, 0),
                this.azuki.Document.GetCharIndexFromLineColumnIndex(beginLine, 0) + line.Length);
        }

        /// <summary>
        /// カーソル行から1文字ずつ指定文字数だけ削除する関数
        /// </summary>
        /// <param name="count">削除する文字数</param>
        public void Remove(int count)
        {
            int beginLine, beginCol;
            string line;
            string lineRemoved = "";
            int scoreLen;

            // カーソル行の内容を取得
            this.azuki.GetLineColumnIndexFromCharIndex(this.azuki.CaretIndex, out beginLine, out beginCol);
            line = this.azuki.Document.GetLineContent(beginLine);
            scoreLen = line.IndexOf(",");
            if (scoreLen < 0) return;  // カーソル行が譜面行で無い場合は処理を行わない

            // 1文字おきに指定文字列を挿入
            int i;
            for (i = 0; i < scoreLen; i+=(count + 1))
            {
                lineRemoved += line[i];
            }
            lineRemoved += line.Substring(scoreLen);

            // 挿入後の文字列をエディタに反映
            this.azuki.Document.Replace(lineRemoved,
                this.azuki.Document.GetCharIndexFromLineColumnIndex(beginLine, 0),
                this.azuki.Document.GetCharIndexFromLineColumnIndex(beginLine, 0) + line.Length);
        }

        #endregion
    }
}
