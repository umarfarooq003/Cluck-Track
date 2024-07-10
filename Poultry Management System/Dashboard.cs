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
    public partial class Dashboard : Form
    {
        private static string ConnectionString = Login.ConnectionString;
        public string TotalRostersText
        {
            get { return totalrosters.Text; }
        }


        public Dashboard()
        {
            InitializeComponent();
        
        }
       

        private void Dashboard_Load(object sender, EventArgs e)
        {
            gettotalsales();
            gettotalexpense();
            totalhens.Text = Convert.ToString(totalnoofhens());
            profit();
            totalchicks.Text = Convert.ToString(totalnoofchicks());
            totalrosters.Text=Convert.ToString(totalnoofrosters());
            totalnoofdeath();

        }
        private void gettotalsales()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string Query = "SELECT SUM(total) FROM Sales";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(Query, sqlConnection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0 && dataTable.Rows[0][0] != DBNull.Value)
                        {
                            totalsalelabel.Text =dataTable.Rows[0][0].ToString();
                        }
                        else
                        {
                            totalsalelabel.Text = "0"; // Assuming you want to display "Rs 0" if no sales are found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void gettotalexpense()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    // Query to get total expenses from the Expense table
                    string expenseQuery = "SELECT SUM(total) FROM Expense";
                    int expenseTotal = 0;
                    using (SqlCommand expenseCommand = new SqlCommand(expenseQuery, sqlConnection))
                    {
                        object expenseResult = expenseCommand.ExecuteScalar();
                        if (expenseResult != DBNull.Value && expenseResult != null)
                        {
                            expenseTotal = Convert.ToInt32(expenseResult);
                        }
                    }

                    // Query to get total from addpoultry
                    string addPoultryQuery = "SELECT SUM(total) FROM addpoultry";
                    int addPoultryTotal = 0;
                    using (SqlCommand addPoultryCommand = new SqlCommand(addPoultryQuery, sqlConnection))
                    {
                        object addPoultryResult = addPoultryCommand.ExecuteScalar();
                        if (addPoultryResult != DBNull.Value && addPoultryResult != null)
                        {
                            addPoultryTotal = Convert.ToInt32(addPoultryResult);
                        }
                    }

                    // Calculate the total expenses by adding the totals from Expense and addpoultry
                    int totalExpenses = expenseTotal + addPoultryTotal;

                    // Display total expenses
                    totalexpenselabel.Text =  totalExpenses.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public static decimal totalnoofchicks()
        {
            decimal totalnoofchicks = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    // Query to get the total of hens
                    SqlCommand hensCommand = new SqlCommand("SELECT SUM(Hen) FROM chicktoadult", sqlConnection);
                    object hensResult = hensCommand.ExecuteScalar();
                    int totalHens = hensResult != DBNull.Value && hensResult != null ? Convert.ToInt32(hensResult) : 0;

                    // Query to get the total of rosters
                    SqlCommand rostersCommand = new SqlCommand("SELECT SUM(Roaster) FROM chicktoadult", sqlConnection);
                    object rostersResult = rostersCommand.ExecuteScalar();
                    int totalRosters = rostersResult != DBNull.Value && rostersResult != null ? Convert.ToInt32(rostersResult) : 0;

                    // Query to get the total of deathpoultry
                    SqlCommand deathPoultryCommand = new SqlCommand("SELECT SUM(amount) FROM deathpoultry where category='Chick'", sqlConnection);
                    object deathPoultryResult = deathPoultryCommand.ExecuteScalar();
                    int totalDeathPoultry = deathPoultryResult != DBNull.Value && deathPoultryResult != null ? Convert.ToInt32(deathPoultryResult) : 0;

                    //Query to get the total no of sales chicks from sales tables
                    SqlCommand Salestrycommand = new SqlCommand("SELECT SUM(amount) FROM Sales where category='Chicks' or category='chicks' or category='Chick' or category='chick'", sqlConnection);
                    object salesresult = Salestrycommand.ExecuteScalar();
                    int totalsaleschicks = salesresult != DBNull.Value && salesresult != null ? Convert.ToInt32(salesresult) : 0;


                    // Calculate the total of hens, rosters, and deathpoultry
                    int total = totalHens + totalRosters + totalDeathPoultry + totalsaleschicks;

                    // Query to get the total amount of chicks from addpoultry
                    string chickQuery = "select sum(amount) from addpoultry where Category='Chick' or Category='Chicks'  or Category='chick' or Category='chicks'";
                    SqlCommand chickCommand = new SqlCommand(chickQuery, sqlConnection);
                    object totalChicksFromAddPoultryResult = chickCommand.ExecuteScalar();
                    int totalChicksFromAddPoultry = totalChicksFromAddPoultryResult != DBNull.Value && totalChicksFromAddPoultryResult != null ? Convert.ToInt32(totalChicksFromAddPoultryResult) : 0;

                    // Calculate the total number of chicks after subtracting hens, roasters, and deathpoultry
                    int totalChicksAfterMinus = totalChicksFromAddPoultry - total;

                    totalnoofchicks =totalChicksAfterMinus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return totalnoofchicks;
        }
        public static decimal totalnoofhens()
        {
            decimal totalnoofhens = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    // Query to get the total sales of hens
                    SqlCommand salesCommand = new SqlCommand("SELECT SUM(amount) FROM Sales WHERE category IN ('hens', 'Hens', 'hen', 'Hen')", sqlConnection);
                    object salesHensResult = salesCommand.ExecuteScalar();
                    int totalSalesHens = salesHensResult != DBNull.Value && salesHensResult != null ? Convert.ToInt32(salesHensResult) : 0;

                    // Query to get the total number of hens from chick to adult
                    SqlCommand chickToAdultCommand = new SqlCommand("SELECT SUM(Hen) FROM chicktoadult", sqlConnection);
                    object chickToAdultResult = chickToAdultCommand.ExecuteScalar();
                    int totalChickToAdultHens = chickToAdultResult != DBNull.Value && chickToAdultResult != null ? Convert.ToInt32(chickToAdultResult) : 0;
                   
                    // Query to get the total deaths of roasters from deathpoultry
                    SqlCommand deathRoasterCommand = new SqlCommand("SELECT COALESCE(SUM(amount), 0) FROM deathpoultry WHERE category = @category", sqlConnection);
                    deathRoasterCommand.Parameters.AddWithValue("@category", "Hen");
                    object deathRoasterResult = deathRoasterCommand.ExecuteScalar();
                    int totalDeathHens = deathRoasterResult != DBNull.Value && deathRoasterResult != null ? Convert.ToInt32(deathRoasterResult) : 0;

                    // Query to get the total added hens from addpoultry
                    SqlCommand addPoultryCommand = new SqlCommand("SELECT SUM(amount) FROM addpoultry WHERE Category IN ('Hen')", sqlConnection);
                    object addPoultryResult = addPoultryCommand.ExecuteScalar();
                    int totalAddPoultryHens = addPoultryResult != DBNull.Value && addPoultryResult != null ? Convert.ToInt32(addPoultryResult) : 0;

                    // Calculate the total number of hens including both from chick to adult and added hens
                    int totalHens = totalChickToAdultHens + totalAddPoultryHens;

                    // Calculate the remaining hens after subtracting the total sales of hens
                    int remainingHens = totalHens - (totalSalesHens + totalDeathHens);

                    // Display the remaining number of hens
                    totalnoofhens = remainingHens;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return totalnoofhens;

        }
        private void totalnoofdeath()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string Query = "SELECT SUM(amount) FROM deathpoultry";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(Query, sqlConnection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0 && dataTable.Rows[0][0] != DBNull.Value)
                        {
                            totaldeath.Text = dataTable.Rows[0][0].ToString();
                        }
                        else
                        {
                            totaldeath.Text = "0"; // Assuming you want to display "Total: Rs 0" if no records are found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
        public static decimal totalnoofrosters()
        { 
            decimal totalnoofrosters = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    // Query to get the total sales of roasters
                    SqlCommand salesCommand = new SqlCommand("SELECT SUM(amount) FROM Sales WHERE category = @category", sqlConnection);
                    salesCommand.Parameters.AddWithValue("@category", "Roaster");
                    object salesRoasterResult = salesCommand.ExecuteScalar();
                    int totalSalesRoasters = salesRoasterResult != DBNull.Value && salesRoasterResult != null ? Convert.ToInt32(salesRoasterResult) : 0;

                    // Query to get the total number of roasters from chick to adult
                    SqlCommand chickToAdultCommand = new SqlCommand("SELECT SUM(Roaster) FROM chicktoadult", sqlConnection);
                    object chickToAdultResult = chickToAdultCommand.ExecuteScalar();
                    int totalChickToAdultRoasters = chickToAdultResult != DBNull.Value && chickToAdultResult != null ? Convert.ToInt32(chickToAdultResult) : 0;

                    // Query to get the total added roasters from addpoultry
                    SqlCommand addPoultryCommand = new SqlCommand("SELECT SUM(amount) FROM addpoultry WHERE Category = @category", sqlConnection);
                    addPoultryCommand.Parameters.AddWithValue("@category", "Roaster");
                    object addPoultryResult = addPoultryCommand.ExecuteScalar();
                    int totalAddPoultryRoasters = addPoultryResult != DBNull.Value && addPoultryResult != null ? Convert.ToInt32(addPoultryResult) : 0;

                    // Query to get the total deaths of roasters from deathpoultry
                    SqlCommand deathRoasterCommand = new SqlCommand("SELECT COALESCE(SUM(amount), 0) FROM deathpoultry WHERE category = @category", sqlConnection);
                    deathRoasterCommand.Parameters.AddWithValue("@category", "Roaster");
                    object deathRoasterResult = deathRoasterCommand.ExecuteScalar();
                    int totalDeathRoasters = deathRoasterResult != DBNull.Value && deathRoasterResult != null ? Convert.ToInt32(deathRoasterResult) : 0;

                    // Calculate the total number of roasters
                    int totalRoasters = totalChickToAdultRoasters + totalAddPoultryRoasters;

                    // Calculate the remaining roasters after subtracting the total sales and deaths of roasters
                    int remainingRoasters = totalRoasters - (totalSalesRoasters + totalDeathRoasters);

                    // Display the remaining number of roasters
                    totalnoofrosters = remainingRoasters;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return totalnoofrosters;

        }

        private void profit()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    // Query to get total sales
                    string salesQuery = "SELECT SUM(total) FROM Sales";
                    using (SqlDataAdapter salesAdapter = new SqlDataAdapter(salesQuery, sqlConnection))
                    {
                        DataTable salesTable = new DataTable();
                        salesAdapter.Fill(salesTable);
                        int salesTotal = salesTable.Rows.Count > 0 && salesTable.Rows[0][0] != DBNull.Value ? Convert.ToInt32(salesTable.Rows[0][0]) : 0;

                        // Query to get total expenses from addpoultry
                        string expenseQuery = "SELECT SUM(total) FROM addpoultry";
                        using (SqlDataAdapter expenseAdapter = new SqlDataAdapter(expenseQuery, sqlConnection))
                        {
                            DataTable expenseTable = new DataTable();
                            expenseAdapter.Fill(expenseTable);
                            int expenseTotal = 0;
                            if (expenseTable.Rows.Count > 0 && expenseTable.Rows[0][0] != DBNull.Value)
                            {
                                expenseTotal = Convert.ToInt32(expenseTable.Rows[0][0]);
                            }

                            // Query to get total amount from Expense
                            string amountQuery = "SELECT SUM(total) FROM Expense";
                            using (SqlDataAdapter amountAdapter = new SqlDataAdapter(amountQuery, sqlConnection))
                            {
                                DataTable amountTable = new DataTable();
                                amountAdapter.Fill(amountTable);
                                int expenseAmount = amountTable.Rows.Count > 0 && amountTable.Rows[0][0] != DBNull.Value ? Convert.ToInt32(amountTable.Rows[0][0]) : 0;

                                // Calculate profit
                                int profitTotal = salesTotal - (expenseTotal + expenseAmount);

                                // Display profit
                                lastprofitlabel.Text =  profitTotal.ToString();
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

        private void totalexpenselabel_Click(object sender, EventArgs e)
        {

        }

        private void lastprofitlabel_Click(object sender, EventArgs e)
        {

        }

        private void totalchicks_Click(object sender, EventArgs e)
        {

        }

        private void totalrosters_Click(object sender, EventArgs e)
        {

        }
    }

}
