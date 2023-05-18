using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 3:16", "Trust in the Lord with all thine heart; and lean not unto thine own understanding");
        string userInput;
        // do
        // {
        Console.WriteLine(scripture.GetRenderedText());
        Console.WriteLine("Press enter to continue or type quit to finish: ");
        userInput = Console.ReadLine();
        while (userInput == "yes")
        {
            scripture.HideWords();
            Console.WriteLine(scripture.GetRenderedText());
            Console.WriteLine("Press enter to continue or type quit to finish: ");
            userInput = Console.ReadLine();
        }
        // } while (userInput != "quit");
        scripture.GetRenderedText();
    }
}

public class Scripture
{
    private string _reference;
    private List<Word> _texts = new List<Word>();

    public Scripture(string reference, string text)
    {
        _reference = reference;
        string[] splittedWords = text.Split(" ");
        foreach (string w in splittedWords)
        {
            Word word = new Word(w);
            _texts.Add(word);
        }
    }

    public bool IsCompletelyHidden()
    {
        bool completelyHidden = false;
        foreach (Word word in _texts)
        {

            if (word.IsHidden())
            {
                completelyHidden = true;
                Console.WriteLine("Word is hidden: " + word.IsHidden());
            }
            else
            {
                completelyHidden = false;
            }
        }
        Console.WriteLine("Completely hidden" + IsCompletelyHidden());
        return completelyHidden;
    }

    public void HideWords()
    {
        // COunter for number of hidden words
        int numOfWords = _texts.Count;
        int counter = 0;
        int numOfWordsToHide = 3;
        foreach (Word word in _texts)
        {
            if (!word.IsHidden())
            {
                counter++;
            }
        }
        Console.WriteLine("Counter: " + counter);

        if (counter % numOfWordsToHide == 0)
        {
            Console.WriteLine("unhidden word is more than 2");
            List<int> randomIndexes = new List<int>();

            // generate three random indexexs
            // check if words in the word list at those random indexes have not been hidden
            for (int i = 0; i < numOfWordsToHide; i++)
            {
                // generate random a index
                Random randomGen = new Random();
                int randomindex = randomGen.Next(numOfWords);

                // add the random index to a list of indexes if the word
                // in the word list at that index have not been hidden
                while (randomIndexes.Contains(randomindex))
                {
                    randomindex = randomGen.Next(numOfWords);
                }

                if (!_texts[randomindex].IsHidden())
                {
                    randomIndexes.Add(randomindex);
                }
            }

            // hide unhidden words in the word list based on random indexes
            for (int i = 0; i < randomIndexes.Count; i++)
            {
                Console.WriteLine("Random Index: " + randomIndexes[i]);
                _texts[randomIndexes[i]].HideWord();
            }
        }
        else
        {
            for (int i = 0; i < numOfWords; i++)
            {
                if (!_texts[i].IsHidden())
                {
                    _texts[i].HideWord();
                }
            }
        }
    }

    // return a combination of scripture reference and text
    // replace hidden words in the text with underscore that match the length of the word
    public string GetRenderedText()
    {
        List<string> textsAsStrings = new List<string>();
        foreach (Word word in _texts)
        {
            if (word.IsHidden())
            {
                // Console.Write("Hidden word here!");
                // calculate the length of a word designated as hidden
                // this allows us to know how many underscores to replace the word with
                int wordLength = word.GetWord().Length;
                string hidden = "";

                for (int i = 0; i < wordLength; i++)
                {
                    hidden += "_";
                }

                textsAsStrings.Add(hidden);
            }
            else
            {
                // Console.Write("No hidden word here!");
                textsAsStrings.Add(word.GetWord());
            }
        }
        return string.Join(" ", textsAsStrings);
    }
}

// Word newWord = new Word();

// newWord.Length;

public class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public string GetWord()
    {
        return _word;
    }
}