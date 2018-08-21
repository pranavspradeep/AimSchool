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
    public partial class Gquestions : Form
    {
        DataLayer d = new DataLayer();
        string qno = "";
        string empno = "";
        public Gquestions()
        {
            InitializeComponent();
        }

        private void Gquestions_Load(object sender, EventArgs e)
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

            string s = "select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions ";
            SqlDataAdapter ad = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dgv_gquestions.DataSource = ds.Tables[0];
        }

        private void dgv_gquestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            qno = dgv_gquestions.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select qno as QustionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions where qno='" + qno + "' ", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                qno = dr[0].ToString();
                empno = dr[1].ToString();
                txtques.Text = dr[2].ToString();
                cmb_mark.Text = dr[3].ToString();
                cmbstd.Text = dr[4].ToString();
                cmbsyll.Text = dr[5].ToString();
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
                MessageBox.Show("Enter Question", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_mark.Text == "" || cmb_mark.Text == null)
            {
                MessageBox.Show("Enter Mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter Standad", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("upd_gquestions", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qno", qno);
                cmd.Parameters.AddWithValue("@question", txtques.Text);
                cmd.Parameters.AddWithValue("@mark", cmb_mark.Text);
                cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("@syllabus", cmbsyll.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question edited successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbstd.Text = "";
                cmbsyll.Text = "";
                cmb_mark.Text = "";
                txtques.Text = "";
                d.con_close();
                dgv_gquestions.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_gquestions.DataSource = ds.Tables[0];
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txtques.Text == "" || txtques.Text == null)
            {
                MessageBox.Show("Enter Question", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_mark.Text == "" || cmb_mark.Text == null)
            {
                MessageBox.Show("Enter Mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ( cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            else
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_gquestions", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", 0);
                cmd.Parameters.AddWithValue("@question", txtques.Text);
                cmd.Parameters.AddWithValue("@mark", cmb_mark.Text);
                cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("@syllabus", cmbsyll.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question added successfully", "Added..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbstd.Text = "";
                cmbsyll.Text = "";
                cmb_mark.Text = "";
                txtques.Text = "";
                d.con_close();
                
                // Display the added questions in datagridview 

                dgv_gquestions.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_gquestions.DataSource = ds.Tables[0];
            }
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbstd.Text = "";
            cmbsyll.Text = "";
            cmb_mark.Text = "";
            txtques.Text = "";
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
                // To delete the question

                d.con_open();

                SqlCommand cmd = new SqlCommand("Delete from tbl_gquestions where qno=" + qno, d.con);
                cmd.ExecuteNonQuery();

                //To refresh the datagridview
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_gquestions.DataSource = null;
                dgv_gquestions.DataSource = ds.Tables[0];

                d.con_close();

                cmbstd.Text = "";
                cmbsyll.Text = "";
                cmb_mark.Text = "";
                txtques.Text = "";
            }

        }
    }
}