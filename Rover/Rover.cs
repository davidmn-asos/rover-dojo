using System;
using System.Collections.Generic;
using System.Text;

namespace Rover
{
    public class Rover
    {
        public Rover(Map map)
        {
            position = new Position(0,0);
            facing = Facing.N;
            this.map = map;
        }

        public string Execute(string command)
        {
            var success = true;
            foreach (var character in command.ToLowerInvariant())
            {
                if (character == 'l')
                {
                    MoveLeft();
                }
                else if (character == 'r')
                {
                    MoveRight();
                }
                else
                {
                    success = MoveForward();
                    if (!success)
                    {
                        break;
                    }
                }
            }

            if (success)
            {
                return $"{position.X}:{position.Y}:{facing.ToString()}";
            }
            else
            {
                return $"O:{position.X}:{position.Y}:{facing.ToString()}";
            }
            
        }

        private void MoveLeft()
        {
            switch (facing)
            {
                case Facing.N:
                    facing = Facing.W;
                    break;
                case Facing.E:
                    facing = Facing.N;
                    break;
                case Facing.S:
                    facing = Facing.E;
                    break;
                case Facing.W:
                    facing = Facing.S;
                    break;
            }
        }

        private void MoveRight()
        {
            switch (facing)
            {
                case Facing.N:
                    facing = Facing.E;
                    break;
                case Facing.E:
                    facing = Facing.S;
                    break;
                case Facing.S:
                    facing = Facing.W;
                    break;
                case Facing.W:
                    facing = Facing.N;
                    break;
            }
        }

        private bool MoveForward()
        {
            var pos = CalculatePosition();
            var obstacleInFront = CheckForObstacle(pos);
            if (!obstacleInFront)
            {
                position = pos;
                return true;
            }
            return false;
        }

        private Position CalculatePosition()
        {
            int x = position.X;
            int y = position.Y;
            switch (facing)
            {
                case Facing.N:
                    y = (position.Y + 1) % map.Height;
                    break;
                case Facing.E:
                    x = (position.X + 1) % map.Width;
                    break;
                case Facing.S:
                    if (y == 0)
                    {
                        y = map.Height - 1;
                    }
                    else
                    {
                        y = (position.Y - 1);
                    }
                    break;
                case Facing.W:
                    if (x == 0)
                    {
                        x = map.Width - 1;
                    }
                    else
                    {
                        x = (position.X - 1) % map.Width;
                    }
                    break;
            }
            var p = new Position(x,y);
            return p;
        }

        private bool CheckForObstacle(Position p)
        {
            foreach (var obs in map.Obstacles)
            {
                if (obs.Position.X == p.X & obs.Position.Y == p.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public Position position;
        public Facing facing;
        private Map map;

        public enum Facing
        {
            N,
            E,
            S,
            W
        }
    }

    
}
