using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TJACodePad.Models
{
    /// <summary>
    /// アプリケーションクラス
    /// </summary>
    public class Apps
    {
        private string name;
        private string path;

        public Apps()
        {
            this.name = "";
            this.path = "";
        }

        public string Name
        {
            set => this.name = value;
            get => this.name;
        }

        public string Path
        {
            set => this.path = value;
            get => this.path;
        }
    }

    /// <summary>
    /// 設定クラス
    /// </summary>
    public class Config
    {
        #region フィールド

        private string template;

        private string playerPath;
        private List<Apps> apps;

        #endregion



        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Config()
        {
            this.template =
                TJA.TITLE + ":" + Environment.NewLine +
                TJA.LEVEL + ":" + Environment.NewLine +
                TJA.BPM + ":" + Environment.NewLine +
                TJA.WAVE + ":" + Environment.NewLine +
                TJA.SONGVOL + ":100" + Environment.NewLine +
                TJA.SEVOL + ":100" + Environment.NewLine +
                Environment.NewLine +
                TJA._START + Environment.NewLine +
                TJA._END + Environment.NewLine;
            this.playerPath = "";
            this.apps = new List<Apps>();
        }

        #endregion



        #region アクセサ

        public string Template
        {
            set => this.template = value;
            get => this.template;
        }

        public string PlayerPath
        {
            set => this.playerPath = value;
            get => this.playerPath;
        }

        public List<Apps> Apps
        {
            set => this.apps = value;
            get => this.apps;
        }

        #endregion



        #region メソッド

        /// <summary>
        /// 設定ファイルを保存する関数
        /// </summary>
        /// <param name="configPath">設定ファイルのパス</param>
        /// <param name="config">設定</param>
        public void Write(string configPath, Config config)
        {
            //XmlSerializerオブジェクトを作成
            //書き込むオブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Config));

            //ファイルを開く（UTF-8 BOM無し）
            StreamWriter sw = new StreamWriter(configPath, false, new UTF8Encoding(false));

            //シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, config);

            //閉じる
            sw.Close();
        }

        /// <summary>
        /// 設定ファイルを読み込み
        /// </summary>
        /// <param name="configPath">設定ファイルのパス</param>
        /// <returns>設定内容</returns>
        public Config Read(string configPath)
        {
            //XmlSerializerオブジェクトの作成
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Config));

            //ファイルを開く
            StreamReader sr = new StreamReader(configPath, new UTF8Encoding(false));

            //XMLファイルから読み込み、逆シリアル化する
            Config config = (Config)serializer.Deserialize(sr);

            //閉じる
            sr.Close();

            // XMLだと改行文字が'\n'なので修正
            string[] line = config.template.Split('\n');
            config.template = string.Empty;
            for (int i=0; i < line.Length; i++)
            {
                config.template += line[i] + Environment.NewLine;
            }

            return config;
        }

        #endregion
    }
}
