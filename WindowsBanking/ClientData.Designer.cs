﻿namespace WindowsBanking
{
    partial class ClientData
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
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label fullAddressLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label notesLabel;
            System.Windows.Forms.Label descriptionLabel2;
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.clientNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateCreatedLabel1 = new System.Windows.Forms.Label();
            this.fullAddressLabel1 = new System.Windows.Forms.Label();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.grpAccount = new System.Windows.Forms.GroupBox();
            this.descriptionLabel3 = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountNumberComboBox = new System.Windows.Forms.ComboBox();
            this.balanceLabel1 = new System.Windows.Forms.Label();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.notesLabel1 = new System.Windows.Forms.Label();
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.lnkProcess = new System.Windows.Forms.LinkLabel();
            clientNumberLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            fullAddressLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            descriptionLabel2 = new System.Windows.Forms.Label();
            this.grpClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.grpAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(56, 25);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(76, 13);
            clientNumberLabel.TabIndex = 0;
            clientNumberLabel.Text = "Client Number:";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(56, 117);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(73, 13);
            dateCreatedLabel.TabIndex = 2;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // fullAddressLabel
            // 
            fullAddressLabel.AutoSize = true;
            fullAddressLabel.Location = new System.Drawing.Point(56, 84);
            fullAddressLabel.Name = "fullAddressLabel";
            fullAddressLabel.Size = new System.Drawing.Size(67, 13);
            fullAddressLabel.TabIndex = 4;
            fullAddressLabel.Text = "Full Address:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(56, 51);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(57, 13);
            fullNameLabel.TabIndex = 6;
            fullNameLabel.Text = "Full Name:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(56, 32);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(90, 13);
            accountNumberLabel.TabIndex = 2;
            accountNumberLabel.Text = "Account Number:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(414, 32);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(49, 13);
            balanceLabel.TabIndex = 4;
            balanceLabel.Text = "Balance:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(386, 62);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(77, 13);
            descriptionLabel.TabIndex = 6;
            descriptionLabel.Text = "Account Type:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(56, 95);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(38, 13);
            notesLabel.TabIndex = 8;
            notesLabel.Text = "Notes:";
            // 
            // descriptionLabel2
            // 
            descriptionLabel2.AutoSize = true;
            descriptionLabel2.Location = new System.Drawing.Point(56, 62);
            descriptionLabel2.Name = "descriptionLabel2";
            descriptionLabel2.Size = new System.Drawing.Size(35, 13);
            descriptionLabel2.TabIndex = 10;
            descriptionLabel2.Text = "State:";
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(clientNumberLabel);
            this.grpClient.Controls.Add(this.clientNumberMaskedTextBox);
            this.grpClient.Controls.Add(dateCreatedLabel);
            this.grpClient.Controls.Add(this.dateCreatedLabel1);
            this.grpClient.Controls.Add(fullAddressLabel);
            this.grpClient.Controls.Add(this.fullAddressLabel1);
            this.grpClient.Controls.Add(fullNameLabel);
            this.grpClient.Controls.Add(this.fullNameLabel1);
            this.grpClient.Location = new System.Drawing.Point(55, 25);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(677, 148);
            this.grpClient.TabIndex = 0;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client Data";
            // 
            // clientNumberMaskedTextBox
            // 
            this.clientNumberMaskedTextBox.AllowPromptAsInput = false;
            this.clientNumberMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientNumber", true));
            this.clientNumberMaskedTextBox.Location = new System.Drawing.Point(138, 22);
            this.clientNumberMaskedTextBox.Mask = "0000-0000";
            this.clientNumberMaskedTextBox.Name = "clientNumberMaskedTextBox";
            this.clientNumberMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.clientNumberMaskedTextBox.TabIndex = 0;
            this.clientNumberMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.clientNumberMaskedTextBox.ValidatingType = typeof(int);
            this.clientNumberMaskedTextBox.Leave += new System.EventHandler(this.clientNumberMaskedTextBox_Leave);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT_TP.Client);
            // 
            // dateCreatedLabel1
            // 
            this.dateCreatedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "DateCreated", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.dateCreatedLabel1.Location = new System.Drawing.Point(138, 117);
            this.dateCreatedLabel1.Name = "dateCreatedLabel1";
            this.dateCreatedLabel1.Size = new System.Drawing.Size(100, 23);
            this.dateCreatedLabel1.TabIndex = 3;
            // 
            // fullAddressLabel1
            // 
            this.fullAddressLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullAddress", true));
            this.fullAddressLabel1.Location = new System.Drawing.Point(138, 84);
            this.fullAddressLabel1.Name = "fullAddressLabel1";
            this.fullAddressLabel1.Size = new System.Drawing.Size(480, 23);
            this.fullAddressLabel1.TabIndex = 5;
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(138, 51);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(480, 23);
            this.fullNameLabel1.TabIndex = 7;
            // 
            // grpAccount
            // 
            this.grpAccount.Controls.Add(descriptionLabel2);
            this.grpAccount.Controls.Add(this.descriptionLabel3);
            this.grpAccount.Controls.Add(accountNumberLabel);
            this.grpAccount.Controls.Add(this.accountNumberComboBox);
            this.grpAccount.Controls.Add(balanceLabel);
            this.grpAccount.Controls.Add(this.balanceLabel1);
            this.grpAccount.Controls.Add(descriptionLabel);
            this.grpAccount.Controls.Add(this.descriptionLabel1);
            this.grpAccount.Controls.Add(notesLabel);
            this.grpAccount.Controls.Add(this.notesLabel1);
            this.grpAccount.Controls.Add(this.lnkDetails);
            this.grpAccount.Controls.Add(this.lnkProcess);
            this.grpAccount.Location = new System.Drawing.Point(55, 189);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(677, 223);
            this.grpAccount.TabIndex = 1;
            this.grpAccount.TabStop = false;
            this.grpAccount.Text = "Bank Account Data";
            // 
            // descriptionLabel3
            // 
            this.descriptionLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountState.Description", true));
            this.descriptionLabel3.Location = new System.Drawing.Point(149, 62);
            this.descriptionLabel3.Name = "descriptionLabel3";
            this.descriptionLabel3.Size = new System.Drawing.Size(100, 23);
            this.descriptionLabel3.TabIndex = 11;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_TP.BankAccount);
            // 
            // accountNumberComboBox
            // 
            this.accountNumberComboBox.DataSource = this.bankAccountBindingSource;
            this.accountNumberComboBox.DisplayMember = "AccountNumber";
            this.accountNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountNumberComboBox.FormattingEnabled = true;
            this.accountNumberComboBox.Location = new System.Drawing.Point(152, 29);
            this.accountNumberComboBox.Name = "accountNumberComboBox";
            this.accountNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.accountNumberComboBox.TabIndex = 3;
            // 
            // balanceLabel1
            // 
            this.balanceLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.balanceLabel1.Location = new System.Drawing.Point(485, 32);
            this.balanceLabel1.Name = "balanceLabel1";
            this.balanceLabel1.Size = new System.Drawing.Size(133, 23);
            this.balanceLabel1.TabIndex = 5;
            this.balanceLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(488, 62);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(130, 23);
            this.descriptionLabel1.TabIndex = 7;
            // 
            // notesLabel1
            // 
            this.notesLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Notes", true));
            this.notesLabel1.Location = new System.Drawing.Point(149, 95);
            this.notesLabel1.Name = "notesLabel1";
            this.notesLabel1.Size = new System.Drawing.Size(469, 74);
            this.notesLabel1.TabIndex = 9;
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Enabled = false;
            this.lnkDetails.Location = new System.Drawing.Point(414, 194);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(65, 13);
            this.lnkDetails.TabIndex = 2;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // lnkProcess
            // 
            this.lnkProcess.AutoSize = true;
            this.lnkProcess.Enabled = false;
            this.lnkProcess.Location = new System.Drawing.Point(202, 194);
            this.lnkProcess.Name = "lnkProcess";
            this.lnkProcess.Size = new System.Drawing.Size(104, 13);
            this.lnkProcess.TabIndex = 1;
            this.lnkProcess.TabStop = true;
            this.lnkProcess.Text = "Process Transaction";
            this.lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcess_LinkClicked);
            // 
            // ClientData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpAccount);
            this.Controls.Add(this.grpClient);
            this.Name = "ClientData";
            this.Text = "ClientData";
            this.Load += new System.EventHandler(this.ClientData_Load);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.GroupBox grpAccount;
        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.LinkLabel lnkProcess;
        private System.Windows.Forms.MaskedTextBox clientNumberMaskedTextBox;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.Label dateCreatedLabel1;
        private System.Windows.Forms.Label fullAddressLabel1;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.ComboBox accountNumberComboBox;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label balanceLabel1;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.Label notesLabel1;
        private System.Windows.Forms.Label descriptionLabel3;
    }
}