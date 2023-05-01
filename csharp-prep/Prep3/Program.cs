using System;

class Program
{
    static void Main(string[] args)
    {
        bool play = true;

        while (play)
        {
            Random randomGen = new Random();
            int magicNum = randomGen.Next(1, 100);

            int guess = -1;
            int count = 0;

            while (guess != magicNum)
            {   
                Console.Write("Guess the magic number: ");
                guess = int.Parse(Console.ReadLine());
                ++count;
                if (guess > magicNum)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }
            }
            Console.WriteLine($"Congratulations! You guessed it correctly after {count} tries.");
            Console.Write("Do you want to play again? [yes or no]: ");
            string replay = Console.ReadLine();
            if (replay == "yes")
            {
                play = true;
            }
            else if (replay == "no")
            {   
                Console.WriteLine("Thanks for playing!");
                play = false;
            }
        }
    }
}