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
    public partial class Crstlbanktrans : Form
    {
        DataLayer d = new DataLayer();
        public Crstlbanktrans()
        {
          InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {   
            double a=0;
            string s = "SELECT bt.TransactionNo,ba.BankName, ba.IFSCCode, bt.Amount, bt.Balance, bt.Type, bt.TransactionDate FROM tbl_Bankadrs AS ba INNER JOIN tbl_BankTran AS bt ON ba.AccountNumber = bt.BankAccNo WHERE TransactionDate >='" + SchoolManagement.dtpb1 + "'AND bt.TransactionDate <='" + SchoolManagement.dtpb2 + "'AND bt.BankAccNo='"+SchoolManagement.accno +"' ORDER BY bt.TransactionDate DESC ";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            DataRow dr;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                string s1 = "SELECT TOP (1) TransactionNo,Balance FROM  tbl_BankTran WHERE BankAccNo ='" + SchoolManagement.accno + "' ORDER BY TransactionNo DESC";
                SqlDataAdapter da1= new SqlDataAdapter(s1,d.con);
                DataSet ds1= new DataSet();
                da1.Fill(ds1);
                DataRow dr1;
                if(ds1.Tables[0].Rows.Count>=1)
                {
                    dr1=ds1.Tables[0].Rows[0];
                    a=Convert.ToDouble(dr1[1].ToString());
                }
                dr = ds.Tables[0].Rows[0];
                crpbanktrans crp = new crpbanktrans();
                crp.SetDataSource(ds.Tables[0]);
                crp.SetParameterValue("closingblnc", a);
                crp.SetParameterValue("accno", SchoolManagement.accno);
                crp.SetParameterValue("startdate", SchoolManagement.dtpb1);
                crp.SetParameterValue("enddate", SchoolManagement.dtpb2);
                crystalReportViewer1.ReportSource = crp;
                crystalReportViewer1.Refresh();

            }
            
        }
    }
}