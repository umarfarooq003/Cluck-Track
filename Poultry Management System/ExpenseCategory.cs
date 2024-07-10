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
    public partial class ExpenseCategory : Form
    {
        private string ConnectionString = Login.ConnectionString;
        public ExpenseCategory()
        {
            InitializeComponent();
        }

        private void addrecord_Click(object sender, EventArgs e)
        {
            string ExpenseCategory = Expensecategorytextbox.Text;
            if (string.IsNullOrEmpty(ExpenseCategory))
            {
                MessageBox.Show("Please filled the category TextBox");
            }
            else
            {
                try
                {
                    using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
                    {
                        sqlconnection.Open();
                        string Query = "insert into expensecategory (category) values (@ExpenseCategory)";
                        SqlCommand cmd = new SqlCommand(Query, sqlconnection);
                        cmd.Parameters.AddWithValue("@ExpenseCategory", ExpenseCategory);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Category Saved Successfully");
                        ClearData();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExpenseCategory_Load(object sender, EventArgs e)
        {
            comboboxshow();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Expensecategorytextbox_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClearData()
        {
            Expensecategorytextbox.Text = null;
            comboBox1.Text = null;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void comboboxshow()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string query = "SELECT category FROM expensecategory ";

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                comboBox1.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
                sqlConnection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ExpenseCategory = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(ExpenseCategory))
            {
                MessageBox.Show("Please select a category to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
                {
                    sqlconnection.Open();
                    string Query = "delete from expensecategory where category=@ExpenseCategory";
                    SqlCommand cmd = new SqlCommand(Query, sqlconnection);
                    cmd.Parameters.AddWithValue("@ExpenseCategory", ExpenseCategory);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted Successfully");
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
