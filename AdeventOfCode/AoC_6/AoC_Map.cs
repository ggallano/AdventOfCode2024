using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_6
{
    public class AoC_Map
    {
        private readonly int width;
        private readonly int height;
        private char[,] grid;

        public AoC_Map(int width, int height) 
        {
            this.width = width;
            this.height = height;
            grid = new char[width, height];
        }

        public void PlaceCharacter(Character character)
        {
            int x = character.Position.X;
            int y = character.Position.Y;
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grid[y, x] = '^';
            }
        }

        public void Display()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(grid[y, x] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
