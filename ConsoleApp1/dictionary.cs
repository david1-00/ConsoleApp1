using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class dictionary
    {
        private Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();
        public bool HasAccount(string fullname) 
        {
            return accounts.ContainsKey(fullname);
        }

        public BankAccount GetAccount(string fullname)
        {
            accounts.TryGetValue(fullname, out BankAccount account);
            return account;
        }

        public BankAccount GetAccount2(string acctno)
        {
            accounts.TryGetValue(acctno, out BankAccount account);
            return account;
        }

        public BankAccount CreateAccount(string fullName, int age, string dob)
        {
            BankAccount account;
            if (HasAccount(fullName))
            {
                Console.WriteLine("Account already exists.");
                account = accounts[fullName];
            }
            else
            {
                string an = AccountHolder.an();
                account = new BankAccount(fullName, age, dob, an);
                accounts.Add(fullName, account);
                Console.WriteLine($"Account created for {fullName}. Account Number: {account.Account_Number}");
            }
            return account;
        }

        public decimal Deposit(decimal amount, string fullname) 
        {
            BankAccount account = GetAccount(fullname.ToLower());

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return account.Balance;
            }
            if (amount > 0m)
            {
                account.deposit(amount); 
                Console.WriteLine($"Deposit successful. New balance: ₦{account.Balance}");
                return account.Balance; 
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
                return account.Balance;
            }
        }


        public decimal Withdraw(decimal amount, string fullname) 
        {

            BankAccount account = GetAccount(fullname.ToLower());

            if (amount <= 0m)//decimal
            {
                Console.WriteLine("Invalid withdrawal amount. Please enter a positive number.");
                return account.Balance;
            }
            else if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient funds for this withdrawal.");
                return account.Balance;
            }
            else
            {
                account.Withdraw(amount);
                Console.WriteLine($"Withdrawal successful. New balance: {account.Balance}");
                return account.Balance;
            }
        }


    }
}
