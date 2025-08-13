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

        long an = 0L;

        BankAccount account = new BankAccount( name , age, dob, an);
        Console.WriteLine($"Account Created For {account.FullName}");
        Console.WriteLine($"Account Number {account.Account_Number}");
        Console.WriteLine($"Account Balance {account.Balance}");
    }
}