using System;
using System.Collections.Generic;
using System.Text;

namespace Rover
{
    public class Map
    {
        public Map()
        {
            Height = 10;
            Width = 10;
            Obstacles = new List<Obstacle>();
        }
        public int Height { get; }
        public int Width { get; }
        public List<Obstacle> Obstacles;
    }
}
