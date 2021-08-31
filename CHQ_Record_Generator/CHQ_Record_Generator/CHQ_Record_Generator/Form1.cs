using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CHQ_Record_Generator.Baseclass;
namespace CHQ_Record_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String connectionString = @"Data Source=192.168.94.145;Initial Catalog=CHEQUEWORKS_BIMB_from_156;User ID=chequeworks;Password=chequeworks";


        String FileNamePath = @"D:\TEMP\2021_05_17\names.txt";

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "Hello";
            str = DateTime.Now.ToYearToMilisecond();



        }
        private SqlConnection CN()
        {
            
            SqlConnection Con = new SqlConnection(connectionString);
            return Con;
        }
        private KDT GetKDT(String SQL)
        {
            SqlDataAdapter DA = new SqlDataAdapter(SQL, CN());
            //DataTable DT = new DataTable();
            KDT DT=new KDT ();
            DT.Load(DA);

            //DA.Fill(DT);            
            return DT;

        }

        private void UpdateKDT(KDT DT)
        {
            SqlDataAdapter DA = new SqlDataAdapter(DT.SQL, CN());
            SqlCommandBuilder CB = new SqlCommandBuilder(DA);

            DA.Update(DT);

        }
        private String GetAddress()
        {
            int i;
            StanddardRandom s = new StanddardRandom();
            int iNumberofWord = s.Next(3, 7);
            StringBuilder strB = new StringBuilder();
            for (i = 1; i <= iNumberofWord; i++)
            {
                strB.Append(cUtil.WordFinder2(5 + s.Next(1, 9))).Append(" ");
            }
            return strB.ToString();
        }

     

        private string GetRandomTitle()
        {
            String[] arTitle = { "MR.", "MRS.","Miss." };


            return arTitle[cUtil.Random(0, 2)];

        }
        List<String> lstName = null;
        private string GetRandomSex()
        {
            int RandomNumber = cUtil.Random(0, 1);
            if (RandomNumber == 0)
            {
                return "M";
            }
            return "F";
        }
        private string GetRandomName()
        {
            if (lstName == null || lstName.Count == 0)
            {
                String FileContent = cUtil.ReadFile(this.FileNamePath);
                String[] arrName = FileContent.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries); ;
                int i;
                lstName = new List<string>();
                for (i = 0; i < arrName.Length; i++)
                {
                    lstName.Add(arrName[i]);
                }
            }
            return lstName[cUtil.Random(0, lstName.Count - 1)];
        }

        private void InsertSTDCIF()
        {
            
            StanddardRandom s = new StanddardRandom();

            String SQL = "Select * from STDCIF";
            KDT DT = GetKDT(SQL);
            int i;
            //int NumberofRecord = 700000;

            int indexbegin = 533124;

            for (i = indexbegin ; i < NumberofRecord; i++)
            {
                DataRow DR = DT.NewRow();
                DR["CIF_NO"] = (i + 1).ToString("0000000000");
                DR["CIS_NO"] = (i + 1).ToString("0000000000");
                DR["CIF_IND"] = "A";
                DR["TITLE"] = GetRandomTitle();
                DR["NAME"] = GetRandomName();
                DR["BRIC"] = cUtil.RandomNumber(12);
                DR["BIRTH_DT"] = "";
                DR["PASSPORT_IND"] = "";
                DR["PASSPORT_ISS_CTR"] = "";
                DR["BAS_GRP_CDE"] = "24";
                DR["SEX"] = GetRandomSex();
                DR["MAIL_ADDR_1"] = GetAddress();
                DR["MAIL_ADDR_2"] = GetAddress();
                DR["MAIL_ADDR_3"] = "";
                DR["MAIL_STATE_CDE"] = "14";
                DR["MAIL_STATE_OTH"] = "";
                DR["MAIL_POST_CDE"] = "53000";
                DR["MAIL_CTR_CDE"] = "MY";
                DR["PMNT_ADDR_1"] = GetAddress ();
                DR["PMNT_ADDR_2"] = "";
                DR["PMNT_ADDR_3"] = "";
                DR["PMNT_STATE_CDE"] = "14";
                DR["PMNT_STATE_OTH"] = "";
                DR["PMNT_POST_CDE"] = "51000";
                DR["PMNT_CTR_CDE"] = "MY";
                DR["MBL_TEL"] = "";
                DR["OFF_TEL"] = "";
                DR["HM_TEL"] = "";
                DR["VIP"] = "N";
                DR["START_DT"] = "20210819";
                DR["END_DT"] = "99991231";
                DR["POSITION"] = "-";
                DR["VRF_FLG"] = "Y";
                DR["VRF_UID"] = "core";
                DR["VRF_TMS"] = "2021082009243250183";
                DR["CFM_UID"] = "core";
                DR["CFM_TMS"] = "2021081913290154189";
                DR["ALLOW_DEL"] = "Y";
                DR["DEL_FLG"] = "N";
                DR["UPD_FUNC"] = "JMETER";
                DR["CRT_TMS"] = "2021082414221922446";
                DR["UPD_TMS"] = "2021082414221922446";
                DR["CRT_UID"] = "JMETER";
                DR["UPD_UID"] = "JMETER";
                DR["PENDING_FROM"] = "N";
                DT.Rows.Add(DR);

            }

            UpdateKDT(DT);

        }

        private void InsertSTDACC()
        {

            StanddardRandom s = new StanddardRandom();

            String SQL = "Select * from STDACC";
            KDT DT = GetKDT(SQL);
            int i;
            //int NumberofRecord = 700000;
            //int NumberofRecord = 1000;


            int indexbegin = 0;

            for (i = indexbegin; i < NumberofRecord; i++)
            {
                DataRow DR = DT.NewRow();
                //DR["CIF_NO"] = (i + 1).ToString("00000000000000");
                //DR["CIS_NO"] = (i + 1).ToString("0000000000");
                DR["BNK_ACC_NO"] = (i + 1).ToString("00000000000000"); ;
                DR["CHQ_ACC_NO"] = (i + 1).ToString("0000000000"); 
                DR["CIF_NO"] = (i + 1).ToString("0000000000"); 
                DR["ACC_TYP"] = "D";
                DR["CUR_CDE"] = "";
                DR["CTT_PERSON"] = "";
                DR["PHONE"] = "";
                DR["FAX"] = "";
                DR["ACC_OPN_DT"] = "20210823";
                DR["BRH_CDE"] = "01014";
                DR["ACC_STATUS"] = "1";
                DR["ACC_STATUS_DT"] = "";
                DR["JOINT_ACC"] = "N";
                DR["VIP"] = "N";
                DR["START_DT"] = "20210823";
                DR["END_DT"] = "99991231";
                DR["VRF_FLG"] = "Y";
                DR["VRF_UID"] = "core";
                DR["VRF_TMS"] = "2021081913085166479";
                DR["CFM_UID"] = "core";
                DR["CFM_TMS"] = "2021081913093990174";
                DR["COMP_IMG"] = "";
                DR["COMP_IMG_TMS"] = "";
                DR["COMP_COP_IMG"] = "";
                DR["COMP_COP_IMG_TMS"] = "";
                DR["IDMTY_AGRM_DT"] = "";
                DR["IDMTY_TEL_PERSON"] = "";
                DR["IDMTY_COV_TEL"] = "";
                DR["IDMTY_COV_FAX"] = "";
                DR["IDMTY_COV_EMAIL"] = "";
                DR["OCS_AMT_FR"] = 0.00;
                DR["OCS_AMT_TO"] = 0.00;
                DR["ICS_AMT_FR"] = 0.00;
                DR["ICS_AMT_TO"] = 0.00;
                DR["SERV_TYP"] = "N";
                DR["ALLOW_DEL"] = "Y";
                DR["DEL_FLG"] = "N";
                DR["UPD_FUNC"] = "JMETER";
                DR["CRT_TMS"] = "2021082310440034636";
                DR["UPD_TMS"] = "2021082310443831333";
                DR["CRT_UID"] = "JMETER";
                DR["UPD_UID"] = "JMETER";
                DR["ACC_KEY"] = "";
                DR["IND"] = "JMETER";
                DR["PENDING_FROM"] = "N";
                DR["VALIDITY"] = "";
                DT.Rows.Add(DR);

            }

            UpdateKDT(DT);

        }

        private void InsertSTDCUSTACC()
        {

            StanddardRandom s = new StanddardRandom();

            String SQL = "Select * from STDCUSTACC";
            KDT DT = GetKDT(SQL);
            int i;
            //int NumberofRecord = 700000;
            //int NumberofRecord = 1000;


            int indexbegin = 0;

            for (i = indexbegin; i < NumberofRecord; i++)
            {
                DataRow DR = DT.NewRow();
                //DR["CIF_NO"] = (i + 1).ToString("00000000000000");
                //DR["CIS_NO"] = (i + 1).ToString("0000000000");
                DR["BNK_ACC_NO"] = (i + 1).ToString("00000000000000"); ;                
                DR["CIF_NO"] = (i + 1).ToString("0000000000");
                DR["POSITION"] = "";
                DR["ACC_RELATIONSHIP"] = "";
                DR["RULES"] = "";
                DR["SEQ_NO"] = 1;
                DR["VRF_FLG"] = "";
                DR["VRF_UID"] = "core";
                DR["VRF_TMS"] = "2021082112182089464";
                DR["CFM_UID"] = "core";
                DR["CFM_TMS"] = "2021082112182089464";
                DR["ALLOW_DEL"] = "Y";
                DR["DEL_FLG"] = "N";
                DR["UPD_FUNC"] = "JMETER";
                DR["CRT_TMS"] = "2021082112182089464";
                DR["UPD_TMS"] = "2021082112182089464";
                DR["CRT_UID"] = "JMETER";
                DR["UPD_UID"] = "JMETER";
                DT.Rows.Add(DR);

            }

            UpdateKDT(DT);

        }
        private int NumberofRecord = 2;

        private void InsertSVSSIGNCOND()
        {
            StanddardRandom s = new StanddardRandom();

            String SQL = "Select * from SVSSIGNCOND";
            KDT DT = GetKDT(SQL);
            int i;
            //int NumberofRecord = 700000;
            //int NumberofRecord = 1000;


            int indexbegin = 0;

            for (i = indexbegin; i < NumberofRecord; i++)
            {
                DataRow DR = DT.NewRow();
                //DR["CIF_NO"] = (i + 1).ToString("00000000000000");
                //DR["CIS_NO"] = (i + 1).ToString("0000000000");
                DR["SIGNCOND_KEY"] = (i+1).ToString ("00000000000000000000");
                DR["SIGNCOND_ID"] = "ANY 1 TO SIGN";
                DR["SIGNCOND_DESC"] = "";
                DR["AMT_FR"] = 0.00;
                DR["AMT_TO"] = 0.00;
                DR["VRF_FLG"] = "Y";
                DR["VRF_UID"] = "core";
                DR["VRF_TMS"] = "2021082309395178768";
                DR["CFM_UID"] = "core";
                DR["CFM_TMS"] = "2021082309401131832";
                DR["ALLOW_DEL"] = "Y";
                DR["DEL_FLG"] = "N";
                DR["UPD_FUNC"] = "JMETER";
                DR["CRT_TMS"] = "2021082309401131832";
                DR["UPD_TMS"] = "2021082309401131832";
                DR["CRT_UID"] = "JMETER";
                DR["UPD_UID"] = "JMETER";
                DR["PENDING_FROM"] = "N";

                DT.Rows.Add(DR);

            }

            UpdateKDT(DT);

        }

        private void InsertSVSSIGNCONDCFG()
        {
            StanddardRandom s = new StanddardRandom();

            String SQL = "Select * from SVSSIGNCONDCFG";
            KDT DT = GetKDT(SQL);
            int i;
            //int NumberofRecord = 700000;
            //int NumberofRecord = 1000;


            int indexbegin = 0;

            for (i = indexbegin; i < NumberofRecord; i++)
            {
                DataRow DR = DT.NewRow();
                //DR["CIF_NO"] = (i + 1).ToString("00000000000000");
                //DR["CIS_NO"] = (i + 1).ToString("0000000000");


                DR["BNK_ACC_NO"] = (i + 1).ToString("00000000000000");
                DR["SIGNCOND_KEY"] = (i + 1).ToString("00000000000000000000"); ;
                DR["SIGNCOND_FDESC"] = "Test JMETER " + (i + 1);
                DR["AMT_FR"] = 0;
                DR["AMT_TO"] = 100000;
                DR["START_DT"] = "20210822";
                DR["END_DT"] = "99991231";
                DR["VRF_FLG"] = "Y";
                DR["VRF_UID"] = "core";
                DR["VRF_TMS"] = "2021082212435930062";
                DR["CFM_UID"] = "core";
                DR["CFM_TMS"] = "2021082212435930062";                
                DR["ALLOW_DEL"] = "Y";
                DR["DEL_FLG"] = "N";
                DR["UPD_FUNC"] = "JMETER";
                DR["CRT_TMS"] = "2021082309401131832";
                DR["UPD_TMS"] = "2021082309401131832";
                DR["CRT_UID"] = "JMETER";
                DR["UPD_UID"] = "JMETER";
                DR["PENDING_FROM"] = "N";

                DT.Rows.Add(DR);

            }

            UpdateKDT(DT);

        }

        private void InsertSVSSIGNDOC()
        {
            StanddardRandom s = new StanddardRandom();

            String SQL = "Select * from SVSSIGNDOC";
            KDT DT = GetKDT(SQL);
            int i;
            //int NumberofRecord = 700000;
            //int NumberofRecord = 1000;


            int indexbegin = 0;

            for (i = indexbegin; i < NumberofRecord; i++)
            {
                DataRow DR = DT.NewRow();
                //DR["CIF_NO"] = (i + 1).ToString("00000000000000");
                //DR["CIS_NO"] = (i + 1).ToString("0000000000");


                DR["BNK_ACC_NO"] = (i + 1).ToString("00000000000000");
                DR["DOC_NO"] = (i + 1).ToString("000000000000"); ;
                DR["DOC_DESC"] = "JMETER " + (i + 1);
                DR["DOC_IMG"] = "RPT" + (i+1).ToString () + ".pdf";
                DR["DOC_IMG_TMS"] = "2021082314250078969";
                DR["START_DT"] = "20210823";
                DR["END_DT"] = "99991231";
                DR["VRF_FLG"] = "Y";
                DR["VRF_UID"] = "core";
                DR["VRF_TMS"] = "99991231";
                DR["CFM_UID"] = "core";
                DR["CFM_TMS"] = "2021082410121941251";
                DR["ALLOW_DEL"] = "Y";
                DR["DEL_FLG"] = "N";
                DR["UPD_FUNC"] = "JMETER";
                DR["CRT_TMS"] = "2021082309401131832";
                DR["UPD_TMS"] = "2021082309401131832";
                DR["CRT_UID"] = "JMETER";
                DR["UPD_UID"] = "JMETER";
                

                DT.Rows.Add(DR);

            }

            UpdateKDT(DT);

        }
        private void InsertSVSSIGINFO()
        {

            StanddardRandom s = new StanddardRandom();

            String SQL = "Select * from SVSSIGNINFO";
            KDT DT = GetKDT(SQL);
            int i;
            //int NumberofRecord = 700000;
            //int NumberofRecord = 1000;


            int indexbegin = 0;

            for (i = indexbegin; i < NumberofRecord; i++)
            {
                DataRow DR = DT.NewRow();
                //DR["CIF_NO"] = (i + 1).ToString("00000000000000");
                //DR["CIS_NO"] = (i + 1).ToString("0000000000");
                DR["BNK_ACC_NO"] = (i + 1).ToString("00000000000000"); ;
                DR["CIF_NO"] = (i + 1).ToString("0000000000");
                DR["START_DT"] = "20210823";
                DR["END_DT"] = "99991231";
                DR["CHQ_IMG"] = "";
                DR["CHQ_IMG_TMS"] = "2021082123171004379";
                DR["SIGN_IMG"] = "";
                DR["SIGN_IMG_TMS"] = "2021082123171004379";
                DR["NOTICE_DT"] = "";
                DR["PEND_SIGN"] = "N";
                DR["SIGN_NO"] = "";
                DR["VRF_FLG"] = "Y";
                DR["VRF_UID"] = "core";
                DR["VRF_TMS"] = "2021082313164757666";
                DR["CFM_UID"] = "core";
                DR["CFM_TMS"] = "2021082313164757666";
                DR["REJ_REA"] = "";
                DR["REMARKS"] = "test";
                DR["ALLOW_DEL"] = "Y";
                DR["DEL_FLG"] = "N";
                DR["UPD_FUNC"] = "";
                DR["CRT_TMS"] = "";
                DR["UPD_TMS"] = "";
                DR["CRT_UID"] = "";
                DR["UPD_UID"] = "";

                DT.Rows.Add(DR);

            }

            UpdateKDT(DT);

        }
        /*
        private void InsertSTDCUSTACC()
        {

            StanddardRandom s = new StanddardRandom();

            String SQL = "Select * from STDCUSTACC";
            KDT DT = GetKDT(SQL);
            int i;
            //int NumberofRecord = 700000;
            int NumberofRecord = 1000;


            int indexbegin = 0;

            for (i = indexbegin; i < NumberofRecord; i++)
            {
                DataRow DR = DT.NewRow();
                //DR["CIF_NO"] = (i + 1).ToString("00000000000000");
                //DR["CIS_NO"] = (i + 1).ToString("0000000000");
                DR["BNK_ACC_NO"] = (i + 1).ToString("00000000000000"); ;
                DR["CIF_NO"] = (i + 1).ToString("0000000000");
                DR["POSITION"] = "";
                DR["ACC_RELATIONSHIP"] = "";
                DR["RULES"] = "";
                DR["SEQ_NO"] = "";
                DR["VRF_FLG"] = "";
                DR["VRF_UID"] = "core";
                DR["VRF_TMS"] = "2021082112182089464";
                DR["CFM_UID"] = "core";
                DR["CFM_TMS"] = "2021082112182089464";
                DR["ALLOW_DEL"] = "Y";
                DR["DEL_FLG"] = "N";
                DR["UPD_FUNC"] = "JMETER";
                DR["CRT_TMS"] = "2021082112182089464";
                DR["UPD_TMS"] = "2021082112182089464";
                DR["CRT_UID"] = "JMETER";
                DR["UPD_UID"] = "JMETER";
                DT.Rows.Add(DR);

            }

            UpdateKDT(DT);

        }
         */
        private void Log(String str)
        {
            this.txtLog.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssss") + " " + str + Environment.NewLine;

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //this.InsertSTDCIF();
                //this.InsertSTDACC();
                //this.InsertSTDCUSTACC();
                //this.InsertSVSSIGINFO();
                this.Log("Begin");
                this.InsertSTDCIF();
                this.Log("Finished insertSTDCIF");
                
                this.InsertSTDACC();
                this.Log("Finished insertSTDACC");
                

                this.InsertSTDCUSTACC();
                this.Log("Finished insertSTDCUSTACC");
                

                this.InsertSVSSIGINFO();
                this.Log("Finished insertSVSSIGNINFO");
                
                

                this.InsertSVSSIGNCOND();
                this.Log("Finished InsertSIGNCONDITION");

                this.InsertSVSSIGNCONDCFG();
                this.Log("Finished InsertSVSSIGNCONDCFG");

                this.InsertSVSSIGNDOC();
                this.Log("Finished InsertSVSSIGNDOC");

                //MessageBox.Show("Done");
               // this.txtLog.Text = "Done " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssss");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                //this.txtLog.Text = ex.ToString();
                this.Log("Exception::" + ex.ToString());

            }
        }
        /*
        private void button2_Click(object sender, EventArgs e)
        {
            KDT DT = new KDT();
            DT = GetKDT("select top 1000 CIF_NO, SEQ_NO, VRF_UID, VRF_TMS, CFM_UID, ALLOW_DEL ,BNK_ACC_NO from STDCUSTACC");
            this.dataGridView1.DataSource = DT;
            int i;
            for (i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].DisplayIndex = i;
            }

        }
         */

    }
}
