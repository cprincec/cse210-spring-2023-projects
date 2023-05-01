using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your score: ");
        int grade = int.Parse(Console.ReadLine());
        string letterGrade;
        string sign;

        if (grade >= 90) {
            letterGrade = "A";
        }
        else if (grade >= 80) {
            letterGrade = "B";
        }
        else if (grade >= 70) {
            letterGrade = "C";
        }
        else if (grade >= 60) {
            letterGrade = "D";
        } 
        else {
            letterGrade = "F";
        }

        if (grade % 10 >=7) {
            if (letterGrade == "A" || letterGrade == "F") {
                sign = "";
            } else {
                sign = "+";
            } 
        } 
        else if (grade % 10 <= 3) {
            if (letterGrade == "F") {
                sign = "";
            } else {
                sign = "-";
            } 
        }
        else {
            sign = "";
        }

        Console.WriteLine($"Your grade is {letterGrade}{sign}");

        if (grade >= 70) {
            Console.WriteLine("Congratulations, you passed!");
        } else {
            Console.WriteLine("Sorry, you failed.");
        }    
    }
}