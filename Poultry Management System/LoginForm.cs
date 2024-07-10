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
    public partial class LoginForm : Form
    {
        private string ConnectionString=Login.ConnectionString;
        
        public LoginForm()
        {
            InitializeComponent();
        }


     

       
        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
        }

        private void ClearData()
        {
            USERNAMEBOX.Text = null;
            PASSWORDBOX.Text = null;
        }

        private void Fpasswordlink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (Sendcode sendcode = new Sendcode())
                sendcode.ShowDialog();
            Application.Exit();
        }

        private void loginbutton_Click_1(object sender, EventArgs e)
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
            if (UserExist(username))
            {
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

            else
            {
                MessageBox.Show("User Does not exist.");
            }
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

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            PASSWORDBOX.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
