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
    public partial class SubjectEntryForClasses : Form
    {
        DataLayer d = new DataLayer();
        int slno;
        string sub = "";

        public SubjectEntryForClasses()
        {
            InitializeComponent();
        }
        public void display_combo()
        {
            d.con_open();
            SqlCommand cmd1 = new SqlCommand("sel_syllabus", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                cmb_syll.Items.Add(r1[0].ToString());
            }
            d.con_close();
        }
        public void display_sub()
        {
            d.con_open();
            SqlCommand cmd2 = new SqlCommand("sel_sub", d.con);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlDataReader r2 = cmd2.ExecuteReader();
            while (r2.Read())
            {
                cmb_sub.Items.Add(r2[0].ToString());                
            }
            d.con_close();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (cmb_std.Text == "" || cmb_std.Text == null)
            {
                MessageBox.Show("Select Standard!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_syll.Text == "" || cmb_syll.Text == null)
            {
                MessageBox.Show("Select Syllabus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_sub.Text == "" || cmb_sub.Text == null)
            {
                MessageBox.Show("Select Subject!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("Select sc.Standard,sc.Syllabus,sc.SubjectNo,s.subject from tbl_subforclass as sc INNER JOIN tbl_subject as s on sc.SubjectNo=s.subjectnum where sc.Standard='" + cmb_std.Text + "' and sc.Syllabus='" + cmb_syll.Text + "' And s.subject='" + cmb_sub.Text + "'", d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("This subject was Already defined for this Class!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Select subjectnum from tbl_subject where subject='" + cmb_sub.Text + "'", d.con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    DataRow dr1;
                    dr1= ds1.Tables[0].Rows[0];
                    int subno = Convert.ToInt32(dr1[0].ToString());


                    d.con_open();
                    SqlCommand cmd1 = new SqlCommand("ins_subforclass", d.con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@standard", cmb_std.Text);
                    cmd1.Parameters.AddWithValue("@sylabus", cmb_syll.Text);
                    cmd1.Parameters.AddWithValue("@subjectno", subno);
                    cmd1.ExecuteNonQuery();
                    d.con_close();
                    cmb_sub.Text = "";
                    MessageBox.Show("Subject Added to the Class Successfully!", "Added....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_subclass.ColumnCount = 0;
                    grid_display();
                }
            }
        }
        public void grid_display()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select sc.Standard,sc.Syllabus,s.subject as Subject from tbl_subforclass as sc INNER JOIN tbl_subject as s on sc.Subjectnum=s.subjectnum where sc.Standard='" + cmb_std.Text + "' and sc.Syllabus='" + cmb_syll.Text + "'" , d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataRow dr1;
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr1 = ds1.Tables[0].Rows[0];
                dgv_subclass.Columns.Add("0", "Standard");
                dgv_subclass.Columns.Add("1", "Syllabus");
                dgv_subclass.Columns.Add("2", "Subject");
                string[] row = new string[] { dr1[0].ToString(), dr1[1].ToString(), dr1[2].ToString() };
                dgv_subclass.Rows.Add(row);
                for (int i = 1; i < ds1.Tables[0].Rows.Count; i++)
                {
                    dr1 = ds1.Tables[0].Rows[i];
                    string[] row1 = new string[] { "", "", dr1[2].ToString() };
                    dgv_subclass.Rows.Add(row1);
                }
            }
        }
        private void SubjectEntryForClasses_Load(object sender, EventArgs e)
        {
            cmb_std.Focus();
            display_combo();
            display_sub();
            cmb_syll.Enabled = false;
            cmb_sub.Enabled = false;
        }

        private void cmb_syll_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_sub.Enabled = true;
            dgv_subclass.ColumnCount = 0;
            grid_display();
            
        }      
        private void dgv_subclass_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            sub = dgv_subclass.Rows[e.RowIndex].Cells[2].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("Select sc.slno,sc.Standard,sc.Syllabus,s.subject from tbl_subforclass as sc INNER JOIN tbl_subject as s on sc.SubjectNo  where sc.Standard='" + cmb_std.Text + "' And sc.Syllabus='" + cmb_syll.Text + "' And s.subject='" + sub + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                slno = Convert.ToInt32(dr[0].ToString());   
          
                                
            }
            else
            {
                MessageBox.Show("Data does not exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to remove this Subject ", "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("Delete from tbl_subforclass where slno=" + slno , d.con);
                cmd.ExecuteNonQuery();
                d.con_close();
                cmb_sub.Text = "";
                MessageBox.Show("Subject Removed From the Class Successfully", "Removed..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_subclass.ColumnCount = 0;
                grid_display();
            }
                
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmb_std.Text = "";
            cmb_sub.Text = "";
            cmb_syll.Text = "";
            dgv_subclass.ColumnCount = 0;

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_std_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_syll.Enabled = true;
            if (cmb_syll.Text != "")
            {
                dgv_subclass.ColumnCount = 0;
                grid_display();
            }
        }
    }
}