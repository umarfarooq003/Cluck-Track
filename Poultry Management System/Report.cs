using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Poultry_Management_System.Login;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;



namespace Poultry_Management_System
{
    public partial class Report : Form
    {
        private string ConnectionString = Login.ConnectionString;
        public Report()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ShowReport_Click(object sender, EventArgs e)
        {
            string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            string queryString = @"SELECT 'Sales' AS [Table], category AS [Category], price AS [Total Price], date AS [Date] FROM Sales WHERE date BETWEEN @StartDate AND @EndDate
UNION ALL
SELECT 'Expense' AS [Table], category AS [Category], amount AS [Total Price], date AS [Date] FROM Expense WHERE date BETWEEN @StartDate AND @EndDate
UNION ALL
SELECT 'Poultry Purchase' AS [Table], Category AS [Category], Total AS [Total Price], SaleDate AS [Date] FROM addpoultry WHERE SaleDate BETWEEN @StartDate AND @EndDate
ORDER BY [Date]"; // Add ORDER BY clause to sort the result by Date

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Add a new column for row numbers and insert it at the first position
                DataColumn rowNumberColumn = new DataColumn("Number", typeof(int));
                dataTable.Columns.Add(rowNumberColumn);
                dataTable.Columns["Number"].SetOrdinal(0); // Move the new column to the first position

                // Assign row numbers to each row
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    dataTable.Rows[i]["Number"] = i + 1;
                }

                dataGridView1.DataSource = dataTable;

                // Set the RowHeadersVisible property to false since we are displaying row numbers in the first column
                dataGridView1.RowHeadersVisible = false;
            }


        }

        private void SaveReport_Click(object sender, EventArgs e)
        {
                if (dataGridView1 != null && dataGridView1.Rows != null && dataGridView1.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (.pdf)|.pdf";
                    sfd.FileName = "Initial PMS Report.pdf";

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
                                Paragraph heading = new Paragraph("Report of Poultry Management System", FontFactory.GetFont(FontFactory.TIMES_BOLD, 20f));
                                heading.Alignment = Element.ALIGN_CENTER;
                                pdfDoc.Add(heading);


                                // Add spacing
                                pdfDoc.Add(new Paragraph("\n"));

                                // Create a phrase
                                Phrase phrase = new Phrase();
                                phrase.Add(new Chunk("Date Printed: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 12f)));
                                phrase.Add(new Chunk(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                                // Create a paragraph with the phrase
                                Paragraph printedDate = new Paragraph(phrase);
                                printedDate.Alignment = Element.ALIGN_RIGHT;

                                // Add the paragraph to the document
                                pdfDoc.Add(printedDate);



                                // Add spacing
                                pdfDoc.Add(new Paragraph("\n"));

                                // Add date range for retrieved data
                                string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                                string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                                // Create a phrase
                                Phrase phrase1 = new Phrase();
                                phrase1.Add(new Chunk("Date Range: ", FontFactory.GetFont(FontFactory.TIMES_BOLD, 12f)));
                                phrase1.Add(new Chunk(startDate + " to " + endDate));

                                // Create a paragraph with the phrase

                                Paragraph dateRange = new Paragraph(phrase1);
                                dateRange.Alignment = Element.ALIGN_LEFT;

                                // Add the paragraph to the document
                                pdfDoc.Add(dateRange);


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
                                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
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
                                            pdfTable.AddCell(cell.Value?.ToString() ?? ""); // Add cell value (handling nulls)
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

                                MessageBox.Show("Data Exported Successfully !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("No Record To Export !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private void Report_Load(object sender, EventArgs e)
            {
   
            }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
