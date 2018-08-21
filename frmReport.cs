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
    public partial class frmReport : Form
    {
        DataLayer d = new DataLayer();
        public frmReport()
        {
            InitializeComponent();
        }

        private void btn_RPT_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select sub.subjectnum AS [Subject No],s.Newsyll AS Syllabus,c.cstandard AS Standard,c.division AS Division,sub.subject AS Subject from tbl_class c INNER JOIN tbl_syllabus s ON c.syllabusnum=s.syllabusnum INNER JOIN tbl_syllabusinstandard ss ON s.syllabusnum=ss.syllabusnum INNER JOIN tbl_subject sub ON ss.subjectnum=sub.subjectnum", d.con);
            DataSet ds = new DataSet();
            DataRow dr;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                crpReport crp = new crpReport();
                crp.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = crp;
                crystalReportViewer1.Refresh();

            }

            //sub.subjectnum AS [Subject No],s.Newsyll AS Syllabus,c.cstandard AS Standard,c.division AS Division,sub.subject AS Subject from tbl_class c INNER JOIN tbl_syllabus s ON c.syllabusnum=s.syllabusnum INNER JOIN tbl_syllabusinstandard ss ON s.syllabusnum=ss.syllabusnum INNER JOIN tbl_subject sub ON ss.subjectnum=sub.subjectnum
        }
    }
}