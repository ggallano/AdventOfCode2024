using System.Net;
using System.Text.RegularExpressions;
using Utilities;

namespace AoC_7
{
    internal class Program
    {
        private const string _inputPath = @".\input\input1.txt";
        private const string RegPattern = @"\d+";
        //  \d+(?=\:)

        // (?<=\s)\d+

        static List<Rope> Ropes = new List<Rope>();

        static void Main(string[] args)
        {
            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = TextExtractor.ExtractText(inputText, RegPattern);

            //for (int i = 0; i < matches.Count; i += 3)
            //{
            //    Ropes.Add();
            //}
        }
    }

    public class Rope
    {
        public int LeftValue { get; set; }
        public List<int> RightValue { get; set; }
    }
}
