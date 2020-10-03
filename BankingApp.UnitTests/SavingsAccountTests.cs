using System;
using Xunit;

namespace BankingApp.UnitTests
{
    public class SavingsAccountTests
    {
        [Fact]
        public void Withdraw_GivenValidAmount_ShouldUpdateBalance()
        {
            // Arrange
            double startingBalance = 200;
            double withdrawalAmount = 20;
            double expected = startingBalance - withdrawalAmount;
            var savingsAccount = new SavingsAccount(owner: "Joe Decker",
                                                    balance: startingBalance);

            // Act
            savingsAccount.Withdraw(withdrawalAmount);

            // Assert
            double actual = savingsAccount.Balance;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Withdraw_GivenInvalidAmount_ShouldThrowException()
        {
            // Arrange
            double startingBalance = 200;
            double exceedingAmount = 300;
            double negativeAmount = -100;
            var savingsAccount = new SavingsAccount(owner: "Joe Decker",
                                                    balance: startingBalance);

            // Act, Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => savingsAccount.Withdraw(negativeAmount));
            Assert.Throws<ArgumentOutOfRangeException>(() => savingsAccount.Withdraw(exceedingAmount));
        }

        [Fact]
        public void Deposit_GivenValidAmount_ShouldUpdateBalance() 
        {
            // Arrange
            double startingBalance = 200;
            double depositAmount = 100;
            double expected = startingBalance + depositAmount;
            var savingsAccount = new SavingsAccount(owner: "Joe Decker",
                                                    balance: startingBalance);

            // Act
            savingsAccount.Deposit(depositAmount);

            // Assert
            double actual = savingsAccount.Balance;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Deposit_GivenInvalidAmount_ShouldThrowException()
        {
            // Arrange
            double startingBalance = 200;
            double negativeAmount = -100;
            var savingsAccount = new SavingsAccount(owner: "Joe Decker",
                                                    balance: startingBalance);

            // Act, Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => savingsAccount.Deposit(negativeAmount));
        }
    }
}
