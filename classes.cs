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
    public partial class classes : Form
    {
        string clasno = "";
        string Empno = "";
        string Empn = "";
        string sylnum = "";
        DataLayer d = new DataLayer();
        public classes()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void classes_Load(object sender, EventArgs e)
        {
            // select teacher from table

            d.con_open();

            SqlCommand cmd = new SqlCommand("se_teach", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader r = cmd.ExecuteReader();
            cmbteach.Items.Clear();
            while (r.Read())
            {
                cmbteach.Items.Add(r[0].ToString());
            }
            d.con_close();

            // select syllabus from table

            d.con_open();

            SqlCommand cmd1 = new SqlCommand("sel_syllabus", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader r1 = cmd1.ExecuteReader();
            cmbsyll.Items.Clear();
            while (r1.Read())
            {
               cmbsyll.Items.Add(r1[0].ToString());
            }
            d.con_close();


            // Display class details in datagridview

            SqlDataAdapter ad1 = new SqlDataAdapter("SELECT class.classno AS [Class No], class.cstandard AS Standard, class.division AS Division, sub.Newsyll AS [New Syllabus], teach.EmpName AS [Emp Name] FROM teacherdet AS teach INNER JOIN tbl_class AS class ON class.classteacherno = teach.Empno INNER JOIN tbl_syllabus AS sub ON sub.syllabusnum = class.syllabusnum", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dgv_class.DataSource = ds1.Tables[0];            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            // to select empno from table 

            string s = "select Empno from teacherdet where Empname='" + cmbteach.Text + "'";
            SqlDataAdapter ad2 = new SqlDataAdapter(s, d.con);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2);
            DataRow dr2;
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                dr2 = ds2.Tables[0].Rows[0];
                Empno = dr2[0].ToString();
            }

            SqlDataAdapter ad4 = new SqlDataAdapter("select syllabusnum from tbl_syllabus  where Newsyll='" + cmbsyll.Text + "'", d.con);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4);
            DataRow dr4;
            if (ds4.Tables[0].Rows.Count >= 1)
            {
                dr4 = ds4.Tables[0].Rows[0];
                sylnum = dr4[0].ToString();
            }

           
            //if (cmbteach.Text == "" || cmbteach.Text == null)
            //{
            //    MessageBox.Show("Enter teacher", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbdiv.Text == "" || cmbdiv.Text == null)
            {
                MessageBox.Show("Enter Division", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                // to select classteacherno from table 

                //SqlDataAdapter ad = new SqlDataAdapter("select classteacherno from tbl_class where classteacherno='" + Empn + "' ", d.con);
                //DataSet  ds = new DataSet();
                //ad.Fill(ds);
                // if (ds.Tables[0].Rows.Count >= 1)
                //{
                //    MessageBox.Show("Teacher name already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}  




                //SqlDataAdapter ad = new SqlDataAdapter("select classteacherno from tbl_class where classteacherno='" + Empn + "' ", d.con);
                //DataSet ds = new DataSet();
                //ad.Fill(ds);
                //if (ds.Tables[0].Rows.Count >= 1)
                //{
                //    MessageBox.Show("Teacher name already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //else
                //{
                    SqlDataAdapter ad3 = new SqlDataAdapter("select cstandard,division from tbl_class where cstandard='" + cmbstd.Text + "' and division='" + cmbdiv.Text + "'", d.con);
                    DataSet ds3 = new DataSet();
                    ad3.Fill(ds3);
                    if (ds3.Tables[0].Rows.Count >= 1)
                    {
                        MessageBox.Show("Same standard and division  already assigned to that class", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                    }


                    else
                    {
                        d.con_open();

                        SqlCommand cmd1 = new SqlCommand("ins_clas", d.con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                        cmd1.Parameters.AddWithValue("@division", cmbdiv.Text);
                        cmd1.Parameters.AddWithValue("@classteacherno", Empno);
                        cmd1.Parameters.AddWithValue("@syllabusnum", sylnum);
                        cmd1.ExecuteNonQuery();

                        cmbteach.Text = "";
                        cmbstd.Text = "";
                        cmbdiv.Text = "";
                        cmbsyll.Text = "";

                        //Display the saved details in datagridview

                        dgv_class.DataSource = null;
                        SqlDataAdapter ad1 = new SqlDataAdapter("SELECT class.classno AS [Class No], class.cstandard AS Standard, class.division AS Division, sub.Newsyll, teach.EmpName AS [Emp Name]FROM teacherdet AS teach INNER JOIN tbl_class AS class ON class.classteacherno = teach.Empno INNER JOIN tbl_syllabus AS sub ON sub.syllabusnum = class.syllabusnum ", d.con);
                        DataSet ds1 = new DataSet();
                        ad1.Fill(ds1);
                        dgv_class.DataSource = ds1.Tables[0];
                        MessageBox.Show("Data saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        d.con_close();
                    }



                
            }
            


        }

        private void btn_edit_Click_1(object sender, EventArgs e)
        {

            //if (cmbteach.Text == "" || cmbteach.Text == null)
            //{
            //    MessageBox.Show("Enter teacher", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (cmbstd.Text == "" || cmbstd.Text == null)
            //{
            //    MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (cmbdiv.Text == "" || cmbdiv.Text == null)
            //{
            //    MessageBox.Show("Enter Division", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{

            //    SqlDataAdapter ad = new SqlDataAdapter("select  classteacherno from tbl_class where classteacherno='" + Empn + "' ", d.con);
            //    DataSet ds = new DataSet();
            //    ad.Fill(ds);
            //    if (ds.Tables[0].Rows.Count >= 1)
            //    {
            //        MessageBox.Show(" Teacher's name already exist", " warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        SqlDataAdapter ad2 = new SqlDataAdapter("select Empno from teacherdet where Empname='" + cmbteach.Text + "'", d.con);
            //        DataSet ds2 = new DataSet();
            //        ad2.Fill(ds2);
            //        DataRow dr2;
            //        if (ds2.Tables[0].Rows.Count >= 1)
            //        {
            //            dr2 = ds2.Tables[0].Rows[0];
            //            Empno = dr2[0].ToString();
            //        }
            //        d.con_open();

            //        SqlCommand cmd = new SqlCommand("edit_clas", d.con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@classno", clasno);
            //        cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
            //        cmd.Parameters.AddWithValue("@division", cmbdiv.Text);
            //        cmd.Parameters.AddWithValue("@classteacherno", Empno);
            //        cmd.Parameters.AddWithValue("@syllabusnum", sylnum);
            //        cmd.ExecuteNonQuery();

            //        cmbdiv.Text = "";
            //        cmbstd.Text = "";
            //        cmbteach.Text = "";
            //        cmbsyll.Text = "";
            //        dgv_class.DataSource = null;

            //        //Display the edited details in datagridview

            //        string sc = "select  class.classno as[Class No],class.cstandard as[Standard],class.division as[Division],teach.EmpName as[Emp Name] from tbl_class class inner join teacherdet teach on class.classteacherno=teach.Empno";
            //        SqlDataAdapter ad1 = new SqlDataAdapter(sc, d.con);
            //        DataSet ds1 = new DataSet();
            //        ad1.Fill(ds1);
            //        dgv_class.DataSource = ds1.Tables[0];
            //        MessageBox.Show("Data edited successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        d.con_close();

            //    }
            //}

        }

        private void dgv_class_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            clasno = dgv_class.Rows[e.RowIndex].Cells[0].Value.ToString();
            string s = "SELECT class.classno AS [Class No], class.cstandard AS Standard, class.division AS Division, sub.Newsyll, teach.EmpName AS [Emp Name]FROM teacherdet AS teach INNER JOIN tbl_class AS class ON class.classteacherno = teach.Empno INNER JOIN tbl_syllabus AS sub ON sub.syllabusnum = class.syllabusnum where Classno= '" + clasno + "'";
            SqlDataAdapter ad1 = new SqlDataAdapter(s, d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            DataRow dr;
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr = ds1.Tables[0].Rows[0];
                cmbstd.Text = dr[1].ToString();
                cmbdiv.Text = dr[2].ToString();
                cmbsyll.Text = dr[3].ToString();
                cmbteach.Text = dr[4].ToString();
            }
            else
            {
                MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbdiv.Text = "";
            cmbstd.Text = "";
            cmbteach.Text = "";
            cmbsyll.Text = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void cmbteach_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlDataAdapter ad = new SqlDataAdapter("select Empno from teacherdet where EmpName='" + cmbteach.Text + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                Empn = dr[0].ToString();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            

        }

        private void btn_edit_click(object sender, EventArgs e)
        {
            
        }

        private void btn_edit_Click_2(object sender, EventArgs e)
        {
            /////

            //if (cmbteach.Text == "" || cmbteach.Text == null)
            //{
            //    MessageBox.Show("Enter teacher", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbdiv.Text == "" || cmbdiv.Text == null)
            {
                MessageBox.Show("Enter Division", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                //SqlDataAdapter ad = new SqlDataAdapter("select  classteacherno from tbl_class where classteacherno='" + Empn + "' ", d.con);
                //DataSet ds = new DataSet();
                //ad.Fill(ds);
                //if (ds.Tables[0].Rows.Count >= 1)
                //{
                //    MessageBox.Show(" Teacher's name already exist", " warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //else
                //{
                    SqlDataAdapter ad2 = new SqlDataAdapter("select Empno from teacherdet where Empname='" + cmbteach.Text + "'", d.con);
                    DataSet ds2 = new DataSet();
                    ad2.Fill(ds2);
                    DataRow dr2;
                    if (ds2.Tables[0].Rows.Count >= 1)
                    {
                        dr2 = ds2.Tables[0].Rows[0];
                        Empno = dr2[0].ToString();
                    }
                    d.con_open();

                    SqlCommand cmd = new SqlCommand("edit_clas", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@classno", clasno);
                    cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                    cmd.Parameters.AddWithValue("@division", cmbdiv.Text);
                    cmd.Parameters.AddWithValue("@classteacherno", Empno);
                    cmd.Parameters.AddWithValue("@syllabusnum", sylnum);

                    cmd.ExecuteNonQuery();
                    cmbdiv.Text = "";
                    cmbstd.Text = "";
                    cmbteach.Text = "";
                    cmbsyll.Text = "";
                    dgv_class.DataSource = null;

                    //Display the edited details in datagridview

                    string sc = "select  class.classno,class.cstandard,class.division,teach.EmpName from tbl_class class inner join teacherdet teach on class.classteacherno=teach.Empno";
                    SqlDataAdapter ad1 = new SqlDataAdapter(sc, d.con);
                    DataSet ds1 = new DataSet();
                    ad1.Fill(ds1);
                    dgv_class.DataSource = ds1.Tables[0];
                    MessageBox.Show("Data edited successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    d.con_close();

                }
            

        }

        private void btn_remove_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to remove class", "warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("delete from tbl_class where cstandard='" + cmbstd.Text + "'and division ='" + cmbdiv.Text + "'", d.con);
                cmd.Parameters.AddWithValue("cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("division", cmbdiv.Text);
                cmd.ExecuteNonQuery();
                d.con_close();
                dgv_class.DataSource = null;

                //Remove the details from datagridview

                string sc = "select  class.classno,class.cstandard,class.division,teach.EmpName from tbl_class class inner join teacherdet teach on class.classteacherno=teach.Empno";
                SqlDataAdapter ad1 = new SqlDataAdapter(sc, d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                dgv_class.DataSource = ds1.Tables[0];
                //MessageBox.Show("Class removed", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                cmbdiv.Text = "";
                cmbstd.Text = "";
                cmbteach.Text = "";
                cmbsyll.Text = "";
            }
        }
    }
}