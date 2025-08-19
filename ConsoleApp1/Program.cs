using ConsoleApp1;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

class Bank
{
    static void Main(string[] args)
    {
        dictionary Dictionary = new dictionary();
        Console.WriteLine("Welcome to Trail Bank ");

        string fullName = "";
        int age = 0;
        string dob = "";
       // BankAccount account = null;

        while (true)
        {
            Console.Write("Would you like to sign up? (yes/no): ");
            string input = Console.ReadLine().ToLower();
            if (input == "yes") 
            {
                Console.Write("Enter Full Name: ");
                string FullName = Console.ReadLine();

                if (Dictionary.HasAccount(FullName))
                {
                    Console.WriteLine("You already have an account.");
                    var existingAccount = Dictionary.GetAccount(FullName);
                    Console.WriteLine($"Your balance is: {existingAccount.Balance}");
                }
                else
                {
                    Console.Write("Enter Age: ");
                    age = int.Parse(Console.ReadLine());

                    Console.Write("Enter Date of Birth (yyyy-mm-dd): ");
                    dob =Console.ReadLine();

                    Dictionary.CreateAccount(FullName, age, dob);
                }
                break;
            }

            else if (input == "no")
            {
                Console.WriteLine("No worries! Come back anytime.");
                return;
            }
            else Console.WriteLine("Invalid input. Please type 'yes' or 'no'.");
        }
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

