using System;
public class TerminalServices
{
    private List<String> _menu = new List<String> {
       "Write",
       "Add new prompt",
       "Display",
       "Load",
       "Save",
       "Quit"
    };
    public void DisplayMenu()
    {
        Console.WriteLine("\nWhat would you like to do? ");
        for (int i = 0; i < _menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_menu[i]}");
        }
    }

    public void PrintOutput<T>(T input)
    {
        if (input is String)
        {
            Console.WriteLine(input);
        }
        else if (input is IEnumerable<T>)
        {
            foreach (var item in (IEnumerable<T>)input)
            {
                Console.WriteLine(item);
            }
        }
    }

    public String ReadInput(String promptText = null)
    {
        if (promptText != null)
        {
            Console.Write(promptText);
        }
        return Console.ReadLine();
    }

    public int getMenuCount()
    {
        return _menu.Count;
    }
}