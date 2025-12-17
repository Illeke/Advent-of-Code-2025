using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Days
{
    public class Day2 : IDay
    {
        string IDay.AnswerA(string pathInput)
        {
            var text = File.ReadAllText(pathInput).Split(',');
            long sumInvalid = 0;

            foreach(var range in text)
            {
                var rangeBoundaries = range.Split('-');
                for (long i = long.Parse(rangeBoundaries[0]); i <= long.Parse(rangeBoundaries[1]); i++)
                {
                    var stringI = i.ToString();
                    var iLength = stringI.Length;
                    var iHalfLength = iLength / 2; 

                    if (even(iLength) && stringI.Substring(0, iHalfLength).Equals(stringI.Substring(iHalfLength, iHalfLength)))
                    {
                        sumInvalid += i;
                    }
                }
            }
            return sumInvalid.ToString();
        }

        string IDay.AnswerB(string pathInput)
        {
            var text = File.ReadAllText(pathInput).Split(',');
            long sumInvalid = 0;

            foreach (var range in text)
            {
                var rangeBoundaries = range.Split('-');
                for (long i = long.Parse(rangeBoundaries[0]); i <= long.Parse(rangeBoundaries[1]); i++)
                {
                    var stringI = i.ToString();
                    var iLength = stringI.Length;

                    for (int j = 1; j <= iLength/2; j++)
                    {
                        if (iLength % j == 0)
                        {
                            var substrings = stringI.Select((c, index) => new { c, index })
                            .GroupBy(x => x.index / j)
                            .Select(group => group.Select(elem => elem.c))
                            .Select(chars => new string(chars.ToArray()));

                            if (substrings.Distinct().Take(2).Count() == 1)
                            {
                                sumInvalid += i;
                                break;
                            }
                        }
                    }  
                }
            }

            return sumInvalid.ToString();
        }

        bool even(int x)
        {
            var mod = (x % 2 + 2) % 2;
            return mod == 0;
        }
    }
}
