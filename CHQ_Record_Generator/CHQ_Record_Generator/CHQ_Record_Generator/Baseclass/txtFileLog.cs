using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CHQ_Record_Generator.Baseclass
{
    public class txtFileLog : ILog
    {
        string _Path = "";
        public txtFileLog(String pPath)
        {
            _Path = pPath;
        }
        public void Log(string message)
        {

            using (StreamWriter w = File.AppendText(_Path))
            {
                DateTime DNow = DateTime.Now;


                w.WriteLine(DNow.ToString("yyyy/MM/dd HH:mm:sss") + ":" + message);
            }

        }

    }
}
