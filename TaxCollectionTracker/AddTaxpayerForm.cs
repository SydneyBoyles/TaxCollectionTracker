using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TaxCollectionTracker
{
    public partial class AddTaxpayerForm : Form
    {
        // Runs when the Add Taxpayer window opens
        public AddTaxpayerForm()
        {
            InitializeComponent();
        }

        // Closes the window when Cancel is clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Runs when the Account Number text changes
        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {
            // We don't need anything here right now
        }

        // Runs when the Save button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Read the information from the text boxes
            string accountNumber = txtAccountNumber.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Check that required fields are not empty
            if (string.IsNullOrWhiteSpace(accountNumber) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter an account number, first name, and last name.");
                return;
            }

            // Set up the database connection
            string connectionString =
                @"Server=.\SQLEXPRESS;Database=TaxCollectionDB;Trusted_Connection=True;TrustServerCertificate=True;";

            // Write the SQL INSERT statement
            string query = @"INSERT INTO Taxpayers
                             (AccountNumber, FirstName, LastName, Email)
                             VALUES
                             (@AccountNumber, @FirstName, @LastName, @Email)";

            try
            {
                // Open the connection to SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Prepare the SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the values safely using parameters
                        command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);

                        // Email is optional, so use DBNull.Value if empty
                        command.Parameters.AddWithValue(
                            "@Email",
                            string.IsNullOrWhiteSpace(email)
                                ? DBNull.Value
                                : email);

                        // Run the INSERT command
                        command.ExecuteNonQuery();
                    }
                }

                // Tell the user the save was successful
                MessageBox.Show("Taxpayer saved successfully!");

                // Close the window after saving
                this.Close();
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                // Account numbers must be unique
                MessageBox.Show("That account number already exists.");
            }
            catch (Exception ex)
            {
                // Show an error if something goes wrong
                MessageBox.Show("Error saving taxpayer: " + ex.Message);
            }
        }
    }
}
