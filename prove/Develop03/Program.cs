using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {   
        Console.Clear();

        Console.WriteLine("What do you want to do? ");
        Console.WriteLine("1. Learn a random scripture");
        Console.WriteLine("2. Type or paste your own scripture to memorize");

        string action = Console.ReadLine();
        Scripture scripture = null;

        if (action == "1")
        {
            Library libray = new Library();
            libray.LoadScripture();
            KeyValuePair<string, string> scriptureWithReference =  libray.getRandomScripture();
            string newReference = scriptureWithReference.Key;
            string newScripture = scriptureWithReference.Value;

            scripture = new Scripture(newReference, newScripture);
        }
        else if (action == "2")
        {   
            Console.WriteLine("What book do you want to memorize?");
            string book = Console.ReadLine();
            
            Console.WriteLine("What chapter do you want to memorize?");
            string chapter = Console.ReadLine();

            Console.WriteLine("What verse do you want to memorize?");
            string verse = Console.ReadLine();

            Console.WriteLine("What is the end verse? Type no if you will learn only one verse");
            string stop = Console.ReadLine();

            Reference reference = null;

            if (stop != "no")
            {
                if (int.TryParse(stop, out int number))
                {
                    string endVerse = stop;
                    reference = new Reference(book, chapter, verse, endVerse);
                }
            }
            else 
            {
                reference = new Reference(book, chapter, verse);
            }

            Console.WriteLine("Type or paste the scripture text");
            string text = Console.ReadLine();

            scripture = new Scripture(reference.GetReference(), text);
        }
      
        bool play = true;
        Console.Clear();
        Console.WriteLine(scripture.GetRenderedText());
        string userInput;

        while (play)
        {
            Console.WriteLine("\nPress enter to continue, type quit to finish.");
            userInput = Console.ReadLine();

            if (userInput == "")
            {
                scripture.HideWords();
                play = true;
            }
            else if (userInput == "quit")
            {
                play = false;
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid input!");
            }
            Console.Clear();
            Console.WriteLine(scripture.GetRenderedText());
            play = !scripture.IsCompletelyHidden();
        }
    }
}