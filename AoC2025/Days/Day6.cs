using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Days
{
    public class Day6 : IDay
    {
        string IDay.AnswerA(string pathInput)
        {
            string[] separatingStrings = [" ", "\r\n"];
            var text = File.ReadAllText(pathInput).Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            long grandTotal = 0;

            var operators = text.Where(x => x.Equals("*") || x.Equals("+")).ToArray();
            long numOperators = operators.Count();
            long[] tempOperation = new long[numOperators];

            for (long j = 0; j < numOperators; j++)
            {
                tempOperation[j] = long.Parse(text[j]);
            }

            for (long i = numOperators; i < text.Length - numOperators; i++)
            {
                var modI = mod(i, numOperators);
                if (operators[modI] == "+")
                {
                    tempOperation[modI] = tempOperation[modI] + long.Parse(text[i]);
                }
                else if (operators[modI] == "*")
                {
                    tempOperation[modI] = tempOperation[modI] * long.Parse(text[i]);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            grandTotal = tempOperation.Sum();

            return grandTotal.ToString();
        }

        string IDay.AnswerB(string pathInput)
        {
            string[] separatingStrings = ["\r\n"];
            var lines = File.ReadAllText(pathInput).Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
            var indexesColumns = findColumns(lines);

            var operators = lines[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            long grandTotal = 0;

            for (int i = 0; i < operators.Length; i ++)
            {
                int startRange = indexesColumns[i];
                int endRange = indexesColumns[i + 1];

                List<long> numbersOperation = new List<long>();

                for (int k = endRange-1; k > startRange; k --)
                {
                    
                    string number = "";

                    for (int j = 0; j < lines.Length - 1; j++)
                    {
                        number = number + lines[j][k];
                    }

                    numbersOperation.Add(long.Parse(number));
                }

                long localResult; 

                if (operators[i] == "+")
                {
                    localResult = numbersOperation.Sum();
                }
                else if (operators[i] == "*")
                {
                    localResult = product(numbersOperation);
                }
                else
                {
                    throw new ArgumentException();
                }
                grandTotal += localResult;
            }


            return grandTotal.ToString();
        }

        long product(List<long> numbers)
        {
            var temp = numbers[0];
            for (int i = 1; i < numbers.Count(); i++)
            {
                temp = temp * numbers[i];
            }

            return temp;
        }

        long mod(long x, long m)
        {
            return (x % m + m) % m;
        }

        List<int> findColumns(string[] lines)
        {
            List<int> indexesColumns = new List<int>{ -1 };

            for (int i = 0; i < lines[0].Length; i++)
            {
                bool allSpace = true;

                for (int j = 0; j < lines.Length; j++)
                {
                    allSpace = allSpace && lines[j][i] == ' ';
                }

                if (allSpace) { indexesColumns.Add(i); }
            }

            indexesColumns.Add(lines[0].Length);

            return indexesColumns;
        }
    }
}
