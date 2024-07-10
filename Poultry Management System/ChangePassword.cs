using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Poultry_Management_System.Sendcode;
using static Poultry_Management_System.Login;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace Poultry_Management_System
{
    public partial class ChangePassword : Form
    {
        private string email;
        private string ConnectionString=Login.ConnectionString;
        public ChangePassword()
        {
            InitializeComponent();
        }
        public ChangePassword(string userEmail)
        {
            InitializeComponent();
            email = userEmail.Trim();
        }
        private void ClearData()
        {
            PasswordBox.Text = "";
            NewPasswordBox.Text = "";
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Checkbox is checked, hide password characters
                NewPasswordBox.UseSystemPasswordChar = false;
                PasswordBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Checkbox is unchecked, show password characters
                NewPasswordBox.UseSystemPasswordChar = true;
                PasswordBox.UseSystemPasswordChar = true;
            }
        }

        private void Changepasswordbtn_Click_1(object sender, EventArgs e)
        {
            string newPassword = NewPasswordBox.Text;
            if (PasswordBox.Text == newPassword)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                    {
                        sqlConnection.Open();
                        string query = "UPDATE login SET password = @NewPassword WHERE email = @Email";
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                            sqlCommand.Parameters.AddWithValue("@Email", email);

                            int rowsAffected = sqlCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Password changed successfully.");
                                this.Hide();
                                using (LoginForm login = new LoginForm())
                                    login.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No user found with the provided email.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Password does not match.");
            }

            ClearData();
        }

        private void Closebtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            using (LoginForm login = new LoginForm())
                login.ShowDialog();
            this.Close();
        }
    }
    }

