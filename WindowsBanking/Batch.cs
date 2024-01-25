using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using BankOfBIT_TP.Data;
using Utility;
using BankOfBIT_TP;
using WindowsBanking.TransactionManager;

namespace WindowsBanking
{
    public class Batch
    {
        /// <summary>
        /// The name of the xml input file.
        /// </summary>
        private String inputFileName;

        /// <summary>
        /// The name of the log file.
        /// </summary>
        private String logFileName;

        /// <summary>
        /// The data to be written to the log file.
        /// </summary>
        private String logData;

        /// <summary>
        /// An instance of the database.
        /// </summary>
        private BankOfBIT_TPContext db;

        /// <summary>
        /// Compares two queries and logs the differences into a log file.
        /// </summary>
        /// <param name="beforeQuery">The first query to be compared.</param>
        /// <param name="afterQuery">The second query to be compared.</param>
        /// <param name="message">The error message.</param>
        private void ProcessErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, String message)
        {
            IEnumerable<XElement> errorRecords = beforeQuery.Except(afterQuery);

            foreach (XElement errorRecord in errorRecords)
            {
                logData += "\n--------ERROR--------";
                logData += $"\nFile: {inputFileName}";
                logData += $"\nInstitution: <institution>{errorRecord.Element("institution")}</institution>";
                logData += $"\nAccount Number: <account_no>{errorRecord.Element("account_no")}</account_no>";
                logData += $"\nTransaction Type: <type>{errorRecord.Element("type")}</type>";
                logData += $"\nAmount: <amount>{errorRecord.Element("amount")}</amount>";
                logData += $"\nNote: <notes>{errorRecord.Element("notes")}</notes>";
                logData += $"\nNodes: {errorRecord.Nodes().Count()}";
                logData += $"{message}";
            }
        }

        /// <summary>
        /// Processes the validity of the attribute of the xml file. Stops all processess if an error occurs.
        /// </summary>
        private void ProcessHeader()
        {
            XDocument document = XDocument.Load(inputFileName);

            XElement root = document.Element("account_update");

            if (root.Attributes().Count() != 3)
            {
                throw new Exception($"\nERROR: Incorrect number of root Attributes in file {inputFileName}.");
            }

            if (!DateTime.Parse(root.Attribute("date").Value).Equals(DateTime.Today))
            {
                throw new Exception($"\nERROR: The date is not today's date in file {inputFileName}.");
            }

            int institutionNumber = int.Parse(root.Attribute("institution").Value);

            this.db = new BankOfBIT_TPContext();

            Institution institute = db.Institutions.Where(x => x.InstitutionNumber == institutionNumber).SingleOrDefault();
            
            if (institute == null)
            {
                throw new Exception($"\nERROR: Institution {institutionNumber} does not exist in file {inputFileName}.");
            }

            int checksum = 0;

            IEnumerable<XElement> transactions = document.Descendants("transaction");

            IEnumerable<XElement> accountNumbers = transactions.Elements("account_no");

            foreach(XElement accountNumber in accountNumbers)
            {
                checksum += int.Parse(accountNumber.Value);
            }

            if (int.Parse(root.Attribute("checksum").Value) != checksum)
            {
                throw new Exception($"\nERROR: Invalid checksum {root.Attribute("checksum").Value} in file {inputFileName}.");
            }
        }

