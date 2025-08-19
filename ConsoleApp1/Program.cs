using ConsoleApp1;
using System.Globalization;

class Bank
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Trail Bank ");

        var store = new dictionary();

        while (true)
        {
            Console.Write("Would you like to sign up? yes or no: ");
            string input = (Console.ReadLine() ?? "").Trim().ToLower();
            if (input == "no")
            {
                Console.WriteLine("Cynthia ofori, oya dy go.");
                return;
            }
            if (input != "yes")
            {
                Console.WriteLine("Type yes or no");
                continue;
            }

            Console.WriteLine("===============================================");
            Console.Write("Enter Full Name: ");
            string fullName = (Console.ReadLine() ?? "").Trim();   // reuse fullName 

            // check existing accounts for this name
            var userAccounts = store.GetAccountNumbersByName(fullName);
            if (userAccounts.Count > 0)
            {
                Console.WriteLine("You already have account(s):");
                for (int i = 0; i < userAccounts.Count; i++)
                    Console.WriteLine($"{i + 1}. {userAccounts[i]}");

                Console.Write("Enter the number to use that account or N to create a new one: ");
                var pick = (Console.ReadLine() ?? "").Trim();

                if (int.TryParse(pick, out int idx) && idx >= 1 && idx <= userAccounts.Count)
                {
                    UseAccountMenu(store, userAccounts[idx - 1]);
                    continue; // go back to main loop after using that account
                }
            }

            // create new account for this user
            int age;
            while (true)
            {
                Console.Write("Enter Age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0) break;
                Console.WriteLine("Enter a valid number");
            }

            Console.Write("Enter Date of Birth yyyy MM dd: ");
            string dob = (Console.ReadLine() ?? "").Trim();

            Console.WriteLine("===============================================");
            var account = store.CreateAccount(fullName, age, dob); ; // use fullName just read

            Console.WriteLine($"Account Created For {account.FullName}");
            Console.WriteLine($"Account Balance {account.Balance}");
            Console.WriteLine("===============================================");

            UseAccountMenu(store, account.Account_Number); // act by account number

            // local function
            static void UseAccountMenu(dictionary store, string accountNumber)
            {
                string currentAcct = accountNumber;

                while (true)
                {
                    var info = store.GetByAccountNumber(currentAcct);
                    if (info == null)
                    {
                        Console.WriteLine("Account not found. Returning to main.");
                        return;
                    }

                    Console.WriteLine();
                    Console.WriteLine("===============================================");
                    Console.WriteLine($"Account {info.Account_Number} for {info.FullName}");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdrawal");
                    Console.WriteLine("3. Show Balance");
                    Console.WriteLine("4. Show Account Info");
                    Console.WriteLine("5. Switch Account");
                    Console.WriteLine("6. Create New Account");
                    Console.WriteLine("7. Exit to Main");
                    Console.WriteLine("8. List All My Accounts");
                    Console.WriteLine("===============================================");
                    Console.Write("Enter 1 to 8: ");


                    var option = (Console.ReadLine() ?? "").Trim();

                    switch (option)
                    {
                        case "1":
                            Console.Write("Enter amount to deposit: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depAmount) && depAmount > 0)
                            {
                                var bal = store.DepositByAccountNumber(depAmount, currentAcct);
                                Console.WriteLine($"Deposited {depAmount}. New Balance: {bal}");
                            }
                            else Console.WriteLine("Invalid amount");
                            break;

                        case "2":
                            Console.Write("Enter Your Withdrawal Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal withAmount) && withAmount > 0)
                            {
                                var bal = store.WithdrawByAccountNumber(withAmount, currentAcct);
                                Console.WriteLine($"Withdrawn {withAmount}. New Balance: {bal}");
                            }
                            else Console.WriteLine("Invalid amount");
                            break;

                        case "3":
                            Console.WriteLine($"Account Balance is: {info.Balance}");
                            break;

                        case "4":
                            Console.WriteLine($"Account Info:");
                            Console.WriteLine($"Name: {info.FullName}");
                            Console.WriteLine($"Age: {info.Age}");
                            Console.WriteLine($"DOB: {info.Date_Of_Birth}");
                            Console.WriteLine($"Balance: {info.Balance}");
                            Console.WriteLine($"Account Number: {info.Account_Number}");
                            break;

                        case "5":
                            {
                                var next = SelectExistingAccountByName(store);
                                if (!string.IsNullOrEmpty(next))
                                    currentAcct = next;
                            }
                            break;

                        case "6":
                            {
                                var newAcct = CreateNewAccountFlow(store);
                                if (!string.IsNullOrEmpty(newAcct))
                                    currentAcct = newAcct;
                            }
                            break;

                        case "7":
                            Console.WriteLine("Back to main");
                            return;

                        case "8":
                            {
                                // list all accounts for this user
                                var list = store.GetAccountNumbersByName(info.FullName);
                                if (list.Count == 0)
                                    Console.WriteLine("No accounts found.");
                                else
                                {
                                    Console.WriteLine("Your accounts:");
                                    foreach (var acctNo in list)
                                    {
                                        var acct = store.GetByAccountNumber(acctNo);
                                        Console.WriteLine($" - {acct.Account_Number} (Balance ₦{acct.Balance})");
                                    }
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
            }



            static string CreateNewAccountFlow(dictionary store)
            {
                Console.Write("Full name: ");
                var name = (Console.ReadLine() ?? "").Trim();

                // If this user already exists, reuse their age and dob
                var existingAccounts = store.GetAccountNumbersByName(name);
                if (existingAccounts.Count > 0)
                {
                    var firstAcct = store.GetByAccountNumber(existingAccounts[0]);
                    var acct = store.CreateAccount(name, firstAcct.Age, firstAcct.Date_Of_Birth);
                    Console.WriteLine($"Created new account {acct.Account_Number} for {acct.FullName}. Balance {acct.Balance}");
                    return acct.Account_Number;
                }
                else
                {
                    // New person: still need age + dob once
                    int age;
                    while (true)
                    {
                        Console.Write("Age: ");
                        if (int.TryParse(Console.ReadLine(), out age) && age > 0) break;
                        Console.WriteLine("Enter a valid number");
                    }

                    Console.Write("Date of birth yyyy MM dd: ");
                    var dob = (Console.ReadLine() ?? "").Trim();

                    var acct = store.CreateAccount(name, age, dob);
                    Console.WriteLine($"Created account {acct.Account_Number} for {acct.FullName}. Balance {acct.Balance}");
                    return acct.Account_Number;
                }
            }

            static string SelectExistingAccountByName(dictionary store)
            {
                Console.Write("Enter your full name: ");
                var name = (Console.ReadLine() ?? "").Trim();

                var list = store.GetAccountNumbersByName(name);
                if (list.Count == 0)
                {
                    Console.WriteLine("No account found for that name");
                    return null;
                }

                Console.WriteLine("Your accounts:");
                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{i + 1}. {list[i]}");

                while (true)
                {
                    Console.Write("Pick a number or type an account number: ");
                    var pick = (Console.ReadLine() ?? "").Trim();

                    if (int.TryParse(pick, out int n) && n >= 1 && n <= list.Count)
                        return list[n - 1];

                    var acct = store.GetByAccountNumber(pick);
                    if (acct != null) return acct.Account_Number;

                    Console.WriteLine("Not found. Try again");
                }
            }
        }
    }
}
