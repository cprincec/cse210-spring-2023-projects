using System;
using System.Collections.Generic;
public class BreathingActivity : Activity
{
    protected double _interval;
    private double _breathingInDuration;
    private double _breathingOutDuration;

    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _interval = 10;
        _breathingInDuration = (60.0 / 100) * _interval;
        _breathingOutDuration = (40.0 / 100) * _interval;
    }

    public void Breathe(string breathingType, int duration)
    {
        Console.Write(breathingType);
        CountDown(duration);
    }

    public void RunActivity()
    {
        DisplayStartMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Spin(_spinnerDuration);

        DateTime activityStartTime = DateTime.Now;
        DateTime activityEndTime = activityStartTime.AddSeconds(_activityDuration);
        while (DateTime.Now < activityEndTime)
        {
            Breathe("\nBreathe in...", (int)_breathingInDuration);
            Breathe("\nNow breathe out...", (int)_breathingOutDuration);
            Console.WriteLine();
        }
        DisplayEndMessage();
        _rounds++;
        _totalTimePlayed += _activityDuration;
    }
}