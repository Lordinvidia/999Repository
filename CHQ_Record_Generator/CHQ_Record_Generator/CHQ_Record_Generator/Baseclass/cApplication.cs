using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHQ_Record_Generator.Baseclass
{
    class cApplication
    {
        private static ILog _LogObject = null;
        public static ILog LogObject
        {
            get
            {
                if (_LogObject == null)
                {
                    _LogObject = new txtFileLog(AppPath + @"\CHQ_Record_Generator.log");
                }
                return _LogObject;
            }
        }
        private static IShowMessage _ShowMessageObject = null;
        public static IShowMessage ShowMessageObject
        {
            get
            {
                if (_ShowMessageObject == null)
                {
                    _ShowMessageObject = new MsgBox();
                }
                return _ShowMessageObject;
            }
        }
        public static String AppPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
        public static string DataFilePath
        {
            get
            {
                return AppPath + @"\Data.xml";
            }
        }
    }
}
