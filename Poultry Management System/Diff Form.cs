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
using static Poultry_Management_System.Dashboard;

namespace Poultry_Management_System
{
    public partial class Diff_Form : Form
    {
        private string ConnectionString = Login.ConnectionString;
        decimal totalchicks = Dashboard.totalnoofchicks();
        public Diff_Form()
        {
            InitializeComponent();
            Expensecategorytextbox.Text=Convert.ToString(Dashboard.totalnoofchicks());

        }

      
        private void Diff_Form_Load(object sender, EventArgs e)
        {
            
        }
  

        private void button1_Click(object sender, EventArgs e)
        {
            int purchase, hen, roaster;

            // Attempt to parse the purchase value from Expensecategorytextbox
            if (!int.TryParse(Expensecategorytextbox.Text, out purchase))
            {
                MessageBox.Show("Please enter a valid number for total chicks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        
         

            // Attempt to parse the values for hen and roaster from textBox3 and textBox2
            if (!int.TryParse(textBox3.Text, out hen) ||
                !int.TryParse(textBox2.Text, out roaster))
            {
                MessageBox.Show("Please fill in the required fields with valid numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculate the total number of hens and roasters
            int total = hen + roaster;

            // Check if the sum of hen and roaster exceeds the total chicks
            if (total > purchase || Expensecategorytextbox.Text == "0")
            {
                MessageBox.Show("The total number of hens and roasters cannot exceed the number of chicks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                // If validations pass, proceed with database operation
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    // Insert data into the database table 'chicktoadult'
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO chicktoadult (totalchicks, Hen, Roaster) VALUES (@purchase, @hen, @roaster)", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@purchase", purchase);
                        cmd.Parameters.AddWithValue("@hen", hen);
                        cmd.Parameters.AddWithValue("@roaster", roaster);
                        cmd.ExecuteNonQuery(); // Execute the SQL command
                    }

                    MessageBox.Show("Data Saved Successfully");
                    Clear(); // Clear input fields

                    // Update total chicks display after first entry
                    Expensecategorytextbox.Text = Convert.ToString(Dashboard.totalnoofchicks());
                }
            }
        }

        private void Clear()
        {
            
            textBox2.Text = "";
            textBox3.Text = "";
            Expensecategorytextbox.Text = "";
        }
        private void Expensecategorytextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
