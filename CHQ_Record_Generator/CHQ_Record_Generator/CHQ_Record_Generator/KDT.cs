using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHQ_Record_Generator
{
    public class KDT:System.Data.DataTable 
    {

        private string _SQL = "";
        public string SQL
        {
            get { return _SQL; }
        }
        public void Load(System.Data.SqlClient.SqlDataAdapter DA)
        {
            _SQL = DA.SelectCommand.CommandText ;
            DA.Fill(this);

            

        }
    }
}
