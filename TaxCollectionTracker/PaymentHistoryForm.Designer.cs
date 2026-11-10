namespace TaxCollectionTracker
{
    partial class PaymentHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPaymentHistory = new Label();
            dgvPayments = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // lblPaymentHistory
            // 
            lblPaymentHistory.AutoSize = true;
            lblPaymentHistory.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPaymentHistory.Location = new Point(12, 9);
            lblPaymentHistory.Name = "lblPaymentHistory";
            lblPaymentHistory.Size = new Size(161, 25);
            lblPaymentHistory.TabIndex = 0;
            lblPaymentHistory.Text = "Payment History";
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Location = new Point(12, 51);
            dgvPayments.MultiSelect = false;
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new Size(627, 272);
            dgvPayments.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(572, 369);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 30);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // PaymentHistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 411);
            Controls.Add(btnClose);
            Controls.Add(dgvPayments);
            Controls.Add(lblPaymentHistory);
            Name = "PaymentHistoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Payment History";
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPaymentHistory;
        private DataGridView dgvPayments;
        private Button btnClose;
    }
}