using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; set; }

        public Account(string accountNumber, string holderName, double balance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }

        public abstract void Withdraw(double amount);

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount} into account {AccountNumber}. New balance: {Balance}");
        }
    }

    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount(string accountNumber, string holderName, double balance, double interestRate) 
            : base(accountNumber, holderName, balance)
        {
            InterestRate = interestRate;
        }

        public void CalculateInterest()
        {
            Deposit(Balance * (InterestRate / 100));
        }

        public override void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount} from account {AccountNumber}. New balance: {Balance}");
            }
        }
    }

    public class CheckingAccount : Account
    {
        public double OverdraftLimit { get; set; }

        public CheckingAccount(string accountNumber, string holderName, double balance, double overdraftLimit) 
            : base(accountNumber, holderName, balance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override void Withdraw(double amount)
        {
            if (amount > Balance + OverdraftLimit)
            {
                Console.WriteLine("Exceeds overdraft limit.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount} from account {AccountNumber}. New balance: {Balance}");
            }
        }
    }

    public class Bank
    {
        private List<Account> accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public void DisplayAccounts()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Holder Name: {account.HolderName}, Balance: {account.Balance}");
            }
        }

        public Account FindAccount(string accountNumber) => 
            accounts.Find(account => account.AccountNumber == accountNumber);

        public void WithdrawFromAccount(string accountNumber, double amount)
        {
            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void DepositToAccount(string accountNumber, double amount)
        {
            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount savingsAccount = new SavingsAccount("SA123", "John Doe", 1000, 5);
            CheckingAccount checkingAccount = new CheckingAccount("CA456", "Jane Smith", 2000, 500);

            Bank bank = new Bank();

            bank.AddAccount(savingsAccount);
            bank.AddAccount(checkingAccount);

            bank.DepositToAccount("SA123", 500);
            bank.WithdrawFromAccount("CA456", 1000);
            bank.DisplayAccounts();

            savingsAccount.CalculateInterest();
        }
    }
}