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
    public partial class Fillblanks : Form
    {
        DataLayer d = new DataLayer();
        string qno = "";
        string empno = "";
        public Fillblanks()
        {
            InitializeComponent();
        }

        private void Fillblanks_Load(object sender, EventArgs e)
        {
            
            d.con_close();

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

            SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_fillblanks ", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dgv_fillblanks.DataSource = ds.Tables[0];
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
            else if (cmbstd.Text  == "" || cmbstd.Text  == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text  == "" || cmbsyll.Text  == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("ins_fillblanks", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", 0);
                cmd.Parameters.AddWithValue("@question", txtques.Text);
                cmd.Parameters.AddWithValue("@mark", cmb_mark.Text);
                cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("@syllabus", cmbsyll.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question Saved successfully","Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbstd.Text = "";
                cmbsyll.Text = "";
                cmb_mark.Text = "";
                txtques.Text = "";

                d.con_close();

                dgv_fillblanks.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_fillblanks ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_fillblanks.DataSource = ds.Tables[0];

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbstd.Text = "";
            cmbsyll.Text = "";
            cmb_mark.Text = "";
            txtques.Text = "";
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
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {

                d.con_open();

                SqlCommand cmd = new SqlCommand("upd_fillblanks", d.con);
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

                dgv_fillblanks.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno,empno,question,mark,cstandard,syllabus from tbl_fillblanks ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_fillblanks.DataSource = ds.Tables[0];
            }
        }

        private void dgv_fillblanks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            qno = dgv_fillblanks.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select qno,empno,question,mark,cstandard,syllabus from tbl_fillblanks where qno='"+qno+"' ", d.con);
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
                SqlCommand cmd = new SqlCommand("Delete from tbl_fillblanks where qno=" + qno , d.con);
                cmd.ExecuteNonQuery();

                //To refresh grid
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_fillblanks ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_fillblanks.DataSource = null;
                dgv_fillblanks.DataSource = ds.Tables[0];


                cmbstd.Text = "";
                cmbsyll.Text = "";
                cmb_mark.Text = "";
                txtques.Text = "";


                d.con_close();

            }
        }

    }
}