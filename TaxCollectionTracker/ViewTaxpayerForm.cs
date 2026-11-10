
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TaxCollectionTracker
{
    public partial class ViewTaxpayerForm : Form
    {
        // Stores the selected taxpayer's ID
        private int taxpayerID;

        // Stores the selected tax account's ID
        private int taxAccountID = 0;

        // Receives the taxpayer ID from Mainform
        public ViewTaxpayerForm(int selectedTaxpayerID)
        {
            InitializeComponent();

            taxpayerID = selectedTaxpayerID;

            // Load personal and financial information
            LoadTaxpayer();
            LoadTaxAccount();
        }

        // Creates a connection to SQL Server
        private SqlConnection GetConnection()
        {
            string connectionString =
                @"Server=.\SQLEXPRESS;Database=TaxCollectionDB;Trusted_Connection=True;TrustServerCertificate=True;";

            return new SqlConnection(connectionString);
        }

        // Loads the taxpayer's personal information
        private void LoadTaxpayer()
        {
            string query = @"SELECT TaxpayerID, AccountNumber,
                                    FirstName, LastName, Email
                             FROM dbo.Taxpayers
                             WHERE TaxpayerID = @TaxpayerID";

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@TaxpayerID", taxpayerID);

                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTaxpayerID.Text =
                                    reader["TaxpayerID"].ToString();

                                txtAccountNumber.Text =
                                    reader["AccountNumber"].ToString();

                                txtFirstName.Text =
                                    reader["FirstName"].ToString();

                                txtLastName.Text =
                                    reader["LastName"].ToString();

                                txtEmail.Text =
                                    reader["Email"].ToString();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Taxpayer record was not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading taxpayer: " + ex.Message);
            }
        }

        // Loads the taxpayer's tax account information
        private void LoadTaxAccount()
        {
            // Reset the account ID before loading
            taxAccountID = 0;

            // Disable payment buttons until an account is found
            btnOpenPayment.Enabled = false;
            btnPaymentHistory.Enabled = false;

            // Clear previous amounts
            txtOriginalAmount.Clear();
            txtAmountPaid.Clear();
            txtBalance.Clear();

            string query = @"SELECT TOP 1
                                    TaxAccountID,
                                    OriginalAmount,
                                    AmountPaid,
                                    Balance
                             FROM dbo.TaxAccounts
                             WHERE TaxpayerID = @TaxpayerID
                             ORDER BY TaxAccountID";

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@TaxpayerID", taxpayerID);

                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Remember which tax account was found
                                taxAccountID = Convert.ToInt32(
                                    reader["TaxAccountID"]);

                                decimal originalAmount =
                                    Convert.ToDecimal(
                                        reader["OriginalAmount"]);

                                decimal amountPaid =
                                    Convert.ToDecimal(
                                        reader["AmountPaid"]);

                                decimal balance =
                                    Convert.ToDecimal(
                                        reader["Balance"]);

                                // Display the financial information
                                txtOriginalAmount.Text =
                                    originalAmount.ToString("C2");

                                txtAmountPaid.Text =
                                    amountPaid.ToString("C2");

                                txtBalance.Text =
                                    balance.ToString("C2");

                                // Enable buttons when an account exists
                                btnOpenPayment.Enabled = true;
                                btnPaymentHistory.Enabled = true;
                            }
                            else
                            {
                                txtOriginalAmount.Text = "No account";
                                txtAmountPaid.Text = "No account";
                                txtBalance.Text = "No account";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading tax account: " + ex.Message);
            }
        }

        // Closes the View Taxpayer window
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Unlocks personal information for editing
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtEmail.ReadOnly = false;

            // Financial information stays read-only
            txtOriginalAmount.ReadOnly = true;
            txtAmountPaid.ReadOnly = true;
            txtBalance.ReadOnly = true;

            btnSaveChanges.Enabled = true;

            txtFirstName.Focus();

            MessageBox.Show(
                "You can now edit the taxpayer's information.");
        }

        // Saves changes to the taxpayer's personal information
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Check required fields
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show(
                    "First Name and Last Name are required.");
                return;
            }

            string query = @"UPDATE dbo.Taxpayers
                             SET FirstName = @FirstName,
                                 LastName = @LastName,
                                 Email = @Email
                             WHERE TaxpayerID = @TaxpayerID";

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@FirstName", firstName);

                        command.Parameters.AddWithValue(
                            "@LastName", lastName);

                        command.Parameters.AddWithValue(
                            "@Email",
                            string.IsNullOrWhiteSpace(email)
                                ? DBNull.Value
                                : email);

                        command.Parameters.AddWithValue(
                            "@TaxpayerID", taxpayerID);

                        int rowsUpdated = command.ExecuteNonQuery();

                        if (rowsUpdated == 0)
                        {
                            MessageBox.Show(
                                "No taxpayer record was updated.");
                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Taxpayer information updated successfully!");

                // Lock the fields again
                txtFirstName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                txtEmail.ReadOnly = true;

                btnSaveChanges.Enabled = false;

                // Reload updated information
                LoadTaxpayer();
                LoadTaxAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating taxpayer: " + ex.Message);
            }
        }

        // Opens the Record Payment form
        private void btnOpenPayment_Click(object sender, EventArgs e)
        {
            // Make sure the taxpayer has a tax account
            if (taxAccountID == 0)
            {
                MessageBox.Show(
                    "This taxpayer does not have a tax account.");
                return;
            }

            // Pass the correct TaxAccountID to the payment window
            using (RecordPaymentForm paymentForm =
                new RecordPaymentForm(taxAccountID))
            {
                paymentForm.ShowDialog(this);
            }

            // Refresh financial values after the window closes
            LoadTaxAccount();
        }

        // Opens the Payment History window
        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            // Make sure a tax account exists
            if (taxAccountID == 0)
            {
                MessageBox.Show(
                    "This taxpayer does not have a tax account.");
                return;
            }

            // Pass the correct TaxAccountID to PaymentHistoryForm
            using (PaymentHistoryForm historyForm =
                new PaymentHistoryForm(taxAccountID))
            {
                historyForm.ShowDialog(this);
            }
        }
    }
}
