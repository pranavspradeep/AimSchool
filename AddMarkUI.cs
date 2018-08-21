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
    
    public partial class AddMarkUI : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();        
        public string admissionno = string.Empty;
        public string examnum = string.Empty;
        public string subno = string.Empty;
       
       
        string std = "";
        public AddMarkUI()
        {
            InitializeComponent();                   
        }
           
        private void AddMarkUI_Load(object sender, EventArgs e)
        {
            getclassdetails();
            getStudentDetails();
            BindCombo();
            dgvClassDetaits.ClearSelection();
            dgvStddetails.ClearSelection();
        }   

        private void getclassdetails()
        {
            string s = "SELECT tbl_subject.subject as Subject, tbl_subforclass.Standard, tbl_subforclass.Syllabus FROM tbl_subforclass INNER JOIN tbl_subject ON tbl_subforclass.SubjectNo = tbl_subject.subjectnum INNER JOIN tbl_class ON tbl_subforclass.Standard = tbl_class.cstandard where tbl_class.classteacherno='" + SchoolManagement.empno + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgvClassDetaits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvClassDetaits.AutoResizeColumns();
                dgvClassDetaits.DataSource = ds.Tables[0];
            }
        }
        private void getStudentDetails()
        {
            string s = "SELECT tbl_student.adno, tbl_student.sname, tbl_class.cstandard, tbl_class.division, tbl_class.classno, tbl_student.Newsyll FROM tbl_student INNER JOIN tbl_stddivision ON tbl_student.adno = tbl_stddivision.adno INNER JOIN tbl_class ON tbl_stddivision.cstandard = tbl_class.cstandard WHERE tbl_class.classteacherno ='" + SchoolManagement.empno + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgvStddetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStddetails.AutoResizeColumns();
                dgvStddetails.DataSource = ds.Tables[0];
            }
        }
        private void BindCombo()
        {
            d.con_open();
            SqlCommand cmd1 = new SqlCommand("sel_exam", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd1.ExecuteReader();
            comboBox1.Items.Clear();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd[0].ToString());
            }
            d.con_close();
        }       
        private void GetExamnumber()
        {
            string cm = "select examnum from tbl_exam where exam ='" + comboBox1.Text + "'";
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
        private void dgvClassDetaits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select subjectnum from tbl_subject where subject ='" + dgvClassDetaits.Rows[e.RowIndex].Cells[0].Value.ToString() + "'",d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            dr = ds.Tables[0].Rows[0];
            subno = dr[0].ToString();
           //if (subno == "" || subno == null)
           //{
           //    MessageBox.Show("Not posible");
           //}
            
        }

        private void dgvStddetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            admissionno = dgvStddetails.Rows[e.RowIndex].Cells[0].Value.ToString();
            std = dgvStddetails.Rows[e.RowIndex].Cells[2].Value.ToString();
            SchoolManagement.adno = dgvStddetails.Rows[e.RowIndex].Cells[0].Value.ToString();

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string g = "";
            if (subno == "" || subno == null)
            {
                MessageBox.Show("Please select your class", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (admissionno == "" || admissionno == null)
            {
                MessageBox.Show("Please select your student", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox1.Text == "" || comboBox1.Text == null)
            {
                MessageBox.Show("Please select your exam", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtmark.Text == "" || txtmark.Text == null)
            {
                MessageBox.Show("Enter your mark", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string s = "Select grade from tbl_gradesetting where (Minmark <=" + txtmark.Text + ") AND(Maxmark >=" + txtmark.Text + ") AND Standard='" + std + "'";            
                SqlDataAdapter da = new SqlDataAdapter(s,d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataRow dr;
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dr = ds.Tables[0].Rows[0];
                    g = dr[0].ToString();
                }
        
                
            
                GetExamnumber();
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_ExamResult", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@examno", examnum));
                cmd.Parameters.Add(new SqlParameter("@stdno", admissionno));
                cmd.Parameters.Add(new SqlParameter("@subno", subno));
                cmd.Parameters.Add(new SqlParameter("@mark", txtmark.Text));                         
                cmd.Parameters.Add(new SqlParameter("@grade",g));
                cmd.ExecuteNonQuery();
                d.con_close();
                txtmark.Text = "";
                MessageBox.Show("Mark saved sucessfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
      
       
        private void btnViewRpt_Click(object sender, EventArgs e)
        {

            if (SchoolManagement.adno == " " || SchoolManagement.adno == null)
            {
                MessageBox.Show("Please Select Your Student");
            }
                
            else if (comboBox1.Text =="" || comboBox1.Text == null)
            {
                MessageBox.Show("Plase select Exam");
            }
            else
            {

                GetExamnumber();
                StudentReportForm srf = new StudentReportForm();
                srf.Show();
            }

        }

        
      }
}