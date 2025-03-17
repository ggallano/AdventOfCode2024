namespace AoC_6_Vrad
{
    internal class Program
    {
        static char[,] map;
        static int rows, cols;
        static int guardX, guardY;
        static char guardDirection;
        static List<(int, int)> distinctPositions = new List<(int, int)>();

        static int[] directX = { -1, 0, 1, 0 };
        static int[] directY = { 0, 1, 0, -1 };
        static int direction;

        static void Main()
        {
            string[] input = File.ReadAllLines(@"C:\Users\ggallan2\Documents\Project_Code\_Github\AdventOfCOde\AdeventOfCode\AoC_6\input\input.txt");

            InitializeMap(input);
            VisitedDistinctPositions();
            Console.WriteLine("Distinct Positions: " + distinctPositions.Count);
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void InitializeMap(string[] input)
        {
            rows = input.Length;
            cols = input[0].Length;
            map = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    map[i, j] = input[i][j];
                    if (map[i, j] == '^' || map[i, j] == '>' || map[i, j] == 'v' || map[i, j] == '<')
                    {
                        guardX = i;
                        guardY = j;
                        guardDirection = map[i, j];

                        if (guardDirection == '^') direction = 0;
                        else if (guardDirection == '>') direction = 1;
                        else if (guardDirection == 'v') direction = 2;
                        else if (guardDirection == '<') direction = 3;
                    }
                }
            }

            distinctPositions.Add((guardX, guardY));
        }

        static void VisitedDistinctPositions()
        {
            while (true)
            {
                int newX = guardX + directX[direction];
                int newY = guardY + directY[direction];

                // break pag lumabas na
                if (newX < 0 || newX >= rows || newY < 0 || newY >= cols)
                    break;

                if (map[newX, newY] == '#')
                {
                    //pang 90 degrees
                    direction = (direction + 1) % 4;
                    Console.WriteLine();
                }
                else
                {
                    guardX = newX;
                    guardY = newY;
                    if (!distinctPositions.Contains((guardX, guardY)))
                    {
                        distinctPositions.Add((guardX, guardY));

                        string stringDir = string.Empty;
                        switch (direction)
                        {
                            case 0:
                                stringDir = "up";
                                break;
                            case 1:
                                stringDir = "right";
                                break;
                            case 2:
                                stringDir = "down";
                                break;
                            case 3:
                                stringDir = "left";
                                break;
                            default:
                                break;
                        }

                        Console.WriteLine("Valid Coordination: {" + "X=" + guardY + "," + "Y=" + guardX + "}, " + "Direction:" + stringDir);
                    }
                }
            }
        }
    }
}
