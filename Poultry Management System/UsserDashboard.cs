using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poultry_Management_System
{
    public partial class UsserDashboard : Form
    {
        public UsserDashboard()
        {
            InitializeComponent();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new Dashboard());
     
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();

        }

        private void addExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addSalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadform(new Add_sales());
        }

        private void addExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new addexpense());
        }

        private void poultryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new Add_poultry());
        }

        private void chicksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new Diff_Form());
        }

        private void deathPoultryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new DeathPoultry());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to sure to Exit?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }
    }
}
