using System;

class Program
{   
    static void Main(string[] args)
    {
        TerminalServices terminal = new TerminalServices();
        PromptGenerator promptGen = new PromptGenerator();
        Journal journal = new Journal();
        string menuOption;
        terminal.PrintOutput("\nWelcome to the Journal Program!");
        do
        {
            terminal.DisplayMenu();
            menuOption = terminal.ReadInput(">> ");

            if (menuOption == "1")
            {
                // Generate and store a random question/prompt
                string prompt = promptGen.GetRandomPrompt();

                // Check if all prompts in the prompts list have been asked
                // if so, return to menu
                if (prompt == null)
                {
                    terminal.PrintOutput("Congratulations!");
                    terminal.PrintOutput("You have answered all the prompts for today's journal entry.");
                    terminal.PrintOutput("See you tomorrow!");
                }
                else
                {
                    Entry entry = new Entry(); 
                    String answer = terminal.ReadInput(prompt + " "); // display the question/prompt and store the input
                    entry.SetEntry(prompt, answer); // save the question and answer as entry attributes
                    journal.AddEntry(entry); // Add the entry to journal entries
                }
            }
            else if (menuOption == "2")
            {
                string newPrompt = terminal.ReadInput("What prompt would you like to add?");
                promptGen.AddPrompt(newPrompt);
            }
            else if (menuOption == "3")
            {
                journal.DisplayEntries();
            }
            else if (menuOption == "4")
            {
                String filename = terminal.ReadInput("What is the name of the file you want to load: ");
                journal.LoadJournal(filename);
            }
            else if (menuOption == "5")
            {
                String filename = terminal.ReadInput("What name would want to save this journal as? ");
                journal.SaveJournal(filename);
            }
            else if (menuOption != "6")
            {
                terminal.PrintOutput("Invalid option. Please select an option 1-5: ");
            }
        } while (menuOption != "6");
    }
}