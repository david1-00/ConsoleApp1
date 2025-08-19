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

        private Dictionary<string, List<string>> byName = new Dictionary<string, List<string>>();
        public bool HasAccount(string fullName)
        {
            return byName.ContainsKey(fullName);
        }


        public BankAccount GetAccount(string fullName)
        {
            var list = GetAccountNumbersByName(fullName);
            if (list.Count == 0) return null;
            return GetByAccountNumber(list[0]);
        }

        public BankAccount GetAccount2(string acctno)
        {
            accounts.TryGetValue(acctno, out BankAccount account);
            return account;
        }

        public List<string> GetAccountNumbersByName(string fullName)
        {
            return byName.TryGetValue(fullName, out var list) ? list : new List<string>();
        }


        public BankAccount GetByAccountNumber(string acctNo)
        {
            accounts.TryGetValue(acctNo, out var acct);
            return acct;
        }

        public BankAccount CreateAccount(string fullName, int age, string dob)
        {
            string an = AccountHolder.an(); // keep generator
            var account = new BankAccount(fullName, age, dob, an);

            // index by account number
            accounts[an] = account;

            // index by name
            if (!byName.TryGetValue(fullName, out var list))
            {
                list = new List<string>();
                byName[fullName] = list;
            }
            list.Add(an);

            Console.WriteLine($"Account created for {fullName}");
            Console.WriteLine($"Account Number: {account.Account_Number}");
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

        // I ADDED THESE TWO, THERE ARE NOT SO DIFFERENT FROM THE PREVIOUS ONE

        public decimal DepositByAccountNumber(decimal amount, string acctNo)
        {
            var account = GetByAccountNumber(acctNo);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return 0m;
            }

            if (amount <= 0m)
            {
                Console.WriteLine("Invalid deposit amount.");
                return account.Balance;
            }

            account.deposit(amount); 
            Console.WriteLine($"Deposit successful. New balance: ₦{account.Balance}");
            return account.Balance;
        }

        public decimal WithdrawByAccountNumber(decimal amount, string acctNo)
        {
            var account = GetByAccountNumber(acctNo);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return 0m;
            }

            if (amount <= 0m)
            {
                Console.WriteLine("Invalid withdrawal amount. Please enter a positive number.");
                return account.Balance;
            }
            else if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient funds for this withdrawal.");
                return account.Balance;
            }

            account.Withdraw(amount);
            Console.WriteLine($"Withdrawal successful. New balance: {account.Balance}");
            return account.Balance;
        }
    }
}
