
namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var savingsAccount = new SavingsAccount(owner: "Joe Decker",
                                                    balance: 200);
            savingsAccount.ShowAccountDetails();
            savingsAccount.Withdraw(20);
            savingsAccount.CheckRemainingBalance();
            savingsAccount.Deposit(100);
            savingsAccount.CheckRemainingBalance();

            var loanAccount = new LoanAccount(owner: "John Wright",
                                              balance: -1200);
            loanAccount.ShowAccountDetails();
            loanAccount.Deposit(200);
            loanAccount.CheckRemainingBalance();

            var investmentAccount = new InvestmentAccount(owner: "Mike Schwartz", 
                                                          balance: 10000);
            investmentAccount.ShowAccountDetails();
            investmentAccount.Withdraw(2000);
            investmentAccount.CheckRemainingBalance();
            investmentAccount.Deposit(1200);
            investmentAccount.CheckRemainingBalance();
        }
    }
}
