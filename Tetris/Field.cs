using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tetris
{
    static class Field
    {
        private const int SCORE_LINE = 100;
        private const int SCORE_BRICK = 4;
        /// <summary>
        /// Bricks that was fallen down
        /// </summary>
        public static bool[,] Commited { get; set; }

        static public Brick fallingBrick;
        static public int Speed { get; private set; }
        static public int Score { get; private set; }
        static private int CountLine
        {
            get { return CountLine; }
            set
            {
                if (CountLine == 10)
                {
                    CountLine = 0;
                    Speed++;
                }
                else CountLine += value;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public static void FallingBrick()
        {
            if (!IsDirection(Direction.Down))
            {
                SetCommited();
                Thread threadCheckLine = new Thread(CheckLine);
                threadCheckLine.Start();
                SetScore(SCORE_BRICK);
            }
            else
            {
                fallingBrick.MoveTo(Direction.Down);
                FallingBrick();
            }
        }

        /// <summary>
        /// Check the position of the figure, after movement
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static bool IsDirection(Direction direction)
        {
            switch (direction)
            {
                case (Direction.Down):
                    {
                        return fallingBrick.Position.Y + 1 < Commited.GetLength(0) && CheckCommited(0, 1);
                    }
                case (Direction.Left):
                    {
                        return fallingBrick.Position.X > 0 && CheckCommited(-1, 0);
                    }
                case (Direction.Right):
                    {
                        return fallingBrick.Position.X + 1 < Commited.Length && CheckCommited(1, 0);
                    }
                default: return false;
            }
        }

        private static bool CheckCommited(int _x, int _y)
        {
            Point checkPoint = GetCheckPoint();
            for (int i = 0; i < fallingBrick.Figure.GetLength(0); i++)
            {
                for (int j = 0; j < fallingBrick.Figure.GetLength(1); j++)
                {
                    if (fallingBrick.Figure[i, j] && Commited[checkPoint.X + i + _x, checkPoint.Y + j + _y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void SetCommited()
        {
            Point checkPoint = GetCheckPoint();
            for (int i = 0; i < fallingBrick.Figure.GetLength(0); i++)
            {
                for (int j = 0; j < fallingBrick.Figure.GetLength(1); j++)
                {
                    if (fallingBrick.Figure[i, j])
                    {
                        Commited[checkPoint.Y + i, checkPoint.X + j] = true;
                    }
                }
            }
        }

        private static Point GetCheckPoint()
        {
            Point output = new Point();
            output.X = fallingBrick.Position.X - (fallingBrick.Figure.GetLength(1) - 2);
            output.Y = fallingBrick.Position.Y - (fallingBrick.Figure.GetLength(0) - 2);
            return output;
        }

        /// <summary>
        /// Key interception
        /// </summary>
        /// <param name="e">Input key</param>
        public static void CatchKeyDirection(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Down):
                    {
                        SetDirection(Direction.Down);
                        break;
                    }
                case (Keys.Left):
                    {
                        SetDirection(Direction.Left);
                        break;
                    }
                case (Keys.Right):
                    {
                        SetDirection(Direction.Right);
                        break;
                    }
            }
        }

        private static void SetDirection(Direction direction)
        {
            if (IsDirection(direction))
            {
                fallingBrick.MoveTo(direction);
            }
        }

        private static void SetScore(int score)
        {
            Score += score;
            if (score == SCORE_LINE)
            {
                CountLine += 1;
            }
        }

        private static void CheckLine()
        {
            bool flag = true;
            for (int y = Commited.GetLength(0) - 1; y >= 0; y--)
            {
                for (int x = 0; x < Commited.GetLength(1); x++)
                {
                    if (!Commited[y, x])
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    SetFallingLine(y);
                    SetScore(SCORE_LINE);
                    y = -1;
                }
            }
        }

        private static void SetFallingLine(int y)
        {
            for (int _y = y - 1; _y >= 0; _y--)
            {
                for (int x = 0; x < Commited.GetLength(1); x++)
                {
                    DownBrick(x, y);
                }
            }
        }

        private static void DownBrick(int x, int y)
        {
            for (int i = y; i < Commited.GetLength(0); i++)
            {
                if (!Commited[i, x])
                {
                    Commited[i, x] = true;
                    Commited[i - 1, x] = false;
                }
            }
        }
    }
}
