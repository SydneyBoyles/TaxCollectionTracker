using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TaxCollectionTracker
{
    public partial class PaymentHistoryForm : Form
    {
        // Stores the ID of the tax account we're viewing
        private int taxAccountID;

        // Receives the TaxAccountID from ViewTaxpayerForm
        public PaymentHistoryForm(int selectedTaxAccountID)
        {
            InitializeComponent();

            // Remember the selected tax account
            taxAccountID = selectedTaxAccountID;

            // Load its payment history
            LoadPayments();
        }

        // Retrieves payment records from SQL Server
        private void LoadPayments()
        {
            // Connection to our local SQL Server
            string connectionString =
                @"Server=.\SQLEXPRESS;Database=TaxCollectionDB;Trusted_Connection=True;TrustServerCertificate=True;";

            // Only retrieve payments for the selected account
            string query = @"SELECT
                                PaymentID,
                                PaymentDate,
                                PaymentAmount,
                                Notes
                             FROM dbo.Payments
                             WHERE TaxAccountID = @TaxAccountID
                             ORDER BY PaymentDate DESC, PaymentID DESC";

            try
            {
                // Connect to the database
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Prepare the SQL query
                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        // Pass the account ID safely
                        command.Parameters.Add(
                            "@TaxAccountID", SqlDbType.Int).Value =
                            taxAccountID;

                        // Retrieve the results
                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();

                            adapter.Fill(dataTable);

                            // Display payments in the DataGridView
                            dgvPayments.DataSource = dataTable;

                            // Format the amount column as currency
                            dgvPayments.Columns["PaymentAmount"]
                                .DefaultCellStyle.Format = "C2";

                            // Format the date column
                            dgvPayments.Columns["PaymentDate"]
                                .DefaultCellStyle.Format = "g";

                            // Show a message if no payments exist
                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show(
                                    "No payments have been recorded for this tax account.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading payment history: " + ex.Message);
            }
        }

        // Closes the Payment History window
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
