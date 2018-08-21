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
    public partial class Otherfees : Form
    {
        DataLayer d = new DataLayer();
        string otherid = "";
        public Otherfees()
        {
            InitializeComponent();
        }

    private void btn_Add_Click(object sender, EventArgs e)
    {

        if (txtother.Text == "" || txtother.Text == null)
        {
            MessageBox.Show("Enter otherfees", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            SqlDataAdapter ad1 = new SqlDataAdapter("select otherfee from tbl_otherfee where otherfee='" + txtother.Text + "'", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                MessageBox.Show("Otherfee already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_otherfee", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@otherfee", txtother.Text);
                cmd.ExecuteNonQuery();
                txtother.Text = "";
                d.con_close();

                // Display the added details in datagridviewmain

                dgv_otherfees.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select otherid as [Fee Id],otherfee as [Other Fees] from tbl_otherfee", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_otherfees.DataSource = ds.Tables[0];
                MessageBox.Show("Fees added successfully", "Added..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
     }

    private void Otherfees_Load(object sender, EventArgs e)
    {
       
           // To select the fee details from table
           SqlDataAdapter ad = new SqlDataAdapter("select otherid,otherfee from tbl_otherfee", d.con);
           DataSet ds = new DataSet();
           ad.Fill(ds);
           dgv_otherfees.DataSource = ds.Tables[0];
   }

        //private void btn_rem_click(object sender, EventArgs e)
        //{

        //}

    private void btn_remove_Click(object sender, EventArgs e)
     {

     }

    private void btn_rem_Click(object sender, EventArgs e)
     {       

     }

    private void dgv_otherfees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
               otherid = dgv_otherfees.Rows[e.RowIndex].Cells[0].Value.ToString();
               SqlDataAdapter ad = new SqlDataAdapter("select otherfee from tbl_otherfee where otherid='" + otherid + "'", d.con);
               DataSet ds = new DataSet();
               ad.Fill(ds);
               DataRow dr;
               if (ds.Tables[0].Rows.Count >= 1)
               {
                   dr = ds.Tables[0].Rows[0];
                   txtother.Text = dr[0].ToString();
               }
               else
               {
                   MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
        }

    private void btn_Cancel_Click(object sender, EventArgs e)
        {
              txtother.Text = "";

        }

       
    private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (txtother.Text == "" || txtother.Text == null)
            {
                MessageBox.Show("Enter otherfees", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                DialogResult dg = MessageBox.Show("Are you sure to delete", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {

                    d.con_open();
                    SqlCommand cmd = new SqlCommand("del_otherfees", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@otherid", otherid);
                    cmd.Parameters.AddWithValue("@otherfee", txtother.Text);
                    txtother.Text = "";
                    cmd.ExecuteNonQuery();

                    d.con_close();

                    // To display the remaining details in datagridview

                    dgv_otherfees.DataSource = null;
                    SqlDataAdapter ad = new SqlDataAdapter("select otherid ,otherfee from tbl_otherfee ", d.con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    dgv_otherfees.DataSource = ds.Tables[0];


                }
            }
         


     }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}