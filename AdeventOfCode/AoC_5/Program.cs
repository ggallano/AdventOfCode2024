using System.Text.RegularExpressions;
using Utilities;

namespace AoC_5
{
    internal class Program
    {
        private const string _inputPath = @".\input\ex_input2.txt";
        const string firstSecRegPattern = @"\d*(?=\|)|(?<=\|)\d*";
        const string secondSecRegPattern = @"(\d*\,)+\d*";

        const string positiveLookBehind = @"(?<=61.*?)29"; // (?<={TargetNum}.*?){RuleNum}
        const string positiveLookAhead = @"13(?=.*?47)"; // {RuleNum}(?=.*?{TargetNum})

        static List<OrderRule> _orderRules = new List<OrderRule>();
        static List<PageOrder> _pageOrders = new List<PageOrder>();

        static void Main(string[] args)
        {

            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = TextExtractor.ExtractText(inputText, firstSecRegPattern);

            for (int i = 0; i < matches.Count; i += 3)
            {
                _orderRules.Add(new OrderRule(int.Parse(matches[i].Value), int.Parse(matches[i + 2].Value)));
            }

            matches = TextExtractor.ExtractText(inputText, secondSecRegPattern);

            foreach (Match item in matches)
            {
                PageOrder tempNums = new PageOrder();
                foreach (var num in item.Value.Split(',').ToList())
                {
                    tempNums.PageNums.Add(int.Parse(num));
                }

                tempNums.PageNum = item.Value;
                tempNums.HasViolation = false;
                tempNums.ViolationCount = 0;
                tempNums.CorrectedPageNum = tempNums.PageNum;
                _pageOrders.Add(tempNums);
            }

            var countRes = SearchViolations();
            var sumMidNum = GetSumMidNum(false);

            Console.WriteLine($"Middle Page Number: {sumMidNum}");

            StartPageOrderCorrection();
            sumMidNum = GetSumMidNum(true);

            Console.WriteLine($"Middle Page Number: {sumMidNum}");
        }

        public static void StartPageOrderCorrection()
        {
            var tempList = _pageOrders.Where(x => x.HasViolation == true).ToList();

            foreach (var pageOrder in tempList)
            {
                Console.WriteLine($"Page Order: {pageOrder.PageNum}");
                foreach (var violation in pageOrder.ViolatedRules)
                {
                    Console.WriteLine($"Violation: {violation.TargetNum} | {violation.RuleNum}");
                    var regExPattern = $@"(?<={violation.TargetNum}.*?){violation.RuleNum}";
                    if (!Regex.IsMatch(pageOrder.CorrectedPageNum, regExPattern))
                    {
                        pageOrder.PageNums.Swap(pageOrder.PageNums.IndexOf(violation.TargetNum), pageOrder.PageNums.IndexOf(violation.RuleNum));
                        pageOrder.CorrectedPageNum = string.Empty;
                        pageOrder.PageNums.ForEach(x => pageOrder.CorrectedPageNum += x + ",");
                        Console.WriteLine(pageOrder.CorrectedPageNum);
                    }

                    
                }

                Console.Write("Corrected Page Order: ");
                pageOrder.PageNums.ForEach(x => Console.Write(x+","));
                Console.WriteLine();
                Console.WriteLine();
            }
        }


        static int GetSumMidNum(bool hasViolation)
        {
            if (hasViolation)
                return _pageOrders.Where(x => x.HasViolation == true).Sum(x => x.MidNum);
            else
                return _pageOrders.Where(x => x.HasViolation == false).Sum(x => x.MidNum);
        }

        static int SearchViolations()
        {
            int violationCount = 0;
            foreach (var pageOrder in _pageOrders)
            {
                foreach (var targetNum in pageOrder.PageNums)
                {
                    var tempOrderRuleList = _orderRules.Where(x => x.TargetNum == targetNum).ToList();

                    foreach (var orderRule in tempOrderRuleList)
                    {
                        var regExPattern = $@"{orderRule.RuleNum}(?=.*?{targetNum})";
                        if (Regex.IsMatch(pageOrder.PageNum, regExPattern))
                        {
                            pageOrder.ViolationCount = ++violationCount;
                            pageOrder.HasViolation = true;
                            pageOrder.ViolatedRules.Add(orderRule);
                        }
                    }
                }
            }

            return violationCount;
        }
    }

    public static class Extensions
    {
        public static void Swap<T>(this List<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
    }
}
