namespace WindowsBanking
{
    partial class History
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpAccount = new System.Windows.Forms.GroupBox();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.balanceLabel1 = new System.Windows.Forms.Label();
            this.accountNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.clientNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.transactionDataGridView = new System.Windows.Forms.DataGridView();
            this.transactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            fullNameLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            this.grpAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAccount
            // 
            this.grpAccount.Controls.Add(clientNumberLabel);
            this.grpAccount.Controls.Add(this.clientNumberMaskedLabel);
            this.grpAccount.Controls.Add(accountNumberLabel);
            this.grpAccount.Controls.Add(this.accountNumberMaskedLabel);
            this.grpAccount.Controls.Add(balanceLabel);
            this.grpAccount.Controls.Add(this.balanceLabel1);
            this.grpAccount.Controls.Add(fullNameLabel);
            this.grpAccount.Controls.Add(this.fullNameLabel1);
            this.grpAccount.Location = new System.Drawing.Point(43, 37);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(708, 126);
            this.grpAccount.TabIndex = 0;
            this.grpAccount.TabStop = false;
            this.grpAccount.Text = "Account Data";
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(385, 419);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(80, 13);
            this.lnkReturn.TabIndex = 1;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Client";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT_TP.Client);
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(431, 32);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(57, 13);
            fullNameLabel.TabIndex = 2;
            fullNameLabel.Text = "Full Name:";
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(494, 32);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(100, 23);
            this.fullNameLabel1.TabIndex = 3;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_TP.BankAccount);
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(431, 70);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(49, 13);
            balanceLabel.TabIndex = 4;
            balanceLabel.Text = "Balance:";
            // 
            // balanceLabel1
            // 
            this.balanceLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.balanceLabel1.Location = new System.Drawing.Point(494, 70);
            this.balanceLabel1.Name = "balanceLabel1";
            this.balanceLabel1.Size = new System.Drawing.Size(108, 23);
            this.balanceLabel1.TabIndex = 5;
            this.balanceLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(129, 70);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(90, 13);
            accountNumberLabel.TabIndex = 6;
            accountNumberLabel.Text = "Account Number:";
            // 
            // accountNumberMaskedLabel
            // 
            this.accountNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountNumber", true));
            this.accountNumberMaskedLabel.Location = new System.Drawing.Point(225, 70);
            this.accountNumberMaskedLabel.Name = "accountNumberMaskedLabel";
            this.accountNumberMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.accountNumberMaskedLabel.TabIndex = 7;
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(143, 32);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(76, 13);
            clientNumberLabel.TabIndex = 7;
            clientNumberLabel.Text = "Client Number:";
            // 
            // clientNumberMaskedLabel
            // 
            this.clientNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientNumber", true));
            this.clientNumberMaskedLabel.Location = new System.Drawing.Point(225, 32);
            this.clientNumberMaskedLabel.Mask = "0000-0000";
            this.clientNumberMaskedLabel.Name = "clientNumberMaskedLabel";
            this.clientNumberMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.clientNumberMaskedLabel.TabIndex = 8;
            this.clientNumberMaskedLabel.Text = "    -";
            // 
            // transactionDataGridView
            // 
            this.transactionDataGridView.AutoGenerateColumns = false;
            this.transactionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8});
            this.transactionDataGridView.DataSource = this.transactionBindingSource;
            this.transactionDataGridView.Location = new System.Drawing.Point(43, 180);
            this.transactionDataGridView.Name = "transactionDataGridView";
            this.transactionDataGridView.Size = new System.Drawing.Size(708, 220);
            this.transactionDataGridView.TabIndex = 2;
            // 
            // transactionBindingSource
            // 
            this.transactionBindingSource.DataSource = typeof(BankOfBIT_TP.Transaction);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DateCreated";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn7.HeaderText = "Date";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TransactionType";
            this.dataGridViewTextBoxColumn10.HeaderText = "Type";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 135;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Deposit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "Amount In";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Withdrawal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "Amount Out";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Notes";
            this.dataGridViewTextBoxColumn8.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 20;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 220;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.transactionDataGridView);
            this.Controls.Add(this.lnkReturn);
            this.Controls.Add(this.grpAccount);
            this.Name = "History";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAccount;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private EWSoftware.MaskedLabelControl.MaskedLabel clientNumberMaskedLabel;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private EWSoftware.MaskedLabelControl.MaskedLabel accountNumberMaskedLabel;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label balanceLabel1;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.DataGridView transactionDataGridView;
        private System.Windows.Forms.BindingSource transactionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}