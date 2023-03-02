using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]

        public void DepositShouldIncreaseBalance()
        {

            //Arrange
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = 100;
            //Act 
            bankAccount.Deposit(depositAmount);
            //Assert
            Assert.AreEqual(depositAmount, bankAccount.Balance);
        }

        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123, 2000m);
            //Act

            //Assert
            Assert.AreEqual(2000m, bankAccount.Balance);
        }

        [TestCase(100)]
        [TestCase(3500)]
        [TestCase(2400)]
        public void DepositShouldIncreaseBalanceAll(decimal depositAmount)
        {
            BankAccount bankAccount = new BankAccount(123);

            bankAccount.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, bankAccount.Balance);
        }

        [Test]
        public void NegativeAmountShouldThrowInvalidOperationException()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;
            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
        }

        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionWithMessage()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;

            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));

            Assert.AreEqual(ex.Message, "Negative Amount");
        }

        [Test]
        public void CreditShouldDecreaseBalance()
        {
            BankAccount bankAccount = new BankAccount(123,200m);
            decimal creditAmount = 100;

            bankAccount.Credit(creditAmount);

            Assert.AreEqual( creditAmount, bankAccount.Balance);

        }
        [Test]
        public void CreditShouldDecreaseBalanceWithException()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal creditAmount = -100;

            Assert.Throws<InvalidOperationException>(() => bankAccount.Credit(creditAmount));
        }

        [Test]
        public void CreditShouldIncreaseBalanceWithOperationExceptionMessage()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal creditAmount = -100;

            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Credit(creditAmount));

            Assert.AreEqual(ex.Message, "Credit Cannot Be Negative Amount");
        }
        [Test]
        public void IncreaseAccountBalanceWithPercentage()
        {
            BankAccount bankAccount = new BankAccount(123, 100);
            decimal percent = 10;

            bankAccount.IncreasePercent(percent);

            Assert.AreEqual(bankAccount.Balance, bankAccount.Balance);
        }

        [TestCase(1001)]
        [TestCase(2001)]
        [TestCase(3001)]
        [TestCase(1000)]
        [TestCase(999)]
        public void BonusShouldIncreaseWithFixedAmount(decimal depositAmount)
        {
            BankAccount bankAccount = new BankAccount(123);

            bankAccount.Deposit(depositAmount);
            bankAccount.Bonus();

            Assert.AreEqual(bankAccount.Balance, bankAccount.Balance);
        }

        [Test]
        public void PaymentForCreditShouldDecreaseBalance()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123,1950);

            //Act
            bankAccount.PaymentForCredit(50);

            //Assert
            Assert.AreEqual(1900, bankAccount.Balance);
        }
        [Test]
        public void PaymentShouldThrowExceptionWhenNumberIsNegative()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123);
            decimal paymentForCredit = -50;
            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(()=>bankAccount.PaymentForCredit(paymentForCredit));
        }
        [Test]
        public void PaymentShouldThrowExceptionWhenNumberIsNull()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123);
            decimal paymentForCredit = 0;
            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(paymentForCredit));
        }
        [Test]
        public void NotEnoughMoneyInBalanceThrowingException()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123,50m);
            decimal paymentForCredit = 100;
            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(paymentForCredit));
        }
        [Test]
        public void LowersTheBalanceWhenThereIsPaymentForCredit()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123, 1950m);
            decimal paymentForCredit = 50;
            //Act
            bankAccount.PaymentForCredit(paymentForCredit);
            //Assert
            Assert.AreEqual(1900, bankAccount.Balance);
        }
        [Test]
        public void PaymentShouldThrowExceptionWhenNumberIsNullOrNegativeWithMessage()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123, 50m);
            decimal paymentForCredit = 0;
            //Act

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(paymentForCredit));
            Assert.AreEqual(ex.Message, "Payment Cannot Be Zero Or Negative");
        }
        [Test]
        public void PaymentShouldThrowExceptionWhenNumberIsNotEnoughWithMessage()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123, 50m);
            decimal paymentForCredit = 100;
            //Act

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(paymentForCredit));
            Assert.AreEqual(ex.Message, "Not Enough Money");
        }
    }
}
