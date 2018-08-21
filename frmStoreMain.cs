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
    public partial class frmStoreMain : Form
    {
        public frmStoreMain()
        {
            InitializeComponent();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mn = new Main();
            mn.Show();
            
        }

        private void frmStoreMain_Load(object sender, EventArgs e)
        {

        }

        private void tsbItem_Click(object sender, EventArgs e)
        {
            frmItem Itemm = new frmItem();
            Itemm.MdiParent = this;
            Itemm.Show();
        }

        private void tsbSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier supplier = new frmSupplier();
            supplier.MdiParent = this;
            supplier.Show();
        }

        private void tsbStock_Click(object sender, EventArgs e)
        {
            frmstock stock = new frmstock();
            stock.MdiParent = this;
            stock.Show();
        }

        private void tsbCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc");
        }

        private void tsbNotePad_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad");
        }

        private void tsbTools_ButtonClick(object sender, EventArgs e)
        {
            tsbTools.ShowDropDown();
        }

        private void tsbTools_MouseEnter(object sender, EventArgs e)
        {
            tsbTools.ShowDropDown();
        }

        private void tsbBilling_Click(object sender, EventArgs e)
        {
            frmsale sales = new frmsale();
            sales.MdiParent = this;
            sales.Show();
        }

        private void tsmSearchInvoice_Click(object sender, EventArgs e)
        {
            SalesRpt sr = new SalesRpt();
            sr.Show();
        }

        private void frmStoreMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmSupplier supplier = new frmSupplier();
                supplier.MdiParent = this;
                supplier.Show();
            }
            else if (e.KeyCode == Keys.F2)
            {
                frmItem Itemm = new frmItem();
                Itemm.MdiParent = this;
                Itemm.Show();
            }
            else if (e.KeyCode == Keys.F3)
            {
                frmstock stock = new frmstock();
                stock.MdiParent = this;
                stock.Show();
            }
            else if (e.KeyCode == Keys.F4)
            {
                frmsale sales = new frmsale();
                sales.MdiParent = this;
                sales.Show();
            }
            else if (e.KeyCode == Keys.F10)
            {
                this.Close();
            }
        }

        private void previousBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviousBills pb = new PreviousBills();
            pb.Show();
        }
    }
}
