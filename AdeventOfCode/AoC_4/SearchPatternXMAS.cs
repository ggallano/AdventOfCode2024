using System.Drawing;
using System.Net;

namespace AoC_4
{
    public class SearchPatternXMAS : AbstractSearchPattern
    {
        string stringPattern = "XMAS";

        public SearchPatternXMAS(List<Letter> letterList)
        {
            this.letterList = letterList;
            searchedPoints = new List<Point>();
        }

        public override int GetPattern()
        {
            int totalCount = 0;
            string tempString = string.Empty;
            foreach (var item in searchedPoints)
            {
                var letter = letterList.Where(x => x.Coordinate == item);

                foreach (var character in letter)
                {
                    if (character.Text == "X")
                        tempString = string.Empty;

                    tempString += character.Text;
                }

                if (stringPattern.Equals(tempString))
                {
                    totalCount++;
                    Console.WriteLine($"Total Count: {totalCount}");

                    tempString = string.Empty;
                }
            }

            return totalCount;
        }

        public override void StartSearch()
        {
            foreach (var letter in letterList)
            {
                if (letter.Text != "X")
                    continue;

                searchedPoints.AddRange(GetUpperCoord(letter.Coordinate));
                searchedPoints.AddRange(GetUpperRightCoord(letter.Coordinate));
                searchedPoints.AddRange(GetRightCoord(letter.Coordinate));
                searchedPoints.AddRange(GetLowerLeftCoord(letter.Coordinate));
                searchedPoints.AddRange(GetLowerCoord(letter.Coordinate));
                searchedPoints.AddRange(GetLowerRightCoord(letter.Coordinate));
                searchedPoints.AddRange(GetLeftCoord(letter.Coordinate));
                searchedPoints.AddRange(GetUpperLeftCoord(letter.Coordinate));
                
            }
        }

        private List<Point> GetLeftCoord(Point coordinate)
        {
            List<Point> tempList = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(new Point(coordinate.X--, coordinate.Y));
            }
            return tempList;
        }

        private List<Point> GetLowerCoord(Point coordinate)
        {
            List<Point> tempList = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(new Point(coordinate.X, coordinate.Y++));
            }
            return tempList;
        }

        private List<Point> GetRightCoord(Point coordinate)
        {
            List<Point> tempList = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(new Point(coordinate.X++, coordinate.Y));
            }
            return tempList;
        }

        private List<Point> GetUpperCoord(Point coordinate)
        {
            List<Point> tempList = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(new Point(coordinate.X, coordinate.Y--));
            }
            return tempList;
        }

        private List<Point> GetLowerLeftCoord(Point coordinate)
        {
            List<Point> tempList = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(new Point(coordinate.X--, coordinate.Y++));
            }
            return tempList;
        }

        private List<Point> GetLowerRightCoord(Point coordinate)
        {
            List<Point> tempList = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(new Point(coordinate.X++, coordinate.Y++));
            }
            return tempList;
        }

        private List<Point> GetUpperLeftCoord(Point coordinate)
        {
            List<Point> tempList = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(new Point(coordinate.X--, coordinate.Y--));
            }
            return tempList;
        }
        private List<Point> GetUpperRightCoord(Point coordinate)
        {
            List<Point> tempList = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                tempList.Add(new Point(coordinate.X++, coordinate.Y--));
            }
            return tempList;
        }
    }
}
