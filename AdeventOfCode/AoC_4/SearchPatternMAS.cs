using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_4
{
    public class SearchPatternMAS
    {
        List<string> stringPatterns = new List<string>() { "ASM", "AMS" };
        List<Point> searchedPoints;
        public SearchPatternMAS(List<Letter> letterList)
        {
            LetterList = letterList;
            searchedPoints = new List<Point>();
        }

        public List<Letter> LetterList { get; }

        public void StartSearch()
        {
            foreach (var letter in LetterList)
            {
                if (letter.Text != "A")
                    continue;

                //Console.WriteLine($"A coordinates:{letter.Coordinate}");

                searchedPoints.Add(letter.Coordinate);
                searchedPoints.Add(GetUpperRightCoord(letter.Coordinate));
                searchedPoints.Add(GetLowerLeftCoord(letter.Coordinate));

                searchedPoints.Add(letter.Coordinate);
                searchedPoints.Add(GetUpperLeftCoord(letter.Coordinate));
                searchedPoints.Add(GetLowerRightCoord(letter.Coordinate));
            }
        }

        
        public int GetMASPattern()
        {
            int count = 0;
            int totalCount = 0;
            string stringPattern = string.Empty;
            for (int i = 0; i < searchedPoints.Count; i += 3)
            {
                for (int j = i; j < i + 3; j++)
                {
                    var letter = LetterList.Where(x => x.Coordinate == searchedPoints[j]);

                    foreach (var character in letter)
                    {
                        Console.WriteLine($"coordinates:{searchedPoints[j]} : {character.Text}");
                        stringPattern += character.Text;
                    }

                    if (stringPatterns.Contains(stringPattern))
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    totalCount++;
                    count = 0;
                    Console.WriteLine($"Total Count: {totalCount}");
                    Console.WriteLine($"");
                }

                stringPattern = string.Empty;
                
            }
            return totalCount;
        }

        private Point GetLowerRightCoord(Point coordinate)
        {
            return new Point(++coordinate.X, ++coordinate.Y);
        }

        private Point GetUpperLeftCoord(Point coordinate)
        {
            return new Point(--coordinate.X, --coordinate.Y);
        }

        private Point GetLowerLeftCoord(Point coordinate)
        {
            return new Point(--coordinate.X, ++coordinate.Y);
        }

        private Point GetUpperRightCoord(Point coordinate)
        {
            return new Point(++coordinate.X, --coordinate.Y);
        }
    }
}
