using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
  public class DataLayer
    {
        #region Private Variables

        string Name = "";
        string Address = "";
        string TinNo = "";
        string Phone1 = "";
        string Phone2 = "";
        string Phone3 = "";

    #endregion

    // public static string constring = 
    //public SqlConnection con = new SqlConnection(constring);
    // public SqlConnection con = new SqlConnection("Data Source=N-C9A38B3B1C114\\SQLEXPRESS;Initial Catalog=school;Trusted_Connection=yes;User ID=sa;Password=;");
    //public SqlConnection con = new SqlConnection("Data Source=M-5AA29E60EEA04\\SQLEXPRESS;Initial Catalog=school;Trusted_Connection=yes;User ID=sa;Password=;");
    // public SqlConnection con = new SqlConnection("Data Source=HP\\SQLEXPRESS;Initial Catalog=school;Trusted_Connection=yes;User ID=sa;Password=;");
    //public SqlConnection con = new SqlConnection("Data Source=VIVEK-PC;Initial Catalog=school;Integrated Security=True");
    // public SqlConnection con = new SqlConnection("Data Source=TLTTVMLT5\\SQLEXPRESS;AttachDbFilename=E:\\school.mdf;Integrated Security=True;Connect Timeout=30");
    //public SqlConnection con = new SqlConnection("Data Source = UNITED-PC\\SQLEXPRESS;Initial Catalog=School;Trusted_Connection=yes;User ID=sa;Password=;");
    //public SqlConnection con = new SqlConnection("Data Source=HP\\SQLEXPRESS;Initial Catalog=school;Trusted_Connection=yes;User ID=sa;Password=;");
// public SqlConnection con = new SqlConnection("Data Source=aimsoftsolutions.com;Initial Catalog=HightechSchool;User ID=DataHig;Password='HiGData@123';");
   public SqlConnection con = new SqlConnection("Data Source=DESKTOP-RIK1JQ3\\SQLEXPRESS;Initial Catalog=HightechSchool;Integrated Security=True");

        public DataLayer()
        {
            //LoadConnString();
            //con = new SqlConnection(constring);
           // constring = System.Configuration.ConfigurationSettings.AppSettings["Con1"].ToString();
        }
        public void con_open()
        {
            con.Open();
        } 
        public void con_close()
        {
            con.Close();
        }
        private void LoadConnString()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("School.txt");
           //string readforDecode = System.Configuration.ConfigurationSettings.AppSettings["Con1"].ToString();
            string readforDecode = file.ReadToEnd();
            //file.ReadToEnd();
           // constring = Decryption(readforDecode, globalKey);
            DataLayer d = new DataLayer();
        }
        public static string Decryption(string CypherText, string key)
        {
            byte[] b = Convert.FromBase64String(CypherText);
            TripleDES des = CreateDES(key);
            ICryptoTransform ct = des.CreateDecryptor();
            byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
            return Encoding.Unicode.GetString(output);

        }

        static TripleDES CreateDES(string key)
        {

            MD5 md5 = new MD5CryptoServiceProvider();

            TripleDES des = new TripleDESCryptoServiceProvider();

            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));

            des.IV = new byte[des.BlockSize / 8];

            return des;

        }


        #region Public Properties

        public string ShopName
        {
            get
            {
                return Name;
            }
        }
        public string ShopAddress
        {
            get
            {
                return Address;
            }
        }
        public string ShopTinNo
        {
            get
            {
                return TinNo;
            }
        }
        public string ShopPhoneNo1
        {
            get
            {
                return Phone1;
            }
        }
        public string ShopPhoneNo2
        {
            get
            {
                return Phone2;
            }
        }
        public string ShopPhoneNo3
        {
            get
            {
                return Phone3;
            }
        }
   
        #endregion
    }

