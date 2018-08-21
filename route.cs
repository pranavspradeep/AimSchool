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
    public partial class route : Form
    {
        string routenum = "";
        DataLayer d= new DataLayer();
        public route()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            
            if (txtroute.Text == "" || txtroute.Text == null)
            {
                
                MessageBox.Show("Enter Route", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txt_busNo.Text == "" || txt_busNo.Text == null)
            {
                MessageBox.Show("Enter Bus No:", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SqlDataAdapter ad1 = new SqlDataAdapter("select route from tbl_route where route='" + txtroute.Text + "' and BusNo='" + txt_busNo.Text + "'", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("Route or Bus No: already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtroute.Text = "";
                    txt_busNo.Text = "";
                }
                else
                {
                    d.con_open();
                    SqlCommand cmd = new SqlCommand("ins_route", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@route", txtroute.Text);
                    cmd.Parameters.AddWithValue("@busno", txt_busNo.Text);
                    cmd.ExecuteNonQuery();
                    dgvroute.DataSource = null;

                    //to display the added details in gridview 

                    SqlDataAdapter ad = new SqlDataAdapter("select routenum as[Route Number],route as Route,BusNo as [Bus No] from tbl_route  ", d.con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        dgvroute.DataSource = ds.Tables[0];
                    }
                    txtroute.Text = "";
                    txt_busNo.Text = "";
                    MessageBox.Show("Route saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    d.con_close();
                }
            }
        }

        private void route_Load(object sender, EventArgs e)
        {
            d.con_open();
            SqlDataAdapter ad = new SqlDataAdapter("select routenum as [Route Number],route as Route,BusNo as [Bus No] from tbl_route ", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgvroute.DataSource = ds.Tables[0];
            }
            d.con_close();

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
                if (txtroute.Text == "" || txtroute.Text == null)
                {

                    MessageBox.Show("Enter Route or Select from the list", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult r = MessageBox.Show("Are you sure to remove the route", "warning...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        d.con_open();
                        SqlCommand cmd = new SqlCommand("del_route", d.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@route", txtroute.Text);
                        cmd.Parameters.AddWithValue("@routenum", routenum);
                        cmd.ExecuteNonQuery();
                        txtroute.Text = "";
                        txt_busNo.Text = "";
                        dgvroute.DataSource = null;

                        // to display remaining  details in datagridview

                        SqlDataAdapter ad = new SqlDataAdapter("select routenum as [Route Number],route as Route,BusNo as [Bus No] from tbl_route  ", d.con);
                        DataSet ds = new DataSet();
                        ad.Fill(ds);
                        if (ds.Tables[0].Rows.Count >= 1)
                        {
                            dgvroute.DataSource = ds.Tables[0];
                        }
                        d.con_close();
                    }
                }
            
           
        }

        private void dgvroute_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            routenum = dgvroute.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select route from tbl_route  where routenum='"+ routenum +"'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtroute.Text = dr[0].ToString();
            }
            else
            {
                MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtroute.Text = "";
            txt_busNo.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (txtroute.Text == "" || txtroute.Text == null)
            {

                MessageBox.Show("Enter Route", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult r = MessageBox.Show("Are you sure to remove the route", "Remove...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    d.con_open();
                    SqlCommand cmd = new SqlCommand("del_route", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@route", txtroute.Text);
                    cmd.Parameters.AddWithValue("@routenum", routenum);
                    cmd.ExecuteNonQuery();
                    txtroute.Text = "";
                    dgvroute.DataSource = null;

                    // to display remaining  details in datagridview

                    SqlDataAdapter ad = new SqlDataAdapter("select routenum,route from tbl_route  ", d.con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        dgvroute.DataSource = ds.Tables[0];
                    }
                    MessageBox.Show("Route removed successfully", "Removed..", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    d.con_close();
                }
            }
        }

        private void txt_busNo_Leave(object sender, EventArgs e)
        {
            SqlDataAdapter ad1 = new SqlDataAdapter("select BusNo from tbl_route where BusNo='" + txt_busNo.Text + "'", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                MessageBox.Show("Bus Number already assigned to another route!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_busNo.Text = "";
            }
        }

        private void txt_busNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
        }
    }
}