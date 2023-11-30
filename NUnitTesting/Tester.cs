using System;
using ArithmeticOperations;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class Tester
{
    private double epsilon = 1e-6;

    [Test]
    public void Deposit_NegativeAmount_ReturnsFalse()
    {
        // Arrange
        Account account = new Account(100);

        // Act
        bool result = account.Deposit(-50);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(0, account.Balance);
    }

    [Test]
    public void Withdraw_NegativeAmount_ReturnsFalse()
    {
        // Arrange
        Account account = new Account(100);
        account.Deposit(50);

        // Act
        bool result = account.Withdraw(-30);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(50, account.Balance);
    }

    [Test]
    public void Withdraw_OverdraftLimit_ReturnsFalse()
    {
        // Arrange
        Account account = new Account(100);
        account.Deposit(50);

        // Act
        bool result = account.Withdraw(200);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(50, account.Balance);
    }

    [Test]
    public void Deposit_ValidAmount_IncreasesBalance()
    {
        // Arrange
        Account account = new Account(100);

        // Act
        bool result = account.Deposit(50);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(50, account.Balance);
    }

    [Test]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        Account account = new Account(100);
        account.Deposit(200);

        // Act
        bool result = account.Withdraw(50);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(150, account.Balance);
    }
}