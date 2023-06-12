using System;
public class ReflectionActivity : Activity
{
    private int _interval;
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private List<string> _reflectedQuestions = new List<string>();

    public ReflectionActivity()
    {
        _name = "Reflection";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _countDownTime = 5;
        _interval = 7;  // How long user will reflect on a question
    }

    public string GetRandomPrompt()
    {
        Random randomGen = new Random();
        return _prompts[randomGen.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random randomGen = new Random();
        List<string> availableQuestions = _questions.Except(_reflectedQuestions).ToList();

        if (availableQuestions.Count == 0)
        {
            // All questions have been reflected upon, so I reset the reflectedQuestions list
            _reflectedQuestions.Clear();
            availableQuestions = _questions.ToList();
        }

        string randomQuestion = availableQuestions[randomGen.Next(availableQuestions.Count)];
        _reflectedQuestions.Add(randomQuestion);
        return randomQuestion;
    }

    public void RunActivity()
    {
        string randomPrompt = GetRandomPrompt();

        DisplayStartMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Spin(_spinnerDuration);

        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {randomPrompt} ---\n");
        Console.Write("When you have something in mind, press enter to continue.\n");
        string ready = Console.ReadLine();
        if (ready == "")
        {
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            CountDown();
        }

        Console.Clear();

        DateTime activityStartTime = DateTime.Now;
        DateTime activityEndTime = activityStartTime.AddSeconds(_activityDuration);

        while (DateTime.Now < activityEndTime)
        {
            string randomQuestion = GetRandomQuestion();
            Console.Write($"> {randomQuestion} ");
            Spin(_interval);
            Console.WriteLine();
        }
        DisplayEndMessage();
        _rounds++;
        _totalTimePlayed += _activityDuration;
    }
}