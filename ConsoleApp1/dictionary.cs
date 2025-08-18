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

        public long CreateAccount(string fullName, int age, string dob)
        {
            BankAccount account;
            if (HasAccount(fullName))
            {
                Console.WriteLine("Account already exists.");
                account = accounts[fullName];
            }
            else
            {
                account = new BankAccount(fullName, age, dob);
                accounts.Add(fullName.ToLower(), account);
                Console.WriteLine($"Account created for {fullName}. Account Number: {account.Account_Number}");
            }

            return account.Account_Number;
        }
    }
}
