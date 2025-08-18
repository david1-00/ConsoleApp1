using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class AccountHolder
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Date_Of_Birth { get; set; }
        public long Account_Number {get; set;}
        public double Balance { get; protected set; } = 0;

        public static long an()
        {
            Random rand = new Random();
            long accountNum;
            long min = 00000000000L;
            long max = 99999999999;

            accountNum = rand.NextInt64(min, max); 
            // = "";
            //for (int i = 0; i < 11; i++)
            //{
            //    accountNum += rand.Next(0, 10);//.ToString();
            //}
            return accountNum;
        }

       // long test = an();

        public AccountHolder(string Fn, int age, string dob)
        {
            FullName = Fn;
            Age = age;
            Date_Of_Birth = dob;
            Account_Number = an();
            Balance = 0;
        }


       

       

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);

        //public abstract string GetaccountNum(string accountNum);

        public double getBalance()
        {
            return Balance;
        }
    }
}
