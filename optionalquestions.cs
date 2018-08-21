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
    public partial class optionalquestions : Form
    {
        DataLayer d = new DataLayer();
        string qno = "";
        string empno = "";
        public optionalquestions()
        {
            InitializeComponent();
        }
        private void optionalquestions_Load(object sender, EventArgs e)
        {
            
            // select syllabus from table syllabus

            d.con_open();
            SqlCommand cmd1 = new SqlCommand("sel_syllabus", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                cmbsyll.Items.Add(r1[0].ToString());
            }
            d.con_close();

            // display the question details in datagridview

            SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question Question,ans1 as Answer1,ans2 as Answer2,ans3 as answer3,ans4 as Answer4,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_optques ",d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dgv_optional.DataSource = ds.Tables[0];
        }
   
        
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtques.Text == "" || txtques.Text == null)
            {
               MessageBox.Show("Enter the question", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans1.Text == "" || txtans1.Text == null)
            {
                MessageBox.Show("Enter answer1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans2.Text == "" || txtans2.Text == null)
            {
                MessageBox.Show("Enter answer2", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans3.Text == "" || txtans3.Text == null)
            {
                MessageBox.Show("Enter answer3", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans4.Text == "" || txtans4.Text == null) 
            {
                MessageBox.Show("Enter answer4", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_mark.Text == "" || cmb_mark.Text == null)
            {
                MessageBox.Show("Enter the mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("ins_optques", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", 0);
                cmd.Parameters.AddWithValue("@question", txtques.Text);
                cmd.Parameters.AddWithValue("@ans1", txtans1.Text);
                cmd.Parameters.AddWithValue("@ans2", txtans2.Text);
                cmd.Parameters.AddWithValue("@ans3", txtans3.Text);
                cmd.Parameters.AddWithValue("@ans4", txtans4.Text);
                cmd.Parameters.AddWithValue("@mark", cmb_mark.Text);
                cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("@syllabus", cmbsyll.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question saved succesfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbstd.Text = "";
                cmbsyll.Text = "";
                txtques.Text = "";
                txtans1.Text = "";
                txtans2.Text = "";
                txtans3.Text = "";
                txtans4.Text = "";
                cmb_mark.Text = "";
                d.con_close();
                dgv_optional.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,ans1 as Answer1,ans2 as Answer2,ans3 as Answer3,ans4 as Answer4,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_optques ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_optional.DataSource = ds.Tables[0];
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbstd.Text = "";
            cmbsyll.Text = "";
            txtques.Text = "";
            txtans1.Text = "";
            txtans2.Text = "";
            txtans3.Text = "";
            txtans4.Text = "";
            cmb_mark.Text = "";
        }

        private void dgv_optional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            qno = dgv_optional.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,ans1 as Answer1,ans2 as Answer2,ans3 as Answer3,ans4 as Answer4,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_optques where qno='" + qno + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                qno = dr[0].ToString();
                empno = dr[1].ToString();
                txtques.Text = dr[2].ToString();
                txtans1.Text = dr[3].ToString();
                txtans2.Text = dr[4].ToString();
                txtans3.Text = dr[5].ToString();
                txtans4.Text = dr[6].ToString();
                cmb_mark.Text = dr[7].ToString();
                cmbstd.Text = dr[8].ToString();
                cmbsyll.Text = dr[9].ToString();
            }
            else
            {
                MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }        

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (txtques.Text == "" || txtques.Text == null)
            {
                MessageBox.Show("Enter the question", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans1.Text == "" || txtans1.Text == null)
            {
                MessageBox.Show("Enter answer1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans2.Text == "" || txtans2.Text == null)
            {
                MessageBox.Show("Enter answer2", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans3.Text == "" || txtans3.Text == null)
            {
                MessageBox.Show("Enter answer3", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans4.Text == "" || txtans4.Text == null)
            {
                MessageBox.Show("Enter answer4", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_mark.Text == "" || cmb_mark.Text == null)
            {
                MessageBox.Show("Enter mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("upd_optques", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qno", qno);
                cmd.Parameters.AddWithValue("@question", txtques.Text);
                cmd.Parameters.AddWithValue("@ans1", txtans1.Text);
                cmd.Parameters.AddWithValue("@ans2", txtans2.Text);
                cmd.Parameters.AddWithValue("@ans3", txtans3.Text);
                cmd.Parameters.AddWithValue("@ans4", txtans4.Text);
                cmd.Parameters.AddWithValue("@mark", cmb_mark.Text);
                cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("@syllabus", cmbsyll.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question edited succesfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbstd.Text = "";
                cmbsyll.Text = "";
                txtques.Text = "";
                txtans1.Text = "";
                txtans2.Text = "";
                txtans3.Text = "";
                txtans4.Text = "";
                cmb_mark.Text = "";

                d.con_close();

                dgv_optional.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question Question,ans1 as Answer1,ans2 as Answer2,ans3 as answer3,ans4 as Answer4,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_optques", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_optional.DataSource = ds.Tables[0];


            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure  you want to delete this question", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("Delete from tbl_optques where qno=" + qno, d.con);
                cmd.ExecuteNonQuery();

                // to display the remaining details in gridview 

                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question Question,ans1 as Answer1,ans2 as Answer2,ans3 as answer3,ans4 as Answer4,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_optques ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_optional.DataSource = ds.Tables[0];

                d.con_close();

                cmbstd.Text = "";
                cmbsyll.Text = "";
                txtques.Text = "";
                txtans1.Text = "";
                txtans2.Text = "";
                txtans3.Text = "";
                txtans4.Text = "";
                cmb_mark.Text = "";

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
    }
}