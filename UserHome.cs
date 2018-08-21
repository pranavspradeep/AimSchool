using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class UserHome : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public UserHome()
        {
            InitializeComponent();
        }

        private void UserHome_Load(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            BusForm b = new BusForm();
            b.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Fess fs = new Fess();
            fs.Show();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            ExamForm ef = new ExamForm();
            ef.Show();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            DailytransactionReport dr = new DailytransactionReport();
            dr.Show();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            ExpenseForm ef = new ExpenseForm();
            ef.Show();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

        }
    }
}
