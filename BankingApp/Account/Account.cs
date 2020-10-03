using BankingApp.Common;
using System;

namespace BankingApp
{
    public class Account
    {
        private readonly string _owner;
        private readonly AccountType _type;
        private readonly ILogger _logger;

        public double Balance { get; set; }

        public Account(string owner, AccountType type, double balance)
        {
            Balance = balance;
            _owner = owner;
            _type = type;
            _logger = new Logger();
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("Insufficient funds");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid withdrawal amount");
            }

            Balance -= amount;
            LogTransaction(TransactionType.Withdraw, amount);
        }

        public virtual void Deposit(double amount) 
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid deposit amount");
            }

            Balance += amount;
            LogTransaction(TransactionType.Deposit, amount);
        }

        public void ShowAccountDetails()
        {
            _logger.Log($"Account Owner: {_owner}\nAccount Type: {_type}\nStarting Balance: ${Balance}\n");
        }

        public void CheckRemainingBalance()
        {
            _logger.Log($"Your remaining balance is ${Balance}.\n");
        }

        public void LogTransaction(TransactionType transactionType, double amount)
        {
            string message = string.Empty;
            switch (transactionType)
            {
                case TransactionType.Withdraw:
                    message = "withdrawn from";
                    break;
                case TransactionType.Deposit:
                    message = "deposited to";
                    break;  
            }

            Console.WriteLine($"${amount} has been {message} your {_type} account.");
        }
    }
}
