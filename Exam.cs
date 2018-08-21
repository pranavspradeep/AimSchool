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
    public partial class Exam : DevComponents.DotNetBar.Office2007Form
    {
       
        DataLayer d = new DataLayer();
        DataSet ds = new DataSet();
        string subno = "";
        string exno = "";
        DataRow dr;
        
        int i;
        public Exam()
        {
            InitializeComponent();
        }

      
        private void btn_Add_Click(object sender, EventArgs e)
        {
         
            SqlDataAdapter ad2 = new SqlDataAdapter("select exam from tbl_exam where exam='" + txtexm.Text + "' AND cstandard='" + cmbstd.Text + "'", d.con);
            DataSet das2 = new DataSet();
            ad2.Fill(das2);
            if (das2.Tables[0].Rows.Count >=1)
            {
                MessageBox.Show("Exam already assigned ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("ins_exam", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@exam", txtexm.Text);
                cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                SqlParameter examno = new SqlParameter("@examno", SqlDbType.Int);
                examno.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(examno);
                cmd.ExecuteNonQuery();
                exno = examno.Value.ToString();

                SqlDataAdapter ad1 = new SqlDataAdapter("select max(examnum) from tbl_exam", d.con);
                DataSet ds1 = new DataSet();
                DataRow dr1;
                ad1.Fill(ds1);
                dr1 = ds1.Tables[0].Rows[0];
                exno = dr1[0].ToString();
                for (i = 0; i< ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    string sno = dr[0].ToString();
                    SqlCommand cmd1 = new SqlCommand("ins_subinexam", d.con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@examnum", exno);
                    cmd1.Parameters.AddWithValue("@subjectnum", sno);
                    cmd1.ExecuteNonQuery();
                }

                MessageBox.Show("Data saved successfully","Saved..",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cmbstd.Text = "";
                txtexm.Text = "";                
                d.con_close();
                grid_view();

               }
        }
        public void grid_view()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select examnum as [Exam No], exam as Exam,cstandard as Standard from tbl_exam ORDER BY examnum DESC", d.con);
            DataSet ds5 = new DataSet();
            da.Fill(ds5);
            dgv_subject.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_subject.AutoResizeColumns();
            dgv_subject.DataSource = ds5.Tables[0];
           
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtexm.Text = "";
            cmbstd.Text = "";
        }

       
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_subject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            subno = dgv_subject.Rows[e.RowIndex].Cells[0].Value.ToString();           
            
        }

        private void Button_remove_Click(object sender, EventArgs e)
        {

            //DialogResult r = MessageBox.Show("Are you sure you want to delete this record", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (r == DialogResult.Yes)
            //{
            //    d.con_open();
            //    SqlCommand cmd = new SqlCommand("Delete from tbl_subinexam where subjectnum=" + subno, d.con);
            //    cmd.ExecuteNonQuery();
            //    d.con_close();

            //}

        }       

        private void cmbstd_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dgv_subject.DataSource = null;
            ds.Clear();
            SqlDataAdapter ad = new SqlDataAdapter("select s.subjectnum as [Subject No] from tbl_subject s inner join tbl_syllabusinstandard sy on s.subjectnum=sy.subjectnum and sy.cstandard ='" + cmbstd.Text + "' ", d.con);
            ad.Fill(ds);

            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                dgv_subject.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_subject.DataSource = ds.Tables[0];

            }
          

        }

        private void Exam_Load(object sender, EventArgs e)
        {
            grid_view();
        }
    }
}