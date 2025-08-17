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
        public string Account_Number {get; set;}  // now string
        public decimal Balance { get; protected set; } = 0m; //to decimal

        public static string an()  // turned account numver to string
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
            return accountNum.ToString();
        }

 

        public AccountHolder(string Fn, int age, string dob, string test)
        {
            FullName = Fn;
            Age = age;
            Date_Of_Birth = dob;
            Account_Number = test;
            //Balance = 0;  // i removed balance here, 
        }


       

       

        public abstract void deposite(decimal amount); // i turned these to decimal
        public abstract void withdraw(decimal amount); // i turned these to decimal
        //public abstract string GetaccountNum(string accountNum);
    }
}
