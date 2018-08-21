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
    public partial class AdminHome : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Addteacher at = new Addteacher();
            at.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DailytransactionReport dr = new DailytransactionReport();
            dr.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            AccountBalanceForm ac = new AccountBalanceForm();
            ac.Show();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            frmaccountdetails fd = new frmaccountdetails();
            fd.Show();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            BusForm bf = new BusForm();
            bf.Show();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            BusForm bf = new BusForm();
            bf.Show();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            AddFee af = new AddFee();
            af.Show();
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            ClassRoom cr = new ClassRoom();
            cr.Show();
        }
    }
}
