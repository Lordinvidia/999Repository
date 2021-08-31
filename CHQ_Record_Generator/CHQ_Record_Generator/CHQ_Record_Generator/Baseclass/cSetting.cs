using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace CHQ_Record_Generator.Baseclass
{
    class cSetting
    {
        //private static Dat
        //private static string fileName = @"D:\CODE\visual studio 2010\Projects\RePlaceDollarSign\RePlaceDollarSign\File\Dictionary.bin";
        //private static string filePath = @"D:\CODE\visual studio 2010\Projects\RePlaceDollarSign\RePlaceDollarSign\File\";

        private static string _fileName = "";
        private static string _filePath = "";
        private static String FileName
        {
            get
            {
                if (_fileName == "")
                {
                    _fileName = System.Configuration.ConfigurationSettings.AppSettings["SettingFilePath"] + System.Configuration.ConfigurationSettings.AppSettings["SettingFileName"];

                }
                return _fileName;
            }
        }
        private static string FilePath
        {
            get
            {
                if (_filePath == "")
                {
                    _filePath = System.Configuration.ConfigurationSettings.AppSettings["SettingFilePath"];
                }
                return _filePath;
            }
        }
        static void Write(Dictionary<string, string> dictionary, string file)
        {
            if (System.IO.File.Exists(file))
            {
                System.IO.File.Create(file).Close();

            }
            using (FileStream fs = File.OpenWrite(file))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                // Put count.
                writer.Write(dictionary.Count);
                // Write pairs.
                foreach (var pair in dictionary)
                {
                    writer.Write(pair.Key);
                    writer.Write(pair.Value);
                }
            }
        }

        static Dictionary<string, string> Read(string file)
        {
            var result = new Dictionary<string, string>();
            try
            {
                using (FileStream fs = File.OpenRead(file))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    // Get count.
                    int count = reader.ReadInt32();
                    // Read in all pairs.
                    for (int i = 0; i < count; i++)
                    {
                        string key = reader.ReadString();
                        string value = reader.ReadString();
                        result[key] = value;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        private static Dictionary<String, String> _MyDic = null;
        public static Dictionary<String, String> MyDic
        {
            get
            {
                if (_MyDic == null)
                {
                    _MyDic = Read(FileName);
                }
                return _MyDic;
            }
        }

        public static void RemoveSetting(String key)
        {
            MyDic.Remove(key);

        }
        public static void SaveSettingDataset(String key, DataSet DS)
        {
            DS.WriteXml(FilePath + key + ".xml");

        }
        public static DataSet GetSettingDataset(String key)
        {

            if (!System.IO.File.Exists(FilePath + key + ".xml"))
            {
                return null;
            }
            DataSet DS = new DataSet();
            DS.ReadXml(FilePath + key + ".xml");
            return DS;

        }
        public static String GetSetting(String key)
        {
            if (!MyDic.ContainsKey(key))
            {

                return "";
            }
            return MyDic[key].ToString();

        }

        public static void SaveSetting(String key, String value)
        {

            if (!MyDic.ContainsKey(key))
            {
                MyDic.Add(key, value);
            }
            MyDic[key] = value;
            //MyDic
            Write(MyDic, FileName);
        }
        public static void GetSettingTxt(System.Windows.Forms.Form F, System.Windows.Forms.TextBox T)
        {
            if (!MyDic.ContainsKey(F.Name + T.Name))
            {
                return;
            }
            T.Text = GetSetting(F.Name + T.Name);

        }
        public static void SaveSettingTxt(System.Windows.Forms.Form F, System.Windows.Forms.TextBox T)
        {
            SaveSetting(F.Name + T.Name, T.Text);
        }
        private static void LoopThoughtAllControl(List<TextBox> lst, Control c)
        {
            foreach (Control child in c.Controls)
            {
                if (child.GetType() == typeof(TextBox))
                {
                    //cSetting.GetSettingTxt(this, (TextBox)c);
                    //cSetting.SaveSettingTxt(F, (TextBox)c);
                    lst.Add((TextBox)child);
                }
                else
                {
                    LoopThoughtAllControl(lst, child);
                }
            }
        }
        public static void SaveSettingAllTxt(System.Windows.Forms.Form F)
        {
            List<TextBox> lst = new List<TextBox>();

            LoopThoughtAllControl(lst, F);

            foreach (TextBox txt in lst)
            {
                SaveSettingTxt(F, txt);
            }
        }

        public static void GetSettingAllTxt(System.Windows.Forms.Form F)
        {
            List<TextBox> lst = new List<TextBox>();

            LoopThoughtAllControl(lst, F);

            foreach (TextBox txt in lst)
            {
                GetSettingTxt(F, txt);
            }
        }

    }
}
