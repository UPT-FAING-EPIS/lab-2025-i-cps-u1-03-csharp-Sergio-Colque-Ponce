using NUnit.Framework;
using Bank.WebApi.Models;

namespace Bank.WebApi.Tests
{
    /// <summary>
    /// Contiene las pruebas unitarias para la clase BankAccount.
    /// Verifica el comportamiento correcto de las operaciones de débito y crédito.
    /// </summary>
    /// <remarks>
    /// Esta clase de pruebas utiliza NUnit para validar:
    /// - Operaciones de débito válidas e inválidas
    /// - Operaciones de crédito válidas e inválidas
    /// - Manejo correcto de excepciones
    /// </remarks>
    public class BankAccountTests
    {
        /// <summary>
        /// Verifica que un débito con monto válido actualice correctamente el balance.
        /// </summary>
        /// <remarks>
        /// Prueba el escenario normal donde el monto a debitar es menor que el balance actual.
        /// </remarks>
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

        /// <summary>
        /// Verifica que un débito con monto mayor al balance lance ArgumentOutOfRangeException.
        /// </summary>
        /// <remarks>
        /// Prueba el comportamiento de validación cuando se intenta debitar más dinero del disponible.
        /// </remarks>
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

        /// <summary>
        /// Verifica que un débito con monto negativo lance ArgumentOutOfRangeException.
        /// </summary>
        /// <remarks>
        /// Prueba la validación de entrada para prevenir débitos con valores negativos.
        /// </remarks>
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

        /// <summary>
        /// Verifica que un crédito con monto positivo incremente correctamente el balance.
        /// </summary>
        /// <remarks>
        /// Prueba el escenario normal de depósito de dinero en la cuenta.
        /// </remarks>
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

        /// <summary>
        /// Verifica que un crédito con monto negativo lance ArgumentOutOfRangeException.
        /// </summary>
        /// <remarks>
        /// Prueba la validación de entrada para prevenir créditos con valores negativos.
        /// </remarks>
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