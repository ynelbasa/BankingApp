namespace BankingApp
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string owner, double balance) : base(owner, AccountType.Savings, balance) { }
    }
}