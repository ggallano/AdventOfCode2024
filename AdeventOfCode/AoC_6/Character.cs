using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_6
{
    public class Character
    {
        public Character(Point position)
        {
            Position = position;
        }

        public Point Position { get; }
    }
}
