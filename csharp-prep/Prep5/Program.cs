using System;

class Program
{
    static void Main(string[] args)
    {        
        DisplayWelcome();
        
        string username = PromptUsername();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);

        DisplayResults(username, squaredNumber);
    }

    static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUsername()
        {
            Console.Write("What is your name? ");
            return Console.ReadLine();
        }

        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number? ");
            return int.Parse(Console.ReadLine());
        }

        static int SquareNumber(int number)
        {
            return number * number;
        }

        static void DisplayResults(string username, int squaredNumber)
        {
            Console.WriteLine($"{username}, the square of your number is {squaredNumber}");
        }


}