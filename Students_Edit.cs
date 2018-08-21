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
    public partial class Students_Edit : Form
    {
        DataLayer d = new DataLayer();
        int SlNo;
        public Students_Edit()
        {
            InitializeComponent();
        }

        private void Students_Edit_Load(object sender, EventArgs e)
        {
              
                d.con_open();

                string s = "select sname,sfname,pnum,email,religion,occupation,nation,sex,dob,smname,mnum,address,photo,preHightechSchool,standard,dofleave,tcnodate,remarks,Newsyll,cstandard,adno,SlNo,caste,dofadmin from tbl_student where adno='" + SchoolManagement.rno + "'";
                SqlDataAdapter er = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                er.Fill(ds);
                DataRow dr;
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dr = ds.Tables[0].Rows[0];

                    txtname.Text = dr[0].ToString();
                    txtfname.Text = dr[1].ToString();
                    txtphno.Text = dr[2].ToString();
                    txtmail.Text = dr[3].ToString();
                    txtrgon.Text = dr[4].ToString();
                    txtocpton.Text = dr[5].ToString();
                    txtnatnalty.Text = dr[6].ToString();
                    cmbsex.Text = dr[7].ToString();
                    dtpdob.Value = Convert.ToDateTime(dr[8].ToString());
                    txtMname.Text = dr[9].ToString();
                    txtmno.Text = dr[10].ToString();
                    txtaddrs.Text = dr[11].ToString();
                    txtpresc.Text = dr[13].ToString();
                    cmbstd.Text = dr[14].ToString();
                    dtpdofleave.Value = Convert.ToDateTime(dr[15].ToString());
                    txttcdate.Text = dr[16].ToString();
                    txtremark.Text = dr[17].ToString();
                    cmbsyll.Text = dr[18].ToString();
                    cmbcstd.Text = dr[19].ToString();
                    txt_AdmisnNo.Text = dr[20].ToString();
                    SlNo = Convert.ToInt32(dr[21].ToString());
                    txt_Caste.Text = dr[22].ToString();
                    dtp_DoAd.Value = Convert.ToDateTime(dr[23].ToString());
                }
                d.con_close();

                // Select syllabus from table 

                d.con_open();
                SqlCommand cmd = new SqlCommand("sel_syllabus", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmbsyll.Items.Clear();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    cmbsyll.Items.Add(r[0].ToString());
                }
                d.con_close();

                      
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public Boolean valid()
        {
            Boolean f = true;
            if (txtname.Text == "" || txtname.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsex.Text == "" || cmbsex.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter sex", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (dtpdob.Text == "" || dtpdob.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter date of birth", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else if (txtrgon.Text == "" || txtrgon.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter religion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtnatnalty.Text == "" || txtnatnalty.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter nationality", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (txtaddrs.Text == "" || txtaddrs.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txtfname.Text == "" || txtfname.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter father's name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txtMname.Text == "" || txtMname.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter mother's name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txtocpton.Text == "" || txtocpton.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter occupation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txtmno.Text == "" || txtmno.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter mobile number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txtmail.Text == "" || txtmail.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter E-mail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}  
               
            //else if (txtphno.Text == "" || txtphno.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter landphone number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txtpresc.Text == "" || txtpresc.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter previous school", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (cmbstd.Text == "" || cmbstd.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else if (dtp_DoAd.Text == "" || dtp_DoAd.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter date of admission", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (txttcdate.Text == "" || txttcdate.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter T.C Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //else if (txtremark.Text == "" || txtremark.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter remarks", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else if (cmbcstd.Text == "" || cmbcstd.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter current standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_AdmisnNo.Text == "" || txt_AdmisnNo.Text == null)
            {
                f = false;
                MessageBox.Show("Please Enter Admission Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (dtpdofleave.Text == "" || dtpdofleave.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter date of leave", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            return f;




        }

        private void edit_Click(object sender, EventArgs e)
        {
           
            if(valid()==true)
            {
                d.con_open();

                //adno=@adno,sname=@sname,sfname=@sfname,pnum=@pnum,email=@email,
                //religion=@religion,caste=@caste,occupation=@occupation,nation=@nation,
                //sex=@sex,dob=@dob,smname=@smname,mnum=@mnum,address=@address,preschool=@preschool,
                //standard=@standard,dofleave=@dofleave,tcnodate=@tcnodate,remarks=@remarks,
                //cstandard=@cstandard,dofadmin=@dofadmin,Newsyll=@Newsyll

                SqlCommand cmd = new SqlCommand("upd_stud1", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@slno", SlNo);
                cmd.Parameters.AddWithValue("@adno", txt_AdmisnNo.Text);
                cmd.Parameters.AddWithValue("@sname", txtname.Text);
                cmd.Parameters.AddWithValue("@sfname", txtfname.Text);
                cmd.Parameters.AddWithValue("@pnum", txtphno.Text);
                cmd.Parameters.AddWithValue("@email", txtmail.Text);
                cmd.Parameters.AddWithValue("@religion", txtrgon.Text);
                cmd.Parameters.AddWithValue("@caste", txt_Caste.Text);
                cmd.Parameters.AddWithValue("@occupation", txtocpton.Text);
                cmd.Parameters.AddWithValue("@nation", txtnatnalty.Text);
                cmd.Parameters.AddWithValue("@sex ", cmbsex.Text);
                cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dtpdob.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@smname", txtMname.Text);
                cmd.Parameters.AddWithValue("@mnum ", txtmno.Text);
                cmd.Parameters.AddWithValue("@address", txtaddrs.Text);
                cmd.Parameters.AddWithValue("@preHightechSchool", txtpresc.Text);
                cmd.Parameters.AddWithValue("@standard", cmbstd.Text);
                cmd.Parameters.AddWithValue("@dofleave", DateTime.Parse(dtpdofleave.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@tcnodate", txttcdate.Text);
                cmd.Parameters.AddWithValue("@remarks", txtremark.Text);                
                cmd.Parameters.AddWithValue("@cstandard", cmbcstd.Text);
                cmd.Parameters.AddWithValue("@dofadmin", DateTime.Parse(dtp_DoAd.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@Newsyll", cmbsyll.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student details edited successfully ", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Text = "";
                txtfname.Text = "";
                txtphno.Text = "";
                txtmail.Text = "";
                txtrgon.Text = "";
                txtocpton.Text = "";
                txtnatnalty.Text = "";
                cmbsex.Text = "";
                dtpdob.Text = "";
                txtMname.Text = "";
                txtmno.Text = "";
                txtaddrs.Text = "";
                txtpresc.Text = "";
                cmbstd.Text = "";
                dtpdofleave.Text = "";                
                txttcdate.Text = "";
                txtremark.Text = "";
                cmbsyll.Text = "";
                cmbcstd.Text = "";
                dtp_DoAd.Text = "";
                txt_AdmisnNo.Text = "";
                txt_Caste.Text = "";
                d.con_close();
                this.Close();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtfname.Text = "";
            txtphno.Text = "";
            txtmail.Text = "";
            txtrgon.Text = "";
            txtocpton.Text = "";
            txtnatnalty.Text = "";
            cmbsex.Text = "";
            dtpdob.Text = "";
            txtMname.Text = "";
            txtmno.Text = "";
            txtaddrs.Text = "";
            txtpresc.Text = "";
            cmbstd.Text = "";
            dtpdofleave.Text = "";
            dtp_DoAd.Text = "";
            txttcdate.Text = "";
            txtremark.Text = "";
            cmbsyll.Text = "";
            txt_Caste.Text = "";
            cmbcstd.Text = "";

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}