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
    public partial class Assignteachertoclass : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        string Empno = "";
        string subno = "";
        string clasno = "";
        string Empnum = "";
        string subjctnum = "";
        string std = "";
        string div = "";
        string clsno = "";

        public Assignteachertoclass()
        {
            InitializeComponent();
        }

        private void Assignteachertoclass_Load(object sender, EventArgs e)
        {
            // to select teacher from table 

            d.con_open();
            SqlCommand cmd = new SqlCommand("se_teach", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sr = cmd.ExecuteReader();
            cmbteach.Items.Clear();
            while (sr.Read())
            {
                cmbteach.Items.Add(sr[0].ToString());

            }
            d.con_close();

            // to select subject from table

            d.con_open();
            SqlCommand cmd1 = new SqlCommand("sel_sub", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader sr1 = cmd1.ExecuteReader();
            cmbsub.Items.Clear();
            while (sr1.Read())
            {
                cmbsub.Items.Add(sr1[0].ToString());

            }
            d.con_close();

            SqlDataAdapter ad3 = new SqlDataAdapter("SELECT t.EmpName AS Teacher, s.subject AS Subject, c.cstandard AS Standard, c.division AS Division FROM teacherdet AS t INNER JOIN tbl_assignteach AS a ON t.Empno = a.classteacherno INNER JOIN tbl_subject AS s ON a.subjectnum = s.subjectnum INNER JOIN tbl_class AS c ON a.classno = c.classno", d.con);
            DataSet ds3 = new DataSet();
            ad3.Fill(ds3);
            if (ds3.Tables[0].Rows.Count >= 1)
            {
                dgv_view.DataSource = ds3.Tables[0];
            }

        }

        private void cmbstd_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlDataAdapter ad = new SqlDataAdapter("select division from tbl_class where cstandard='" + cmbstd.Text + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            cmbdiv.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                cmbdiv.Items.Add(dr[0].ToString());

            }

        }

        private void btn_Assign_Click(object sender, EventArgs e)
        {

            // to select employ num from table 

            SqlDataAdapter ad = new SqlDataAdapter("select Empno from teacherdet where EmpName='" + cmbteach.Text + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                Empno = dr[0].ToString();
            }

            // to select subject num from table

            SqlDataAdapter ad1 = new SqlDataAdapter("select subjectnum from tbl_subject where subject='" + cmbsub.Text + "'", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            DataRow dr1;
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr1 = ds1.Tables[0].Rows[0];
                subno = dr1[0].ToString();
            }

            // to select class num from table

            SqlDataAdapter ad2 = new SqlDataAdapter("select classno from tbl_class where cstandard='" + cmbstd.Text + "' and division='" + cmbdiv.Text + "'", d.con);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2);
            DataRow dr2;
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                dr2 = ds2.Tables[0].Rows[0];
                clasno = dr2[0].ToString();
            }

            SqlDataAdapter ad4 = new SqlDataAdapter("select classteacherno,subjectnum,classno from tbl_assignteach where classteacherno='" + Empno + "'and subjectnum='" + subno + "' and classno='" + clasno + "'", d.con);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4);
            if (ds4.Tables[0].Rows.Count >= 1)
            {
                MessageBox.Show("Data already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {

                SqlDataAdapter ad5 = new SqlDataAdapter("select classno,subjectnum from tbl_assignteach where classno='" + clasno + "'and subjectnum='" + subno + "'", d.con);
                DataSet ds5 = new DataSet();
                ad5.Fill(ds5);
                if (ds5.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("Subject and standard already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    // to add the details in table

                    d.con_open();
                    SqlCommand cmd = new SqlCommand("ins_assignteacher", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@classteacherno", Empno);
                    cmd.Parameters.AddWithValue("@subjectnum", subno);
                    cmd.Parameters.AddWithValue("@classno", clasno);
                    MessageBox.Show("Teacher assigned successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmd.ExecuteNonQuery();

                    d.con_close();

                    cmbdiv.Text = "";
                    cmbstd.Text = "";
                    cmbteach.Text = "";
                    cmbsub.Text = "";


                    // to display added details in grid

                    string s = "SELECT t.EmpName AS Teacher, s.subject AS Subject, c.cstandard AS Standard, c.division AS Division FROM teacherdet AS t INNER JOIN tbl_assignteach AS a ON t.Empno = a.classteacherno INNER JOIN tbl_subject AS s ON a.subjectnum = s.subjectnum INNER JOIN tbl_class AS c ON a.classno = c.classno";
                    SqlDataAdapter ad3 = new SqlDataAdapter(s, d.con);
                    DataSet ds3 = new DataSet();
                    ad3.Fill(ds3);
                    if (ds3.Tables[0].Rows.Count >= 1)
                    {
                        dgv_view.DataSource = ds3.Tables[0];
                    }

                }

            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            // to select employ num from table 

            SqlDataAdapter ad = new SqlDataAdapter("select Empno from teacherdet where EmpName='" + cmbteach.Text + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                Empno = dr[0].ToString();
            }

            // to select subject num from table

            SqlDataAdapter ad1 = new SqlDataAdapter("select subjectnum from tbl_subject where subject='" + cmbsub.Text + "'", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            DataRow dr1;
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr1 = ds1.Tables[0].Rows[0];
                subno = dr1[0].ToString();
            }

            // to select class num from table

            SqlDataAdapter ad2 = new SqlDataAdapter("select classno from tbl_class where cstandard='" + cmbstd.Text + "' and division='" + cmbdiv.Text + "'", d.con);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2);
            DataRow dr2;
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                dr2 = ds2.Tables[0].Rows[0];
                clasno = dr2[0].ToString();
            }

            SqlDataAdapter ad4 = new SqlDataAdapter("select classteacherno,subjectnum,classno from tbl_assignteach where classteacherno='" + Empno + "'and subjectnum='" + subno + "' and classno='" + clasno + "'", d.con);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4);
            if (ds4.Tables[0].Rows.Count >= 1)
            {
                MessageBox.Show("Data already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                d.con_open();
                SqlCommand cmd1 = new SqlCommand("upd_assignteacher", d.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@classteacherno", Empno);
                cmd1.Parameters.AddWithValue("@subjectnum", subno);
                cmd1.Parameters.AddWithValue("@classno", clasno);
                cmd1.Parameters.AddWithValue("@Empnum", Empnum);
                cmd1.Parameters.AddWithValue("@subjctnum", subjctnum);
                cmd1.Parameters.AddWithValue("@clsno", clsno);
                MessageBox.Show("Teacher edited successfully", "Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd1.ExecuteNonQuery();
                d.con_close();

                cmbdiv.Text = "";
                cmbstd.Text = "";
                cmbteach.Text = "";
                cmbsub.Text = "";


                //to display the edited details in grid

                SqlDataAdapter ad3 = new SqlDataAdapter("SELECT t.EmpName AS Teacher, s.subject AS Subject, c.cstandard AS Standard, c.division AS Division FROM teacherdet AS t INNER JOIN tbl_assignteach AS a ON t.Empno = a.classteacherno INNER JOIN tbl_subject AS s ON a.subjectnum = s.subjectnum INNER JOIN tbl_class AS c ON a.classno = c.classno", d.con);
                DataSet ds3 = new DataSet();
                ad3.Fill(ds3);
                if (ds3.Tables[0].Rows.Count >= 1)
                {
                    dgv_view.DataSource = ds3.Tables[0];
                }

            }


        }

        private void dgv_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string teacher = dgv_view.Rows[e.RowIndex].Cells[0].Value.ToString();
            string subject = dgv_view.Rows[e.RowIndex].Cells[1].Value.ToString();
            string standard = dgv_view.Rows[e.RowIndex].Cells[2].Value.ToString();
            string division = dgv_view.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbteach.Text = teacher;
            cmbsub.Text = subject;
            cmbstd.Text = standard;
            cmbdiv.Text = division;


           
            // to select employ number from table

            SqlDataAdapter ad = new SqlDataAdapter("select Empno from teacherdet where EmpName='" + teacher + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                Empnum = dr[0].ToString();
            }

            // to select subject number from table

            SqlDataAdapter ad1 = new SqlDataAdapter("select subjectnum  from tbl_subject where subject='" + subject + "'", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            DataRow dr1;
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr1 = ds1.Tables[0].Rows[0];
                subjctnum = dr1[0].ToString();
            }

            // to select standard from table

            SqlDataAdapter ad2 = new SqlDataAdapter("select cstandard from tbl_class where cstandard='" + standard + "'", d.con);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2);
            DataRow dr2;
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                dr2 = ds2.Tables[0].Rows[0];
                std = dr2[0].ToString();
            }

            // to select division from table

            SqlDataAdapter ad3 = new SqlDataAdapter("select division from tbl_class where division='" + division + "'", d.con);
            DataSet ds3 = new DataSet();
            ad3.Fill(ds3);
            DataRow dr3;
            if (ds3.Tables[0].Rows.Count >= 1)
            {
                dr3 = ds3.Tables[0].Rows[0];
                div = dr3[0].ToString();
            }

            // to select class number from table

            SqlDataAdapter ad4 = new SqlDataAdapter("select classno from tbl_class where cstandard='" + std + "' and division ='" + div + "'", d.con);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4);
            DataRow dr4;
            if (ds4.Tables[0].Rows.Count >= 1)
            {
                dr4 = ds4.Tables[0].Rows[0];
                clsno = dr4[0].ToString();
            }

           
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbdiv.Text = "";
            cmbstd.Text = "";
            cmbteach.Text = "";
            cmbsub.Text = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            DialogResult d1 = MessageBox.Show("Are you sure to remove the record ", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d1 == DialogResult.Yes)
            {

                d.con_open();
                SqlCommand cmd = new SqlCommand("del_assignteacher", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@classteacherno", Empnum);
                cmd.Parameters.AddWithValue("@subjectnum", subjctnum);
                cmd.Parameters.AddWithValue("@classno", clsno);
                //MessageBox.Show("Teacher deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.ExecuteNonQuery();
                d.con_close();

                // to display the remaining details in grid

                SqlDataAdapter ad3 = new SqlDataAdapter("SELECT t.EmpName AS Teacher, s.subject AS Subject, c.cstandard AS Standard, c.division AS Division FROM teacherdet AS t INNER JOIN tbl_assignteach AS a ON t.Empno = a.classteacherno INNER JOIN tbl_subject AS s ON a.subjectnum = s.subjectnum INNER JOIN tbl_class AS c ON a.classno = c.classno", d.con);
                DataSet ds3 = new DataSet();
                ad3.Fill(ds3);
                if (ds3.Tables[0].Rows.Count >= 1)
                {
                    dgv_view.DataSource = ds3.Tables[0];
                }

                cmbdiv.Text = "";
                cmbstd.Text = "";
                cmbteach.Text = "";
                cmbsub.Text = "";


            }
        }
    }
}