using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BankAccount :AccountHolder
    {
        public BankAccount(string fullName, int age, string dob,string an) : base(fullName, age, dob,an) { }

        public override void deposite(decimal amount) //now decimal
        {
            if (amount > 0m)  //decimal
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

        public override void withdraw(decimal amount)  //separate logic of insufficuent funds and invalid input
        {
            if (amount <= 0m)//decimal
            {
                Console.WriteLine("Invalid withdrawal amount. Please enter a positive number.");
                return;
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds for this withdrawal.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawal successful. New balance: #{Balance}");
            }
        }
    }
}
