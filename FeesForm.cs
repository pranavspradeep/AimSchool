using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class FeesForm : Form
    {
        public FeesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fee addfees = new Fee();
            addfees.Show();
        }

        private void butQstnPrpsn_Click(object sender, EventArgs e)
        {
            addotherfees adfee = new addotherfees();
            adfee.Show();
        }

        private void butExam_Click(object sender, EventArgs e)
        {
            Tuitionfees tutnfee = new Tuitionfees();
            tutnfee.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FeeCollection feecol = new FeeCollection();
            feecol.Show();
        }
    }
}