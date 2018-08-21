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
    public partial class AddFee : Form
    {
        public AddFee()
        {
            InitializeComponent();
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            Fee fe = new Fee();
            fe.Show();
           // addotherfees aot = new addotherfees();
            //aot.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FeesCollection fsc = new FeesCollection();
            fsc.Show();
        }
    }
}
