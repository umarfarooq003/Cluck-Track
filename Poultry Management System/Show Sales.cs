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
    public partial class Show_Sales : Form
    {
        private string ConnectionString=Login.ConnectionString;
        
        public Show_Sales()
        {
            InitializeComponent();
            salesrecord.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
        }

        

        private void searchbutton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DateTime startDate;
            DateTime endDate;

            // Parse the dates from text boxes and validate
            if (!DateTime.TryParse(fromdate.Text, out startDate) || !DateTime.TryParse(todate.Text, out endDate))
            {
                MessageBox.Show("Invalid date format. Please enter valid dates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if start date is after end date
            if (startDate > endDate)
            {
                MessageBox.Show("Start date must be before end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if end date is greater than today's date
            if (endDate > DateTime.Now.Date)
            {
                MessageBox.Show("End date cannot be greater than today's date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT sales, category, price, date, description FROM Sales WHERE (@Category IS NULL OR category = @Category) AND [date] BETWEEN @StartDate AND @EndDate";
                SqlCommand command = new SqlCommand(query, connection);

                // Add category parameter only if a category is selected
                if (!string.IsNullOrEmpty(salescombobox.Text))
                {
                    command.Parameters.AddWithValue("@Category", salescombobox.Text);
                }
                else
                {
                    command.Parameters.AddWithValue("@Category", DBNull.Value);
                }

                // Set parameter values for the date range
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            salesrecord.DataSource = dataTable;

        }

        private void ClearData()
        { 
            salescombobox.SelectedItem = null;
        }

        private void Show_Sales_Load(object sender, EventArgs e)
        {
            LoadDataIntoComboBox();
        }

        private void showdata_Click(object sender, EventArgs e)
        {
            
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT sales,category,price,date,description FROM Sales";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            salesrecord.DataSource = dataTable;
        }

        

        private void LoadDataIntoComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT distinct category FROM Sales"; // Modify query according to your database structure
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        salescombobox.Items.Add(reader["category"].ToString());
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data into the ComboBox: " + ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delete selected rows from the database and DataGridView
                foreach (DataGridViewRow row in salesrecord.SelectedRows)
                {
                    string sales = Convert.ToString(row.Cells["sales"].Value);
                    string Category = Convert.ToString(row.Cells["category"].Value);
                    string Description = Convert.ToString(row.Cells["description"].Value);
                    int Amount = Convert.ToInt32(row.Cells["price"].Value);

                    // Delete row from database
                    DeleteRowFromDatabase(sales, Category, Amount, Description);

                    // Remove row from DataGridView
                    salesrecord.Rows.Remove(row);
                }

                MessageBox.Show("Selected row(s) deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DeleteRowFromDatabase(string sales, string Category, int Amount, string Description)
        {
            // Delete row from database based on the given Idsss
            string query = "DELETE FROM Sales WHERE sales = @sales and category=@Category and price=@Amount and description=@Description";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@sales", sales);
                command.Parameters.AddWithValue("@Category", Category);
                command.Parameters.AddWithValue("@Amount", Amount);
                command.Parameters.AddWithValue("@Description", Description);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
