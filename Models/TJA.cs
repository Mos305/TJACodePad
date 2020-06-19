using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TJACodePad.Models
{
    /// <summary>
    /// TJA命令クラス
    /// </summary>
    public class TJA
    {
        public static readonly string TITLE = "TITLE";
        public static readonly string LEVEL = "LEVEL";
        public static readonly string BPM = "BPM";
        public static readonly string WAVE = "WAVE";
        public static readonly string OFFSET = "OFFSET";
        public static readonly string BALLOON = "BALLOON";
        public static readonly string SONGVOL = "SONGVOL";
        public static readonly string SEVOL = "SEVOL";
        public static readonly string COURSE = "COURSE";
        public static readonly string STYLE = "STYLE";
        public static readonly string GAME = "GAME";
        public static readonly string LIFE = "LIFE";
        public static readonly string DEMOSTART = "DEMOSTART";
        public static readonly string SIDE = "SIDE";
        public static readonly string SUBTITLE = "SUBTITLE";
        public static readonly string SCOREMODE = "SCOREMODE";
        public static readonly string SCOREINIT = "SCOREINIT";
        public static readonly string SCOREDIFF = "SCOREDIFF";

        public static readonly string TITLE_DEFAULT = string.Empty;

        public static readonly int LEVEL_DEFAULT = 0;

        public static readonly double BPM_DEFAULT = 100.0;

        public static readonly string WAVE_DEFAULT = string.Empty;

        public static readonly double OFFSET_DEFAULT = 0.0;

        public static readonly string BALLOON_DEFAULT = string.Empty;

        public static readonly int SONGVOL_DEFAULT = 100;

        public static readonly int SEVOL_DEFAULT = 100;

        public static readonly int COURSE_EASY_NUM = 0;
        public static readonly int COURSE_NORMAL_NUM = 1;
        public static readonly int COURSE_HARD_NUM = 2;
        public static readonly int COURSE_ONI_NUM = 3;
        public static readonly int COURSE_EDIT_NUM = 4;
        public static readonly string COURSE_EASY_STR = "Easy";
        public static readonly string COURSE_NORMAL_STR = "Normal";
        public static readonly string COURSE_HARD_STR = "Hard";
        public static readonly string COURSE_ONI_STR = "Oni";
        public static readonly string COURSE_EDIT_STR = "Edit";

        public static readonly int COURSE_DEFAULT_NUM = COURSE_ONI_NUM;
        public static readonly string COURSE_DEFAULT_STR = COURSE_ONI_STR;

        public static readonly int STYLE_SINGLE_NUM = 1;
        public static readonly int STYLE_DOUBLE_NUM = 2;
        public static readonly string STYLE_SINGLE_STR = "Single";
        public static readonly string STYLE_DOUBLE_STR = "Double";
        public static readonly string STULE_COUPLE_STR = "Couple";

        public static readonly int STYLE_DEFAULT_NUM = STYLE_SINGLE_NUM;
        public static readonly string STYLE_DEFAULT_STR = STYLE_SINGLE_STR;

        public static readonly string GAME_TAIKO = "Taiko";
        public static readonly string GAME_JUDE = "Jude";

        public static readonly string GAME_DEFAULT = GAME_TAIKO;

        public static readonly int LIFE_DEFAULT = 0;

        public static readonly double DEMOSTART_DEFAULT = 0.0;

        public static readonly int SIDE_NORMAL_NUM = 1;
        public static readonly int SIDE_EX_NUM = 2;
        public static readonly int SIDE_BOTHL_NUM = 3;
        public static readonly string SIDE_NORMAL_STR = "Normal";
        public static readonly string SIDE_EX_STR = "Ex";
        public static readonly string SIDE_BOTH_STR = "Both";

        public static readonly int SIDE_DEFAULT_NUM = SIDE_BOTHL_NUM;
        public static readonly string SIDE_DEFAULT_STR = SIDE_BOTH_STR;

        public static readonly string SUBTITLE_DEFAULT = string.Empty;

        public static readonly int SCOREMODE_0 = 0;
        public static readonly int SCOREMODE_1 = 1;
        public static readonly int SCOREMODE_2 = 2;

        public static readonly int SCOREMODE_DEFUALT = SCOREMODE_1;

        public static readonly int SCOREINIT_DEFAULT = 0;

        public static readonly int SCOREDIFF_DEFAULT = 0;



        public static readonly string _START = "#START";
        public static readonly string _START_P1 = "#START P1";
        public static readonly string _START_P2 = "#START P2";
        public static readonly string _END = "#END";

        public static readonly string _BPMCHANGE = "#BPMCHANGE";
        public static readonly string _GOGOSTART = "#GOGOSTART";
        public static readonly string _GOGOEND = "#GOGOEND";
        public static readonly string _MEASURE = "#MEASURE";
        public static readonly string _SCROLL = "#SCROLL";
        public static readonly string _DELAY = "#DELAY";
        public static readonly string _SECTION = "#SECTION";
        public static readonly string _BRANCHSTART = "#BRANCHSTART";
        public static readonly string _BRANCHEND = "#BRANCHEND";
        public static readonly string _N = "#N";
        public static readonly string _E = "#E";
        public static readonly string _M = "#M";
        public static readonly string _LEVELHOLD = "#LEVELHOLD";
        public static readonly string _BMSCROLL = "#BMSCROLL";
        public static readonly string _HBSCROLL = "#HBSCROLL";
        public static readonly string _BARLINEOFF = "#BARLINEOFF";
        public static readonly string _BARLINEON = "#BARLINEON";

        public static readonly double _BPMCHANGE_DEFAULT = 100.0;
        public static readonly string _MEASURE_DEFAULT = "4/4";
        public static readonly double _SCROLL_DEFAULT = 1.0;
    }
}
