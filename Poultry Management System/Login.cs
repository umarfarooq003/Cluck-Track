using ActiveUp.Net.Groupware.vCalendar;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poultry_Management_System
{

    public partial class Login : Form
    {
        public static string ConnectionString= "Server=tcp:faaez.database.windows.net,1433;Initial Catalog=faaez;Persist Security Info=False;User ID=pms;Password=Faaezabdullahmusa!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
         
       // public static string ConnectionString = "Data Source=DESKTOP-5BG8Q2I;Initial Catalog=poultry;Integrated Security=True;Encrypt=False";
       
        public Login()
        {
            InitializeComponent();
           
           

        }

        private void Fpasswordlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (Sendcode sendcode = new Sendcode())
            sendcode.ShowDialog();
            Application.Exit();

        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            string username = USERNAMEBOX.Text;
            string password = PASSWORDBOX.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in both fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsValidEmail(username) && username != "admin")
            {
                MessageBox.Show("Invalid email format. Use @ and gmail.com", "Email Syntax Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string query = "SELECT email, password, type FROM login WHERE email = @Username AND password = @Password";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Username", username);
                        sqlCommand.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userType = reader["type"].ToString();
                                if (userType == "admin")
                                {
                                    Hide();
                                    using (MainForm mainMenu = new MainForm())
                                    {
                                        mainMenu.ShowDialog();
                                    }
                                }
                                else if (userType == "user")
                                {
                                    Hide();
                                    using (UsserDashboard userDashboard = new UsserDashboard())
                                    {
                                        userDashboard.ShowDialog();
                                    }
                                }
                                Application.Exit();
                                ClearData();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
        }

        private bool UserExist(string Username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM login WHERE email = @UserEmail";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserEmail", Username);

                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking user existence: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
         private void ClearData()
        {
            USERNAMEBOX.Text = null;
            PASSWORDBOX.Text = null;
            SuggestionLbl.Text = null;
        }

        private void ClearLabel()
        {
            SuggestionLbl.Text = null;
        }

        private void USERNAMEBOX_TextChanged_1(object sender, EventArgs e)
        {
            ClearLabel();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Checkbox is checked, hide password characters
                PASSWORDBOX.UseSystemPasswordChar = false;
            }
            else
            {
                // Checkbox is unchecked, show password characters
                PASSWORDBOX.UseSystemPasswordChar = true;
            }
        }
    }
}
