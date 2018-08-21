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
    public partial class ExamForm : Form
    {
        public ExamForm()
        {
            InitializeComponent();
        }
        private void butExam_Click(object sender, EventArgs e)
        {
            Exam exm = new Exam();
            exm.Show();
        }
        private void butQstnPrpsn_Click(object sender, EventArgs e)
        {
            ExamTypes qpp = new ExamTypes();
            qpp.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddMarkUI amu = new AddMarkUI();            
            amu.Show();
        }
    }
}