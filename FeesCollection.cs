using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class FeesCollection : Form
    {
         DataLayer d = new DataLayer();
        public FeesCollection()
        {
            InitializeComponent();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
           
            SchoolManagement.dtp3 = datetime1.Value.ToShortDateString();

            SchoolManagement.dtp4 = dateTime2.Value.ToShortDateString();
            string s = "SELECT        Amount, BillNo, Feetype, Description, TranDate FROM tbl_FeesCollection where TranDate>='" + SchoolManagement.dtp3 + "'AND TranDate<= '" + SchoolManagement.dtp4 + "' ";
                SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count >=1)
                {
                   FeeCollectionReprt fcr = new FeeCollectionReprt();
                   fcr.Show();
                }
                else
                {
                    MessageBox.Show("No transaction avialable between these two days", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
            

        }
    }
