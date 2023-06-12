public class Menu 
{
    List<string> _menu = new List<string> {
        "Start breathing activity",
        "Start reflecting activity",
        "Start listening actvity",
        "Quit"
    };

    public string ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        for (int index = 0; index < _menu.Count; index++) 
        {
            Console.WriteLine($"{index + 1}. {_menu[index]}");
        }
        Console.Write("Select a choice from the menu: ");
        string menuOption = Console.ReadLine();
        return menuOption;
    }

}