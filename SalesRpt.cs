using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SchoolManagement
{
    public partial class SalesRpt : Form
    {
        DataLayer d = new DataLayer();
        public SalesRpt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Select sm.BillNo,sm.admno,st.sname,st.cstandard as [Standard],sm.Discount,sm.Amount as [BillAmount],sm.CurrDate from tbl_SalesMaster sm inner join tbl_student st on sm.admno=st.adno  where sm.currDate between'" + Convert.ToDateTime(dateTimePicker1.Value.ToString()).ToString("yyyy-MMM-dd") + "'  and '" + Convert.ToDateTime(dateTimePicker2.Value.ToString()).ToString("yyyy-MMM-dd") + "' GROUP BY sm.BillNo,sm.admno,st.sname,st.cstandard,sm.Discount,sm.Amount,sm.CurrDate order by sm.BillNo";
            SqlDataAdapter da = new SqlDataAdapter(sql, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            double tt = 0;
            DataRow dr;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                tt = Convert.ToDouble(dr[5].ToString()) + tt;
            }
            SalesReport sr = new SalesReport();
            
            sr.SetDataSource(ds.Tables[0]);
            sr.SetParameterValue("FrmMnth", Convert.ToString(Convert.ToDateTime(dateTimePicker1.Value.ToString()).ToString("yyyy-MMM-dd")));
            sr.SetParameterValue("ToMnth", Convert.ToString(Convert.ToDateTime(dateTimePicker2.Value.ToString()).ToString("yyyy-MMM-dd")));
            sr.SetParameterValue("TT", tt.ToString());
            crystalReportViewer1.ReportSource = sr;


        }
    }
}
