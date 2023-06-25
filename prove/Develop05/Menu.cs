using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Menu
{
    private List<string> _menuList = new List<string> {
            "Create New goal",
            "List goals",
            "Save Goals",
            "Load goals",
            "Record Event",
            "Quit"
        };

    public string DisplayMenu(int totalPoints)
    {
        Console.WriteLine($"You now have {totalPoints} points.\n");
        Console.WriteLine("Menu options: ");
        for (int i = 0; i < _menuList.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_menuList[i]}");
        }
        Console.Write("Select a choice from the menu: ");
        return Console.ReadLine();
    }
}
