using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Poultry_Management_System
{
    public partial class ConnectionChecKform : Form
    {

        public static string ConnectionString = "Data Source=DESKTOP-5BG8Q2I;Initial Catalog=poultry;Integrated Security=True;Encrypt=False";
        public ConnectionChecKform()
        {
            InitializeComponent();
        }

        private void connectionbtn_Click(object sender, EventArgs e)
        {
            MySqlConnection connection=new MySqlConnection(ConnectionString);

            try
            {
                connection.Open();
                MessageBox.Show("Connection to MySQL database successful!");

                // Load data into the DataGridView
                
            }
            catch (MySqlException ex)
            {
                string errorMessage = "MySQL Error: ";

                // Determine specific MySQL error code
                switch (ex.Number)
                {
                    case 0:
                        errorMessage += "Cannot connect to server.";
                        break;
                    case 1045:
                        errorMessage += "Invalid username/password.";
                        break;
                    default:
                        errorMessage += ex.Message.ToString();
                        break;
                }

                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ConnectionChecKform_Load(object sender, EventArgs e)
        {
            loaddataintogrid();
        }
        

        private void loaddataintogrid()
        {
            try
            {
                // Query to select all data from the 'login' table
                string query = "SELECT * FROM login";
                MySqlConnection connection = new MySqlConnection(ConnectionString);

                // Create MySqlCommand to execute the query
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Create DataAdapter to retrieve the data
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);

                // Create a DataTable to hold the query results
                DataTable dataTable = new DataTable();

                // Fill the DataTable with data from the DataAdapter
                dataAdapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
