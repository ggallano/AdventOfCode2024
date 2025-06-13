using System.Text.RegularExpressions;
using Utilities;

namespace AoC_11
{
    internal class Program
    {
        private const string _inputPath = @".\input\ex_input.txt";
        private const string RegPattern = @"\d+";

        static List<int> stones = new List<int>();
        static List<List<int>> blinks = new List<List<int>>();

        static void Main(string[] args)
        {
            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = TextExtractor.ExtractText(inputText, RegPattern);

            stones.AddRange(matches.Select(m => int.Parse(m.Value)).ToList());
            blinks.Add(stones);

            for (int i = 0; i < 25; i++)
            {
                var input = blinks.Last();
                stones = new List<int>();

                for (int j = 0; j < input.Count; j++)
                {

                }
            }
        }
    }
}
