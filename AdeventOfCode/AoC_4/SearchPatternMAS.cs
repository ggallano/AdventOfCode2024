using System.Drawing;

namespace AoC_4
{
    public class SearchPatternMAS : AbstractSearchPattern
    {
        List<string> stringPatterns = new List<string>() { "ASMMS", "AMSSM", "AMSMS", "ASMSM" };

        public SearchPatternMAS(List<Letter> letterList)
        {
            this.letterList = letterList;
            searchedPoints = new List<Point>();
        }

        public override int GetMASPattern()
        {
            int totalCount = 0;
            string stringPattern = string.Empty;
            for (int i = 0; i < searchedPoints.Count; i += 5)
            {
                for (int j = i; j < i + 5; j++)
                {
                    var letter = letterList.Where(x => x.Coordinate == searchedPoints[j]);

                    foreach (var character in letter)
                    {
                        Console.WriteLine($"coordinates:{searchedPoints[j]} : {character.Text}");
                        stringPattern += character.Text;
                    }

                    if (stringPatterns.Contains(stringPattern))
                    {
                        totalCount++;
                        Console.WriteLine($"Total Count: {totalCount}");
                    }
                }

                stringPattern = string.Empty;

            }
            return totalCount;
        }

        public override void StartSearch()
        {
            foreach (var letter in letterList)
            {
                if (letter.Text != "A")
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
