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
        private readonly int width;
        private readonly int height;
        private char[,] grid;

        private FileExporter export;

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

        public void PlaceCharacter(Character character)
        {
            int x = character.Position.X;
            int y = character.Position.Y;
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grid[x, y] = '^';
                if (character.TrackMoveList.Count > 0)
                    grid[character.TrackMoveList.Last().X, character.TrackMoveList.Last().Y] = 'X';
            }

            character.TrackMoveList.Add(character.Position);
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

        public void Display()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(grid[x, y] + "");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool CheckValidMove(Point position)
        {
            int x = position.X;
            int y = position.Y;

            if (x < 0 || y < 0)
                return false;

            if (x >= width || y >= height)
                return false;

            //if (!(x <= 0 || x < width))
            //    return false;

            //if (!(y <= 0 || y < height))
            //    return false;

            if ((grid[x, y] == '.') || (grid[x, y] == '^') || (grid[x, y] == 'X'))
                return true;

            return false;
        }
    }
}
