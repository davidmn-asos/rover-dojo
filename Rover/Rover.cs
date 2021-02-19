using System;
using System.Data;

namespace Rover
{
    public class Rover
    {
        public Rover(Map map)
        {
            _position = new Position(0,0);
            _facing = Facing.N;
            _map = map;
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
                else if (character == 'm')
                {
                    success = MoveForward();
                    if (!success)
                    {
                        break;
                    }
                }
                else
                {
                    throw new Exception($"Unknown command {character}");
                }
            }

            if (success)
            {
                return $"{_position.X}:{_position.Y}:{_facing.ToString()}";
            }
            return $"O:{_position.X}:{_position.Y}:{_facing.ToString()}";
        }

        private void MoveLeft()
        {
            switch (_facing)
            {
                case Facing.N:
                    _facing = Facing.W;
                    break;
                case Facing.E:
                    _facing = Facing.N;
                    break;
                case Facing.S:
                    _facing = Facing.E;
                    break;
                case Facing.W:
                    _facing = Facing.S;
                    break;
            }
        }

        private void MoveRight()
        {
            switch (_facing)
            {
                case Facing.N:
                    _facing = Facing.E;
                    break;
                case Facing.E:
                    _facing = Facing.S;
                    break;
                case Facing.S:
                    _facing = Facing.W;
                    break;
                case Facing.W:
                    _facing = Facing.N;
                    break;
            }
        }

        private bool MoveForward()
        {
            var nextPosition = CalculateNextPosition(_position.X, _position.Y);
            var isBlocked = CheckForObstacle(nextPosition);
            if (isBlocked)
            {
                return false;
            }
            _position = nextPosition;
            return true;
        }

        private Position CalculateNextPosition(int x, int y)
        {
            switch (_facing)
            {
                case Facing.N:
                    y = (_position.Y + 1) % _map.Height;
                    break;
                case Facing.E:
                    x = (_position.X + 1) % _map.Width;
                    break;
                case Facing.S:
                    if (y == 0)
                    {
                        y = _map.Height - 1;
                    }
                    else
                    {
                        y = (_position.Y - 1);
                    }
                    break;
                case Facing.W:
                    if (x == 0)
                    {
                        x = _map.Width - 1;
                    }
                    else
                    {
                        x = (_position.X - 1);
                    }
                    break;
            }
            var p = new Position(x,y);
            return p;
        }

        private bool CheckForObstacle(Position p)
        {
            foreach (var obs in _map.Obstacles)
            {
                if (obs.X == p.X & obs.Y == p.Y)
                {
                    return true;
                }
            }

            return false;
        }

        private Position _position;
        private Facing _facing;
        private Map _map;


    }

    
}
