using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Tetris
{
    enum Direction { Right, Left, Up, Down }
    internal class Brick
    {
        public bool[,] Figure { get; internal set; }
        public Point Position { get; internal set; }

        //need to test it for first!!
        public void Rotate(Direction rotation)
        {
            int n = Figure.Length;

            switch (rotation)
            {
                case Direction.Right:
                    for (int i = 0; i < n; ++i)
                    {
                        for (int j = 0; j < n; ++j)
                        {
                            Figure[i, j] = Figure[n - j - 1, i];
                        }
                    }
                    break;
                case Direction.Left:
                    for (int i = 0; i < n; ++i)
                    {
                        for (int j = 0; j < n; ++j)
                        {
                            Figure[i, j] = Figure[j, n - i - 1];
                        }
                    }
                    break;
            }
        }

        public void MoveTo(Direction moveDirection)
        {
            //switch (moveDirection)
            //{
            //    case Direction.Right: 
            //        break;
            //    case Direction.Left:
            //        break;
            //    case Direction.Up:
            //        break;
            //    case Direction.Down:
            //        break;
            //    default:
            //        break;
            //}

            //need to choose what is better!!
            Position = new Point(Position.X + moveDirection == Direction.Left ? -1 : moveDirection == Direction.Right ? 1 : 0,
                Position.Y + moveDirection == Direction.Up ? 1 : moveDirection == Direction.Down ? -1 : 0);
        }
        public void MoveTo(Point destenation)
        {
            Position = destenation;
        }

    }

    internal static class Bricks
    {
        static Brick[] GetAllBricks { get; private set; }
        static Brick L
        {
            get
            {
                bool[,] figure = new bool[4, 4];
                figure[1, 1] = true;
                figure[1, 2] = true;
                figure[1, 3] = true;
                figure[2, 3] = true;
                return new Brick() { Figure = figure };
            }
        }
        static Brick J
        {
            get
            {
                bool[,] figure = new bool[4, 4];
                figure[2, 1] = true;
                figure[2, 2] = true;
                figure[1, 3] = true;
                figure[2, 3] = true;
                return new Brick() { Figure = figure };
            }
        }
        static Brick O
        {
            get
            {
                bool[,] figure = new bool[4, 4];
                figure[1, 1] = true;
                figure[1, 2] = true;
                figure[2, 1] = true;
                figure[2, 2] = true;
                return new Brick() { Figure = figure };
            }
        }
        static Brick S
        {
            get
            {
                bool[,] figure = new bool[4, 4];
                figure[2, 1] = true;
                figure[2, 2] = true;
                figure[1, 2] = true;
                figure[1, 3] = true;
                return new Brick() { Figure = figure };
            }
        }

        static Bricks()
        {
            GetAllBricks = new Brick[] { L, J, O, S };
        }
    }
}
