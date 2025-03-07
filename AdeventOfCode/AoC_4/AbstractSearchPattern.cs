
using System.Drawing;

namespace AoC_4
{
    public abstract class AbstractSearchPattern
    {
        public List<Letter> letterList;
        public List<Point> searchedPoints;
        public abstract int GetMASPattern();
        public abstract void StartSearch();
    }
}