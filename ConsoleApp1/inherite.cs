using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BankAccount :AccountHolder
    {
        public BankAccount(string fullName, int age, string dob,long an) : base(fullName, age, dob,an) { }

        public override void deposite(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposit successful. New balance: #{Balance}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }

        //public override string getaccountnum(string accountnum)
        //{
        //    return accountnum;
        //}

        public override void withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawal successful. New balance: #{Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds or invalid amount.");
            }
        }
    }
}
