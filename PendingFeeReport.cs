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
    public partial class PendingFeeReport : Form
    {
        DataLayer d = new DataLayer();
        public PendingFeeReport()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int CurMt = Convert.ToInt32(Convert.ToDateTime(dateTimePicker1.Text).ToString("mm"));

            d.con_open();
            SqlCommand cmd = new SqlCommand("Select_PendingFee", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mnt", CurMt);
            IDataReader dr=cmd.ExecuteReader();
            //SqlDataReader dr = cmd.ExecuteReader();

            PendingFees pf = new PendingFees();
            pf.SetDataSource(dr);

            crystalReportViewer1.ReportSource = pf;

            d.con_close();


        }

        private void PendingFeeReport_Load(object sender, EventArgs e)
        {

        }
    }
}
