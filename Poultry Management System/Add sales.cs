using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Poultry_Management_System.Login;
using static Poultry_Management_System.Dashboard;

namespace Poultry_Management_System
{
    public partial class Add_sales : Form
    {
        private string ConnectionString=Login.ConnectionString;
        decimal total;
        decimal GetValue = Dashboard.totalnoofrosters();
        decimal Gethen = Dashboard.totalnoofhens();
        decimal Getchick = Dashboard.totalnoofchicks();
        public Add_sales()
        {
            InitializeComponent();
        }

        private void Add_sales_Load(object sender, EventArgs e)
        {
            
        }

        private void addrecord_Click(object sender, EventArgs e)
        {
           
        }
        private void ClearData()
        {
            salesnametextbox.Text = "";
            descriptionbox.Text = "";
            priceperunittextbox.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            categorycombobox.SelectedItem = null;
            amounttextbox.Text = null;
        }

        private void addrecord_Click_1(object sender, EventArgs e)
        {
            string sales = salesnametextbox.Text;
            string category = categorycombobox.SelectedItem?.ToString();
            string priceText = priceperunittextbox.Text;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string description = descriptionbox.Text;
            string amounttext = amounttextbox.Text;

            if (string.IsNullOrEmpty(sales) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(priceText) || string.IsNullOrEmpty(date) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(amounttext))
            {
                MessageBox.Show("Please fill in the required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int price;
                if (!int.TryParse(priceText, out price))
                {
                    MessageBox.Show("Price must be a valid integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int amount;
                if (!int.TryParse(amounttext, out amount))
                {
                    MessageBox.Show("Amount must be a valid integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    // Calculate total by multiplying amount with price
                    decimal total = amount * price;

                    // Check if the category is not "Hen", "Roaster", or "Chick"
                    if (!(category.Equals("Hen", StringComparison.OrdinalIgnoreCase) ||
                          category.Equals("Roaster", StringComparison.OrdinalIgnoreCase) ||
                          category.Equals("Chick", StringComparison.OrdinalIgnoreCase)))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Sales ([sales], category, amount, price, total, date, description) VALUES (@sales, @category, @amount, @price, @total, @date, @description)", sqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@sales", sales);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@price", price);
                            cmd.Parameters.AddWithValue("@total", total);
                            cmd.Parameters.AddWithValue("@date", date);
                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (GetValue < decimal.Parse(amounttext) && category == "Roaster")
                    {
                        MessageBox.Show("Don't Have Enough Rosters Amount");
                    }
                    else if (Gethen < decimal.Parse(amounttext) && category == "Hen")
                    {
                        MessageBox.Show("Don't Have Enough Hens Amount");
                    }
                    else if (Getchick < decimal.Parse(amounttext) && category == "Chick")
                    {
                        MessageBox.Show("Don't Have Enough Chick Amount");
                    }

                    else
                    {
                        // Query to get the total amount from Expense for the category
                      /*  string expenseQuery = "SELECT SUM(amount) FROM Expense WHERE Category = @category";
                        using (SqlCommand expenseCommand = new SqlCommand(expenseQuery, sqlConnection))
                        {
                            expenseCommand.Parameters.AddWithValue("@category", category);
                            object expenseResult = expenseCommand.ExecuteScalar();
                            int expenseTotal = (expenseResult != DBNull.Value && expenseResult != null) ? Convert.ToInt32(expenseResult) : 0;

                            // Query to get the total amount from addpoultry for the category
                            string poultryQuery = "SELECT SUM(amount) FROM addpoultry WHERE Category = @category";
                            using (SqlCommand poultryCommand = new SqlCommand(poultryQuery, sqlConnection))
                            {
                                poultryCommand.Parameters.AddWithValue("@category", category);
                                object poultryResult = poultryCommand.ExecuteScalar();
                                int poultryTotal = (poultryResult != DBNull.Value && poultryResult != null) ? Convert.ToInt32(poultryResult) : 0;

                                // Query to get the total deaths from deathpoultry for the category
                                string deathQuery = "SELECT SUM(amount) FROM deathpoultry WHERE Category = @category";
                                using (SqlCommand deathCommand = new SqlCommand(deathQuery, sqlConnection))
                                {
                                    deathCommand.Parameters.AddWithValue("@category", category);
                                    object deathResult = deathCommand.ExecuteScalar();
                                    int deathTotal = (deathResult != DBNull.Value && deathResult != null) ? Convert.ToInt32(deathResult) : 0;

                                    // Calculate the available quantity after considering deaths
                                    int availableQuantity = poultryTotal + expenseTotal - deathTotal;

                                    // Check if the sales quantity exceeds the available quantity
                                    if (amount > availableQuantity || availableQuantity == 0)
                                    {
                                        MessageBox.Show("Sales quantity exceeds available quantity for the specified category or the available quantity is zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }*/

                        // Proceed with inserting the sales data
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Sales ([sales], category, amount, price, total, date, description) VALUES (@sales, @category, @amount, @price, @total, @date, @description)", sqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@sales", sales);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@price", price);
                            cmd.Parameters.AddWithValue("@total", total);
                            cmd.Parameters.AddWithValue("@date", date);
                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show(category + "Saved Successfully");
                        ClearData();
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void comboboxshow()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = "SELECT category FROM Scategory";

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0)) 
                            {
                                categorycombobox.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
                 sqlConnection.Close();
            }

        }

        private void categorycombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_sales_Load_1(object sender, EventArgs e)
        {
            comboboxshow();
        }

        private void descriptionbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
