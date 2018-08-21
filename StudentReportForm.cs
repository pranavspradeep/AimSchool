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
    public partial class StudentReportForm : Form
    {
        DataLayer d = new DataLayer();
        public StudentReportForm()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            string s = "SELECT  s.sname, s.sfname, a.classno, a.cstandard, c.division, s.Newsyll, e.Grade, e.mark, sb.subject, em.exam FROM tbl_student AS s INNER JOIN tbl_attend AS a ON s.adno = a.adno INNER JOIN  tbl_class AS c ON a.classno = c.classno INNER JOIN tbl_ExamResult AS e ON c.classno = e.stdno INNER JOIN tbl_subject AS sb ON e.subno = sb.subjectnum INNER JOIN  tbl_exam AS em ON e.examno = em.examnum where a.adno=" + SchoolManagement.adno + "AND e.examno = " + SchoolManagement.exmno + " ";
                SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                DataRow dr;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dr = ds.Tables[0].Rows[0];
                    CrystalReportStudentReportForm crpf = new CrystalReportStudentReportForm();
                    crpf.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = crpf;
                    crystalReportViewer1.Refresh();

                }
            


        }
    }
}