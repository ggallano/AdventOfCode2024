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
            this.Position = position;
            this.TrackMoveList = new List<Point>();
        }
        public string Direction { get; set; }

        public Point Position { get; set; }

        public List<Point> TrackMoveList { get; set; }

        public void Move(string direction)
        {
            var position = Position;
            switch (direction)
            {
                case "up":
                    position.Y -= 1;
                    Position = position;
                    break;
                case "down":
                    position.Y += 1;
                    Position = position;
                    break;
                case "left":
                    position.X -= 1;
                    Position = position;
                    break;
                case "right":
                    position.X += 1;
                    Position = position;
                    break;
            }
        }

        public void MoveUndo(string direction)
        {
            var position = Position;
            switch (direction)
            {
                case "up":
                    position.Y += 1;
                    Position = position;
                    break;
                case "down":
                    position.Y -= 1;
                    Position = position;
                    break;
                case "left":
                    position.X += 1;
                    Position = position;
                    break;
                case "right":
                    position.X -= 1;
                    Position = position;
                    break;
            }
        }
    }
}
