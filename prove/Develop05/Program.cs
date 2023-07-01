using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        GoalTracker goalTracker = new GoalTracker();

        string choice = menu.DisplayMenu(goalTracker.TotalPointsEarned);

        while (choice != "6")
        {
            if (choice == "1")
            {
                Console.WriteLine();
                string goalType = goalTracker.DisplayGoalTypes();
                string name;
                string description;
                int basePoint;

                switch (goalType)
                {
                    case "1":
                        Console.Write("What is the name of your goal? ");
                        name = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        description = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        basePoint = int.Parse(Console.ReadLine());

                        SimpleGoal simpleGoal = new SimpleGoal(name, description, basePoint);
                        goalTracker.AddGoal(simpleGoal);
                        break;

                    case "2":
                        Console.Write("What is the name of your goal? ");
                        name = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        description = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        basePoint = int.Parse(Console.ReadLine());

                        EternalGoal eternalGoal = new EternalGoal(name, description, basePoint);
                        goalTracker.AddGoal(eternalGoal);
                        break;

                    case "3":
                        Console.Write("What is the name of your goal? ");
                        name = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        description = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        basePoint = int.Parse(Console.ReadLine());
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        int numOfTimes = int.Parse(Console.ReadLine());
                        Console.Write("What is the bonus points for accomplishing it that many times? ");
                        int bonusPoints = int.Parse(Console.ReadLine());

                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, basePoint, numOfTimes, bonusPoints);
                        goalTracker.AddGoal(checklistGoal);
                        break;

                    default:
                        break;
                }
                Console.WriteLine();
                choice = menu.DisplayMenu(goalTracker.TotalPointsEarned);
            }
            else if (choice == "2")
            {
                Console.WriteLine();
                goalTracker.DisplayGoals();
                Console.WriteLine();
                choice = menu.DisplayMenu(goalTracker.TotalPointsEarned);
            }
            else if (choice == "3")
            {
                goalTracker.SaveGoals();
                // string serializedGoal = JsonSerializer.Serialize(goalTracker);
                // Console.WriteLine(serializedGoal);

                Console.WriteLine();
                choice = menu.DisplayMenu(goalTracker.TotalPointsEarned);
            }
            else if (choice == "4")
            {
                Console.WriteLine();
                choice = menu.DisplayMenu(goalTracker.TotalPointsEarned);
            }
            else if (choice == "5")
            {
                Console.WriteLine();
                Goal goal = goalTracker.DisplayGoalNames();
                int pointsEarned = goal.RecordEvent();
                goalTracker.TotalPointsEarned = pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");

                Console.WriteLine();
                choice = menu.DisplayMenu(goalTracker.TotalPointsEarned);
            }
        }
    }
}