using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Poultry_Management_System.Login;

namespace Poultry_Management_System
{
    public partial class MainForm : Form
    {
        string role;
        string type = "user";
        private const int AnimationDuration = 500;
        private Timer slideTimer;
        private int startY;
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

   
    
    public MainForm()
        {
            InitializeComponent();
            
           
        }
       
        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new Dashboard());
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to sure to Exit?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }

        private void addExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
        }

     
        private void deathPoultryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new DeathPoultry());
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
                loadform(new SalesCategory());
            }
        

        private void expensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
                loadform(new ExpenseCategory());
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
           
                loadform(new Show_Sales());
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                loadform(new Show_Expense());
        }

        private void deathPoultryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            
            loadform(new Show_Death_poultry());
        }

        private void addSalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
                loadform(new Add_sales());
        }

        private void addExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
                loadform(new addexpense());
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

    

        private void addUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            loadform(new Add_User());
        }

        private void delUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            loadform(new Del_User());
        }

        private void poultryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new Add_poultry());
        }

        private void chicksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new Diff_Form());
        }

        private void poultryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            loadform(new showpoultry());
        }

        private void initialReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (role == type)
            {
                MessageBox.Show("You don't have Permission to do this.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                loadform(new Report());
        }

        private void finalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                loadform(new FinalReport());
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                loadform(new Reset());
        }

      
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
