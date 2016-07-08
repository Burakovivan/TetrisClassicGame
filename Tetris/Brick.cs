using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Tetris
{
    enum Direction { Right, Left, Down, Up }
    class Brick
    {
        public bool[,] Figure { get; set; }
        public Point Position;

        //need to test it for first!!
        public void Rotate(Direction rotation)
        {
            int n = Figure.GetLength(0);

            switch (rotation)
            {
                case Direction.Right:
                    // transpose
                    transpose(Figure);

                    // swap columns
                    for (int j = 0; j < Figure.GetLength(0) / 2; j++)
                    {
                        for (int i = 0; i < Figure.GetLength(0); i++)
                        {
                            bool x = Figure[i,j];
                            Figure[i, j] = Figure[Figure.GetLength(0) - 1 - i, j];
                            Figure[Figure.GetLength(0) - 1 - i, j] = x;
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
        private static void transpose(bool[,] m)
        {

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = i; j < m.GetLength(0); j++)
                {
                    bool x = m[i,j];
                    m[i,j] = m[j,i];
                    m[j,i] = x;
                }
            }
        }

        public void MoveTo(Direction moveDirection)
        {
            switch (moveDirection)
            {
                case Direction.Right:
                    Position.X++;
                    break;
                case Direction.Left:
                    Position.X--;
                    break;
                case Direction.Down:
                    Position.Y++;
                    break;
                default:
                    break;
            }
        }

    }

    internal static class Bricks
    {
        public static Brick[] AllBricks { get; private set; }
        static Brick L
        {
            get
            {
                bool[,] figure = new bool[5, 5];
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
        static Brick _S
        {
            get
            {
                bool[,] figure = new bool[4, 4];
                figure[1, 1] = true;
                figure[2, 2] = true;
                figure[1, 2] = true;
                figure[2, 3] = true;
                return new Brick() { Figure = figure };
            }
        }

        static Brick T
        {
            get
            {
                bool[,] figure = new bool[3, 3];
                figure[1, 0] = true;
                figure[0, 1] = true;
                figure[1, 1] = true;
                figure[2, 1] = true;
                return new Brick() { Figure = figure };
            }
        }
        static Brick I
        {
            get
            {
                bool[,] figure = new bool[5, 5];
                figure[2, 1] = true;
                figure[2, 2] = true;
                figure[2, 3] = true;
                figure[2, 4] = true;
                return new Brick() { Figure = figure };
            }
        }

        static Bricks()
        {
            AllBricks = new Brick[] { L, J, O, S, _S, T, I };
        }
    }
}
