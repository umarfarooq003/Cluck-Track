using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Poultry_Management_System.Login;
using System.Diagnostics;
using Image = iTextSharp.text.Image;
using iTextSharp.text.html.simpleparser;

namespace Poultry_Management_System
{
    public partial class FinalReport : Form
    {
        private string ConnectionString=Login.ConnectionString;
        public FinalReport()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Total", "Total");
        }

        private void SaveReport_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                // Query to get the total sum of price from Sales table
                string saleQuery = "SELECT SUM(price) AS TotalSale FROM Sales";
                decimal totalSale = ExecuteScalarQuery<decimal>(saleQuery, sqlConnection);

                // Query to get the total sum of amount from Expense table
                string expenseQuery = "SELECT SUM(amount) AS TotalExpense FROM Expense";
                decimal totalExpense = ExecuteScalarQuery<decimal>(expenseQuery, sqlConnection);

                // Calculate profit
                decimal profit = totalSale - totalExpense;
                string profitStatus = (profit > 0) ? "Profit" : "No profit";
                decimal profitPercentage = (totalSale != 0) ? (profit / totalSale) * 100 : 0;

                // Query to get total purchase amount from AddPoultry table
                string purchaseQuery = "SELECT SUM(amount) AS TotalPurchaseAmount FROM AddPoultry";
                decimal totalPurchase = ExecuteScalarQuery<decimal>(purchaseQuery, sqlConnection);

                // Query to get the total sum of amount from DeathPoultry table
                string deathQuery = "SELECT SUM(amount) AS TotalDeath FROM DeathPoultry";
                decimal totalDeath = ExecuteScalarQuery<decimal>(deathQuery, sqlConnection);

                // Calculate Death Percentage
                string deathStatus = (totalPurchase > 0) ? "Death" : "No death";
                decimal deathPercentage = (totalPurchase != 0) ? (totalDeath / totalPurchase) * 100 : 0;

                // Display results in the DataGridView
                dataGridView1.Rows.Clear(); // Clear existing rows

                dataGridView1.Rows.Add("Sale", totalSale);
                dataGridView1.Rows.Add("Expense", totalExpense);
                dataGridView1.Rows.Add("Profit", profit);
                dataGridView1.Rows.Add("Profit Status", profitStatus);
                dataGridView1.Rows.Add("Profit Percentage", $"{Math.Max(profitPercentage, 0):F2}%");
                dataGridView1.Rows.Add("Death", totalDeath);
                dataGridView1.Rows.Add("Death Status", deathStatus);
                dataGridView1.Rows.Add("Death Percentage", $"{Math.Max(deathPercentage, 0):F2}%");
            }
        }


        private T ExecuteScalarQuery<T>(string query, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Execute the query and return the scalar result
                object result = command.ExecuteScalar();

                // Convert the result to the specified type (T)
                return (result == DBNull.Value || result == null) ? default : (T)Convert.ChangeType(result, typeof(T));
            }
        }

        private void SaveReportbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.Rows != null && dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Final PMS Report.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Check if the file exists and delete it
                        if (File.Exists(sfd.FileName))
                        {
                            File.Delete(sfd.FileName);
                        }

                        // Create PDF document and table
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            // Add report heading
                            Paragraph heading = new Paragraph("Final Report of Poultry Management System", FontFactory.GetFont(FontFactory.TIMES_BOLD, 20f));
                            heading.Alignment = Element.ALIGN_CENTER;
                            pdfDoc.Add(heading);

                            // Add spacing
                            pdfDoc.Add(new Paragraph("\n"));

                            // Add date printed
                            Phrase printedDatePhrase = new Phrase();
                            printedDatePhrase.Add(new Chunk("Date Printed: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 14f)));
                            printedDatePhrase.Add(new Chunk(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                            Paragraph printedDate = new Paragraph(printedDatePhrase);
                            printedDate.Alignment = Element.ALIGN_RIGHT;
                            pdfDoc.Add(printedDate);

                            // Add spacing
                            pdfDoc.Add(new Paragraph("\n"));

                            // Create PDF table for data
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 4;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            // Add column headers to PDF table
                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.TIMES_BOLD, 14f)));
                                pdfTable.AddCell(cell);
                            }

                            // Add rows and cells to PDF table
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value is DateTime)
                                    {
                                        pdfTable.AddCell(((DateTime)cell.Value).ToString("MM/dd/yyyy"));
                                    }
                                    else
                                    {
                                        PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12f)));
                                        pdfTable.AddCell(pdfCell);
                                    }
                                }
                            }


                            // Add PDF table to document and close the document
                            pdfDoc.Add(pdfTable);
                            //Add space after datagrid view
                            pdfDoc.Add(new Paragraph("\n"));
                            // Add footer text
                            Paragraph footer = new Paragraph("Design and Develop By: Umar and Faeez", FontFactory.GetFont(FontFactory.TIMES_BOLD, 20f));
                            footer.Alignment = Element.ALIGN_CENTER;
                            pdfDoc.Add(footer);
                            //add space 
                            pdfDoc.Add(new Paragraph("\n"));
                            // Create a new Paragraph for the centered links
                            Paragraph centeredLinks = new Paragraph();
                            centeredLinks.Alignment = Element.ALIGN_CENTER; // Center-align the paragraph horizontally

                            // Create a Chunk containing the first link
                            Chunk link1 = new Chunk("Visit Umar's Linktree", FontFactory.GetFont(FontFactory.TIMES_BOLD, 16f));
                            link1.SetAnchor("https://linktr.ee/umarfarooq003"); // Set the link URL
                            link1.SetAction(new iTextSharp.text.pdf.PdfAction(new Uri("https://linktr.ee/umarfarooq003")));
                            // Add the first link Chunk to the centered paragraph
                            centeredLinks.Add(link1);
                            centeredLinks.Add(new Phrase("\n")); // Add spacing between the links

                            // Create a Chunk containing the second link
                            Chunk link2 = new Chunk("Visit Faeez's Linktree", FontFactory.GetFont(FontFactory.TIMES_BOLD, 16f));
                            link2.SetAnchor("https://linktr.ee/faaez_usmani"); // Set the link URL
                            link2.SetAction(new iTextSharp.text.pdf.PdfAction(new Uri("https://linktr.ee/faaez_usmani")));

                            // Add the second link Chunk to the centered paragraph
                            centeredLinks.Add(link2);

                            // Add the centered paragraph with clickable links to the PDF document
                            pdfDoc.Add(centeredLinks);

                            pdfDoc.Close();

                            MessageBox.Show("Data Exported Successfully to PDF!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Open the saved PDF file in the default program (typically a web browser)
                            Process.Start(sfd.FileName);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error: Unable to access file. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
    }
}
