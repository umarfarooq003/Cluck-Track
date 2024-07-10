using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Poultry_Management_System.Login;

namespace Poultry_Management_System
{
    public partial class Add_User : Form
    {
        public Add_User()
        {
            InitializeComponent();
        }

        private void Add_User_Load(object sender, EventArgs e)
        {

        }

        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
        }

        private void adduser_Click(object sender, EventArgs e)
        {
            string uname = username.Text;
            string password = pass.Text;
            string type = "user";
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(uname))
            {
                MessageBox.Show("Please fill in the TextBox");
            }
            else if (!IsValidEmail(uname))
            {
                MessageBox.Show("Please enter a valid email address");
            }
            else
            {
                try
                {
                    using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
                    {
                        sqlconnection.Open();
                        string Query = "insert into login (email,password,type) values (@uname,@password,@type)";
                        SqlCommand cmd = new SqlCommand(Query, sqlconnection);
                        cmd.Parameters.AddWithValue("@uname", uname);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User Added Successfully");
                        ClearData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT email as Login, password as pass FROM login WHERE type ='user'";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                dataGridView1.DataSource = dataTable;
            }

        }
        

        private void ClearData()
        {
            pass.Text = "";
            username.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