        /// <summary>
        /// Processes the elements of the xml file.
        /// </summary>
        private void ProcessDetails()
        {
            XDocument document = XDocument.Load(inputFileName);

            IEnumerable<XElement> firstQuery = document.Descendants().Where(x => x.Name == "transaction");

            IEnumerable<XElement> secondQuery = firstQuery.Where(x => x.Nodes().Count() == 5);

            ProcessErrors(firstQuery, secondQuery, "\nError: Incorrect number of child nodes.\n");

            IEnumerable<XElement> thirdQuery = secondQuery.Where(x => x.Element("institution").Value == document.Element("account_update").Attribute("institution").Value);

            ProcessErrors(secondQuery, thirdQuery, "\nError: Incorrect institution.\n");

            IEnumerable<XElement> fourthQuery = thirdQuery.Where(x => Numeric.IsNumeric(x.Element("type").Value, System.Globalization.NumberStyles.Integer) &&
                                                                 Numeric.IsNumeric(x.Element("amount").Value, System.Globalization.NumberStyles.Float));

            ProcessErrors(thirdQuery, fourthQuery, "\nError: Incorrect value inserted into type or amount. Must be Numeric.\n");

            IEnumerable<XElement> fifthQuery = fourthQuery.Where(x => int.Parse(x.Element("type").Value) == 2 || int.Parse(x.Element("type").Value) == 6);

            ProcessErrors(fourthQuery, fifthQuery, "\nError: Type node must be of type Withdrawal (2) or InterestCalculation (6).\n");

            IEnumerable<XElement> sixthQuery = fifthQuery.Where(x => (int.Parse(x.Element("type").Value) == 6 && float.Parse(x.Element("amount").Value) == 0) ||
                                                                (int.Parse(x.Element("type").Value) == 2 && float.Parse(x.Element("amount").Value) > 0));

            ProcessErrors(fifthQuery, sixthQuery, "\nError: Incorrect amount values for type Withdrawal or InterestCalculation\n");

            IEnumerable<long> bankAccounts = db.BankAccounts.Select(x => x.AccountNumber).ToList();

            IEnumerable<XElement> seventhQuery = sixthQuery.Where(x => bankAccounts.Contains(long.Parse(x.Element("account_no").Value)));

            ProcessErrors(sixthQuery, seventhQuery, "\nError: Incorrect bank account number entered.\n");

            ProcessTransactions(seventhQuery);
        }

        /// <summary>
        /// Processes the Transactions of the xlm file.
        /// </summary>
        /// <param name="transactionRecords">The records to be processed.</param>
        private void ProcessTransactions(IEnumerable<XElement> transactionRecords)
        {
            TransactionManagerClient transaction = new TransactionManagerClient();

            foreach (XElement transactionRecord in transactionRecords)
            {
                double? balance;

                int accountNumber = int.Parse(transactionRecord.Element("account_no").Value);

                BankAccount account = db.BankAccounts.Where(x => x.AccountNumber == accountNumber).SingleOrDefault();

                if (transactionRecord.Element("type").Value == "2")
                {
                    balance = transaction.Withdrawal(account.BankAccountId,
                                           double.Parse(transactionRecord.Element("amount").Value),
                                           transactionRecord.Element("notes").Value);
                    if (balance != null)
                    {
                        logData += $"\nTransaction completed successfully: Withdrawal - {transactionRecord.Element("amount").Value} " +
                                   $"applied to account {transactionRecord.Element("account_no").Value}.";
                    }
                    else
                    {
                        logData += "\nTransaction completed unsuccessfully.";
                    }
                }
                else
                {
                    balance = transaction.CalculateInterest(account.BankAccountId,
                                           transactionRecord.Element("notes").Value);

                    if (balance != null)
                    {
                        logData += $"\nTransaction completed successfully: Interest - *** " +
                                   $"applied to account {transactionRecord.Element("account_no").Value}.";
                    }
                    else
                    {
                        logData += "\nTransaction completed unsuccessfully.";
                    }
                }
            }
        }

        /// <summary>
        /// Writes all processing data into a logfile.
        /// </summary>
        /// <returns>The processed data and errors.</returns>
        public String WriteLogData()
        {
            //to be modified
            StreamWriter writer = new StreamWriter(logFileName);

            writer.Write(logData);
            writer.Close();

            string errors = logData;

            logData = "";

            inputFileName = "";

            return errors;
        }

        /// <summary>
        /// Creates the log files and checks if the xml file exists then processes the header and details.
        /// </summary>
        /// <param name="institution">The institution the transaction will take place at.</param>
        /// <param name="key">The key used to encrypt the data.</param>
        public void ProcessTransmission(String institution, String key)
        {
            DateTime date = DateTime.Today;

            this.inputFileName = $"{date.ToString("yyyy")}-{date.DayOfYear.ToString("000")}-{institution}.xml";

            this.logFileName = $"LOG {inputFileName.Substring(0, inputFileName.Length - 4)}.txt";

            if (!File.Exists(inputFileName))
            {
                this.logData += $"\nThe file {inputFileName} does not exist.";
            }
            else
            {
                try
                {
                    ProcessHeader();
                    ProcessDetails();
                }
                catch (Exception ex)
                {
                    this.logData += $"{ex.Message}\n";
                }           
            }
        }
    }
}
