using System;

namespace BankingApp
{
    public class LoanAccount : Account
    {
        public LoanAccount(string owner, double balance) : base(owner, AccountType.Loan, balance) { }

        public override void Withdraw(double amount) 
        {
            throw new InvalidOperationException($"Withdrawal is not allowed for {AccountType.Loan} accounts.");
        }
    }
}
