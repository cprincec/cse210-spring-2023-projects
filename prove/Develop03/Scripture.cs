using System;

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
        bool completelyHidden = true;  // Initialize to true

        foreach (Word word in _texts)
        {
            if (!word.IsHidden())  // Check if any word is not hidden
            {
                completelyHidden = false;  // Set to false if any word is not hidden
                break;  // Exit the loop since the condition is already not met
            }
        }
        return completelyHidden;
    }


    public void HideWords()
    {
        // No. of words in the scripture
        int numOfWords = _texts.Count;

        // keeps track of the number of unhidden words in the scripture
        int counter = 0;

        // Variable to determine the no. of words to hide at a time
        int numOfWordsToHide = 3;

        // count unhidden words in the scripture
        foreach (Word word in _texts)
        {
            if (!word.IsHidden())
            {
                counter++;
            }
        }

        // check if there are still more unhidden words than the number of 
        // words to hide at a time
        if (counter > numOfWordsToHide)
        {
            List<int> randomIndexes = new List<int>();

            for (int i = 0; i < numOfWordsToHide; i++)
            {
                // generate random a index
                Random randomGen = new Random();
                int randomindex = randomGen.Next(numOfWords);

                // Ensure the word at the index of the random number is not already hidden
                while (_texts[randomindex].IsHidden())
                {
                    randomindex = randomGen.Next(numOfWords);
                }
                // hide the word at a random index
                _texts[randomindex].HideWord();
            }
        }
        // hide all the remaining words
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
        // This list is used to store string of text of scripture and its reference
        List<string> textsAsStrings = new List<string>();
        textsAsStrings.Add(_reference);
        foreach (Word word in _texts)
        {
            if (word.IsHidden())
            {
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
