using System;
public class Activity

{
    protected string _name;
    protected string _description;
    protected int _activityDuration;
    protected int _spinnerDuration;
    protected int _countDownTime;
    protected int _rounds;
    protected int _totalTimePlayed;
    protected DateTime _dateTime;

    public Activity()
    {
        _spinnerDuration = 3;
        _rounds = 0;
        _dateTime = DateTime.Now;
    }

    public int GetRoundsPlayed()
    {
        return _rounds;
    }

    public int GetTotalTimePlayed()
    {
        return _totalTimePlayed;
    }

    public void Spin(int duration = 0)
    {
        string spinnerParts = "|/-\\";
        
        DateTime startTime = DateTime.Now;
        DateTime endTime;

        if (duration != 0)
        {
            endTime = startTime.AddSeconds(duration);  
        }
        else 
        {
            endTime = startTime.AddSeconds(_spinnerDuration);
        }

        int counter = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerParts[counter]);
            Thread.Sleep(500);
            Console.Write("\b \b");

            counter++;

            if (counter % spinnerParts.Length == 0)
            {
                counter = 0;
            }
        }
    }

    public void CountDown(int seconds = 0)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime; 
        int counter;

        if (seconds != 0)
        {
            endTime = startTime.AddSeconds(seconds);
            counter = seconds;
        }
        else {
            endTime = startTime.AddSeconds(_countDownTime);
            counter = _countDownTime;
        }

        while (DateTime.Now < endTime)
        {
            Console.Write(counter);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            counter--;
        }
    }

    public void DisplayStartMessage()
    {   
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _activityDuration = int.Parse(Console.ReadLine());
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!!");
        Spin();
        Console.WriteLine($"\nYou have completed {_activityDuration} seconds of the {_name} Activity.");
        Spin();
    }
}