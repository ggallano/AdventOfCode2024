using System.Text.RegularExpressions;
using System.Threading.Channels;
using Utilities;

namespace AoC_11
{
    internal class Program
    {
        private const string _inputPath = @".\input\ex_input.txt";
        private const string RegPattern = @"\d+";

        static List<ulong> stones = new List<ulong>();
        static List<List<ulong>> blinks = new List<List<ulong>>();

        static void Main(string[] args)
        {
            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = TextExtractor.ExtractText(inputText, RegPattern);

            stones.AddRange(matches.Select(m => ulong.Parse(m.Value)).ToList());
            blinks.Add(stones);

            for (int i = 0; i < 25; i++)
            {
                var input = blinks.Last();
                stones = new List<ulong>();

                for (int j = 0; j < input.Count; j++)
                {
                    if (input[j] == 0)
                    {
                        stones.Add(1);
                        continue;
                    }

                    var temp = input[j].ToString().Length;
                    var median = input[j].ToString().Length / 2;
                    if (temp % 2 == 0)
                    {
                        var firstHalf = input[j].ToString().Substring(0, median);
                        var secondHalf = input[j].ToString().Substring(median, median);
                        stones.Add(ulong.Parse(firstHalf));
                        stones.Add(ulong.Parse(secondHalf));

                        continue;
                    }

                    stones.Add(input[j] * 2024);
                }

                blinks.Add(stones);

                Console.Write($"Blink {i + 1}: ");
                //stones.ForEach(p => Console.Write($"{p} "));
                Console.Write($" Stones: {stones.Count} ");
                Console.WriteLine();
            }
        }
    }
}
