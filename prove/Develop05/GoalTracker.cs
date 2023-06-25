using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class GoalTracker
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalPointsEarned;
    private List<string> _goalTypes = new List<string> {
        "Simple Goal",
        "Eternal Goal",
        "Checklist Goal"
    };

    public GoalTracker()
    {
        _totalPointsEarned = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public int TotalPointsEarned
    {
        get => _totalPointsEarned;
        set => _totalPointsEarned += value;
    }

    public void DisplayGoals()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are: ");
        int i = 1;
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete)
            {
                if (goal is ChecklistGoal checklistGoal)
                {
                    Console.WriteLine($"{i}. [X] {checklistGoal.Name} ({checklistGoal.Description}) -- Currently completed: {checklistGoal.CheckProgress()}");
                }
                else
                {
                    Console.WriteLine($"{i}. [X] {goal.Name} ({goal.Description})");
                }
            }
            else
            {
                if (goal is ChecklistGoal checklistGoal)
                {
                    Console.WriteLine($"{i}. [ ] {checklistGoal.Name} ({checklistGoal.Description}) -- Currently completed: {checklistGoal.CheckProgress()}");
                }
                else
                {
                    Console.WriteLine($"{i}. [ ] {goal.Name} ({goal.Description})");
                }
            }
            i++;
        }
    }

    public string DisplayGoalTypes()
    {
        Console.WriteLine();
        Console.WriteLine("The types of goals are: ");
        for (int i = 0; i < _goalTypes.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goalTypes[i]}");
        }
        Console.Write("What type of goal would you like to create: ");
        return Console.ReadLine();
    }

    public Goal DisplayGoalNames()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are: ");
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.Name}");
            i++;
        }
        Console.Write("What goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine());
        while (index < 1 || index > _goals.Count)
        {
            Console.WriteLine("\nInvalid input. Please select a valid goal number.");
            index = int.Parse(Console.ReadLine());
        }
        return _goals[index - 1];
    }

    public void SaveGoals()
    {
        // foreach (Goal goal in _goals)
        // {

            string serializedGoal = JsonSerializer.Serialize(_goals);
            // if (goal is EternalGoal eternalGoal)
            // {
            //     serializedGoal = JsonSerializer.Serialize(eternalGoal);
            // }
            // else if (goal is ChecklistGoal checklistGoal)
            // {
            //     serializedGoal = JsonSerializer.Serialize(checklistGoal);
            // }
            // else
            // {
            //     serializedGoal = JsonSerializer.Serialize(goal);
            // }
            Console.WriteLine(serializedGoal);
        // }

    }

    public void LoadGoals(string filename)
    {
        throw new System.NotImplementedException();
    }
}
