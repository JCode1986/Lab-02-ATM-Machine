using System;

namespace ATM_Machine
{
    public class Program
    {
        public static decimal Balance = 5000;
        static void Main(string[] args)
        {
            MenuScreen();
        }

        // Keep asking the user to choose a transaction until they choose to ‘exit’ the application.
        /// <summary>
        /// Starts App - loops until user chooses to exit
        /// </summary>
        public static decimal MenuScreen()
        {
            bool isValid = true;
            while (isValid)
            {
                try
                {
                    Console.WriteLine($"Welcome to JCH Bank!\n");
                    Console.WriteLine($"'v' or '1' - View Account");
                    Console.WriteLine($"'w' or '2' - Withdraw");
                    Console.WriteLine($"'d' or '3' - Deposit");
                    Console.WriteLine($"'x' or 'exit' - To exit anytime during a transaction");
                    Console.Write($"\nWhat would you like to do?: ");

                    string input = Console.ReadLine();

                    if (input == "v" || input == "1")
                    {
                        Console.Clear();
                        Console.WriteLine(ViewBalance(Balance));
                        Console.WriteLine();
                    }
                    else if (input == "w" || input == "2")
                    {
                        Console.Clear();
                        Console.Write("\nHow much would you like to withdraw? ");
                        string withdrawInput = Console.ReadLine();
                        decimal withdraw = Convert.ToInt32(withdrawInput);
                        Withdraw(withdraw);
                    }
                    else if (input == "d" || input == "3")
                    {
                        Console.Clear();
                        Console.Write("\nHow much would you like to deposit? ");
                        string depositInput = Console.ReadLine();
                        decimal deposit = Convert.ToInt32(depositInput);
                        Deposit(deposit);
                    }
                    else if (input == "x" || input == "exit")
                    {
                        Console.WriteLine("Thank you. Come again.");
                        isValid = false;
                        break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("\nInsufficient Funds\n", e.Message);
                    MenuScreen();
                }
            }
            return Balance;
        }

        /// <summary>
        /// Views total in bank account
        /// </summary>
        /// <returns>decimal = Balance</returns>
        public static decimal ViewBalance(decimal currentBalance)
        {
            return currentBalance;
        }

        /// <summary>
        /// Deducts from bank account
        /// </summary>
        /// <param name="num"></param>
        /// <returns>decimal = Balance</returns>
        public static decimal Withdraw(decimal value)
        {
            return value > Balance ? throw new Exception("Insufficient Funds.") : Balance -= value;
        }

        /// <summary>
        /// Adds money to bank account
        /// </summary>
        /// <param name="num"></param>
        /// <returns>decimal = Balance</returns>
        public static decimal Deposit(decimal value)
        {
            return Balance += value;
        }
    }
}
