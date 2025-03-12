using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character char1 = new Character("Hero", 100, new int[] { 0, 0 });
            Map gameMap = new Map(5, 5);

            gameMap.PlaceCharacter(char1);
            gameMap.Display();

            Console.WriteLine(char1);
            char1.Move("right");
            char1.Move("up");

            gameMap = new Map(5, 5);  // Reset the map
            gameMap.PlaceCharacter(char1);
            gameMap.Display();

            Console.WriteLine(char1);
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int[] Position { get; set; }

        public Character(string name, int health, int[] position)
        {
            Name = name;
            Health = health;
            Position = position;
        }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    Position[1] += 1;
                    break;
                case "down":
                    Position[1] -= 1;
                    break;
                case "left":
                    Position[0] -= 1;
                    break;
                case "right":
                    Position[0] += 1;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name} is at position ({Position[0]}, {Position[1]}) with {Health} health.";
        }
    }

    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public char[,] Grid { get; set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new char[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Grid[y, x] = '.';
                }
            }
        }

        public void PlaceCharacter(Character character)
        {
            int x = character.Position[0];
            int y = character.Position[1];
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                Grid[y, x] = 'C';
            }
        }

        public void Display()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(Grid[y, x] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
