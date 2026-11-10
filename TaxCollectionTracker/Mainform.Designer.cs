namespace TaxCollectionTracker
{
    partial class Mainform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvTaxpayers = new DataGridView();
            btnAdd = new Button();
            btnView = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTaxpayers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(299, 37);
            label1.TabIndex = 0;
            label1.Text = "Tax Collection Tracker";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 44);
            label2.Name = "label2";
            label2.Size = new Size(139, 15);
            label2.TabIndex = 1;
            label2.Text = "Taxpayer Account Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(245, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(0, 40);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvTaxpayers
            // 
            dgvTaxpayers.AllowUserToAddRows = false;
            dgvTaxpayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaxpayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaxpayers.Location = new Point(416, 0);
            dgvTaxpayers.MultiSelect = false;
            dgvTaxpayers.Name = "dgvTaxpayers";
            dgvTaxpayers.ReadOnly = true;
            dgvTaxpayers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaxpayers.Size = new Size(569, 611);
            dgvTaxpayers.TabIndex = 4;
            dgvTaxpayers.CellContentClick += dgvTaxpayers_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(0, 78);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add Taxpayers";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnView
            // 
            btnView.Location = new Point(0, 116);
            btnView.Name = "btnView";
            btnView.Size = new Size(75, 23);
            btnView.TabIndex = 6;
            btnView.Text = "View Account";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // Mainform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 610);
            Controls.Add(btnView);
            Controls.Add(btnAdd);
            Controls.Add(dgvTaxpayers);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Mainform";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tax Collection Tracker";
            ((System.ComponentModel.ISupportInitialize)dgvTaxpayers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvTaxpayers;
        private Button btnAdd;
        private Button btnView;
    }
}
