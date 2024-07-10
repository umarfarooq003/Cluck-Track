using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Poultry_Management_System.Login;

namespace Poultry_Management_System
{
    public partial class addexpense : Form
    {
        private string ConnectionString=Login.ConnectionString;
        public addexpense()
        {
            InitializeComponent();
        }

        private void ADD_Expense_Load(object sender, EventArgs e)
        {
            comboboxshow();
        }

        private void addrecordbutton_Click(object sender, EventArgs e)
        {
        }
        private void ClearData()
        {
            expensetextbox.Text = "";
            descriptionbox.Text = "";
            pricetextbox.Text = "";
            dateTimePicker.Value = DateTime.Now;
            expensecombobox.SelectedItem = null;
            priceperunittextbox.Text= null;
        }

        private void expensecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void comboboxshow()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = "SELECT category FROM expensecategory";

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                expensecombobox.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
                sqlConnection.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addrecordbutton_Click_1(object sender, EventArgs e)
        {
            string expense = expensetextbox.Text;
            string category = expensecombobox.SelectedItem?.ToString(); // Use null conditional operator
            string amount = pricetextbox.Text;
            string date = dateTimePicker.Value.ToString("yyyy-MM-dd");
            string description = descriptionbox.Text;
            string price=priceperunittextbox.Text;

            decimal total=Convert.ToDecimal(price) * Convert.ToDecimal(amount);

            // Check if category is null or empty
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please Select a category from the Category ComboBox");
                return;
            }

            // Check if expense, price, or date is null or empty
            if (string.IsNullOrEmpty(expense) || string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(date) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill in the required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if price is zero or negative
            if (!int.TryParse(amount, out int priceValue) || priceValue <= 0)
            {
                MessageBox.Show("Price must be a positive non-zero value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Expense ([expense name], category, amount,price,total, date, description) VALUES (@expenseName, @category, @amount,@price,@total, @date, @description)", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@expenseName", expense);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@amount", priceValue);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@description", description);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show( category +" Saved Successfully");
                }

                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pricetextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
