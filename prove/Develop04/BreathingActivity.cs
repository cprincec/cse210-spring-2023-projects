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
            Console.Write("\nBreathe in...");

            DateTime inStartTime = DateTime.Now;
            DateTime inEndTime = inStartTime.AddSeconds(_breathingInDuration);

            int inCounter = (int)_breathingInDuration;
            while (DateTime.Now < inEndTime)
            {
                Console.Write(inCounter);
                Thread.Sleep(1000);
                Console.Write("\b \b");

                inCounter--;
            }

            Console.Write("\nNow breathe out...");

            DateTime outStartTime = DateTime.Now;
            DateTime outEndTime = outStartTime.AddSeconds(_breathingOutDuration);

            int outCounter = (int)_breathingOutDuration;
            while (DateTime.Now < outEndTime)
            {
                Console.Write(outCounter);
                Thread.Sleep(1000);
                Console.Write("\b \b");

                outCounter--;
            }

            Console.WriteLine();
        }
        DisplayEndMessage();
        _rounds++;
        _totalTimePlayed += _activityDuration;
    }
}