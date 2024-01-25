using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankOfBIT_TP.Data
{
    public class BankOfBIT_TPContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BankOfBIT_TPContext() : base("name=BankOfBIT_TPContext")
        {
        }

        public System.Data.Entity.DbSet<BankOfBIT_TP.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.AccountState> AccountStates { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.BankAccount> BankAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.BronzeState> BronzeStates { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.SilverState> SilverStates { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.GoldState> GoldStates { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.PlatinumState> PlatinumStates { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.ChequingAccount> ChequingAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.SavingsAccount> SavingsAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.InvestmentAccount> InvestmentAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.MortgageAccount> MortgageAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.NextUniqueNumber> NextUniqueNumbers { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.NextSavingsAccount> NextSavingsAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.NextMortgageAccount> NextMortgageAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.NextInvestmentAccount> NextInvestmentAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.NextChequingAccount> NextChequingAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.NextTransaction> NextTransactions { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.NextClient> NextClients { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.Payee> Payees { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.Institution> Institutions { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.TransactionType> TransactionTypes { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_TP.Transaction> Transactions { get; set; }
    }
}
