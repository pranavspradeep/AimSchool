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
    public partial class MarkSheetrpt : Form
    {
        DataLayer d = new DataLayer();
        public string examnum = string.Empty;
        public MarkSheetrpt()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
        
        }
        private void BindExam()
        {
            d.con_open();
            SqlCommand cmd1 = new SqlCommand("sel_exam", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd1.ExecuteReader();
            cmb_Exam.Items.Clear();
            while (rd.Read())
            {
                cmb_Exam.Items.Add(rd[0].ToString());
            }
            d.con_close();
        }       
        private void GetExamnumber()
        {
            string cm = "select examnum from tbl_exam where exam ='" + cmb_Exam.Text + "'";
            SqlDataAdapter ad = new SqlDataAdapter(cm, d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                examnum = dr[0].ToString();
                SchoolManagement.exmno = dr[0].ToString();

            }
        }     
        public Boolean valid()
        {
            Boolean b = true;
            if (cmb_Stdrd.Text == "" || cmb_Stdrd.Text == null)
            {
                b = false;
                MessageBox.Show("Select Standard!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_Divs.Text == "" || cmb_Divs.Text == null)
            {
                b = false;
                MessageBox.Show("Select Division!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return b;
        }
        private void txt_Student_TextChanged(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                lstbx_Students.Items.Clear();
                string s = "SELECT tbl_student.sname FROM tbl_stddivision INNER JOIN tbl_student ON tbl_stddivision.adno = tbl_student.adno where tbl_stddivision.cstandard='" + cmb_Stdrd.Text + "' And tbl_stddivision.division='" + cmb_Divs.Text + "' And tbl_student.sname Like '" + txt_Student.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataRow dr;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dr = ds.Tables[0].Rows[i];
                        lstbx_Students.Items.Add(dr[0].ToString());
                        
                    }
                    
                }
            }
        }

        private void MarkSheetrpt_Load(object sender, EventArgs e)
        {
            BindExam();
            cmb_Exam.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetExamnumber();
            if (lstbx_Students.SelectedItem.ToString() != "")
            {

                string s1 = "SELECT tbl_subject.subjectnum as [Subject No], tbl_subject.subject as Subject, tbl_ExamResult.Mark, tbl_ExamResult.Grade FROM tbl_subject INNER JOIN tbl_ExamResult ON tbl_subject.subjectnum = tbl_ExamResult.subno INNER JOIN tbl_student ON tbl_ExamResult.adno = tbl_student.adno where tbl_student.sname='" + lstbx_Students.SelectedItem.ToString() + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(s1, d.con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);              

                MarkSheet msr = new MarkSheet();
                msr.SetDataSource(ds1.Tables[0]);


                string s = "SELECT tbl_student.sname, tbl_stddivision.cstandard, tbl_stddivision.division, tbl_student.adno, tbl_exam.exam, tbl_subject.subject, tbl_ExamResult.Mark, ";
                s = s + "tbl_ExamResult.Grade, tbl_School.SchoolName, tbl_School.SchoolAddress, tbl_School.Phone FROM tbl_ExamResult INNER JOIN tbl_student ON tbl_ExamResult.adno = tbl_student.adno INNER JOIN";
                s = s + "  tbl_stddivision ON tbl_student.adno = tbl_stddivision.adno INNER JOIN tbl_exam ON tbl_ExamResult.ExamNo = tbl_exam.examnum INNER JOIN tbl_subject ON tbl_ExamResult.subno = tbl_subject.subjectnum CROSS JOIN tbl_School";
                s = s + " where tbl_ExamResult.ExamNo =" + examnum + " And tbl_stddivision.cstandard='" + cmb_Stdrd.Text + "' And tbl_stddivision.division='" + cmb_Divs.Text + "' And tbl_student.sname='" + lstbx_Students.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataRow dr;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                    msr.SetParameterValue("AdmissionNo", dr[3].ToString());
                    msr.SetParameterValue("StudentName", dr[0].ToString());
                    msr.SetParameterValue("Standard", dr[1].ToString());
                    msr.SetParameterValue("Division", dr[2].ToString());
                    msr.SetParameterValue("Exam", dr[4].ToString());
                    //msr.SetParameterValue("TotalMark", dr[3].ToString());
                    msr.SetParameterValue("SchoolName", dr[8].ToString());
                    msr.SetParameterValue("Addr", dr[9].ToString());
                    msr.SetParameterValue("DT", DateTime.Now.ToString());
                    msr.SetParameterValue("SchoolPhNo", dr[10].ToString());                    
                    crystalReportViewer1.ReportSource = msr;
                }       
            }
        }

        private void cmb_Stdrd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmb_Divs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txt_Student_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void lstbx_Students_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lstbx_Students.SelectedItem.ToString() != "")
            {
                if (e.KeyChar == (char)13)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
            else
            {
                MessageBox.Show("Select Student from the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_Student_Enter(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                lstbx_Students.Items.Clear();
                string s = "SELECT tbl_student.sname FROM tbl_stddivision INNER JOIN tbl_student ON tbl_stddivision.adno = tbl_student.adno where tbl_stddivision.cstandard='" + cmb_Stdrd.Text + "' And tbl_stddivision.division='" + cmb_Divs.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataRow dr;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dr = ds.Tables[0].Rows[i];
                        lstbx_Students.Items.Add(dr[0].ToString());

                    }

                }
            }
        }       
        
    }
}
