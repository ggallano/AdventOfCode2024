﻿using System.Text.RegularExpressions;
using Utilities;

namespace AoC_5
{
    internal class Program
    {
        private const string _inputPath = @"C:\Users\ggallan2\Documents\Project_Code\_Github\AdventOfCOde\AdeventOfCode\AoC_5\input\input.txt";

        static void Main(string[] args)
        {
            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = TextExtractor.ExtractText(inputText, @"\d*\|\d*");
        }
    }
}
