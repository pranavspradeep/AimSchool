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
    public partial class ExamTypes : Form
    {
        DataLayer d = new DataLayer();
        string qno = "";
        string empno = "";
        string filno = "";
        string filempno = "";
        string opno = "";
        string opempno = "";
        public ExamTypes()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.ToString() == "1")
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

                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_fillblanks ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_fillblanks.DataSource = ds.Tables[0];
            }
            if (tabControl1.SelectedIndex.ToString() == "2")
            {

                // select syllabus from table syllabus

                d.con_open();
                SqlCommand cmd1 = new SqlCommand("sel_syllabus", d.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataReader r1 = cmd1.ExecuteReader();
                while (r1.Read())
                {
                    sylbs.Items.Add(r1[0].ToString());
                }
                d.con_close();

                // display the question details in datagridview

                string s = "select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions ";
                SqlDataAdapter ad = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_gquestions.DataSource = ds.Tables[0];
            }
        }

        private void ExamTypes_Load(object sender, EventArgs e)
        {
            // select syllabus from table syllabus

            d.con_open();
            SqlCommand cmd1 = new SqlCommand("sel_syllabus", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                syllabus.Items.Add(r1[0].ToString());

            }
            d.con_close();

            // display the question details in datagridview

            SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question Question,ans1 as Answer1,ans2 as Answer2,ans3 as answer3,ans4 as Answer4,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_optques ", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dgv_optional.DataSource = ds.Tables[0];

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (std.Text == "" || std.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (syllabus.Text == "" || syllabus.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (question.Text == "" || question.Text == null)
            {
                MessageBox.Show("Enter the question", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans1.Text == "" || txtans1.Text == null)
            {
                MessageBox.Show("Enter answer1", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans2.Text == "" || txtans2.Text == null)
            {
                MessageBox.Show("Enter answer2", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans3.Text == "" || txtans3.Text == null)
            {
                MessageBox.Show("Enter answer3", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans4.Text == "" || txtans4.Text == null)
            {
                MessageBox.Show("Enter answer4", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (mark.Text == "" || mark.Text == null)
            {
                MessageBox.Show("Enter the mark", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("ins_optques", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", 0);
                cmd.Parameters.AddWithValue("@question", question.Text);
                cmd.Parameters.AddWithValue("@ans1", txtans1.Text);
                cmd.Parameters.AddWithValue("@ans2", txtans2.Text);
                cmd.Parameters.AddWithValue("@ans3", txtans3.Text);
                cmd.Parameters.AddWithValue("@ans4", txtans4.Text);
                cmd.Parameters.AddWithValue("@mark", mark.Text);
                cmd.Parameters.AddWithValue("@cstandard", std.Text);
                cmd.Parameters.AddWithValue("@syllabus", syllabus.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question saved succesfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                std.Text = "";
                syllabus.Text = "";
                question.Text = "";
                txtans1.Text = "";
                txtans2.Text = "";
                txtans3.Text = "";
                txtans4.Text = "";
                mark.Text = "";
                d.con_close();
                dgv_optional.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,ans1 as Answer1,ans2 as Answer2,ans3 as Answer3,ans4 as Answer4,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_optques ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_optional.DataSource = ds.Tables[0];
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (question.Text == "" || question.Text == null)
            {
                MessageBox.Show("Enter the question", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans1.Text == "" || txtans1.Text == null)
            {
                MessageBox.Show("Enter answer1", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans2.Text == "" || txtans2.Text == null)
            {
                MessageBox.Show("Enter answer2", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans3.Text == "" || txtans3.Text == null)
            {
                MessageBox.Show("Enter answer3", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtans4.Text == "" || txtans4.Text == null)
            {
                MessageBox.Show("Enter answer4", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (mark.Text == "" || mark.Text == null)
            {
                MessageBox.Show("Enter mark", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("upd_optques", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qno", qno);
                cmd.Parameters.AddWithValue("@question", question.Text);
                cmd.Parameters.AddWithValue("@ans1", txtans1.Text);
                cmd.Parameters.AddWithValue("@ans2", txtans2.Text);
                cmd.Parameters.AddWithValue("@ans3", txtans3.Text);
                cmd.Parameters.AddWithValue("@ans4", txtans4.Text);
                cmd.Parameters.AddWithValue("@mark", mark.Text);
                cmd.Parameters.AddWithValue("@cstandard", std.Text);
                cmd.Parameters.AddWithValue("@syllabus", syllabus.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question edited succesfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                std.Text = "";
                syllabus.Text = "";
                question.Text = "";
                txtans1.Text = "";
                txtans2.Text = "";
                txtans3.Text = "";
                txtans4.Text = "";
                mark.Text = "";

                d.con_close();

                dgv_optional.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question Question,ans1 as Answer1,ans2 as Answer2,ans3 as answer3,ans4 as Answer4,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_optques", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_optional.DataSource = ds.Tables[0];


            }

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
               
                question.Text = dr[2].ToString();
                txtans1.Text = dr[3].ToString();
                txtans2.Text = dr[4].ToString();
                txtans3.Text = dr[5].ToString();
                txtans4.Text = dr[6].ToString();
                mark.Text = dr[7].ToString();
                std.Text = dr[8].ToString();
                syllabus.Text = dr[9].ToString();
            }
            else
            {
                MessageBox.Show("Data does not exist", "warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            std.Text = "";
            syllabus.Text = "";
            question.Text = "";
            txtans1.Text = "";
            txtans2.Text = "";
            txtans3.Text = "";
            txtans4.Text = "";
            mark.Text = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure  you want to delete this question", "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                std.Text = "";
                syllabus.Text = "";
                question.Text = "";
                txtans1.Text = "";
                txtans2.Text = "";
                txtans3.Text = "";
                txtans4.Text = "";
                mark.Text = "";

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Select standard", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Select syllabus", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtques.Text == "" || txtques.Text == null)
            {
                MessageBox.Show("Enter Question", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_mark.Text == "" || cmb_mark.Text == null)
            {
                MessageBox.Show("Enter Mark", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Question Saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (txtques.Text == "" || txtques.Text == null)
            {
                MessageBox.Show("Enter question", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_mark.Text == "" || cmb_mark.Text == null)
            {
                MessageBox.Show("Enter Mark", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {

                d.con_open();

                SqlCommand cmd = new SqlCommand("upd_fillblanks", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qno", filno);
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
            filno = dgv_fillblanks.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select qno,empno,question,mark,cstandard,syllabus from tbl_fillblanks where qno='" + filno + "' ", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                filno = dr[0].ToString();
                filempno = dr[1].ToString();
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            cmbstd.Text = "";
            cmbsyll.Text = "";
            cmb_mark.Text = "";
            txtques.Text = "";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure  you want to delete this question", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("Delete from tbl_fillblanks where qno=" + filno, d.con);
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (standard.Text == "" || standard.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (sylbs.Text == "" || sylbs.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (qustn.Text == "" || qustn.Text == null)
            {
                MessageBox.Show("Enter Question", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (qutnmrk.Text == "" || qutnmrk.Text == null)
            {
                MessageBox.Show("Enter Mark", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_gquestions", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", 0);
                cmd.Parameters.AddWithValue("@question", qustn.Text);
                cmd.Parameters.AddWithValue("@mark", qutnmrk.Text);
                cmd.Parameters.AddWithValue("@cstandard", standard.Text);
                cmd.Parameters.AddWithValue("@syllabus", sylbs.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                standard.Text = "";
                sylbs.Text = "";
                qutnmrk.Text = "";
                qustn.Text = "";               
                               
                d.con_close();

                // Display the added questions in datagridview 

                dgv_gquestions.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_gquestions.DataSource = ds.Tables[0];
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (standard.Text == "" || standard.Text == null)
            {
                MessageBox.Show("Enter Standad", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (sylbs.Text == "" || sylbs.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (qustn.Text == "" || qustn.Text == null)
            {
                MessageBox.Show("Enter Question", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (qutnmrk.Text == "" || qutnmrk.Text == null)
            {
                MessageBox.Show("Enter Mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("upd_gquestions", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qno", opno);
                cmd.Parameters.AddWithValue("@question", qustn.Text);
                cmd.Parameters.AddWithValue("@mark", qutnmrk.Text);
                cmd.Parameters.AddWithValue("@cstandard", standard.Text);
                cmd.Parameters.AddWithValue("@syllabus", sylbs.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Question edited successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                standard.Text = "";
                sylbs.Text = "";
                qutnmrk.Text = "";
                qustn.Text = "";
                d.con_close();

                dgv_gquestions.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_gquestions.DataSource = ds.Tables[0];
            }
        }

        private void dgv_gquestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            opno = dgv_gquestions.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select qno as QustionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions where qno='" + opno + "' ", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                opno = dr[0].ToString();
                opempno = dr[1].ToString();
                qustn.Text = dr[2].ToString();
                qutnmrk.Text = dr[3].ToString();
                standard.Text = dr[4].ToString();
                sylbs.Text = dr[5].ToString();
            }
            else
            {
                MessageBox.Show("Data does not exist", "warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            standard.Text = "";
            sylbs.Text = "";
            qustn.Text = "";
            qutnmrk.Text = "";
            
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure  you want to delete this question", "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                // To delete the question

                d.con_open();

                SqlCommand cmd = new SqlCommand("Delete from tbl_gquestions where qno=" + opno, d.con);
                cmd.ExecuteNonQuery();

                //To refresh the datagridview
                SqlDataAdapter ad = new SqlDataAdapter("select qno as QuestionNumber,empno as EmployNumber,question as Question,mark as Mark,cstandard as Standard,syllabus as Syllabus from tbl_gquestions ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_gquestions.DataSource = null;
                dgv_gquestions.DataSource = ds.Tables[0];

                d.con_close();

                standard.Text = "";
                sylbs.Text = "";
                qustn.Text = "";
                qutnmrk.Text = "";
            }
        }
    }
}