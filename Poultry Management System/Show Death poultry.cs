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
    public partial class Show_Death_poultry : Form
    {
        private string ConnectionString = Login.ConnectionString;
        public Show_Death_poultry()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
            expenserecord.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
           
        }

        private void LoadDataIntoComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT distinct category FROM deathpoultry"; // Modify query according to your database structure
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Deathcombobox.Items.Add(reader["category"].ToString());
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data into the ComboBox: " + ex.Message);
            }
        }


        private void searchbutton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "Select category,amount ,deathdate,causeofdeath from deathpoultry where category=@Category";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Category", Deathcombobox.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            expenserecord.DataSource = dataTable;
        }

        private void showdata_Click(object sender, EventArgs e)
        {

            {
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "Select category AS Category,amount AS Price,deathdate as Date,causeofdeath AS Description from deathpoultry";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                expenserecord.DataSource = dataTable;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Show_Death_poultry_Load(object sender, EventArgs e)
        {

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delete selected rows from the database and DataGridView
                foreach (DataGridViewRow row in expenserecord.SelectedRows)
                {

                    string Category = Convert.ToString(row.Cells["Category"].Value);
                    string Description = Convert.ToString(row.Cells["Description"].Value);
                    int Amount = Convert.ToInt32(row.Cells["Price"].Value);

                    // Delete row from database
                    DeleteRowFromDatabase(Category, Amount, Description);

                    // Remove row from DataGridView
                    expenserecord.Rows.Remove(row);
                }

                MessageBox.Show("Selected row(s) deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void expenserecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DeleteRowFromDatabase( string Category, int Amount, string Description)
        {
            // Delete row from database based on the given Idsss
            string query = "DELETE FROM deathpoultry WHERE  category=@Category and amount=@Amount and causeofdeath=@Description";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Category", Category);
                command.Parameters.AddWithValue("@Amount", Amount);
                command.Parameters.AddWithValue("@Description", Description);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
