using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using Utilities;
using Utilities.Export;

namespace AoC_6
{
    internal class Program
    {
        const string _inputPath = @".\input\input.txt";
        static Character character;
        static FileExporter export = new FileExporter(new TextFileExport());
        static List<HashtagObstacle> hashtagObstacles = new List<HashtagObstacle>();
        static int invalidMoveCount = 0;
        static AoC_Map map;

        static int offset = 2;  // offset for the new line character "\r\n"
        static int size = 130;  // actiual input text file length
        static int length = size + offset;
        static string ChangeDirection(string direction)
        {
            map.stringBuilder.AppendLine($"");
            switch (direction)
            {
                case "up":
                    return "right";
                case "right":
                    return "down";
                case "down":
                    return "left";
                case "left":
                    return "up";
                default:
                    return "up";
            }
        }

        private static List<HashtagObstacle> FillHashtagObstacleList(MatchCollection matches)
        {
            foreach (Match item in matches)
            {
                var point = new Point(item.Index % length, (item.Index / length));
                hashtagObstacles.Add(new HashtagObstacle(point, "Hashtag", item.Value));
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
            map = new AoC_Map(size, size, export);
            map.OutofBouncePosition += Map_OutofBouncePosition;

            map.PlaceCharacter(character);
            map.PlaceObstacles(hashtagObstacles);

            var direction = "up";

            invalidMoveCount = 0;
            do
            {
                character.Direction = direction;
                character.Move(direction);

                if (map.CheckValidMove(character.Position)) // x:121 y:6
                {
                    map.PlaceCharacter(character);
                    invalidMoveCount = 0;
                    Console.WriteLine($"Valid Coordination: {character.Position}, Direction:{character.Direction}");
                }
                else
                {
                    character.MoveUndo(direction);
                    map.PlacePlusSymbol(character.Position);
                    Console.Write($"Invalid direction {direction}, ");
                    
                    map.PlacePlusSymbol(character.Position);

                    direction = ChangeDirection(direction);
                    character.Direction = direction;
                    Console.WriteLine($"Change direction to {character.Direction}");
                    
                    invalidMoveCount++;

                    map.Display();
                }
            } while (invalidMoveCount <= 1);

            map.Export();

            Console.WriteLine($"Distinct Positions: {character.TrackMoveList.Distinct().ToList().Count()}");
        }

        private static void Map_OutofBouncePosition(Point position)
        {
            invalidMoveCount = 2;
        }
    }
}
