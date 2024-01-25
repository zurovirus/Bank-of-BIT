 /*
 * Name: To Phuc 
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 3
 * Created: 2022-01-07
 * Updated: 2022-01-07
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility;
using BankOfBIT_TP.Data;
using System.Data.SqlClient;
using System.Data;

namespace BankOfBIT_TP
{
    /// <summary>
    /// Client Model. Represents the Client table in the database.
    /// </summary>
    public class Client
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Display(Name = "Client\nNumber")]
        public long ClientNumber { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        [Display(Name = "First\nName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        [Display(Name = "Last\nName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [RegularExpression("^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK|YT)",
            ErrorMessage = "Invalid Canadian province entered.")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateCreated { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}",
                                     FirstName, LastName);
            }
        }

        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return String.Format("{0} {1}, {2}",
                                     Address, City, Province);
            }
        }

        public void SetNextClientNumber()
        {
            ClientNumber = (long)StoredProcedure.NextNumber("NextClient");
        }

        public virtual ICollection<BankAccount> BankAccount { get; set; }
    }

    /// <summary>
    /// AccountState model. Represents the AccountState table in the database.
    /// </summary>
    public abstract class AccountState
    {
        protected static BankOfBIT_TPContext db = new BankOfBIT_TPContext();

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountStateId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Lower\nLimit")]
        public double LowerLimit { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Upper\nLimit")]
        public double UpperLimit { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:p2}")]
        public double Rate { get; set; }

        [Display(Name = "Account\nState")]
        public string Description
        {
            get
            {
                return BusinessRules.ParseName(GetType().Name, "State");
            }
        }

        public abstract double RateAdjustment(BankAccount bankAccount);

        public abstract void StateChangeCheck(BankAccount bankAccount);

        public virtual ICollection<BankAccount> BankAccount { get; set; }
    }

    /// <summary>
    /// BronzeState model. Represents the BronzeState table in the database.
    /// </summary>
    public class BronzeState : AccountState
    {
        private static BronzeState bronzeState;

        /// <summary>
        /// Instantiates an instance of BronzeState.
        /// </summary>
        private BronzeState()
        {
            this.LowerLimit = 0;
            this.UpperLimit = 5000;
            this.Rate = 0.01;
        }

        /// <summary>
        /// Gets an instance of BronzeState if exists.
        /// Creates an instance of BronzeState if it does not exist.
        /// </summary>
        /// <returns>The instance of BronzeState.</returns>
        public static BronzeState GetInstance()
        {
            if (bronzeState == null)
            {
                bronzeState = db.BronzeStates.SingleOrDefault();

                if (bronzeState == null)
                {
                    bronzeState = new BronzeState();

                    db.BronzeStates.Add(bronzeState);

                    db.SaveChanges();
                }
            }

            return bronzeState;
        }

        /// <summary>
        /// Adjusts the interest rate if below $0.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns>The adjusted interest rate.</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double adjustedRate = this.Rate;

            if (bankAccount.Balance < 0)
            {
                adjustedRate += .045;
            }

            return adjustedRate;
        }

        /// <summary>
        /// Checks the balance of the bank account and upgrades the state to the next tier if the upper limit is exceeded.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance > this.UpperLimit)
            {
                bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;
            }

            db.SaveChanges();
        }
    }

    /// <summary>
    /// SilverState model. Represents the SilverState table in the database.
    /// </summary>
    public class SilverState : AccountState
    {
        private static SilverState silverState;

        /// <summary>
        /// Instantiates an instance of SilverState.
        /// </summary>
        private SilverState()
        {
            this.LowerLimit = 5000;
            this.UpperLimit = 10000;
            this.Rate = 0.0125;
        }

        /// <summary>
        /// Gets an instance of SilverState if exists.
        /// Creates an instance of SilverState if it does not exist.
        /// </summary>
        /// <returns>The instance of SilverState.</returns>
        public static SilverState GetInstance()
        {
            if (silverState == null)
            {
                silverState = db.SilverStates.SingleOrDefault();

                if (silverState == null)
                {
                    silverState = new SilverState();

                    db.SilverStates.Add(silverState);

                    db.SaveChanges();
                }
            }

            return silverState;
        }

        /// <summary>
        /// Adjusts the interest rate.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns>The adjusted interest rate.</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double adjustedRate = this.Rate;

            return adjustedRate;
        }

        /// <summary>
        /// Checks the state of the bank account and upgrades the state to the next tier if the upper limit is exceeded, 
        /// or downgrades the state if the lower limit is exceeded.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance > this.UpperLimit)
            {
                bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;
            }

            if (bankAccount.Balance < this.LowerLimit)
            {
                bankAccount.AccountStateId = BronzeState.GetInstance().AccountStateId;
            }

            db.SaveChanges();
        }
    }

    /// <summary>
    /// GoldState model. Represents the GoldState table in the database.
    /// </summary>
    public class GoldState : AccountState
    {
        private static GoldState goldState;

        /// <summary>
        /// Instantiates an instance of GoldState.
        /// </summary>
        private GoldState()
        {
            this.LowerLimit = 10000;
            this.UpperLimit = 20000;
            this.Rate = 0.0200;
        }

        /// <summary>
        /// Gets an instance of GoldState if exists.
        /// Creates an instance of GoldState if it does not exist.
        /// </summary>
        /// <returns>The instance of GoldState.</returns>
        public static GoldState GetInstance()
        {
            if (goldState == null)
            {
                goldState = db.GoldStates.SingleOrDefault();

                if (goldState == null)
                {
                    goldState = new GoldState();

                    db.GoldStates.Add(goldState);

                    db.SaveChanges();
                }
            }

            return goldState;
        }

        /// <summary>
        /// Adjusts the interest rate if the account is older than 10 years.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns>The adjusted interest rate.</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double adjustedRate = this.Rate;

            if (bankAccount.DateCreated <= DateTime.Now.AddYears(-10))
            {
                adjustedRate += .01;
            }

            return adjustedRate;
        }

        /// <summary>
        /// Checks the balance of the bank account and upgrades the state to the next tier if the upper limit is exceeded, 
        /// or downgrades the state if the lower limit is exceeded.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance > this.UpperLimit)
            {
                bankAccount.AccountStateId = PlatinumState.GetInstance().AccountStateId;
            }

            if (bankAccount.Balance < this.LowerLimit)
            {
                bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;
            }

            db.SaveChanges();
        }
    }

    /// <summary>
    /// PlatinumState model. Represents the PlatinumState table in the database.
    /// </summary>
    public class PlatinumState : AccountState
    {
        private static PlatinumState platinumState;

        /// <summary>
        /// Instantiates an instance of PlatinumState.
        /// </summary>
        private PlatinumState()
        {
            this.LowerLimit = 20000;
            this.UpperLimit = 0;
            this.Rate = 0.0250;
        }

        /// <summary>
        /// Gets an instance of PlatinumState if exists.
        /// Creates an instance of PlatinumState if it does not exist.
        /// </summary>
        /// <returns>The instance of PlatinumState.</returns>
        public static PlatinumState GetInstance()
        {
            if (platinumState == null)
            {
                platinumState = db.PlatinumStates.SingleOrDefault();

                if (platinumState == null)
                {
                    platinumState = new PlatinumState();

                    db.PlatinumStates.Add(platinumState);

                    db.SaveChanges();
                }
            }

            return platinumState;
        }

        /// <summary>
        /// Adjusts the interest rate if the account is older than 10 years, or if the account has double the lower limit.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns>The adjusted interest rate.</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double adjustedRate = this.Rate;

            if (bankAccount.DateCreated <= DateTime.Now.AddYears(-10))
            {
                adjustedRate += .01;
            }

            if (bankAccount.Balance > this.LowerLimit * 2)
            {
                adjustedRate += .005;
            }

            return adjustedRate;
        }

        /// <summary>
        /// Checks the balance of the bank account and downgrades the state if the lower limit is exceeded.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance < this.LowerLimit)
            {
                bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;
            }

            db.SaveChanges();
        }
    }

    /// <summary>
    /// BankAccount model. Represents the BankAccount table in the database.
    /// </summary>
    public abstract class BankAccount
    {
        BankOfBIT_TPContext db = new BankOfBIT_TPContext();

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("AccountState")]
        public int AccountStateId { get; set; }

        [Display(Name = "Account\nNumber")]
        public long AccountNumber { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Balance { get; set; }

        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateCreated { get; set; }

        public string Notes { get; set; }

        public string Description
        {
            get
            {
                return BusinessRules.ParseName(GetType().Name, "Account");
            }
        }

        /// <summary>
        /// Changes the Account state of the Bank Account if limits are exceeded.
        /// </summary>
        public void ChangeState()
        {
            AccountState state = db.AccountStates.Find(this.AccountStateId);
            int previousState = 0;

            while (previousState != state.AccountStateId)
            {
                state.StateChangeCheck(this);

                previousState = state.AccountStateId;

                state = db.AccountStates.Find(AccountStateId);
            }
        }

        /// <summary>
        /// Sets the next account number.
        /// </summary>
        public abstract void SetNextAccountNumber();

        public virtual Client Client { get; set; }
        public virtual AccountState AccountState { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }

    /// <summary>
    /// SavingsAccount model. Represents the SavingsAccount table in the database.
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        [Required]
        [Display(Name = "SavingService\nCharges")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double SavingServiceCharges { get; set; }

        /// <summary>
        /// Sets the next savings account number.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedure.NextNumber("NextSavingsAccount");
        }
    }

    /// <summary>
    /// MortgageAccount model. Represents the MortgageAccount table in the database.
    /// </summary>
    public class MortgageAccount : BankAccount
    {
        [Required]
        [Display(Name = "Mortgage\nRate")]
        [DisplayFormat(DataFormatString = "{0:p2}")]
        public double MortgageRate { get; set; }

        [Required]
        public int Amortization { get; set; }

        /// <summary>
        /// Sets the next mortgage account number.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedure.NextNumber("NextMortgageAccount");
        }
    }

    /// <summary>
    /// InvestmentAccount model. Represents the InvestmentAccount table in the database.
    /// </summary>
    public class InvestmentAccount : BankAccount
    {
        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:p2}")]
        public double InterestRate { get; set; }

        /// <summary>
        /// Sets the next investment account number.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedure.NextNumber("NextInvestmentAccount");
        }
    }

    /// <summary>
    /// ChequingAccount model. Represents the ChequingAccount table in the database.
    /// </summary>
    public class ChequingAccount : BankAccount
    {
        [Required]
        [Display(Name = "ChequingService\nCharges")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double ChequingServiceCharges { get; set; }

        /// <summary>
        /// Sets the next chequing account number.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedure.NextNumber("NextChequingAccount");
        }
    }

    /// <summary>
    /// Transaction Model. Represents the Transaction table in the database.
    /// </summary>
    public class Transaction
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }

        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }

        [Display(Name = "Number")]
        public long TransactionNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double? Deposit { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double? Withdrawal { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateCreated { get; set; }

        public String Notes { get; set; }

        /// <summary>
        /// Automatically sets the next transaction number.
        /// </summary>
        public void SetNextTransactionNumber()
        {
            TransactionNumber = (long)StoredProcedure.NextNumber("NextTransaction");
        }

        public virtual BankAccount BankAccount { get; set; }

        public virtual TransactionType TransactionType { get; set; }
    }

    /// <summary>
    /// TransactionType model. Represents the TransactionType table in the database.
    /// </summary>
    public class TransactionType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; }

        [Required]
        [Display(Name = "Type")]
        public String Description { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }

    /// <summary>
    /// Institution model. Represents the Institution table in the database.
    /// </summary>
    public class Institution
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InstitutionId { get; set; }

        [Required]
        [Display(Name = "Number")]
        public int InstitutionNumber { get; set; }

        [Required]
        [Display(Name = "Institution")]
        public String Description { get; set; }
    }

    /// <summary>
    /// Payee model. Represents the Payee table in the database.
    /// </summary>
    public class Payee
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PayeeId { get; set; }

        [Required]
        [Display(Name = "Payee")]
        public String Description { get; set; }
    }

    /// <summary>
    /// Stores the SQL procedures.
    /// </summary>
    public static class StoredProcedure
    {
        public static long? NextNumber(String discriminator)
        {
            try
            {
                // An object that opens a connection to the database.
                SqlConnection connection = new SqlConnection("Data Source=localhost; " +
                                                             "Initial Catalog=BankOfBIT_TPContext;Integrated Security=True");

                // The current return value of long?.
                long? returnValue = 0;

                // Retrieves a string using the stored procedure Next Number text in the database.
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);

                // Interprets the string as a stored procedure.
                storedProcedure.CommandType = CommandType.StoredProcedure;

                // Sets the value of the discriminator in the StoredProcedure with the discriminator passed by the class.
                storedProcedure.Parameters.AddWithValue("@Discriminator", discriminator);

                // Instantiates an instance of the SqlParameter class with the values from the Next Number stored procedure.
                SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                {
                    // Sets the outputParameter as an output only type.
                    Direction = ParameterDirection.Output
                };

                // Adds the output parameter created to the storedProcedure.
                storedProcedure.Parameters.Add(outputParameter);

                // Opens the connection tot he database.
                connection.Open();

                // Executes the command.
                storedProcedure.ExecuteNonQuery();
                
                // Closes the connection.
                connection.Close();

                // Sets the return value to the output value from the database stored procedure cast as a long?
                returnValue = (long?)outputParameter.Value;

                return returnValue;
            }
            catch (Exception)
            {
                long? returnValue = null;

                return (long)returnValue;
            }
        }
    }

    /// <summary>
    /// NextuniqueNumber model. Represents the NextUniqueNumber table in the database.
    /// </summary>
    public abstract class NextUniqueNumber
    {
        protected static BankOfBIT_TPContext db = new BankOfBIT_TPContext();

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextUniqueNumberId { get; set; }

        [Required]
        public long NextAvailableNumber { get; set; }
    }

    /// <summary>
    /// NextSavingsAccount model. Represents the NextSavingsAccount table in the database
    /// </summary>
    public class NextSavingsAccount : NextUniqueNumber
    {
        private static NextSavingsAccount nextSavingsAccount;

        /// <summary>
        /// Instantiates an instance of the NextSavingsAccount.
        /// </summary>
        private NextSavingsAccount()
        {
            this.NextAvailableNumber = 20000;
        }

        /// <summary>
        /// Gets an instance of NextSavingsAccount if exists.
        /// Creates an instance of NextSavingsAccount if it does not exist.
        /// </summary>
        /// <returns>The instance of NextSavingsAccount.</returns>
        public static NextSavingsAccount GetInstance()
        {
            if (nextSavingsAccount == null)
            {
                nextSavingsAccount = db.NextSavingsAccounts.SingleOrDefault();

                if (nextSavingsAccount == null)
                {
                    nextSavingsAccount = new NextSavingsAccount();

                    db.NextSavingsAccounts.Add(nextSavingsAccount);

                    db.SaveChanges();
                }
            }

            return nextSavingsAccount;
        }
    }

    /// <summary>
    /// NextMortgageAccount model. Represents the NextMortgageAccount table in the database
    /// </summary>
    public class NextMortgageAccount : NextUniqueNumber
    {
        private static NextMortgageAccount nextMortgageAccount;

        /// <summary>
        /// Instantiates an instance of the NextMortgageAccount.
        /// </summary>
        private NextMortgageAccount()
        {
            this.NextAvailableNumber = 200000;
        }

        /// <summary>
        /// Gets an instance of NextMortgageAccount if exists.
        /// Creates an instance of NextMortageAccount if it does not exist.
        /// </summary>
        /// <returns>The instance of NextMortgageAccount.</returns>
        public static NextMortgageAccount GetInstance()
        {
            if (nextMortgageAccount == null)
            {
                nextMortgageAccount = db.NextMortgageAccounts.SingleOrDefault();

                if (nextMortgageAccount == null)
                {
                    nextMortgageAccount = new NextMortgageAccount();

                    db.NextMortgageAccounts.Add(nextMortgageAccount);

                    db.SaveChanges();
                }
            }

            return nextMortgageAccount;
        }
    }

    /// <summary>
    /// NextInvestmentAccount model. Represents the NextInvestmentAccount table in the database
    /// </summary>
    public class NextInvestmentAccount : NextUniqueNumber
    {
        private static NextInvestmentAccount nextInvestmentAccount;

        /// <summary>
        /// Instantiates an instance of the NextInvestmentAccount.
        /// </summary>
        private NextInvestmentAccount()
        {
            NextAvailableNumber = 2000000;
        }

        /// <summary>
        /// Gets an instance of NextInvestmentAccount if exists.
        /// Creates an instance of NextInvestmentAccount if it does not exist.
        /// </summary>
        /// <returns>The instance of NextInvestmentAccount.</returns>
        public static NextInvestmentAccount GetInstance()
        {
            if (nextInvestmentAccount == null)
            {
                nextInvestmentAccount = db.NextInvestmentAccounts.SingleOrDefault();

                if (nextInvestmentAccount == null)
                {
                    nextInvestmentAccount = new NextInvestmentAccount();

                    db.NextInvestmentAccounts.Add(nextInvestmentAccount);

                    db.SaveChanges();
                }
            }

            return nextInvestmentAccount;
        }
    }

    /// <summary>
    /// NextChequingAccount model. Represents the NextChequingAccount table in the database
    /// </summary>
    public class NextChequingAccount : NextUniqueNumber
    {
        private static NextChequingAccount nextChequingAccount;

        /// <summary>
        /// Instantiates an instance of the NextChequingAccount.
        /// </summary>
        private NextChequingAccount()
        {
            NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Gets an instance of NextChequingAccount if exists.
        /// Creates an instance of NextChequingAccount if it does not exist.
        /// </summary>
        /// <returns>The instance of NextChequingAccount.</returns>
        public static NextChequingAccount GetInstance()
        {
            if (nextChequingAccount == null)
            {
                nextChequingAccount = db.NextChequingAccounts.SingleOrDefault();

                if (nextChequingAccount == null)
                {
                    nextChequingAccount = new NextChequingAccount();

                    db.NextChequingAccounts.Add(nextChequingAccount);

                    db.SaveChanges();
                }
            }

            return nextChequingAccount;
        }
    }


    /// <summary>
    /// NextClient model. Represents the NextClient table in the database
    /// </summary>
    public class NextClient : NextUniqueNumber
    {
        private static NextClient nextClient;

        /// <summary>
        /// Instantiates an instance of the NextClient.
        /// </summary>
        private NextClient()
        {
            NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Gets an instance of NextClient if exists.
        /// Creates an instance of NextClient if it does not exist.
        /// </summary>
        /// <returns>The instance of NextClient.</returns>
        public static NextClient GetInstance()
        {
            if (nextClient == null)
            {
                nextClient = db.NextClients.SingleOrDefault();

                if (nextClient == null)
                {
                    nextClient = new NextClient();

                    db.NextClients.Add(nextClient);

                    db.SaveChanges();
                }
            }

            return nextClient;
        }
    }

    /// <summary>
    /// NextTransaction model. Represents the NextTransaction table in the database
    /// </summary>
    public class NextTransaction : NextUniqueNumber
    {
        private static NextTransaction nextTransaction;

        /// <summary>
        /// Instantiates an instance of the NextTransaction.
        /// </summary>
        private NextTransaction()
        {
            NextAvailableNumber = 700;
        }

        /// <summary>
        /// Gets an instance of NextTransaction if exists.
        /// Creates an instance of NextTransaction if it does not exist.
        /// </summary>
        /// <returns>The instance of NextTransaction.</returns>
        public static NextTransaction GetInstance()
        {
            if (nextTransaction == null)
            {
                nextTransaction = db.NextTransactions.SingleOrDefault();

                if (nextTransaction == null)
                {
                    nextTransaction = new NextTransaction();

                    db.NextTransactions.Add(nextTransaction);

                    db.SaveChanges();
                }
            }

            return nextTransaction;
        }
    }
}