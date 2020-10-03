using System;

namespace BankingApp
{
    public class InvestmentAccount : Account
    {
        public static double MANAGEMENT_FEE = 0.02;

        public InvestmentAccount(string owner, double balance) : base(owner, AccountType.Investment, balance)
        {
        }

        public override void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("Insufficient funds");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid withdrawal amount");
            }

            Balance -= amount + (amount * InvestmentAccount.MANAGEMENT_FEE);
            LogTransaction(TransactionType.Withdraw, amount);
        }
    }
}
