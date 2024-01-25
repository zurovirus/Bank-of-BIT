using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using BankOfBIT_TP;
using WindowsBanking.TransactionManager;

namespace WindowsBanking
{
    /// <summary>
    /// Form representing the ProcessTransaction class
    /// </summary>
    public partial class ProcessTransaction : Form
    {
        ConstructorData constructorData;

        BankOfBIT_TP.Data.BankOfBIT_TPContext db = new BankOfBIT_TP.Data.BankOfBIT_TPContext();

        /// Form can only be opened with a Constructor Data object
        /// containing client and account details.
        /// </summary>
        /// <param name="constructorData">Populated Constructor data object.</param>
        public ProcessTransaction(ConstructorData constructorData)
        {
            //Given, more code to be added.
            InitializeComponent();
            this.constructorData = constructorData;

            clientBindingSource.DataSource = constructorData.Client;
            bankAccountBindingSource.DataSource = constructorData.BankAccount;
        }

        /// <summary>
        /// Return to the Client Data form passing specific client and 
        /// account information within ConstructorData.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientData client = new ClientData(constructorData);
            client.MdiParent = this.MdiParent;
            client.Show();
            this.Close();
        }

        /// <summary>
        /// Always display the form in the top right corner of the frame.
        /// </summary>
        private void ProcessTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(0, 0);

                BusinessRules.AccountFormat(accountNumberMaskedLabel.Mask);

                IQueryable<TransactionType> types = db.TransactionTypes.Where(x => x.TransactionTypeId < 5);

                transactionTypeBindingSource.DataSource = types.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }

        }

        /// <summary>
        /// Represents the selected index changed event of the description combo box control.
        /// </summary>
        private void descriptionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (descriptionComboBox.Text) 
            {
                case "Deposit":
                    cboPayeeAccount.Visible = false;
                    lblPayeeAccount.Visible = false;
                    lblNoAdditionalAccounts.Visible = false;
                    lnkUpdate.Enabled = true;
                    break;

                case "Withdrawal":
                    cboPayeeAccount.Visible = false;
                    lblPayeeAccount.Visible = false;
                    lblNoAdditionalAccounts.Visible = false;
                    lnkUpdate.Enabled = true;
                    break;

                case "Bill Payment":
                    IQueryable<string> payees = db.Payees.Select(x => x.Description);
                    cboPayeeAccount.DataSource = payees.ToList();
                    cboPayeeAccount.Visible = true;
                    lblPayeeAccount.Visible = true;
                    lblNoAdditionalAccounts.Visible = false;
                    lnkUpdate.Enabled = true;

                    break;

                case "Transfer":
                    IQueryable<long> bankAccounts = db.BankAccounts.Where(x => x.BankAccountId != constructorData.BankAccount.BankAccountId 
                                                                            && x.ClientId == constructorData.Client.ClientId)
                                                                   .Select(x => x.AccountNumber);
                    if (bankAccounts.Count() < 1)
                    {
                        cboPayeeAccount.Visible = false;
                        lblPayeeAccount.Visible = false;
                        lblNoAdditionalAccounts.Visible = true;
                        lnkUpdate.Enabled = false;
                    }
                    else
                    {
                        cboPayeeAccount.DataSource = bankAccounts.ToList();
                        cboPayeeAccount.Visible = true;
                        lblPayeeAccount.Visible = true;
                        lblNoAdditionalAccounts.Visible = false;
                        lnkUpdate.Enabled = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// Represents the link clicked event of the lnkUpdate control.
        /// </summary>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Checks if the number is numeric else throws a message box.
            if (!Utility.Numeric.IsNumeric(txtAmount.Text, System.Globalization.NumberStyles.Float))
            {
                MessageBox.Show("Please enter a valid amount.", "Incorrect input");
            }
            else
            {
                // Checks if the amount entered is more than the amount in the balance if an option other than deposit is chosen,
                // else the transaction will take place.
                if (descriptionComboBox.Text != "Deposit" && constructorData.BankAccount.Balance < double.Parse(txtAmount.Text))
                {
                    MessageBox.Show("Insufficient funds exist for requested transaction", "Insufficient funds");
                }
                else
                {
                    TransactionManagerClient service = new TransactionManagerClient();

                    double? updatedBalance = null;

                    try
                    {
                        switch (descriptionComboBox.Text)
                        {
                            case "Deposit":
                                updatedBalance = service.Deposit(constructorData.BankAccount.BankAccountId, double.Parse(txtAmount.Text), descriptionComboBox.Text);
                                break;

                            case "Withdrawal":
                                updatedBalance = service.Withdrawal(constructorData.BankAccount.BankAccountId, double.Parse(txtAmount.Text), descriptionComboBox.Text);
                                break;

                            case "Bill Payment":
                                updatedBalance = service.BillPayment(constructorData.BankAccount.BankAccountId, double.Parse(txtAmount.Text), $"Bill Payment to {cboPayeeAccount.Text}.");
                                break;

                            case "Transfer":
                                int sendTo = int.Parse(cboPayeeAccount.Text);

                                BankAccount account = db.BankAccounts.Where(x => x.AccountNumber == sendTo).SingleOrDefault();

                                updatedBalance = service.Transfer(constructorData.BankAccount.BankAccountId, account.BankAccountId, double.Parse(txtAmount.Text),
                                                $"Transfer from {constructorData.BankAccount.AccountNumber.ToString()} to {cboPayeeAccount.Text}.");
                                break;
                        }

                        if (updatedBalance == null)
                        {
                            MessageBox.Show("Error completing Transaction", "Transaction Error");
                        }
                        else
                        {
                            balanceLabel1.Text = String.Format("{0:c2}", updatedBalance);
                        }   
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
        }
    }
}
