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
    public partial class matchcase : Form
    {
        DataLayer d = new DataLayer();
        string qno = "";
        string empno = "";
        public matchcase()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            
            if (txtfield1.Text == "" || txtfield1.Text == null)
            {
               MessageBox.Show("Enter field1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtfield2.Text == "" || txtfield2.Text == null)
            {
               MessageBox.Show("Enter field2", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbmark.Text == "" || cmbmark.Text == null)
            {
               MessageBox.Show("Enter mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text  == null)
            {
                MessageBox.Show("Enter syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("ins_matchcase", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", 0);
                cmd.Parameters.AddWithValue("@field1", txtfield1.Text);
                cmd.Parameters.AddWithValue("@field2", txtfield2.Text);
                cmd.Parameters.AddWithValue("@mark", cmbmark.Text);
                cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("@syllabus", cmbsyll.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question Saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbstd.Text = "";
                cmbsyll.Text = "";
                cmbmark.Text = "";
                txtfield1.Text = "";
                txtfield2.Text = "";

                d.con_close();

                dgv_matchcase.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,field1 as Field1,field2 as Field2,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_matchcase ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_matchcase.DataSource = ds.Tables[0];
            }
        }

        private void matchcase_Load(object sender, EventArgs e)
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

            SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,field1 as Field1,field2 as Field2,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_matchcase ", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dgv_matchcase.DataSource = ds.Tables[0];

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbstd.Text = "";
            cmbsyll.Text = "";
            cmbmark.Text = "";
            txtfield1.Text = "";
            txtfield2.Text = "";
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            
            if (txtfield1.Text == "" || txtfield1.Text == null)
            {
                MessageBox.Show("Enter field1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtfield2.Text == "" || txtfield2.Text == null)
            {
                MessageBox.Show("Enter field2", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbmark.Text == "" || cmbmark.Text == null)
            {
                MessageBox.Show("Enter mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                d.con_open();

                SqlCommand cmd = new SqlCommand("upd_matchcase", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qno", qno);
                cmd.Parameters.AddWithValue("@field1", txtfield1.Text);
                cmd.Parameters.AddWithValue("@field2", txtfield2.Text);
                cmd.Parameters.AddWithValue("@mark", cmbmark.Text);
                cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("@syllabus", cmbsyll.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question edited successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbstd.Text = "";
                cmbsyll.Text = "";
                cmbmark.Text = "";
                txtfield1.Text = "";
                txtfield2.Text = "";
                d.con_close();
                dgv_matchcase.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,field1 as Field1,field2 as Field2,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_matchcase", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_matchcase.DataSource = ds.Tables[0];
            }
        }

        private void dgv_matchcase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            qno = dgv_matchcase.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,field1 as Field1,field2 as Field2,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_matchcase where qno='" + qno + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                qno = dr[0].ToString();
                empno = dr[1].ToString();
                txtfield1.Text = dr[2].ToString();
                txtfield2.Text = dr[3].ToString();
                cmbmark.Text = dr[4].ToString();
                cmbstd.Text = dr[5].ToString();
                cmbsyll.Text = dr[6].ToString();
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
                // To delete the question

                d.con_open();

                SqlCommand cmd = new SqlCommand("Delete from tbl_matchcase where qno=" + qno, d.con);
                cmd.ExecuteNonQuery();

                //To refresh the datagridview
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,field1 as Field1,field2 as Field2,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_matchcase ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_matchcase.DataSource = null;
                dgv_matchcase.DataSource = ds.Tables[0];

                d.con_close();
                cmbstd.Text = "";
                cmbsyll.Text = "";
                cmbmark.Text = "";
                txtfield1.Text = "";
                txtfield2.Text = "";

            }

        }
    }
}