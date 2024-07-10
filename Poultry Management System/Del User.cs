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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Poultry_Management_System
{
    public partial class Del_User : Form
    {
        public Del_User()
        {
            InitializeComponent();
        }

        private void Del_User_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT email as username,password as pass FROM login where email!='admin'";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                delusershow.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void delusershow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = this.delusershow.Rows[e.RowIndex];

                // Check if the cell values are not null before accessing them
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    // Directly assign cell values to text boxes without conversion if they are already strings
                    username.Text = row.Cells[0].Value.ToString();
                    pass.Text = row.Cells[1].Value.ToString();
                }
                else
                {
                    // Handle case where cell values are null to prevent exceptions
                    // For example, set text boxes to empty strings
                    username.Text = "";
                    pass.Text = "";
                }
            }

        }

        private void deluser_Click(object sender, EventArgs e)
        {
            string uname = username.Text;
            string password = pass.Text;
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(uname))
            {
                MessageBox.Show("Please filled the TextBox");
            }
            else
            {
                try
                {
                    using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
                    {
                        sqlconnection.Open();
                        string Query = "delete from login where email = @uname";
                        SqlCommand cmd = new SqlCommand(Query, sqlconnection);
                        cmd.Parameters.AddWithValue("@uname", uname);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("login deleted");
                        ClearData();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearData()
        {
            pass.Text = "";
            username.Text = "";
        }
    }
}
