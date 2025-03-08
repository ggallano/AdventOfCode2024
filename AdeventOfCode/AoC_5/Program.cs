using System.Text.RegularExpressions;
using Utilities;

namespace AoC_5
{
    internal class Program
    {
        private const string _inputPath = @".\input\ex_input.txt";
        const string tempRegPattern = @"\d*(?=\|)|(?<=\|)\d*";

        List<OrderRule> _orderRules = new List<OrderRule>();

        static void Main(string[] args)
        {
            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = TextExtractor.ExtractText(inputText, tempRegPattern);

            for (int i = 0; i >= matches.Count; i+=2)
            {
                _orderRules.Add(new OrderRule(matches[i].Value, matches[i + 1].Value));
            }

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
