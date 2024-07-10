using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Poultry_Management_System.Login;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Poultry_Management_System
{
    public partial class Reset : Form
    {
        public Reset()
        {
            InitializeComponent();
            Credentialpanel.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Credentialpanel.Visible=true;
        }

        

        private void Reset_Load(object sender, EventArgs e)
        {
            
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            string adminUsername = USERNAMEBOX.Text;
            string adminPassword = PASSWORDBOX.Text;

            if (string.IsNullOrEmpty(adminUsername) || string.IsNullOrEmpty(adminPassword))
            {
                MessageBox.Show("Please fill in the required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check admin login
            string adminType = "";
            using (SqlConnection loginConnection = new SqlConnection(ConnectionString))
            {
                loginConnection.Open();
                string loginQuery = "SELECT type FROM login WHERE email = @adminUsername AND password = @adminPassword";
                using (SqlCommand loginCmd = new SqlCommand(loginQuery, loginConnection))
                {
                    loginCmd.Parameters.AddWithValue("@adminUsername", adminUsername);
                    loginCmd.Parameters.AddWithValue("@adminPassword", adminPassword);
                    adminType = (string)loginCmd.ExecuteScalar(); // Retrieve the type
                }
            }

            // If admin login is successful and type is admin
            if (!string.IsNullOrEmpty(adminType) && adminType == "admin")
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete all tables?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If user confirms, delete all tables
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                    {
                        sqlConnection.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Expense", sqlConnection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM addpoultry", sqlConnection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM chicktoadult", sqlConnection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM deathpoultry", sqlConnection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Sales", sqlConnection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        ClearData();
                        MessageBox.Show("Data from tables deleted successfully");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid admin credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearData()
        {
            USERNAMEBOX.Text = "";
            PASSWORDBOX.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            PASSWORDBOX.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Credentialpanel.Visible=false;
        }
    }
}
