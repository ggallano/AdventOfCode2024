﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_4
{
    public class Letter
    {
        public Point Coordinate { get; set; }
        public string Text { get; set; }

        public Letter(Point coord, string text)
        {
            this.Coordinate = coord;
            this.Text = text;
        }
    }
}
