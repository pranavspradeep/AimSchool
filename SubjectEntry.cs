using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class SubjectEntry : Form
    {
        DataLayer d = new DataLayer();
        string subjt = "";
        public SubjectEntry()
        {
            InitializeComponent();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_subject.Text == "" || txt_subject.Text == null)
            {
                MessageBox.Show("Enter Subject!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("Select subject from tbl_subject where subject='" + txt_subject.Text + "'", d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("Subject Already Exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_subject.Text = "";
                }
                else
                {
                    d.con_open();
                    SqlCommand cmd = new SqlCommand("ins_subject", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subject", txt_subject.Text);
                    cmd.ExecuteNonQuery();
                    txt_subject.Text = "";
                    d.con_close();

                    //Display the Added Subject in Datagridview

                    grid_display();
                    MessageBox.Show("Subject Added Successfully", "Added..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        public void grid_display()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select subjectnum as [Sub-Num],subject as [Subject] from tbl_subject", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);            
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgv_Subject.DataSource = ds.Tables[0];
            }
        }
        private void SubjectEntry_Load(object sender, EventArgs e)
        {
            grid_display();
        }
        private void dgv_Subject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            subjt = dgv_Subject.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter da = new SqlDataAdapter("Select subjectnum,subject from tbl_subject where subjectnum='" + subjt + "'", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                subjt = dr[0].ToString();
                txt_subject.Text = dr[1].ToString();                
            }
            else
            {
                MessageBox.Show("Data does not exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgv_Subject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            subjt = dgv_Subject.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter da = new SqlDataAdapter("Select subjectnum,subject from tbl_subject where subjectnum='" + subjt + "'", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                subjt = dr[0].ToString();
                txt_subject.Text = dr[1].ToString();

            }
            else
            {
                MessageBox.Show("Data does not exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if(txt_subject.Text == "" || txt_subject.Text == null)
            {
                MessageBox.Show("Enter Subject!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);               
            }
            else
            {
                SqlDataAdapter da1 = new SqlDataAdapter("Select subject from tbl_subject where subject='" + txt_subject.Text + "'" , d.con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("Subject Already Exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                }
                else
                {
                    d.con_open();
                    SqlCommand cmd2 = new SqlCommand("upd_subject", d.con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@subjectnum", subjt);
                    cmd2.Parameters.AddWithValue("@subject", txt_subject.Text);
                    cmd2.ExecuteNonQuery();
                    txt_subject.Text = "";
                    d.con_close();

                    // To display the edited details in datagridview

                    grid_display();
                    MessageBox.Show("Subject Edited Successfully!", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_subject.Text = "";
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to remove the Subject ", "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("Delete from tbl_subject where subject='" + txt_subject.Text + "'", d.con);                
                cmd.ExecuteNonQuery();
                d.con_close();

                // Display the remaining details in grid

                grid_display();
                MessageBox.Show("Subject Removed Successfully", "Removed..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_subject.Text = "";
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
    }
}
