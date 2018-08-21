using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace SchoolManagement
{
    public partial class Login : DevComponents.DotNetBar.Office2007Form
    {
        string globalKey = "AimS2012";
        
        DataLayer d = new DataLayer();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           // Chk_Demo();
           // LoadConnString();
        }
        //private void LoadConnString()
        //{
            
        //    System.IO.StreamReader file = new System.IO.StreamReader("School.txt");
        //   // string readforDecode = System.Configuration.ConfigurationSettings.AppSettings["Con1"].ToString();
        //    string readforDecode = file.ReadToEnd();
        //        // file.ReadToEnd();
        //    DataLayer.constring = Decryption(readforDecode, globalKey);
        //    DataLayer d = new DataLayer();

        //}
        //public static string Decryption(string CypherText, string key)
        //{
        //    byte[] b = Convert.FromBase64String(CypherText);
        //    TripleDES des = CreateDES(key);
        //    ICryptoTransform ct = des.CreateDecryptor();
        //    byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
        //    return Encoding.Unicode.GetString(output);

        //}

        //static TripleDES CreateDES(string key)
        //{

        //    MD5 md5 = new MD5CryptoServiceProvider();

        //    TripleDES des = new TripleDESCryptoServiceProvider();

        //    des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));

        //    des.IV = new byte[des.BlockSize / 8];

        //    return des;

        //}

        private void Chk_Demo()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Count", d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    d.con_open();
                    SqlCommand cmd = new SqlCommand("Insert into tbl_Count values(0)", d.con);
                    cmd.ExecuteNonQuery();
                    d.con_close();
                }
               SqlDataAdapter da1 = new SqlDataAdapter("Select * from tbl_Count", d.con);
               DataSet  ds1 = new DataSet();
                da1.Fill(ds1);

                DataRow dr;
                dr = ds1.Tables[0].Rows[0];
                if (Convert.ToInt32(dr[0].ToString()) >= 180)
                {
                    this.Close();
                }
                else
                {
                    d.con_open();
                    SqlCommand cmd = new SqlCommand("Update tbl_Count set CT=CT+1", d.con);

                    cmd.ExecuteNonQuery();
                    d.con_close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Error while connecting to server system. Please contact software vendor");
                this.Close();

            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            string s = "SELECT username, password,Empno,EmpType FROM teacherdet where username='" + txtUser.Text.Trim() + "' and password='" + txtPass.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            Boolean lg = false;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                lg = true;
                dr = ds.Tables[0].Rows[0];
                SchoolManagement.empno = dr[2].ToString();
                SchoolManagement.UserType = dr[3].ToString();
                
            }
            else
            {               
                MessageBox.Show("Invalid Username/Password!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);              
            }
            if (lg == true)
            {
                Main mn = new Main();
                mn.Show();
                this.Visible = false;
            }

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
