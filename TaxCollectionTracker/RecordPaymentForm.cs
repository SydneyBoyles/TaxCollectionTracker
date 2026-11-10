using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TaxCollectionTracker
{
    public partial class RecordPaymentForm : Form
    {
        // Stores the tax account receiving the payment
        private int taxAccountID;

        // Receives the account ID from ViewTaxpayerForm
        public RecordPaymentForm(int selectedTaxAccountID)
        {
            InitializeComponent();

            taxAccountID = selectedTaxAccountID;

            // Display the account ID (read-only)
            txtTaxAccountID.Text = taxAccountID.ToString();
        }

        // Closes the payment window without saving
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Records a new payment in SQL Server
        private void btnRecordPayment_Click(object sender, EventArgs e)
        {
            // Read the payment amount entered by the user
            string amountText = txtPaymentAmount.Text.Trim();
            string notes = txtNotes.Text.Trim();

            // Check that the amount is a valid positive decimal
            if (!decimal.TryParse(amountText, out decimal paymentAmount) ||
                paymentAmount <= 0 ||
                decimal.Round(paymentAmount, 2) != paymentAmount)
            {
                MessageBox.Show(
                    "Please enter a valid payment amount greater than zero, with no more than two decimal places.");
                return;
            }

            // Connect to our local SQL Server database
            string connectionString =
                @"Server=.\SQLEXPRESS;Database=TaxCollectionDB;Trusted_Connection=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    // A transaction keeps both database changes together
                    using (SqlTransaction transaction =
                        connection.BeginTransaction())
                    {
                        try
                        {
                            // Read the current balance and lock the account
                            string balanceQuery =
                                @"SELECT Balance
                                  FROM dbo.TaxAccounts WITH (UPDLOCK, HOLDLOCK)
                                  WHERE TaxAccountID = @TaxAccountID";

                            decimal currentBalance;

                            using (SqlCommand balanceCommand =
                                new SqlCommand(balanceQuery, connection, transaction))
                            {
                                balanceCommand.Parameters.Add(
                                    "@TaxAccountID", SqlDbType.Int).Value =
                                    taxAccountID;

                                object result = balanceCommand.ExecuteScalar();

                                if (result == null || result == DBNull.Value)
                                {
                                    throw new Exception(
                                        "Tax account was not found.");
                                }

                                currentBalance = Convert.ToDecimal(result);
                            }

                            // Don't accept a payment larger than the balance
                            if (paymentAmount > currentBalance)
                            {
                                MessageBox.Show(
                                    "Payment cannot exceed the remaining balance of " +
                                    currentBalance.ToString("C2"));

                                transaction.Rollback();
                                return;
                            }

                            // Insert the individual payment record
                            string insertQuery =
                                @"INSERT INTO dbo.Payments
                                    (TaxAccountID, PaymentAmount, Notes)
                                  VALUES
                                    (@TaxAccountID, @PaymentAmount, @Notes)";

                            using (SqlCommand insertCommand =
                                new SqlCommand(insertQuery, connection, transaction))
                            {
                                insertCommand.Parameters.Add(
                                    "@TaxAccountID", SqlDbType.Int).Value =
                                    taxAccountID;

                                SqlParameter amountParameter =
                                    insertCommand.Parameters.Add(
                                        "@PaymentAmount", SqlDbType.Decimal);

                                amountParameter.Precision = 10;
                                amountParameter.Scale = 2;
                                amountParameter.Value = paymentAmount;

                                insertCommand.Parameters.Add(
                                    "@Notes", SqlDbType.NVarChar, 200).Value =
                                    string.IsNullOrWhiteSpace(notes)
                                        ? DBNull.Value
                                        : notes;

                                insertCommand.ExecuteNonQuery();
                            }

                            // Update the total amount paid for this account
                            string updateQuery =
                                @"UPDATE dbo.TaxAccounts
                                  SET AmountPaid = AmountPaid + @PaymentAmount
                                  WHERE TaxAccountID = @TaxAccountID";

                            using (SqlCommand updateCommand =
                                new SqlCommand(updateQuery, connection, transaction))
                            {
                                updateCommand.Parameters.Add(
                                    "@TaxAccountID", SqlDbType.Int).Value =
                                    taxAccountID;

                                SqlParameter amountParameter =
                                    updateCommand.Parameters.Add(
                                        "@PaymentAmount", SqlDbType.Decimal);

                                amountParameter.Precision = 10;
                                amountParameter.Scale = 2;
                                amountParameter.Value = paymentAmount;

                                int rowsUpdated =
                                    updateCommand.ExecuteNonQuery();

                                if (rowsUpdated != 1)
                                {
                                    throw new Exception(
                                        "The tax account could not be updated.");
                                }
                            }

                            // Save both database changes together
                            transaction.Commit();
                        }
                        catch
                        {
                            // Undo changes if something went wrong
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception)
                            {
                                // Transaction may already be finished
                            }

                            throw;
                        }
                    }
                }

                MessageBox.Show("Payment recorded successfully!");

                // Close the form after saving
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error recording payment: " + ex.Message);
            }
        }
    }
}
