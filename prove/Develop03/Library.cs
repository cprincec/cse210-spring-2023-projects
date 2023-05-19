using System;

public class Library
{
    Dictionary<string, string> _scriptures = new Dictionary<string, string>();
    public void LoadScripture()
    {
        string fileName = "library.txt";
        string[] lines = File.ReadAllLines(fileName);
        
        foreach (string line in lines)
        {
            string[] newLine = line.Split(" - ");
            string reference = newLine[0];
            string text = newLine[1];
            string strippedText = text.Trim('"');
            
            _scriptures.Add(reference, strippedText);
        }
    }

    public KeyValuePair<string, string> getRandomScripture()
    {
        Random randomGen = new Random();
        int randomIndex = randomGen.Next(_scriptures.Count);
        
        return _scriptures.ElementAt(randomIndex);
    }
}