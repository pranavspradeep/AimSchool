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
    public partial class DailytransactionReport : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        public DailytransactionReport()
        {
            InitializeComponent();
        }

        private void DailytransactionReport_Load(object sender, EventArgs e)
        {

            grid();
        }
        private void grid()
        {
            SchoolManagement.date = dtp1.Value.ToShortDateString();
            SchoolManagement.str = "select * from tbl_dailytrans where convert(varchar(10),Date,101) ='" + dtp1.Value.ToString("MM/dd/yyyy") + "'";
            SqlDataAdapter da = new SqlDataAdapter(SchoolManagement.str, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgv1.DataSource = ds.Tables[0];
                dgv1.Columns[0].Visible = false;
               
            }
            else
            {
                MessageBox.Show("No transaction avialable", "Message....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void getvar()
        {
            string str = "select TOP(1)SlNo,Balance from tbl_dailytrans where Date <'" + dtp1.Value + "' ORDER BY SlNo DESC";
            SqlDataAdapter da = new SqlDataAdapter(str, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                SchoolManagement.opngbalc = dr[1].ToString();
            }
            else
            {
                SchoolManagement.opngbalc = "00.00";
            }
            string str1 = "select TOP(1)SlNo,Balance from tbl_dailytrans where Date ='" + dtp1.Value + "' ORDER BY SlNo DESC";
            SqlDataAdapter da1 = new SqlDataAdapter(str1, d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataRow dr1;
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dr1 = ds1.Tables[0].Rows[0];
                SchoolManagement.clngbalc = dr1[1].ToString();
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            grid();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            grid();
            getvar();
            DailytransactionReportview dtr = new DailytransactionReportview();
            dtr.Show();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}