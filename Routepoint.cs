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
    public partial class Routepoint : DevComponents.DotNetBar.Office2007Form
    {
        
        DataLayer d = new DataLayer();
        
        string routenum = "";
        string ptno = "";
        string rtnum = "";
        

        public Routepoint()
        {
            InitializeComponent();
        }

        private void Routepoint_Load(object sender, EventArgs e)
        {
            //Select route from the table 

            d.con_open();
            SqlCommand cmd = new SqlCommand("sel_route", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@route", cmbroute.Text);
            SqlDataReader r = cmd.ExecuteReader();
            cmbroute.Items.Clear();
            while (r.Read())
            {
                cmbroute.Items.Add(r[0].ToString());
            }
            d.con_close();

            // display the route details in datagridview

            SqlDataAdapter ad1 = new SqlDataAdapter("SELECT rt.ptnum as [Point Number], r.route as [Route],rt.rfrom as [Route From], rt.rto as [Route To], rt.fare as [Fare] FROM tbl_routepoint AS rt INNER JOIN tbl_route AS r ON rt.routenum = r.routenum ", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
           
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dgv_route.DataSource = ds1.Tables[0];
            }
           

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (cmbroute.Text == "" || cmbroute.Text == null)
            {
                MessageBox.Show("Enter Route", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtfr.Text == "" || txtfr.Text == null)
            {
                MessageBox.Show("Enter Routefrom", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtto.Text == "" || txtto.Text == null)
            {
                MessageBox.Show("Enter RouteTo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtfare.Text == "" || txtfare.Text == null)
            {
                MessageBox.Show("Enter Fare", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            SqlDataAdapter ad3 = new SqlDataAdapter("select r.route as [Route],rt.rfrom as [Route From],rt.rto as [Route To] from tbl_routepoint rt inner join tbl_route r on r.routenum=rt.routenum where r.route='" + cmbroute.Text + "'and rt.rfrom='" + txtfr.Text + "'and rt.rto='" + txtto.Text + "'", d.con);
            DataSet ds3 = new DataSet();
            ad3.Fill(ds3);
            if (ds3.Tables[0].Rows.Count >= 1)
            {
                MessageBox.Show("Route already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
            else
            {
                routenum = "";
                string s = "select routenum from tbl_route where route ='" + cmbroute.Text + "'";
                SqlDataAdapter ad = new SqlDataAdapter(s, d.con);
                ad.Fill(ds);
                DataRow dr;
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dr = ds.Tables[0].Rows[0];
                    routenum = dr[0].ToString();
                }


                d.con_open();

                SqlCommand cmd = new SqlCommand("ins_routepoint", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@routenum", routenum);
                cmd.Parameters.AddWithValue("@rfrom", txtfr.Text);
                cmd.Parameters.AddWithValue("@rto", txtto.Text);
                cmd.Parameters.AddWithValue("@fare", txtfare.Text);
                cmd.ExecuteNonQuery();

                d.con_close();

                // to display the added details in datagridview

                SqlDataAdapter ad1 = new SqlDataAdapter("SELECT rt.ptnum as[Point Number], r.route as [Route],rt.rfrom as [Route From], rt.rto as [Route To], rt.fare as [Fare] FROM tbl_routepoint AS rt INNER JOIN tbl_route AS r ON rt.routenum = r.routenum ", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                DataRow dr1;
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    dr1 = ds1.Tables[0].Rows[0];
                    dgv_route.DataSource = ds1.Tables[0];
                    MessageBox.Show("Route added successfully", "Added..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbroute.Text = "";
                    txtfr.Text = "";
                    txtto.Text = "";
                    txtfare.Text = "";

                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (cmbroute.Text == "" || cmbroute.Text == null)
            {
                MessageBox.Show("Enter Route", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtfr.Text == "" || txtfr.Text == null)
            {
                MessageBox.Show("Enter Routefrom", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtto.Text == "" || txtto.Text == null)
            {
                MessageBox.Show("Enter RouteTo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtfare.Text == "" || txtfare.Text == null)
            {
                MessageBox.Show("Enter Fare", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                SqlDataAdapter ad2 = new SqlDataAdapter("select routenum from tbl_route where route='" + cmbroute.Text + "'", d.con);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                DataRow dr2;
                if (ds2.Tables[0].Rows.Count >= 1)
                {
                    dr2 = ds2.Tables[0].Rows[0];
                    rtnum = dr2[0].ToString();
                }
                
                    d.con_open();
                    SqlCommand cmd = new SqlCommand("upd_routepoint", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ptnum", ptno);
                    //cmd.Parameters.AddWithValue("@routenum", rtnum);
                    cmd.Parameters.AddWithValue("@rfrom", txtfr.Text);
                    cmd.Parameters.AddWithValue("@rto", txtto.Text);
                    cmd.Parameters.AddWithValue("@fare", txtfare.Text);
                    cmd.ExecuteNonQuery();
                    d.con_close();

                    // to display the edited details in datagridview

                    dgv_route.DataSource = null;
                    SqlDataAdapter ad1 = new SqlDataAdapter("SELECT rt.ptnum as [Point Number], r.route as [Route],rt.rfrom as [Route From], rt.rto as [Route To], rt.fare as [Fare] FROM tbl_routepoint AS rt INNER JOIN tbl_route AS r ON rt.routenum = r.routenum", d.con);
                    DataSet ds1 = new DataSet();
                    ad1.Fill(ds1);

                    if (ds1.Tables[0].Rows.Count >= 1)
                    {
                        dgv_route.DataSource = ds1.Tables[0];
                    }
                    cmbroute.Text = "";
                    txtfr.Text = "";
                    txtto.Text = "";
                    txtfare.Text = "";
                    MessageBox.Show("Route Edited Successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }

        private void dgv_route_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                ptno = dgv_route.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbroute.Text = dgv_route.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtfr.Text = dgv_route.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtto.Text = dgv_route.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtfare.Text = dgv_route.Rows[e.RowIndex].Cells[4].Value.ToString();

               
        }
        

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbroute.Text = "";
            txtfr.Text = "";
            txtto.Text = "";
            txtfare.Text = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            DialogResult r=MessageBox.Show("Are you sure you want to remove","warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(r==DialogResult.Yes)
            {

            d.con_open();
            SqlCommand cmd=new SqlCommand("delete from tbl_routepoint where ptnum='"+ptno+"'",d.con);
            cmd.Parameters.AddWithValue("rfrom", txtfr.Text);
            cmd.Parameters.AddWithValue("rto", txtto.Text);
            cmd.Parameters.AddWithValue("fare", txtfare.Text);
            cmd.ExecuteNonQuery();
            d.con_close();
            
            dgv_route.DataSource = null;
            SqlDataAdapter ad1 = new SqlDataAdapter("SELECT rt.ptnum as [Point Number], r.route as [Route],rt.rfrom as [Route From], rt.rto as [Route To], rt.fare as [Fare] FROM tbl_routepoint AS rt INNER JOIN tbl_route AS r ON rt.routenum = r.routenum", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dgv_route.DataSource = ds1.Tables[0];
            }
             cmbroute.Text = "";
             txtfr.Text = "";
             txtto.Text = "";
             txtfare.Text = "";
             
         }
        }


        }
    }
