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
    public partial class CristelReportstudent : Form
    {
        DataLayer d = new DataLayer();
        public CristelReportstudent()
        {
            InitializeComponent();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select s.adno AS [Admission No],s.sname AS [Student Name],s.Newsyll AS Syllabus,d.cstandard AS Standard,d.Division from tbl_class c INNER JOIN tbl_stddivision d ON c.classno=d.classno INNER JOIN tbl_student s ON d.adno=s.adno ", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                crpReport crs = new crpReport();
                crs.SetDataSource(ds.Tables[0]);
                crpviewer1.ReportSource = crs;
                crpviewer1.Refresh();

            }
        }
    }
}