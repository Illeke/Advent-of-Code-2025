using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Days
{
    public class Day1 : IDay
    {
        string IDay.AnswerA(string pathInput)
        {
            int dialPointer = 50;
            int passwordCounter = 0;

            var lines = File.ReadLines(pathInput);
            foreach (var line in lines)
            {
                char a = line.FirstOrDefault();
                int b = Int32.Parse(line.Substring(1));

                if (a.Equals('R'))
                {
                    dialPointer = mod(dialPointer + b, 100);
                }
                else if (a.Equals('L'))
                {
                    dialPointer = mod(dialPointer - b, 100);
                }
                else
                {
                    throw new ArgumentException();
                }

                if (dialPointer == 0) passwordCounter++;
            }
            return passwordCounter.ToString();
        }

        string IDay.AnswerB(string pathInput)
        {
            int dialPointer = 50;
            int passwordCounter = 0;

            var lines = File.ReadLines(pathInput);
            foreach (var line in lines)
            {
                char a = line.FirstOrDefault();
                int b = Int32.Parse(line.Substring(1));

                if (a.Equals('R'))
                {
                    for (int i = 0; i < b; i++)
                    {
                        dialPointer = mod(dialPointer + 1, 100);
                        if (dialPointer == 0) passwordCounter++;
                    }
                }
                else if (a.Equals('L'))
                {
                    for (int i = 0; i < b; i++)
                    {
                        dialPointer = mod(dialPointer - 1, 100);
                        if (dialPointer == 0) passwordCounter++;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            return passwordCounter.ToString();
        }

        int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
