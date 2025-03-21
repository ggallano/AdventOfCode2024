using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Export;

namespace AoC_6
{
    public class AoC_Map
    {
        public FileExporter export;
        public StringBuilder stringBuilder = new StringBuilder();
        private readonly int height;
        private readonly int width;
        private char[,] grid;

        public AoC_Map(int width, int height, FileExporter export)
        {
            this.export = export;
            this.width = width;
            this.height = height;
            grid = new char[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[x, y] = '.';
                }
            }
        }

        public delegate void Notify(Point position);

        public event Notify OutofBouncePosition;

        enum CoordStatus
        {
            Dot = '.',
            Carrot = '^',
            Hash = '#',
            Underscore = '_',
            X = 'X'
        }

        public bool CheckValidMove(Point position)
        {
            int x = position.X;
            int y = position.Y;

            if (x < 0 || y < 0)
                return false;

            if (x >= width || y >= height)
            {
                OutofBouncePosition?.Invoke(position);
                return false;
            }

            if ((grid[x, y] == '.') || (grid[x, y] == '^') || (grid[x, y] == 'X') || (grid[x, y] == '-') || (grid[x, y] == '|'))
                return true;

            return false;
        }

        public void Display()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(grid[x, y] + "");
                    stringBuilder.Append(grid[x, y] + "");
                }
                Console.WriteLine();
                stringBuilder.AppendLine("");
            }
            Console.WriteLine();
            stringBuilder.AppendLine("");
        }

        public void PlaceCharacter(Character character)
        {
            character.TrackMoveList.Add(character.Position);
            stringBuilder.AppendLine($"Valid Coordination: {character.Position}, Direction:{character.Direction}");
        }

        public void PlacePlusSymbol(Point position)
        {
            int x = position.X;
            int y = position.Y;
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grid[x, y] = '+';
            }
        }

        public void PlaceObstacles(List<HashtagObstacle> obstacles)
        {
            foreach (HashtagObstacle obstacle in obstacles)
            {
                int x = obstacle.Position.X;
                int y = obstacle.Position.Y;

                if (x >= 0 && x < width && y >= 0 && y < height)
                {
                    grid[x, y] = '#';
                }
            }
        }
        internal void Export()
        {
            export.ExportText(stringBuilder.ToString());
        }

        internal void PreviousPlaceCharacter(Character character)
        {
            int x = character.TrackMoveList[character.TrackMoveList.Count - 2].X;
            int y = character.TrackMoveList[character.TrackMoveList.Count - 2].Y;

            if ((grid[x, y] == '+') || (grid[x, y] == '^'))
                return;

            if ((grid[x, y] == '-') || (grid[x, y] == '|'))
            {
                grid[x, y] = '+';
                return;
            }

            if (character.Direction == "up" || character.Direction == "down")
                grid[x, y] = '|';
            else
                grid[x, y] = '-';
        }

        internal void InitialCharacterPosition(Point position)
        {
            int x = position.X;
            int y = position.Y;
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grid[x, y] = '^';
            }
        }
    }
}
