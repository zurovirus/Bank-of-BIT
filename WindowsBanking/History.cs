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

namespace WindowsBanking
{
    /// <summary>
    /// Form representing the Transaction History class
    /// </summary>
    public partial class History : Form
    {
        ConstructorData constructorData;

        BankOfBIT_TP.Data.BankOfBIT_TPContext db = new BankOfBIT_TP.Data.BankOfBIT_TPContext();

        /// <summary>
        /// Form can only be opened with a Constructor Data object
        /// containing client and account details.
        /// </summary>
        /// <param name="constructorData">Populated Constructor data object.</param>
        public History(ConstructorData constructorData)
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
        /// Loads the form with data from the parent form.
        /// </summary>
        private void History_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                BusinessRules.AccountFormat(accountNumberMaskedLabel.Mask);

                var transactions = (from transaction in db.Transactions
                                    join type in db.TransactionTypes
                                    on transaction.TransactionTypeId equals type.TransactionTypeId
                                    where transaction.BankAccountId == constructorData.BankAccount.BankAccountId
                                    select new
                                    {
                                        DateCreated = transaction.DateCreated,
                                        TransactionType = type.Description,
                                        Deposit = transaction.Deposit,
                                        Withdrawal = transaction.Withdrawal,
                                        Notes = transaction.Notes
                                    });

                transactionBindingSource.DataSource = transactions.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }

        }
    }
}
