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
    public partial class FeesReport : Form
    {
        DataLayer d = new DataLayer();
        public FeesReport()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            d.con_open();
            string s = "select f.feeid,f.feetype,f.cstandard,f.amount,f.fine,t.Total from tbl_fee f INNER JOIN tbl_TotalFees t  ON f.feeid = t.feeid " ;
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                FeeReport cr = new FeeReport();
                cr.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = cr;
                crystalReportViewer1.Refresh();
                d.con_close();
            }
        }

        private void FeesReport_Load(object sender, EventArgs e)
        {

        }
    }
}