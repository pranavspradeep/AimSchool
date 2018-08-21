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
    public partial class GardeEntryForm : Form
    {
        DataLayer d = new DataLayer();
        public GardeEntryForm()
        {
            InitializeComponent();
        }

        private void GardeEntryForm_Load(object sender, EventArgs e)
        {
            //BindCombo();
            gridviwbind();


        }
        private void gridviwbind()
        {
            string s = "select slno as SlNo,Standard,Type,MinMark as [Minimum Mark],MaxMark as [Maximum Mark],Grade from tbl_gradesetting";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                Dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Dgv1.AutoResizeColumns();
                Dgv1.DataSource = ds.Tables[0];
                Dgv1.Columns[0].Visible = false;
            }
        }
        private void BindCombo()
        {
            d.con_open();
            SqlCommand cmd1 = new SqlCommand("sel_standard", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd1.ExecuteReader();
            cobboxstd.Items.Clear();
            while (rd.Read())
            {
                cobboxstd.Items.Add(rd[0].ToString());
            }
            d.con_close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            if (cobboxstd.Text == "" || cobboxstd.Text == null)
            {
                MessageBox.Show("please select Standard");
            }
            else if (cmbtype.Text == "" || cmbtype.Text == null)
            {
                MessageBox.Show("please select Type");
            }
            else
            {
                string s = "select slno,Standard,Type,MinMark,MaxMark,Grade from tbl_gradesetting where Type='" + cmbtype.Text + "' AND Standard ='" + cobboxstd.Text + "'";

                SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count >= 1)
                {
                    Dgv1.DataSource = ds.Tables[0];
                }
            }


        }

        private void cobboxstd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (valid() == true && valid1()==true)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_gradesetting", d.con);
                cmd.CommandType = CommandType.StoredProcedure;        
                cmd.Parameters.AddWithValue("@min", txtmin.Text);
                cmd.Parameters.AddWithValue("@max", txtmax.Text);
                cmd.Parameters.AddWithValue("@grade", txtgrade.Text);
                cmd.Parameters.AddWithValue("@type", cmbtype.Text);
                cmd.Parameters.AddWithValue("@std", cobboxstd.Text);
                cmd.ExecuteNonQuery();
                d.con_close();
                MessageBox.Show("Grade entered Successfully","Saved..",MessageBoxButtons.OK,MessageBoxIcon.Information);
                gridviwbind();
            }
        }
       

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sl = "";
            sl = Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
            SchoolManagement.slno = Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string s = "select slno,Standard,Type,Minmark,MaxMark,Grade from tbl_Gradesetting where slno ='" + sl + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                cobboxstd.Text = dr[1].ToString();
                cmbtype.Text = dr[2].ToString();
                txtmin.Text = dr[3].ToString();
                txtmax.Text = dr[4].ToString();
                txtgrade.Text = dr[5].ToString();

            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SchoolManagement.slno == null || SchoolManagement.slno == "")
            {
                MessageBox.Show("Please select one Row you want to delete", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult d1 = MessageBox.Show("Are you sure to delete", "Confirm..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d1 == DialogResult.Yes)
                {

                    SqlDataAdapter da = new SqlDataAdapter("Delete from tbl_gradesetting where slno= " + SchoolManagement.slno + "", d.con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    gridviwbind();



                }
            }


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SchoolManagement.slno == null || SchoolManagement.slno == "")
            {
                MessageBox.Show("Please select Row you want to Update", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (valid() == true && valid1() == true)
            {

                d.con_open();
                SqlCommand cmd = new SqlCommand("upd_gardesng", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@std", cobboxstd.Text);
                cmd.Parameters.AddWithValue("@type", cmbtype.Text);
                cmd.Parameters.AddWithValue("@min", txtmin.Text);
                cmd.Parameters.AddWithValue("@max", txtmax.Text);
                cmd.Parameters.AddWithValue("@grade", txtgrade.Text);
                cmd.Parameters.AddWithValue("@slno", SchoolManagement.slno);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Grade Detail edited successfully ", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                d.con_close();
                gridviwbind();
            }
           
        }
        public Boolean valid()
        {
            Boolean f = true;
            if (cobboxstd.Text == "" || cobboxstd.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter standard", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
            else if (cmbtype.Text == "" || cmbtype.Text == null)
            {
                f = false;
                MessageBox.Show("Please select type", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (txtmin.Text == "" || txtmin.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter minmum mark", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (txtmax.Text == "" || txtmax.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter maximum mark", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtgrade.Text == "" || txtgrade.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter grade", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return f;
        }
        public Boolean valid1()
        {   
            Boolean z = true;
            string ss = "select Standard,Type,Grade from tbl_gradesetting where Standard='" + cobboxstd.Text + "' AND Type='" + cmbtype.Text + "' AND Grade='" + txtgrade.Text + "'";
            SqlDataAdapter Da = new SqlDataAdapter(ss, d.con);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                z = false;
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    if (txtgrade.Text == dr[2].ToString())
                    {
                        MessageBox.Show("Grade  Already Exist");
                    }
                   
                    else if (cmbtype.Text == dr[1].ToString())
                    {
                      
                        MessageBox.Show("Type  Already Exist");
                    }
                    else if (cobboxstd.Text == dr[0].ToString())
                    {

                        MessageBox.Show("Standard Already Exist");
                    }
                    
                      
                }
                
                
            }
            return z;
        }
        private Boolean valid2()
        {
            Boolean z = true;
            string ss = "select Standard,Type,Grade from tbl_gradesetting where Standard='" + cobboxstd.Text + "' AND Type='" + cmbtype.Text + "' AND Grade='" + txtgrade.Text + "'";
            SqlDataAdapter Da = new SqlDataAdapter(ss, d.con);
            DataSet ds = new DataSet();
            Da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                z = false;
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    if (txtgrade.Text != dr[2].ToString())
                    {
                        if (cmbtype.Text != dr[1].ToString())
                        {
                            if (cobboxstd.Text == dr[0].ToString())
                            {

                            }
                            else
                            {
                             MessageBox.Show("Standard Already Exist");
                            }

                                             
                         }
                         else 
                         {
                            MessageBox.Show("Type  Already Exist");
                         }


                        
                      }
                      else
                     {
                      MessageBox.Show("Grade  Already Exist");
                     }                      
                }
                
                
            }
            return z;

        }

        private void Dgv1_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.SuppressKeyPress = true;
        //        int iColumn = Dgv1.CurrentCell.ColumnIndex;
        //        int iRow = Dgv1.CurrentCell.RowIndex;
        //        if (iColumn == Dgv1.Columns.Count - 1)
        //            Dgv1.CurrentCell = Dgv1[0, iRow + 1];
        //        else
        //            Dgv1.CurrentCell = Dgv1[iColumn + 1, iRow];

        //    }
        }

        private void txtmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
        }

        private void txtmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
        }

        

        
    }
   
}