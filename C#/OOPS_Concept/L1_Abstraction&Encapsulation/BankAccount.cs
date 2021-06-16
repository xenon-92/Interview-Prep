using System;
using System.Collections.Generic;

namespace L1_Abstraction_Encapsulation
{
    public class BankAccount
    {
        /*
        This is a data member. It's private, which means it can only be accessed by code inside the BankAccount class. 
        It's a way of separating the public responsibilities (like having an account number)
        from the private implementation (how account numbers are generated). 
        It is also static, which means it is shared by all of the BankAccount objects.
         The value of a non-static variable is unique to each instance of the BankAccount object.
        */
        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        private readonly decimal minimumBalance;
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
        {

        }
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed += 1;

            this.Owner = name;
            //this.Balance = initialBalance;
            this.minimumBalance = minimumBalance;
            if (initialBalance > 0)
            {
                MakeDeposit(initialBalance, DateTime.Now, "initial balance");

            }
        }
        private List<Transaction> allTransactions = new List<Transaction>();
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        // public void MakeWithdrawl(decimal amount, DateTime date, string note)
        // {
        //     if (amount <= 0)
        //     {
        //         throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        //     }
        //     if (Balance - amount <= minimumBalance)
        //     {
        //         throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        //     }
        //     Transaction withdrawl = new Transaction(-amount, date, note);
        //     allTransactions.Add(withdrawl);
        // }
        public void MakeWithdrawl(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");
            }

            return report.ToString();
        }
        public virtual void PerformMonthEndTransactions()
        {

        }
    }
}