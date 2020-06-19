using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJACodePad.Models
{
    public class Score
    {
        #region フィールド

        private double bpm;

        #endregion



        #region コンストラクタ

        public Score()
        {
            this.bpm = TJA.BPM_DEFAULT;
        }

        #endregion



        #region アクセサ

        public double Bpm
        {
            set => this.bpm = value;
            get => this.bpm;
        }

        #endregion
    }
}
