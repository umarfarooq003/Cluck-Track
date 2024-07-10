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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Perform any asynchronous initialization tasks
            await InitializeAsync();

            // Once initialization is complete, open the new form
            OpenNewForm();
        }

        private async Task InitializeAsync()
        {
            // Simulate database operation asynchronously
            await Task.Delay(1000); // Example delay, replace with actual database query or initialization

            // Other initialization tasks can be performed here asynchronously
        }
        private void OpenNewForm()
        {
            this.Hide();
            using (LoginForm login = new LoginForm())
                login.ShowDialog();
            Application.Exit();

            
        }

    }
}
