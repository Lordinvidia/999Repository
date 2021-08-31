using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CHQ_Record_Generator.Baseclass
{
    class cLogging
    {
        private static string _LogPath = "";
        private static string LogPath
        {
            get
            {
                if (_LogPath == "")
                {
                    _LogPath = System.Configuration.ConfigurationSettings.AppSettings["LogFilePath"];
                }
                return _LogPath;
            }

        }
        public static void Log(string str)
        {
            string strLog = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ssss ::") + str + Environment.NewLine;

            System.IO.StreamWriter SW = new StreamWriter(LogPath, true);

            SW.Write(strLog);
            SW.Close();
        }
    }
}
