using System;
using Xunit;

namespace BankingApp.UnitTests
{
    public class InvestmentAccountTests
    {
        [Fact]
        public void Withdraw_GivenValidAmount_ShouldUpdateBalance()
        {
            // Arrange
            double startingBalance = 10000;
            double withdrawalAmount = 2000;
            double expected = startingBalance - (withdrawalAmount + (withdrawalAmount * InvestmentAccount.MANAGEMENT_FEE));
            var investmentAccount = new InvestmentAccount(owner: "Mike Schwartz",
                                                          balance: startingBalance);

            // Act
            investmentAccount.Withdraw(withdrawalAmount);

            // Assert
            double actual = investmentAccount.Balance;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Withdraw_GivenInvalidAmount_ShouldThrowException()
        {
            // Arrange
            double startingBalance = 10000;
            double exceedingAmount = 12000;
            double negativeAmount = -100;
            var investmentAccount = new InvestmentAccount(owner: "Mike Schwartz",
                                                          balance: startingBalance);

            // Act, Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => investmentAccount.Withdraw(negativeAmount));
            Assert.Throws<ArgumentOutOfRangeException>(() => investmentAccount.Withdraw(exceedingAmount));
        }

        [Fact]
        public void Deposit_GivenValidAmount_ShouldUpdateBalance()
        {
            // Arrange
            double startingBalance = 1000;
            double depositAmount = 1200;
            double expected = startingBalance + depositAmount;
            var investmentAccount = new InvestmentAccount(owner: "Mike Schwartz",
                                                          balance: startingBalance);

            // Act
            investmentAccount.Deposit(depositAmount);

            // Assert
            double actual = investmentAccount.Balance;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Deposit_GivenInvalidAmount_ShouldThrowException()
        {
            // Arrange
            double startingBalance = 200;
            double negativeAmount = -100;
            var investmentAccount = new InvestmentAccount(owner: "Mike Schwartz",
                                                          balance: startingBalance);

            // Act, Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => investmentAccount.Deposit(negativeAmount));
        }
    }
}
