using System;

public class ListingActivity : Activity
{
   private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _responses = new List<string>();
    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _countDownTime = 5;
    }

    public string GetRandomPrompt()
    {
        Random randomGen = new Random();
        return _prompts[randomGen.Next(_prompts.Count)];
    }

    public void RunActivity()
    {
        DisplayStartMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Spin(_spinnerDuration);

        string randomPrompt = GetRandomPrompt();
        Console.WriteLine("\nList as many responses you can to the following prompt:\n");
        Console.WriteLine($"--- {randomPrompt} ---\n");
        Console.Write("You may begin in: ");
        CountDown();
        Console.WriteLine();

        DateTime activityStartTime = DateTime.Now;
        DateTime activityEndTime = activityStartTime.AddSeconds(_activityDuration);

        while (DateTime.Now < activityEndTime)
        {
            Console.Write($"> ");
            string response = Console.ReadLine();
            _responses.Add(response);
        }
        Console.WriteLine($"You listed {_responses.Count} items!");
        
        DisplayEndMessage();
        _responses.Clear();
        _rounds++;
        _totalTimePlayed += _activityDuration;
    }
}