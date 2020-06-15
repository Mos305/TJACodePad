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
        #region パラメータ

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
            this.azuki.ColorScheme.SetColor(CharClass.Heading3, Color.Gray, backColor);
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

        #endregion
    }
}
