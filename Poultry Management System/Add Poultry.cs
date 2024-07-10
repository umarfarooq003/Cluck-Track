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
    public partial class Add_poultry : Form
    {
        private string ConnectionString = Login.ConnectionString;
        public Add_poultry()
        {
            InitializeComponent();
        }

        private void Add_poultry_Load(object sender, EventArgs e)
        {
            comboboxshow();
        }
        private void ClearData()
        {
            salesnametextbox.Text = "";
            descriptionbox.Text = "";
            amomounttextbox.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            categorycombobox.SelectedItem = null;
            textBox1.Text = "";
        }

        private void addrecord_Click(object sender, EventArgs e)
        {
            

        }

        private void categorycombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public void comboboxshow()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = "SELECT category FROM pcategory";

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

        private void button1_Click(object sender, EventArgs e)
        {
            string sales = salesnametextbox.Text;
            string category = categorycombobox.SelectedItem?.ToString();
            string amount = amomounttextbox.Text;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string description = descriptionbox.Text;
            string price = textBox1.Text;

            if (string.IsNullOrEmpty(sales) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(date) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(amount))
            {
                MessageBox.Show("Please fill in the required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate amount and price inputs
            if (!int.TryParse(amount, out int parsedAmount) || parsedAmount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(price, out int parsedPrice) || parsedPrice <= 0)
            {
                MessageBox.Show("Please enter a valid positive price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculate total price
            int totalPrice = parsedAmount * parsedPrice;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO addpoultry ([Name], Category, amount, SaleDate, Description, price, Total) VALUES (@sales, @category, @amount, @date, @description, @price, @total)", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@sales", sales);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@amount", parsedAmount);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@price", parsedPrice);
                        cmd.Parameters.AddWithValue("@total", totalPrice); // Store total in the database
                        cmd.ExecuteNonQuery();
                    }

                    ClearData();
                    MessageBox.Show( category +"Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
