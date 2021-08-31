using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHQ_Record_Generator.Baseclass
{
    public class MsgBox : IShowMessage
    {

        public void Show(string Message)
        {
            System.Windows.Forms.MessageBox.Show(Message);
        }
    }
}
