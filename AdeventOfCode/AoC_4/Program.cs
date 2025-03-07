using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using Utilities;

namespace AoC_4
{
    internal class Program
    {
        private const string _inputPath = @"C:\Users\ggallan2\Documents\Project_Code\_Github\AdventOfCOde\AdeventOfCode\AoC_4\input\ex_input.txt";
        static List<Letter> _letterList = new List<Letter>();

        static void Main(string[] args)
        {
            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = ExtractCharacterLetter(inputText);
            _letterList = FillLetterList(matches);

            AbstractSearchPattern searchPattern = new SearchPatternMAS(_letterList);
            searchPattern.StartSearch();
            Console.WriteLine(searchPattern.GetMASPattern());
        }

        private static List<Letter> FillLetterList(MatchCollection matches)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < matches.Count; i++)
            {
                if (i % 140 == 0 && i > 0)
                //if (i % 10 == 0 && i > 0)
                {
                    x = 0;
                    y++;
                }

                _letterList.Add(new Letter(new Point(x++, y), matches[i].Value));
            }

            return _letterList;
        }

        private static MatchCollection ExtractCharacterLetter(string inputText)
        {
            return Regex.Matches(inputText, @"\w|\.");
        }
    }
}
