using ConsoleApp1;
using System.Reflection.Metadata;

class Bank
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Trail Bank ");

        while (true)
        {
            Console.Write("Would you like to sign up? (yes/no): ");
            string input = Console.ReadLine().ToLower();
            if (input == "yes") 
            {
                break;
            }
            else if (input == "no")
            {
                Console.WriteLine("No worries! Come back anytime.");
                return;
            }
            else Console.WriteLine("Invalid input. Please type 'yes' or 'no'.");
        }

        Console.Write("Enter your full name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter your date of birth (YYYY-MM-DD): ");
        string dob = Console.ReadLine();

        string an = AccountHolder.an();   // call method that generated account number

        BankAccount account = new BankAccount( name , age, dob, an);
        Console.WriteLine($"Account Created For {account.FullName}");
        Console.WriteLine($"Account Number {account.Account_Number}");
        Console.WriteLine($"Account Balance {account.Balance}");


        //okay start your menu loop here

        while (true)
        {
            Console.WriteLine(" CHOOSE YOUR  POISON");
            Console.WriteLine( "1. Deposit");
            // finish the rest yourself
            // you  must be able to deposit, withdraw, show balance, show account info (name, age, dob, account number, balance)
            Console.WriteLine(  "Enter 1 to 5");

            var option =  Console.ReadLine().ToLower();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter amount to deposit: ");
                    var depamount = Console.ReadLine();  //make sure to validate the amount, must be valid and greater than zero
                    break;
                default:
                    Console.WriteLine("AFa, na wah oh");
                    break;
            }

        }
    }
}

