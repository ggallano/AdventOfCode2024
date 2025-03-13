using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using Utilities;

namespace AoC_6
{
    internal class Program
    {
        const string _inputPath = @".\input\ex_input.txt";
        static Character character;
        static List<HashtagObstacle> hashtagObstacles = new List<HashtagObstacle>();
        static AoC_Map map;

        static int offset = 2;  // offset for the new line character "\r\n"
        static int size = 10;  // actiual input text file length
        static int length = size + offset;

        private static List<HashtagObstacle> FillHashtagObstacleList(MatchCollection matches)
        {
            foreach (Match item in matches)
            {
                hashtagObstacles.Add(new HashtagObstacle(new Point(item.Index % length, (item.Index / length)), "Hashtag", item.Value));
            }

            return hashtagObstacles;
        }

        private static Point GetInitialCharPosition(MatchCollection matches)
        {
            foreach (Match item in matches)
            {
                if (item.Value == "^")
                {
                    return new Point(item.Index % length, (item.Index / length));
                }
            }
            return new Point(0, 0);
        }

        static void Main(string[] args)
        {
            var inputText = InputFileReader.ReadText(_inputPath);
            MatchCollection matches = TextExtractor.ExtractText(inputText, @"\#");
            hashtagObstacles = FillHashtagObstacleList(matches);

            matches = TextExtractor.ExtractText(inputText, @"\^");
            Point charPosition = GetInitialCharPosition(matches);

            character = new Character(charPosition);
            map = new AoC_Map(size, size);

            map.PlaceCharacter(character);
            map.PlaceObstacles(hashtagObstacles);
            map.Display();

            Console.WriteLine();

            var direction = "up";

            character.Direction = direction;
            character.Move(direction);

            if (map.CheckValidMove(character.Position))
                map.PlaceCharacter(character);
            else
            {
                character.MoveUndo(direction);
                ChangeDirection(direction);
            }

            map.Display();
        }

        static void ChangeDirection(string direction)
        {
            switch (direction)
            {
                case "up":
                    character.Direction = "right";
                    break;
                case "right":
                    character.Direction = "down";
                    break;
                case "down":
                    character.Direction = "left";
                    break;
                case "left":
                    character.Direction = "up";
                    break;
                default:
                    break;
            }
        }
    }
}
