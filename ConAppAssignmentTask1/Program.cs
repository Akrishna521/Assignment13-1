using System;

class BankAccount
{
    private static int accountNumberCounter = 100;

    public BankAccount(string accountHolderName)
    {
        AccountNumber = GenerateAccountNumber();
        AccountHolderName = accountHolderName;
        Balance = 0;
    }

    public int AccountNumber { get; }

    public string AccountHolderName { get; set; }

    private decimal Balance { get; set; }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn ${amount}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }
    }

    private int GenerateAccountNumber()
    {
        return accountNumberCounter++;
    }

    public decimal GetBalance()
    {
        return Balance;
    }
}

class Program
{
    static void Main()
    {
        BankAccount myAccount = new BankAccount("John Doe");

        Console.WriteLine($"Account Number: {myAccount.AccountNumber}");
        Console.WriteLine($"Account Holder: {myAccount.AccountHolderName}");
        Console.WriteLine($"Initial Balance: ${myAccount.GetBalance()}");

        myAccount.Deposit(1000);
        myAccount.Withdraw(500);

        Console.WriteLine($"Final Balance: ${myAccount.GetBalance()}");
    }
}