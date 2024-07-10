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
    public partial class Show_Expense : Form
    {
        private string ConnectionString = Login.ConnectionString;
        public Show_Expense()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
            expenserecord.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
        }
        private void LoadDataIntoComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT category FROM Expense"; // Modify query according to your database structure
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        expensecombobox.Items.Add(reader["category"].ToString());
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

            try
            {
                // Parse the dates from text boxes
                if (!DateTime.TryParse(fromdate.Text, out DateTime startDate) || !DateTime.TryParse(todate.Text, out DateTime endDate))
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

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT [expense name], category, amount, date, description FROM Expense WHERE (@Category IS NULL OR category = @Category) AND [date] BETWEEN @StartDate AND @EndDate";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Add category parameter only if a category is selected
                    if (!string.IsNullOrEmpty(expensecombobox.Text))
                    {
                        command.Parameters.AddWithValue("@Category", expensecombobox.Text);
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

                expenserecord.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void ClearData()
        {
            
            expensecombobox.SelectedItem = null;
        }

        private void showdata_Click(object sender, EventArgs e)
        {
            {
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT [expense name],category,amount,date,description FROM Expense ";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                expenserecord.DataSource = dataTable;
            }
        }

        private void Show_Expense_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'poultryDataSet.Expense' table. You can move, or remove it, as needed.
            LoadDataIntoComboBox();

        }

        private void expenserecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteButton.Enabled = expenserecord.SelectedRows.Count > 0;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Prompt user for confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delete selected rows from the database and DataGridView
                foreach (DataGridViewRow row in expenserecord.SelectedRows)
                {
                    string Expensename = Convert.ToString(row.Cells["expense name"].Value);
                    string Category= Convert.ToString(row.Cells["category"].Value); 
                    string Description = Convert.ToString(row.Cells["description"].Value); 
                     int    Amount = Convert.ToInt32(row.Cells["amount"].Value); 

                    // Delete row from database
                    DeleteRowFromDatabase(Expensename, Category, Amount,Description);

                    // Remove row from DataGridView
                    expenserecord.Rows.Remove(row);
                }

                MessageBox.Show("Selected row(s) deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteRowFromDatabase(string Expensename,string Category,int Amount,string Description)
        {
            // Delete row from database based on the given Idsss
            string query = "DELETE FROM Expense WHERE [expense name] = @Expensename and category=@Category and amount=@Amount and description=@Description"; 

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Expensename", Expensename);
                command.Parameters.AddWithValue("@Category", Category);
                command.Parameters.AddWithValue("@Amount", Amount);
                command.Parameters.AddWithValue("@Description", Description);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
