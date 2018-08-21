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
    public partial class RegFrm : Form
    {
        DataLayer d = new DataLayer();
        public RegFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void txtmno_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {

        }

        private void txtfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void side3_Click(object sender, EventArgs e)
        {

        }

        private void side4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator7_Click(object sender, EventArgs e)
        {

        }

        private void side1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbsex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtocpton_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtphno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaddrs_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrgon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnatnalty_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("ins_student", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StName",txtname.Text);
            cmd.Parameters.AddWithValue("@FName",txtfname.Text);
            cmd.Parameters.AddWithValue("@PhoNo",txtphno.Text);
            cmd.Parameters.AddWithValue("@Email",txtmail.Text);
            cmd.Parameters.AddWithValue("@Rel",txtrgon.Text);
            cmd.Parameters.AddWithValue("@Occ",txtocpton.Text);
            cmd.Parameters.AddWithValue("@Nation",txtnatnalty.Text);
            cmd.Parameters.AddWithValue("@Sex",cmbsex.Text);
            cmd.Parameters.AddWithValue("@DOB",dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@MName",txtMname.Text);
            cmd.Parameters.AddWithValue("@Mob",txtmno.Text);
            cmd.Parameters.AddWithValue("@Addr",txtaddrs.Text);
            cmd.Parameters.AddWithValue("@School",txtschool.Text);
            cmd.Parameters.AddWithValue("@Std",txtstd.Text);
            cmd.Parameters.AddWithValue("@DOA",cmbdoa.Text);
            cmd.Parameters.AddWithValue("@DOL",cmbdol.Text);
            cmd.Parameters.AddWithValue("@TCNo",txttcno.Text);
            cmd.Parameters.AddWithValue("@Remarks",txtremarks.Text);
            cmd.Parameters.AddWithValue("@Photo","");
            cmd.Parameters.AddWithValue("@Status", "0");
            cmd.ExecuteNonQuery();
            d.con_close();

        }

        
    }
}