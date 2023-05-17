public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Return all available entries.
    // This is helpfull when I need to use any specific entry in another class
    public List<Entry> GetEntries()
    {
        return _entries;
    }

    //Print all entries in the specified format
    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"\nDate: {entry._date}");
            Console.WriteLine($"Time: {entry._time}");
            Console.WriteLine($"Question: {entry._question}");
            Console.WriteLine($"Answer: {entry._answer}");
        }
    }

    public void SaveJournal(String filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._time}~|~{entry._question}~|~{entry._answer}");
               
            }
        }
    }

    public void LoadJournal(string filename)
    {   
        TerminalServices terminal = new TerminalServices();
        _entries.Clear();

        // Read the content of the file into a list of string
        string[] lines = File.ReadAllLines(filename);
        foreach (String line in lines)
        {
            // Remove extra spaces and split the line into parts
            string cleanLine = line.Trim();
            string[] lineParts = line.Split("~|~");
            string date = lineParts[0];
            string time = lineParts[1];
            string question = lineParts[2];
            string answer = lineParts[3];

            // Add date, time, question and answer to entry
            Entry entry = new Entry();
            entry.SetEntry(question, answer, date, time);
            _entries.Add(entry);
        }
        DisplayEntries();
    }
}