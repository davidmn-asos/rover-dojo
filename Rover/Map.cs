using System.Collections.Generic;

namespace Rover
{
    public class Map
    {
        public Map()
        {
            Height = 10;
            Width = 10;
            Obstacles = new List<Position>();
        }
        public int Height { get; }
        public int Width { get; }
        public readonly ICollection<Position> Obstacles;
    }
}
