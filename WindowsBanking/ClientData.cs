using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankOfBIT_TP;

namespace WindowsBanking
{
    /// <summary>
    /// Form representing the Client Data class
    /// </summary>
    public partial class ClientData : Form
    {
        ConstructorData constructorData = new ConstructorData();

        BankOfBIT_TP.Data.BankOfBIT_TPContext db = new BankOfBIT_TP.Data.BankOfBIT_TPContext();

        /// <summary>
        /// This constructor will execute when the form is opened
        /// from the MDI Frame.
        /// </summary>
        public ClientData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This constructor will execute when the form is opened by
        /// returning from the History or Transaction forms.
        /// </summary>
        /// <param name="constructorData">Populated ConstructorData object.</param>
        public ClientData(ConstructorData constructorData)
        {
            //Given:
            InitializeComponent();
            this.constructorData = constructorData;

            //More code to be added:
            
            clientNumberMaskedTextBox.Text = constructorData.Client.ClientNumber.ToString();

            clientNumberMaskedTextBox_Leave(null, null);

        }

        /// <summary>
        /// Open the Transaction form passing ConstructorData object.
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Given, more code to be added.
            PopulateConstructorData();
            ProcessTransaction transaction = new ProcessTransaction(constructorData);
            transaction.MdiParent = this.MdiParent;
            transaction.Show();
            this.Close();
        }

        /// <summary>
        /// Open the History form passing ConstructorData object.
        /// </summary>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Given, more code to be added.
            PopulateConstructorData();
            History history = new History(constructorData);
            history.MdiParent = this.MdiParent;
            history.Show();
            this.Close();
        }

        /// <summary>
        /// Always display the form in the top right corner of the frame.
        /// </summary>
        private void ClientData_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
        }

        /// <summary>
        /// Handles the leave event of the clientNumber maskedtextbox control
        /// </summary>
        private void clientNumberMaskedTextBox_Leave(object sender, EventArgs e)
        {
            if (clientNumberMaskedTextBox.Text != string.Empty)
            {
                int clientNumber = int.Parse(clientNumberMaskedTextBox.Text.ToString());

                Client client = db.Clients.Where(x => x.ClientNumber == clientNumber).SingleOrDefault();

                // If client is null, a message will appear, else the controls will be populated.
                if (client == null)
                {
                    lnkDetails.Enabled = false;
                    lnkProcess.Enabled = false;

                    clientNumberMaskedTextBox.Focus();

                    clientBindingSource.DataSource = typeof(Client);
                    bankAccountBindingSource.DataSource = typeof(BankAccount);

                    string message = $"Client Number: {clientNumberMaskedTextBox.Text.ToString()} does not exist.";
                    string title = "Invalid Client Number";

                    MessageBox.Show(message, title);
                }
                else
                {
                    clientBindingSource.DataSource = client;

                    IQueryable<BankAccount> bankAccounts = (from results in db.BankAccounts where results.ClientId == client.ClientId select results);

                    if (bankAccounts == null)
                    {
                        lnkDetails.Enabled = false;
                        lnkProcess.Enabled = false;

                        bankAccountBindingSource.DataSource = typeof(BankAccount);
                    }
                    else
                    {
                        bankAccountBindingSource.DataSource = bankAccounts.ToList();
                        lnkDetails.Enabled = true;
                        lnkProcess.Enabled = true;
                        bankAccountBindingSource.DataSource = bankAccounts.ToList();

                        if(constructorData.BankAccount != null)
                        {
                            accountNumberComboBox.Text = constructorData.BankAccount.AccountNumber.ToString();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Populates the constructor data with the current selections.
        /// </summary>
        private void PopulateConstructorData()
        {
            this.constructorData.Client = (Client)clientBindingSource.Current;
            this.constructorData.BankAccount = (BankAccount)bankAccountBindingSource.Current;
        }
    }
}
