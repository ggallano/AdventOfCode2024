using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using Utilities;

namespace AoC_6
{
    internal class Program
    {
        private const string _inputPath = @".\input\ex_input.txt";
        private static List<HashtagObstacle> hashtagObstacles = new List<HashtagObstacle>();
        private static Character character;

        static void Main(string[] args)
        {
            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = TextExtractor.ExtractText(inputText, @"\#");
            hashtagObstacles = FillHashtagObstacleList(matches);

            matches = TextExtractor.ExtractText(inputText, @"\^");
            Point charPosition = GetInitialCharPosition(matches);

            character = new Character(charPosition);
        }

        private static List<HashtagObstacle> FillHashtagObstacleList(MatchCollection matches)
        {
            int y = 0;
            foreach (Match item in matches)
            {
                hashtagObstacles.Add(new HashtagObstacle(new Point(item.Index, y++), "Hashtag", item.Value));
            }

            return hashtagObstacles;
        }

        private static Point GetInitialCharPosition(MatchCollection matches)
        {
            int length = 12;    // subject to change based from the input text file length
            foreach (Match item in matches)
            {
                if (item.Value == "^")
                {
                    return new Point(item.Index % length, (item.Index / length));
                }
            }
            return new Point(0, 0);
        }
    }
}