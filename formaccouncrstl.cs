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
    public partial class formaccouncrstl : Form
    {
        DataLayer d = new DataLayer();
        public formaccouncrstl()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("select s.adno as [AdNo:],s.sname as [Name],st.cstandard as [Standard],st.division as [Division],'TutionFee' as [FeeType],tp.Amount from tbl_student s join tbl_stddivision st on s.adno=st.adno join tbl_tutionfeepayment tp on tp.adno=s.adno", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            CrystalReportAccountfee crp1 = new CrystalReportAccountfee();
            crp1.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = crp1;
            crystalReportViewer1.Refresh();

           /* string s = "Select s.";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            DataRow dr;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];

                CrystalReportAccountfee crp1 = new CrystalReportAccountfee();
                crp1.SetDataSource(ds.Tables[0]);                
                crp1.SetParameterValue("startdate", SchoolManagement.dtp1);
                crp1.SetParameterValue("enddate", SchoolManagement.dtp2);
                crystalReportViewer1.ReportSource = crp1;
                crystalReportViewer1.Refresh();

            }*/
        }
    }
}