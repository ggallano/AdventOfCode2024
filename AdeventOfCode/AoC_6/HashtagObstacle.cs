using System.Drawing;

namespace AoC_6
{
    public class HashtagObstacle : Obstacle
    {
        public HashtagObstacle(Point position, string name, string desc)
        {
            base.Description = desc;
            base.Name = name;
            base.Position = position;
        }
    }
}
