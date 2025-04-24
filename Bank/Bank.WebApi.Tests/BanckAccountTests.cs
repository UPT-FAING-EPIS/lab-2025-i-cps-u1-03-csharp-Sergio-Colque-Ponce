using NUnit.Framework;
using Bank.WebApi.Models;
namespace Bank.WebApi.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [Test]
        public void Debit_WithAmountGreaterThanBalance_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100.0;
            double debitAmount = 150.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [Test]
        public void Debit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100.0;
            double debitAmount = -50.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [Test]
        public void Credit_WithPositiveAmount_IncreasesBalance()
        {
            // Arrange
            double beginningBalance = 100.0;
            double creditAmount = 25.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.AreEqual(125.0, account.Balance, 0.001, "Account not credited correctly");
        }

        [Test]
        public void Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100.0;
            double creditAmount = -10.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }

    }
}