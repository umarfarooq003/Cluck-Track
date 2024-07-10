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
    public partial class showpoultry : Form
    {
        public showpoultry()
        {
            InitializeComponent();
            salesrecord.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void showpoultry_Load(object sender, EventArgs e)
        {

        }

        private void showdata_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Name, Category, amount, SaleDate, price, Total, Description FROM addpoultry";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            salesrecord.DataSource = dataTable;

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
                string query = "SELECT Name, Category, amount, SaleDate, price, total, Description FROM addpoultry WHERE [SaleDate] BETWEEN @StartDate AND @EndDate";
                SqlCommand command = new SqlCommand(query, connection);

                // Set parameter values for the date range
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            salesrecord.DataSource = dataTable;

        }

        private void salesrecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delete selected rows from the database and DataGridView
                foreach (DataGridViewRow row in salesrecord.SelectedRows)
                {

                    string Category = Convert.ToString(row.Cells["Category"].Value);
                    string Description = Convert.ToString(row.Cells["Description"].Value);
                    int Amount = Convert.ToInt32(row.Cells["amount"].Value);

                    // Delete row from database
                    DeleteRowFromDatabase(Category, Amount, Description);

                    // Remove row from DataGridView
                    salesrecord.Rows.Remove(row);
                }

                MessageBox.Show("Selected row(s) deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteRowFromDatabase(string Category, int Amount, string Description)
        {
            // Delete row from database based on the given Idsss
            string query = "DELETE FROM addpoultry WHERE  Category=@Category and amount=@Amount and Description=@Description";

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
