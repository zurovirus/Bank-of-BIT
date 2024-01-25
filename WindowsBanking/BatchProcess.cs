using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankOfBIT_TP.Data;
using BankOfBIT_TP;

namespace WindowsBanking
{
    /// <summary>
    /// The batch process form class.
    /// </summary>
    public partial class BatchProcess : Form
    {
        BankOfBIT_TPContext db = new BankOfBIT_TPContext();

        /// <summary>
        /// Initializes the BatchProcess class.
        /// </summary>
        public BatchProcess()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Always display the form in the top right corner of the frame. Loads the data for the form.
        /// </summary>
        private void BatchProcess_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
            IQueryable<Institution> institutions = db.Institutions;

            institutionBindingSource.DataSource = institutions.ToList();
        }

        /// <summary>
        /// Handles the link clicked event of the link process label
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //given:  Ensure key has been entered.  Note: for use with Assignment 9
            //if(txtKey.Text.Length == 0)
            //{
            //    MessageBox.Show("Please enter a key to decrypt the input file(s).", "Key Required");
            //}
            Batch batch = new Batch();

            string log = string.Empty;

            if (radSelect.Checked)
            {
                batch.ProcessTransmission(descriptionComboBox.SelectedValue.ToString(), "0");

                log = batch.WriteLogData();
            }

            if (radAll.Checked)
            {
                foreach (Institution item in descriptionComboBox.Items)
                {
                    batch.ProcessTransmission(item.InstitutionNumber.ToString(), "0");

                    log += batch.WriteLogData();
                }
            }

            rtxtLog.Text = log;
        }

        /// <summary>
        /// Handles the changed event of the radio buttons.
        /// </summary>
        private void radSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelect.Checked)
            {
                descriptionComboBox.Visible = true;
            }
            else
            {
                descriptionComboBox.Visible = false;
            }
        }
    }
}
