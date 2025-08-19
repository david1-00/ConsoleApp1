using ConsoleApp1;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

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
            if (input == "no")
            {
                Console.WriteLine("No worries! Come back anytime.");
                return;
            }
            else if (input == "yes")
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
                    dob = Console.ReadLine();

                    var accountinfo = Dictionary.CreateAccount(FullName, age, dob);

                    //Console.WriteLine($"Account Created For {accountinfo.FullName}");
                    //Console.WriteLine($"Account Number {accountinfo.Account_Number}");
                    Console.WriteLine($"Account Balance {accountinfo.Balance}");

                    Console.WriteLine("=============================================== ");


                    Console.WriteLine(" CHOOSE YOUR  POISON");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdrawal");
                    Console.WriteLine("3. Show Balance");
                    Console.WriteLine("4. Show Account Info");
                    Console.WriteLine("5. Exit the Menu")
                  ;

                    while (true)
                    {
                        Console.WriteLine("Enter 1 to 5");
                        var option = Console.ReadLine().ToLower ();
                        switch (option)
                        {
                            case "1":
                                Console.WriteLine("Enter amount to deposit: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal depAmount) && depAmount > 0)     //make sure to validate the amount, must be valid and greater than zero
                                {
                                    var bal = Dictionary.Deposit(depAmount, accountinfo.FullName);
                                    Console.WriteLine($"Deposited {depAmount}. New Balance: {bal}");
                                }
                                break;
                            case "2":
                                Console.WriteLine("Enter Your Withdrawal Amount: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal withAmount) && withAmount > 0)
                                {
                                    var bal = Dictionary.Withdraw(withAmount, accountinfo.FullName);
                                    Console.WriteLine($"Withdrawed Amount {withAmount}. New Balance: {bal}");
                                }
                                break;

                            case "3":
                                Console.WriteLine($" Account Balance is: {accountinfo.Balance}");
                                break;
                            case "4":
                                Console.WriteLine($"Account Info:\nName: {accountinfo.FullName}\nAge: {accountinfo.Age}\nBalance: {accountinfo.Balance}");
                                break;
                            case "5":
                                Console.WriteLine("Thanks for banking with us. Goodbye!");
                                return; 

                            default:
                                Console.WriteLine("Nawa oo shu ");
                                break;
                        }
                    }   
                }
            }
        }
    }
}

