using System.Drawing;

namespace AoC_4
{
    public class SearchPatternXMAS : SearchPattern
    {
        string stringPattern = "XMAS";

        public SearchPatternXMAS(List<Letter> letterList)
        {
            this.letterList = letterList;
            searchedPoints = new List<Point>();
        }

        public override int GetMASPattern()
        {
            throw new NotImplementedException();
        }

        public override void StartSearch()
        {
            foreach (var letter in letterList)
            {
                if (letter.Text != "X")
                    continue;


                searchedPoints.Add(letter.Coordinate);
                searchedPoints.Add(GetUpperRightCoord(letter.Coordinate));
                searchedPoints.Add(GetLowerLeftCoord(letter.Coordinate));
                searchedPoints.Add(GetUpperLeftCoord(letter.Coordinate));
                searchedPoints.Add(GetLowerRightCoord(letter.Coordinate));
            }
        }

        private Point GetLowerLeftCoord(Point coordinate)
        {
            return new Point(--coordinate.X, ++coordinate.Y);
        }

        private Point GetLowerRightCoord(Point coordinate)
        {
            return new Point(++coordinate.X, ++coordinate.Y);
        }

        private Point GetUpperLeftCoord(Point coordinate)
        {
            return new Point(--coordinate.X, --coordinate.Y);
        }
        private Point GetUpperRightCoord(Point coordinate)
        {
            return new Point(++coordinate.X, --coordinate.Y);
        }
    }
}
