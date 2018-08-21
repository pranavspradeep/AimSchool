using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class Main : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        public Main()
        {
            InitializeComponent();
        }
        private void Main_emp_add_Click(object sender, EventArgs e)
        {
            Addteacher ad = new Addteacher();
            ad.MdiParent = this;
            ad.Show();
        }
        private void Main_emp_edit_Click(object sender, EventArgs e)
        {
            Addteacher ad1 = new Addteacher();
            ad1.MdiParent = this;
            ad1.Show();
        }
        private void Main_emp_delete_Click(object sender, EventArgs e)
        {
            DeleteEmp del = new DeleteEmp();
            del.Show();
        }               
        private void Main_cls_assign_Click(object sender, EventArgs e)
        {            
        }
        private void Main_cls_edit_Click(object sender, EventArgs e)
        {
            classes cs1 = new classes();
            cs1.MdiParent = this;
            cs1.Show();
        }
        private void Main_trns_add_Click(object sender, EventArgs e)
        {
            route rt = new route();
            rt.MdiParent = this;
            rt.Show();
        }
        private void Main_trans_point_Click(object sender, EventArgs e)
        {
            Routepoint rt1 = new Routepoint();
            rt1.MdiParent = this;
            rt1.Show();
        }

        private void Main_trans_fair_Click(object sender, EventArgs e)
        {
            Routepoint rt2 = new Routepoint();
            rt2.MdiParent = this;
            rt2.Show();
        }
        private void Main_fee_assign_Click(object sender, EventArgs e)
        {
            Fee tf = new  Fee();
            tf.MdiParent = this;
            tf.Show();
        }
        private void Main_fee_collect_Click(object sender, EventArgs e)
        {
            //Tuitionfees tf1 = new Tuitionfees();
            //tf1.MdiParent = this;
            //tf1.Show();
            FeeCollection fc = new FeeCollection();
            fc.MdiParent = this;
            fc.Show();
        }
        private void Main_fee_payment_Click(object sender, EventArgs e)
        {
            SearchFees sf = new SearchFees();
            sf.MdiParent = this;
            sf.Show();

        }
        private void Select_School()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select SchoolName from tbl_School", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                SchoolManagement.SchoolName = dr[0].ToString();
            }
        }
        private void Dm_Chk()
        {
            int cnt=0;
            SqlDataAdapter da = new SqlDataAdapter("Select CT from tbl_Count", d.con);
            DataSet ds = new DataSet();
            DataRow dr;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                cnt = Convert.ToInt32(dr[0].ToString());
                if (Convert.ToInt32(dr[0].ToString()) >= 200)
                {
                    MessageBox.Show("Please contact software vendor ");
                    Application.Exit();
                }

            }
            else
            {
                cnt = cnt + 1;
                d.con_open();
                SqlCommand cmd = new SqlCommand("Insert into tbl_Count Values(" + cnt + ")", d.con);
                cmd.ExecuteNonQuery();
                d.con_close();
            }

          
            d.con_open();
            SqlCommand cmd1 = new SqlCommand("Update tbl_Count set CT=Ct+1", d.con);
            cmd1.ExecuteNonQuery();
            d.con_close();
            
        }
        private void Main_Load(object sender, EventArgs e)
        {
            privilege();
            Dm_Chk();
            /*if (SchoolManagement.UserType != "Admin")
            {
                privilege();
            }
            else
            {
                for (int i = 0; i <= 14; i++)
                {
                    if(i != 10)                    
                    menuStrip1.Items[i].Visible = true;

                    for (int j = 0; j <= 22; j++)
                    {
                        if (j != 10 & j != 11 & j != 14 & j != 15 & j != 18 & j != 19)
                            toolStrip1.Items[j].Visible = true;
                    }
                }
                
            }

            Select_School();*/
       
        }
      
        public void privilege()
        {
            menuStrip1.Items[0].Visible = true;
            toolStrip1.Items[0].Visible = true;
            toolStrip1.Items[1].Visible = true;
            menuStrip1.Items[1].Visible = true;
            toolStrip1.Items[2].Visible = true;
            toolStrip1.Items[3].Visible = true;
            menuStrip1.Items[2].Visible = true;
            toolStrip1.Items[4].Visible = true;
            toolStrip1.Items[5].Visible = true;
            menuStrip1.Items[3].Visible = true;
            toolStrip1.Items[6].Visible = true;
            toolStrip1.Items[7].Visible = true;
            menuStrip1.Items[4].Visible = true;
            toolStrip1.Items[8].Visible = true;
            toolStrip1.Items[9].Visible = true;
            menuStrip1.Items[6].Visible = true;
            menuStrip1.Items[5].Visible = true;
            menuStrip1.Items[7].Visible = true;
            toolStrip1.Items[12].Visible = true;
            toolStrip1.Items[13].Visible = true;
            menuStrip1.Items[8].Visible = true;
            toolStrip1.Items[16].Visible = true;
            toolStrip1.Items[17].Visible = true;
            menuStrip1.Items[13].Visible = true;
            menuStrip1.Items[11].Visible = true;
            toolStrip1.Items[20].Visible = true;
            toolStrip1.Items[21].Visible = true;
            menuStrip1.Items[12].Visible = true;
            menuStrip1.Items[9].Visible = true; 

            /*
            string s = "SELECT privilege FROM tbl_privilege where userid='" + SchoolManagement.empno + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
              
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                   
                    dr = ds.Tables[0].Rows[i];
                    if (Convert.ToInt32(dr[0].ToString()) == 1)// Employee
                    {
                      
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 2)//student
                    {
                       

                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 3)//class
                    {
                       
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 4)//transportation
                    {
                      
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 5)// fees management
                    {
                       
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 6)//teacher activities
                    {
                       
                        //toolStrip1.Items[].Visible = true;
                        //toolStripButton4.Visible = true;
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 7)//goto classes
                    {
                        
                        //toolStrip1.Items[7].Visible = true;
                        //toolStrip1.Items[4].Visible = true;
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 8)//Exam
                    {
                       
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 9)// progress report
                    {
                       
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 10)//performance chart
                    {
                        //menuStrip1.Items[10].Visible = true;
                        //toolStrip1.Items[18].Visible = true;
                        //toolStrip1.Items[19].Visible = true;
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 11)//tools
                    {
                                              
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 12)//settings
                    {
                        
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 13)//store management
                    {
             
                        
                    }
                    if (Convert.ToInt32(dr[0].ToString()) == 14)//report
                    {
                                               
                    }
                }
            }*/
        }
        private void Main_goto_attendnce_Click(object sender, EventArgs e)
        {
            Attendstatus at = new Attendstatus();
            at.MdiParent = this;
            at.Show();            
        }
        private void Main_exm_exmschdle_Click(object sender, EventArgs e)
        {
            Exam ex = new Exam();
            ex.MdiParent = this;
            ex.Show();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.MdiParent = this;
            s.Show();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.MdiParent = this;
            em.Show();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ClassRoom c = new ClassRoom();
            c.MdiParent = this;
            c.Show();
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            BusForm bfrm = new BusForm();
            bfrm.MdiParent = this;
            bfrm.Show();
        }
        private void marksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkSheetrpt msr = new MarkSheetrpt();
            msr.MdiParent = this;
            msr.Show();
        }
        private void remarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //loginteacher lt = new loginteacher();
            //lt.MdiParent = this;
            //lt.Show();
        }
        private void userSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adminsettings ads = new Adminsettings();
            ads.MdiParent = this;
            ads.Show();  
        }
        private void addSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectEntry se = new SubjectEntry();
            se.MdiParent = this;
            se.Show();
        }
        private void assignSubjectForAClassToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            SubjectEntryForClasses sec = new SubjectEntryForClasses();
            sec.MdiParent = this;
            sec.Show();
        }
        private void deleteSubjectFromAClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectEntryForClasses sec = new SubjectEntryForClasses();
            sec.MdiParent = this;
            sec.Show();
        }
        private void deleteSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectEntry se = new SubjectEntry();
            se.MdiParent = this;
            se.Show();
        }
        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewStudent ns = new NewStudent();
            ns.MdiParent = this;
            ns.Show();
        }
        private void editStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_view sv = new Student_view();
            sv.MdiParent = this;
            sv.Show();
        }

        private void deleteStudentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteStudent ds = new DeleteStudent();
            ds.MdiParent = this;
            ds.Show();
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_view sv1 = new Student_view();
            sv1.MdiParent = this;
            sv1.Show();
        }
        private void assignClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            classes css = new classes();
            css.MdiParent = this;
            css.Show();
        }
        private void editClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            classes css = new classes();
            css.MdiParent = this;
            css.Show();
        }
        private void deleteClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            classes css = new classes();
            css.MdiParent = this;
            css.Show();
        }
        private void asignTecherToAClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assignteachertoclass atc = new Assignteachertoclass();
            atc.MdiParent = this;
            atc.Show();
        }
        private void editTeacherInAClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assignteachertoclass atc = new Assignteachertoclass();
            atc.MdiParent = this;
            atc.Show();
        }
        private void deleteTeacherFromTheClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assignteachertoclass atc = new Assignteachertoclass();
            atc.MdiParent = this;
            atc.Show();
        }
        private void studentDivisionTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stddivision stdiv = new stddivision();
            stdiv.MdiParent = this;
            stdiv.Show();
        }
        private void Main_trans_assign_Click(object sender, EventArgs e)
        {
            Assignroutetostud ars = new Assignroutetostud();
            ars.MdiParent = this;
            ars.Show();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void feesPaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //formaccouncrstl fa = new formaccouncrstl();
            //fa.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FeesForm ff = new FeesForm();
            ff.MdiParent = this;
            ff.Show();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStoreMain stm = new frmStoreMain();
            stm.Show();
        }

        private void storeManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStoreMain stm = new frmStoreMain();
            stm.Show();
        }

        private void studentTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stddivision stdivn = new stddivision();
            stdivn.MdiParent = this;
            stdivn.Show();
        }

        private void textpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad");
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc");
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void tsb_Feetype_Click(object sender, EventArgs e)
        {
            Otherfees ofs = new Otherfees();
            ofs.MdiParent = this;
            ofs.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Main_exm_mrkentry_Click(object sender, EventArgs e)
        {
            AddMarkUI Markentry = new AddMarkUI();
            Markentry.MdiParent = this;
            Markentry.Show();
        }

        private void Main_exm_qprep_Click(object sender, EventArgs e)
        {
            ExamTypes qpp = new ExamTypes();
            qpp.MdiParent = this;
            qpp.Show();
        }

        private void entryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GardeEntryForm gef = new GardeEntryForm();
            gef.MdiParent = this;
            gef.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkSheetrpt msr1 = new MarkSheetrpt();
            msr1.MdiParent = this;
            msr1.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

            MarkSheetrpt msr2 = new MarkSheetrpt();
            msr2.MdiParent = this;
            msr2.Show();
        }

        private void classWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceReport ar = new AttendanceReport();
            ar.MdiParent = this;
            ar.Show();
        }

        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            lgn.Show();
            this.Close();            
        }

        private void studentPromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Promotion sp = new Student_Promotion();
            sp.MdiParent = this;
            sp.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            ExamForm efm = new ExamForm();
            efm.MdiParent = this;
            efm.Show();
        }
        private void progressReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MarkSheetrpt msr4 = new MarkSheetrpt();
            msr4.MdiParent = this;
            msr4.Show();
        }

        private void smsToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Smstoparents smstoparents = new Smstoparents();
            smstoparents.MdiParent = this;
            smstoparents.Show();
        }
    }
}