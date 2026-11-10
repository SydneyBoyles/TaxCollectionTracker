
namespace TaxCollectionTracker
{
    partial class RecordPaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            lblTaxAccountID = new Label();
            txtTaxAccountID = new TextBox();
            lblPaymentAmount = new Label();
            txtPaymentAmount = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnRecordPayment = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTaxAccountID
            // 
            lblTaxAccountID.AutoSize = true;
            lblTaxAccountID.Location = new Point(12, 9);
            lblTaxAccountID.Name = "lblTaxAccountID";
            lblTaxAccountID.Size = new Size(86, 15);
            lblTaxAccountID.TabIndex = 0;
            lblTaxAccountID.Text = "Tax Account ID";
            // 
            // txtTaxAccountID
            // 
            txtTaxAccountID.Location = new Point(12, 27);
            txtTaxAccountID.Name = "txtTaxAccountID";
            txtTaxAccountID.ReadOnly = true;
            txtTaxAccountID.Size = new Size(100, 23);
            txtTaxAccountID.TabIndex = 1;
            // 
            // lblPaymentAmount
            // 
            lblPaymentAmount.AutoSize = true;
            lblPaymentAmount.Location = new Point(12, 71);
            lblPaymentAmount.Name = "lblPaymentAmount";
            lblPaymentAmount.Size = new Size(101, 15);
            lblPaymentAmount.TabIndex = 2;
            lblPaymentAmount.Text = "Payment Amount";
            // 
            // txtPaymentAmount
            // 
            txtPaymentAmount.Location = new Point(12, 89);
            txtPaymentAmount.Name = "txtPaymentAmount";
            txtPaymentAmount.Size = new Size(100, 23);
            txtPaymentAmount.TabIndex = 3;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(12, 133);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(95, 15);
            lblNotes.TabIndex = 4;
            lblNotes.Text = "Notes (Optional)";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(12, 151);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(100, 23);
            txtNotes.TabIndex = 5;
            // 
            // btnRecordPayment
            // 
            btnRecordPayment.Location = new Point(230, 276);
            btnRecordPayment.Name = "btnRecordPayment";
            btnRecordPayment.Size = new Size(121, 23);
            btnRecordPayment.TabIndex = 6;
            btnRecordPayment.Text = "Record Payment";
            btnRecordPayment.UseVisualStyleBackColor = true;
            btnRecordPayment.Click += btnRecordPayment_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(357, 276);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // RecordPaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 311);
            Controls.Add(btnCancel);
            Controls.Add(btnRecordPayment);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(txtPaymentAmount);
            Controls.Add(lblPaymentAmount);
            Controls.Add(txtTaxAccountID);
            Controls.Add(lblTaxAccountID);
            Name = "RecordPaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Record Tax Payment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Labels
        private Label lblTaxAccountID;
        private Label lblPaymentAmount;
        private Label lblNotes;

        // Textboxes
        private TextBox txtTaxAccountID;
        private TextBox txtPaymentAmount;
        private TextBox txtNotes;

        // Buttons
        private Button btnRecordPayment;
        private Button btnCancel;
    }
}
