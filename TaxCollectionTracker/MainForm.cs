
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TaxCollectionTracker
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        // Creates a connection to our SQL Server database
        private SqlConnection GetConnection()
        {
            string connectionString =
                @"Server=.\SQLEXPRESS;Database=TaxCollectionDB;Trusted_Connection=True;TrustServerCertificate=True;";

            return new SqlConnection(connectionString);
        }

        // Runs when the Search button is clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the account number entered by the user
            string searchTerm = txtSearch.Text.Trim();

            try
            {
                // Connect to SQL Server
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();

                    // SQL query to find a taxpayer by account number
                    string query = @"SELECT TaxpayerID, AccountNumber,
                                            FirstName, LastName, Email
                                     FROM Taxpayers
                                     WHERE AccountNumber = @AccountNumber";

                    // Prepare the SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Safely pass the user's search input
                        command.Parameters.AddWithValue(
                            "@AccountNumber", searchTerm);

                        // Retrieve the database results
                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();

                            adapter.Fill(dataTable);

                            // Display results in the DataGridView
                            dgvTaxpayers.DataSource = dataTable;

                            // Check whether any taxpayers were found
                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("No taxpayer found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display any database errors
                MessageBox.Show(
                    "Search failed: " + ex.Message);
            }
        }

        // Runs when the Add Taxpayer button is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create and open the Add Taxpayer form
            using (AddTaxpayerForm addForm = new AddTaxpayerForm())
            {
                addForm.ShowDialog(this);
            }
        }

        // Runs when the View button is clicked
        private void btnView_Click(object sender, EventArgs e)
        {
            // Make sure a taxpayer row is selected
            if (dgvTaxpayers.CurrentRow == null ||
                dgvTaxpayers.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Please search for and select a taxpayer first.");
                return;
            }

            // Check that the selected row contains a Taxpayer ID
            if (dgvTaxpayers.CurrentRow.Cells["TaxpayerID"].Value == null ||
                dgvTaxpayers.CurrentRow.Cells["TaxpayerID"].Value == DBNull.Value)
            {
                MessageBox.Show("Please select a valid taxpayer.");
                return;
            }

            // Read the Taxpayer ID from the selected row
            int taxpayerID = Convert.ToInt32(
                dgvTaxpayers.CurrentRow.Cells["TaxpayerID"].Value);

            // Pass the selected taxpayer's ID to the View form
            using (ViewTaxpayerForm viewForm =
                new ViewTaxpayerForm(taxpayerID))
            {
                viewForm.ShowDialog(this);
            }

            // Automatically refresh the search results
            // after the View window closes
            btnSearch_Click(sender, e);
        }

        private void dgvTaxpayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
