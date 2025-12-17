// See https://aka.ms/new-console-template for more information
using Days;
using System.ComponentModel.Design;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Which day do you want to run?");
        int inputDay = Convert.ToInt32(Console.ReadLine());
        IDay day = getDay(inputDay);

        Console.WriteLine("\nDo you want to run 'A' or 'B'?");
        char inputPart = char.ToUpper(Console.ReadKey().KeyChar);

        int result;
        string pathInput = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Inputs", $"Day{inputDay}", $"Input{inputPart}.txt");

        if (inputPart == 'A')
        {
            result = day.AnswerA(pathInput);
        }
        else if (inputPart == 'B')
        {
            result = day.AnswerB(pathInput);
        }
        else
        {
            throw new ArgumentException($"{inputPart} is an invalid input.");
        }

        Console.WriteLine($"\n\nResult of day {day} is: \n{result}");
    }
    private static IDay getDay(int day)
    {
        switch (day)
        {
            case 1:
                return new Day1();
            default:
                throw new ArgumentException($"{day} is an invalid value for day.");
        }
    }
}
