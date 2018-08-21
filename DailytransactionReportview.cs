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
    public partial class DailytransactionReportview : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        public DailytransactionReportview()
        {
            InitializeComponent();
        }

        private void DailytransactionReportview_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(SchoolManagement.str, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {

                dr = ds.Tables[0].Rows[0];
                CrystalReportDailytrans frp = new CrystalReportDailytrans();
                frp.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = frp;
                frp.SetParameterValue("Opening", SchoolManagement.opngbalc);
                frp.SetParameterValue("Closing", SchoolManagement.clngbalc);
                frp.SetParameterValue("date", SchoolManagement.date);
                crystalReportViewer1.Refresh();
            }
        }
    }
}