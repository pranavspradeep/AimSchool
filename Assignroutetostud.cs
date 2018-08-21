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
    
    public partial class Assignroutetostud : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        string adno = "";
        string ptnum = "";
        string route = "";
        string rfrom = "";
        string rto = "";
        string fare = "";
        string name = "";
        string std = "";
     
        public Assignroutetostud()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            if (r1.Checked == false && r2.Checked == false && r3.Checked == false)
            {
                MessageBox.Show("Select option for search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (r1.Checked == true)
            {
                txtcls.Text = null;
                txtrol.Text = null;
                if (txt_Cname.Text == "" || txt_Cname.Text == null)
                {
                    MessageBox.Show("Enter Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select sname from tbl_student  where sname like '" + txt_Cname.Text + "%'  ", d.con);
                    DataSet dt1 = new DataSet();
                    da1.Fill(dt1);
                    if (dt1.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search name does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter ad = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student where sname like '" + txt_Cname.Text + "%'", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_stud.DataSource = ds.Tables[0];


            }

            if (r2.Checked == true)
            {
                txt_Cname.Text = null;
                txtcls.Text = null;

                if (txtrol.Text == "" || txtrol.Text == null)
                {
                    MessageBox.Show("Enter Roll Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlDataAdapter da2 = new SqlDataAdapter("select adno from tbl_student where adno='" + txtrol.Text + "' ", d.con);
                    DataSet dt2 = new DataSet();
                    da2.Fill(dt2);
                    if (dt2.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search roll number does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter ad1 = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student where adno='" + txtrol.Text + "'", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                dgv_stud.DataSource = ds1.Tables[0];


            }
            if (r3.Checked == true)
            {
                txt_Cname.Text = null;
                txtrol.Text = null;
                if (txtcls.Text == "" || txtcls.Text == null)
                {
                    MessageBox.Show("Enter Class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    SqlDataAdapter da3 = new SqlDataAdapter("select cstandard from tbl_student where cstandard='" + txtcls.Text + "'", d.con);
                    DataSet dt3 = new DataSet();
                    da3.Fill(dt3);
                    if (dt3.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search class  does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter ad2 = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student where cstandard='" + txtcls.Text + "'", d.con);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                dgv_stud.DataSource = ds2.Tables[0];

            }

        }

        private void Assignroutetostud_Load(object sender, EventArgs e)
        {
            // display the student details in datagridview

            SqlDataAdapter ad = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgv_stud.DataSource = ds.Tables[0];
            }
            // display the route details in datagridview

            SqlDataAdapter ad1 = new SqlDataAdapter("SELECT rt.ptnum as [Point Number], r.route as [Route],rt.rfrom as [Route From], rt.rto as [Route To], rt.fare as [Fare] FROM tbl_routepoint AS rt INNER JOIN tbl_route AS r ON rt.routenum = r.routenum ", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dgv_route.DataSource = ds1.Tables[0];
            }
            else
            {
                MessageBox.Show("Data does not exist", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SqlDataAdapter ad2 = new SqlDataAdapter("SELECT s.sname as Name, s.cstandard as Standard, r1.route as Route, r.rfrom as [ Route From], r.rto as [Route To], r.fare as Fare FROM tbl_student AS s INNER JOIN tbl_assignroute AS a ON s.adno = a.adno INNER JOIN tbl_routepoint AS r ON a.ptnum = r.ptnum INNER JOIN tbl_route AS r1 ON r.routenum = r1.routenum  ", d.con);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                dgv_assigned.DataSource = ds2.Tables[0];
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_Cname.Text = "";
            txtcls.Text = "";
            txtrol.Text = "";

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void dgv_stud_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            adno = dgv_stud.Rows[e.RowIndex].Cells[0].Value.ToString();
            name = dgv_stud.Rows[e.RowIndex].Cells[1].Value.ToString();
            std = dgv_stud.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgv_route_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ptnum = dgv_route.Rows[e.RowIndex].Cells[0].Value.ToString();
            route   = dgv_route.Rows[e.RowIndex].Cells[1].Value.ToString();
            rfrom = dgv_route.Rows[e.RowIndex].Cells[2].Value.ToString();
            rto = dgv_route.Rows[e.RowIndex].Cells[3].Value.ToString();
            fare = dgv_route.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void btn_assign_Click(object sender, EventArgs e)
        {

            if (adno == "" ||adno==null )
            {
                MessageBox.Show("Please select the student details","warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (ptnum == "" || ptnum == null)
            {
                MessageBox.Show("Please select the route details", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                string s = "SELECT a.adno,a.ptnum,r1.route FROM tbl_assignroute AS a INNER JOIN tbl_routepoint AS r ON a.ptnum = r.ptnum INNER JOIN tbl_route AS r1 ON r.routenum = r1.routenum where a.adno='" + adno + "' and r1.route='"+route+"'";
                SqlDataAdapter ad = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("Route already assigned to student", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    d.con_open();
                    SqlCommand cmd = new SqlCommand("ins_assignroute", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@adno", adno);
                    cmd.Parameters.AddWithValue("@ptnum", ptnum);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Route assigned", "Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    d.con_close();


                    // to display the assigned students in grid

                    dgv_assigned.DataSource = null;
                    SqlDataAdapter ad2 = new SqlDataAdapter("SELECT s.sname as Name, s.cstandard as Standard, r1.route as Route, r.rfrom as [Route From], r.rto as [Route To], r.fare as Fare FROM tbl_student AS s INNER JOIN tbl_assignroute AS a ON s.adno = a.adno INNER JOIN tbl_routepoint AS r ON a.ptnum = r.ptnum INNER JOIN tbl_route AS r1 ON r.routenum = r1.routenum  where a.adno='" + adno + "' and r1.route='"+route+"'", d.con);
                    DataSet ds2 = new DataSet();
                    ad2.Fill(ds2);
                    if (ds2.Tables[0].Rows.Count >= 1)
                    {
                        dgv_assigned.DataSource = ds2.Tables[0];
                    }

                }
            }
        }

        private void dgv_assigned_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void dgv_route_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}