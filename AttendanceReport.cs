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
    public partial class AttendanceReport : Form
    {
        DataLayer d = new DataLayer();
        public AttendanceReport()
        {
            InitializeComponent();
        }
        public Boolean valid()
        {
            Boolean b = true;
            if (cmb_Standard.Text == null || cmb_Standard.Text == "")
            {
                b = false;
                MessageBox.Show("Select Standard!", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Standard.Focus();
            }
            else if (cmb_Division.Text == null || cmb_Division.Text == "")
            {
                b = false;
                MessageBox.Show("Select Division!", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Division.Focus();
            }
            return b;
        }
        private void txt_Student_TextChanged(object sender, EventArgs e)
        {
              try
                {
                    dgv_Studlist.DataSource = null;
                    String s = "SELECT tbl_student.adno as [Admn No], tbl_student.sname as Name, tbl_stddivision.cstandard as Standard, tbl_stddivision.division as Division FROM tbl_stddivision INNER JOIN tbl_student ON tbl_stddivision.adno = tbl_student.adno where tbl_stddivision.cstandard='" + cmb_Standard.Text + "' And tbl_stddivision.division='" + cmb_Division.Text + "' And tbl_student.sname LIKE '" + txt_Student.Text + "%'";
                    SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgv_Studlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgv_Studlist.AutoResizeColumns();
                        dgv_Studlist.DataSource = ds.Tables[0];
                    }
                }
                catch { }            
        }

        private void dgv_Studlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SchoolManagement.admno = dgv_Studlist.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void btn_studwise_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            pnl_mode.Visible = false;
            pnl_studdetails.Visible = true;
        }

        private void btn_classwise_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox5.Visible = true;
            pnl_mode.Visible = false;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                if (SchoolManagement.admno != "")
                {
                    pnl_studdetails.Visible = false;
                    groupBox3.Visible = true;
                    groupBox4.Visible = true;
                }
                else
                {
                    MessageBox.Show("Select Student from the List!", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }                        
        }
        private void txt_Student_Enter(object sender, EventArgs e)
        {
            if (valid() == true)
            {                
            }
        }

        private void btn_ViewReport_Click(object sender, EventArgs e)
        {            
            SqlDataAdapter da1 = new SqlDataAdapter("Select cstandard, division from tbl_class where classteacherno=" + SchoolManagement.empno, d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataRow dr1;
            dr1 = ds1.Tables[0].Rows[0];

            String s = "SELECT tbl_attendance.adno AS AdmissionNo, tbl_attendance.rollno AS RollNo, tbl_student.sname AS Name, CASE WHEN tbl_attendance.status= 1 Then 'Present' else 'Absend' END as Status FROM tbl_student INNER JOIN tbl_attendance ON tbl_student.adno = tbl_attendance.adno INNER JOIN tbl_class ON tbl_attendance.classno = tbl_class.classno where Convert(Varchar(10),tbl_attendance.date,101)='" + Convert.ToDateTime(dtp_classwise.Value.ToString()).ToString("MM/dd/yyyy") + "' And tbl_class.cstandard='" + dr1[0].ToString() + "'And tbl_class.division='" + dr1[1].ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            AttendRptClasswise ar = new AttendRptClasswise();
            ar.SetDataSource(ds.Tables[0]);


            SqlDataAdapter da2 = new SqlDataAdapter("Select SchoolName,SchoolAddress,Phone from tbl_School", d.con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            DataRow dr2;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                dr2 = ds2.Tables[0].Rows[0];
                ar.SetParameterValue("Standard", dr1[0].ToString());
                ar.SetParameterValue("Division", dr1[1].ToString());
                ar.SetParameterValue("SchoolName", dr2[0].ToString());
                ar.SetParameterValue("Addr", dr2[1].ToString());
                ar.SetParameterValue("SchoolPhNo", dr2[2].ToString());
                ar.SetParameterValue("Date", dtp_classwise.Value.ToString());
                crystalReportViewer1.ReportSource = ar;
            }
        }
    }
}
