
using System.Drawing;

namespace AoC_4
{
    public abstract class AbstractSearchPattern
    {
        public List<Letter> letterList;
        public List<Point> searchedPoints;
        public abstract int GetPattern();
        public abstract void StartSearch();
    }
}