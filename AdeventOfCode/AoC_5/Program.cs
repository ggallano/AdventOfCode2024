using System.Text.RegularExpressions;
using Utilities;

namespace AoC_5
{
    internal class Program
    {
        private const string _inputPath = @".\input\ex_input.txt";
        const string firstSecRegPattern = @"\d*(?=\|)|(?<=\|)\d*";
        const string secondSecRegPattern = @"(\d*\,)+\d*";

        const string positiveLookBehind = @"(?<=61.*?)29"; // (?<={TargetNum}.*?){RuleNum}
        const string positiveLookAhead = @"13(?=.*?47)"; // {RuleNum}(?=.*?{TargetNum})

        static List<OrderRule> _orderRules = new List<OrderRule>();
        static List<PageOrder> _pageOrder = new List<PageOrder>();

        static void Main(string[] args)
        {
            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = TextExtractor.ExtractText(inputText, firstSecRegPattern);

            for (int i = 0; i < matches.Count; i+=3)
            {
                _orderRules.Add(new OrderRule(int.Parse(matches[i].Value), int.Parse(matches[i + 2].Value)));
            }

            matches = TextExtractor.ExtractText(inputText, secondSecRegPattern);

            foreach (Match item in matches)
            {
                PageOrder tempNums = new PageOrder();
                foreach (var num in item.Value.Split(',').ToList())
                {
                    tempNums.PageNums.Add(num);
                }
                
                tempNums.PageNum = item.Value;
                _pageOrder.Add(tempNums);
            }
        }
    }
}
