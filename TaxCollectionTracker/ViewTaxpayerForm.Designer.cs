
namespace TaxCollectionTracker
{
    partial class ViewTaxpayerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTaxpayerID = new Label();
            txtTaxpayerID = new TextBox();
            lblAccountNumber = new Label();
            txtAccountNumber = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnClose = new Button();
            btnEdit = new Button();
            btnSaveChanges = new Button();
            lblAccountDetails = new Label();
            lblOriginalAmount = new Label();
            lblAmountPaid = new Label();
            lblBalance = new Label();
            txtOriginalAmount = new TextBox();
            txtAmountPaid = new TextBox();
            txtBalance = new TextBox();
            btnOpenPayment = new Button();
            btnPaymentHistory = new Button();
            SuspendLayout();
            // 
            // lblTaxpayerID
            // 
            lblTaxpayerID.AutoSize = true;
            lblTaxpayerID.Location = new Point(20, 15);
            lblTaxpayerID.Name = "lblTaxpayerID";
            lblTaxpayerID.Size = new Size(67, 15);
            lblTaxpayerID.TabIndex = 0;
            lblTaxpayerID.Text = "Taxpayer ID";
            // 
            // txtTaxpayerID
            // 
            txtTaxpayerID.Location = new Point(20, 38);
            txtTaxpayerID.Name = "txtTaxpayerID";
            txtTaxpayerID.ReadOnly = true;
            txtTaxpayerID.Size = new Size(200, 23);
            txtTaxpayerID.TabIndex = 1;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Location = new Point(20, 70);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(99, 15);
            lblAccountNumber.TabIndex = 2;
            lblAccountNumber.Text = "Account Number";
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.Location = new Point(20, 93);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.ReadOnly = true;
            txtAccountNumber.Size = new Size(200, 23);
            txtAccountNumber.TabIndex = 3;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(20, 125);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(64, 15);
            lblFirstName.TabIndex = 4;
            lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(20, 148);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.ReadOnly = true;
            txtFirstName.Size = new Size(200, 23);
            txtFirstName.TabIndex = 5;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(20, 180);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 6;
            lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(20, 203);
            txtLastName.Name = "txtLastName";
            txtLastName.ReadOnly = true;
            txtLastName.Size = new Size(200, 23);
            txtLastName.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 235);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 253);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 9;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(543, 559);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 30);
            btnClose.TabIndex = 10;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(321, 559);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 30);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new Point(427, 559);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(110, 30);
            btnSaveChanges.TabIndex = 12;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // lblAccountDetails
            // 
            lblAccountDetails.AutoSize = true;
            lblAccountDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccountDetails.Location = new Point(20, 298);
            lblAccountDetails.Name = "lblAccountDetails";
            lblAccountDetails.Size = new Size(160, 21);
            lblAccountDetails.TabIndex = 13;
            lblAccountDetails.Text = "Tax Account Details";
            // 
            // lblOriginalAmount
            // 
            lblOriginalAmount.AutoSize = true;
            lblOriginalAmount.Location = new Point(23, 329);
            lblOriginalAmount.Name = "lblOriginalAmount";
            lblOriginalAmount.Size = new Size(96, 15);
            lblOriginalAmount.TabIndex = 14;
            lblOriginalAmount.Text = "Original Amount";
            // 
            // lblAmountPaid
            // 
            lblAmountPaid.AutoSize = true;
            lblAmountPaid.Location = new Point(23, 369);
            lblAmountPaid.Name = "lblAmountPaid";
            lblAmountPaid.Size = new Size(77, 15);
            lblAmountPaid.TabIndex = 15;
            lblAmountPaid.Text = "Amount Paid";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(23, 408);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(108, 15);
            lblBalance.TabIndex = 16;
            lblBalance.Text = "Remaining Balance";
            // 
            // txtOriginalAmount
            // 
            txtOriginalAmount.Location = new Point(137, 326);
            txtOriginalAmount.Name = "txtOriginalAmount";
            txtOriginalAmount.ReadOnly = true;
            txtOriginalAmount.Size = new Size(118, 23);
            txtOriginalAmount.TabIndex = 17;
            txtOriginalAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Location = new Point(137, 369);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.ReadOnly = true;
            txtAmountPaid.Size = new Size(118, 23);
            txtAmountPaid.TabIndex = 18;
            txtAmountPaid.TextAlign = HorizontalAlignment.Right;
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(137, 408);
            txtBalance.Name = "txtBalance";
            txtBalance.ReadOnly = true;
            txtBalance.Size = new Size(118, 23);
            txtBalance.TabIndex = 19;
            txtBalance.TextAlign = HorizontalAlignment.Right;
            // 
            // btnOpenPayment
            // 
            btnOpenPayment.Location = new Point(195, 559);
            btnOpenPayment.Name = "btnOpenPayment";
            btnOpenPayment.Size = new Size(120, 30);
            btnOpenPayment.TabIndex = 20;
            btnOpenPayment.Text = "Record Payment";
            btnOpenPayment.UseVisualStyleBackColor = true;
            btnOpenPayment.Click += btnOpenPayment_Click;
            // 
            // btnPaymentHistory
            // 
            btnPaymentHistory.Location = new Point(69, 559);
            btnPaymentHistory.Name = "btnPaymentHistory";
            btnPaymentHistory.Size = new Size(120, 30);
            btnPaymentHistory.TabIndex = 21;
            btnPaymentHistory.Text = "Payment History";
            btnPaymentHistory.UseVisualStyleBackColor = true;
            btnPaymentHistory.Click += btnPaymentHistory_Click;
            // 
            // ViewTaxpayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 601);
            Controls.Add(btnPaymentHistory);
            Controls.Add(btnOpenPayment);
            Controls.Add(txtBalance);
            Controls.Add(txtAmountPaid);
            Controls.Add(txtOriginalAmount);
            Controls.Add(lblBalance);
            Controls.Add(lblAmountPaid);
            Controls.Add(lblOriginalAmount);
            Controls.Add(lblAccountDetails);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnEdit);
            Controls.Add(lblTaxpayerID);
            Controls.Add(txtTaxpayerID);
            Controls.Add(lblAccountNumber);
            Controls.Add(txtAccountNumber);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnClose);
            Name = "ViewTaxpayerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View Taxpayer Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTaxpayerID;
        private TextBox txtTaxpayerID;

        private Label lblAccountNumber;
        private TextBox txtAccountNumber;

        private Label lblFirstName;
        private TextBox txtFirstName;

        private Label lblLastName;
        private TextBox txtLastName;

        private Label lblEmail;
        private TextBox txtEmail;

        private Button btnClose;
        private Button btnEdit;
        private Button btnSaveChanges;
        private Label lblAccountDetails;
        private Label lblOriginalAmount;
        private Label lblAmountPaid;
        private Label lblBalance;
        private TextBox txtOriginalAmount;
        private TextBox txtAmountPaid;
        private TextBox txtBalance;
        private Button btnOpenPayment;
        private Button btnPaymentHistory;
    }
}
