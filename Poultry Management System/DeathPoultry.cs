using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Poultry_Management_System.Login;
using static Poultry_Management_System.Dashboard;

namespace Poultry_Management_System
{
    public partial class DeathPoultry : Form
    {
        private string ConnectionString = Login.ConnectionString;

        public DeathPoultry()
        {
            InitializeComponent();

        }





        private void ClearData()
        {

            descriptionbox.Text = "";
            amounttextbox.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            categorycombobox.SelectedItem = null;
        }


        public void comboboxshow()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = "SELECT category FROM dcategory";

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

        private void DeathPoultry_Load(object sender, EventArgs e)
        {
            comboboxshow();
        }

        private void descriptionbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void addrecord_Click(object sender, EventArgs e)
        {
            decimal GetValue = Dashboard.totalnoofrosters();
            decimal Gethen = Dashboard.totalnoofhens();
            decimal Getchick = Dashboard.totalnoofchicks();
            string category = categorycombobox.SelectedItem?.ToString();
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string amount = amounttextbox.Text;
            string description = descriptionbox.Text;

            // Check if amount is empty or zero
            if (string.IsNullOrEmpty(amount) || amount == "0")
            {
                MessageBox.Show("Amount must be a valid positive integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if amount is a valid integer
            if (!int.TryParse(amount, out int deathAmount) || deathAmount <= 0)
            {
                MessageBox.Show("Amount must be a valid positive integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GetValue < decimal.Parse(amount) && category == "Roaster")
            {
                MessageBox.Show("Don't Have Enough Rosters Amount");
            }
            else if (Gethen < decimal.Parse(amount) && category == "Hen")
            {
                MessageBox.Show("Don't Have Enough Hens Amount");
            }
            else if (Getchick < decimal.Parse(amount) && category == "Chick")
            {
                MessageBox.Show("Don't Have Enough Chick Amount");
            }
            else
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                    {
                        sqlConnection.Open();

                        // Query to get the total number of poultry (Hen and Roaster) from addpoultry and chicktoadult tables
                        string totalPoultryQuery = "SELECT SUM(amount) FROM addpoultry WHERE Category = @category";
                        using (SqlCommand totalPoultryCommand = new SqlCommand(totalPoultryQuery, sqlConnection))
                        {
                            totalPoultryCommand.Parameters.AddWithValue("@category", category);
                            object totalPoultryResult = totalPoultryCommand.ExecuteScalar();
                            int totalPoultry = (totalPoultryResult != DBNull.Value && totalPoultryResult != null) ? Convert.ToInt32(totalPoultryResult) : 0;

                            // Query to get the total number of deaths for the specified category from deathpoultry table
                            string totalDeathsQuery = "SELECT SUM(amount) FROM deathpoultry WHERE Category = @category";
                            using (SqlCommand totalDeathsCommand = new SqlCommand(totalDeathsQuery, sqlConnection))
                            {
                                totalDeathsCommand.Parameters.AddWithValue("@category", category);
                                object totalDeathsResult = totalDeathsCommand.ExecuteScalar();
                                int totalDeaths = (totalDeathsResult != DBNull.Value && totalDeathsResult != null) ? Convert.ToInt32(totalDeathsResult) : 0;

                                // Check if the sum of entered death count and existing count exceeds the total poultry count
                                if (deathAmount > totalPoultry)
                                {
                                    MessageBox.Show("Total death count exceeds the total number of poultry for the specified category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Proceed with inserting the death data
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO deathpoultry (category, amount, deathdate, causeofdeath) VALUES (@category, @amount, @date, @description)", sqlConnection))
                                {
                                    cmd.Parameters.AddWithValue("@category", category);
                                    cmd.Parameters.AddWithValue("@amount", deathAmount);
                                    cmd.Parameters.AddWithValue("@date", date);
                                    cmd.Parameters.AddWithValue("@description", description);

                                    cmd.ExecuteNonQuery();
                                }

                                MessageBox.Show("Data Inserted Successfully");
                                ClearData();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
    }
}