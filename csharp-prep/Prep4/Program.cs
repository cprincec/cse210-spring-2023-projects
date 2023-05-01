using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // create list to accept integers
        List<double> numbers = new List<double>();
        double entry;
        double sum = 0;
        double average;
        double max = 0;
        double smallestPositive = 999999999;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        // prompt user for numbers
        // insert number in numbers list
        do
        {
            Console.Write("Enter a number: ");
            entry = double.Parse(Console.ReadLine());
            if (entry != 0)
            {
                numbers.Add(entry);
            }
        } while (entry != 0);

        if (numbers.Count > 0)
        {
            foreach (double number in numbers)
            {
                // Add all numbers in the list
                sum = sum + number;

                // calculate maximum.
                if (number > max)
                {
                    max = number;
                }

                // find smallest postive number
                if (number < smallestPositive && number > 0)
                {
                    smallestPositive = number;
                }

            }
            // Calculate average of numbers in numbers list.
            average = sum / numbers.Count;

            // sort the list
            numbers.Sort();

            // display results
            Console.WriteLine($"\nThe sum is {sum}");
            Console.WriteLine($"The average is {average}");
            Console.WriteLine($"The largest number is {max}");
            Console.WriteLine($"The smallest positive number is {smallestPositive}\n");
            Console.WriteLine("The sorted list is: ");
            foreach (double number in numbers) 
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("There is no number in the list.\n");
        }
    }
}