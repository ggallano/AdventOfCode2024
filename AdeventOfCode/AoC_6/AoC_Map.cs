using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_6
{
    public class AoC_Map
    {
        private readonly int width;
        private readonly int height;
        private readonly List<Obstacle> obstacles;

        public AoC_Map(int width, int height, List<Obstacle> obstacles) 
        {
            this.width = width;
            this.height = height;
            this.obstacles = obstacles;
        }
    }
}
