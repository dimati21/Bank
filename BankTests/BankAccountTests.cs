using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance() //Проверка на обновление баланса функцией Debit()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.Debit(debitAmount);
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange() //Проверка на обновление баланса с отрицательным аргументом функцией Debit()
        {
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange() //Проверка на обновление баланса с аргументом больше имеющегося баланса функцией Debit()
        {
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void Debit_WhenAmountEqualZero_ShouldThrowArgumentOutOfRange() //Проверка на обновление баланса с нулевым аргументом функцией Debit()
        {
            double beginningBalance = 11.99;
            double debitAmount = 0.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance() //Проверка на обновление баланса функцией Credit()
        {
            double beginningBalance = 10.11;
            double creditAmount = 5.44;
            double expected = 15.55;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.Credit(creditAmount);
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange() //Проверка на обновление баланса с отрицательным аргументом функцией Credit()
        {
            double beginningBalance = 11.99;
            double creditAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }
        [TestMethod]
        public void Credit_WhenAmountEqualZero_ShouldThrowArgumentOutOfRange() //Проверка на обновление баланса с нулевым аргументом функцией Credit()
        {
            double beginningBalance = 11.99;
            double creditAmount = 0.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }
    }
}
