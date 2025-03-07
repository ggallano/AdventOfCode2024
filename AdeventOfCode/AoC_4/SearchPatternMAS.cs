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
            return 0;
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
