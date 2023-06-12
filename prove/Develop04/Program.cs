using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        string choice = menu.ShowMenu();

        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity listingActivity = new ListingActivity();

        while (choice != "4")
        {
            if (choice == "1")
            {
                breathingActivity.RunActivity();
            }
            else if (choice == "2")
            {
                reflectionActivity.RunActivity();
            }
            else if (choice == "3")
            {
                listingActivity.RunActivity();
            }
            
            choice = menu.ShowMenu();
        }

        Console.WriteLine();
        Console.WriteLine("------------");
        Console.WriteLine("STATISTICS: ");
        Console.WriteLine("------------");
        Console.WriteLine($"Breathing Activity: {breathingActivity.GetRoundsPlayed()} round(s) for a total of {breathingActivity.GetTotalTimePlayed()} seconds.");
        Console.WriteLine($"Reflection activity: {reflectionActivity.GetRoundsPlayed()} round(s) for a total of {reflectionActivity.GetTotalTimePlayed()} seconds.");
        Console.WriteLine($"Listing activity: {listingActivity.GetRoundsPlayed()} round(s) for a total of {listingActivity.GetTotalTimePlayed()} seconds.");
    }
}