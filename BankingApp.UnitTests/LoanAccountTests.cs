using System;
using Xunit;

namespace BankingApp.UnitTests
{
    public class LoanAccountTests
    {
        [Fact]
        public void Withdraw_ShouldThrowException()
        {
            // Arrange
            double startingBalance = 200;
            var loanAccount = new LoanAccount(owner: "Joe Decker",
                                                    balance: startingBalance);

            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => loanAccount.Withdraw(0));
        }

        [Fact]
        public void Deposit_GivenValidAmount_ShouldUpdateBalance()
        {
            // Arrange
            double startingBalance = -1200;
            double depositAmount = 200;
            double expected = startingBalance + depositAmount;
            var loanAccount = new LoanAccount(owner: "John Wright",
                                              balance: startingBalance);

            // Act
            loanAccount.Deposit(depositAmount);

            // Assert
            double actual = loanAccount.Balance;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Deposit_GivenInvalidAmount_ShouldThrowException()
        {
            // Arrange
            double startingBalance = -1200;
            double negativeAmount = -100;
            var loanAccount = new LoanAccount(owner: "John Wright",
                                              balance: startingBalance);

            // Act, Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => loanAccount.Deposit(negativeAmount));
        }
    }
}
