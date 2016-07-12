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
        private const int WIDTH = 15;
        private const int HEIGHT = 20;
        /// <summary>
        /// Bricks that was fallen down
        /// </summary>
        public static bool[,] Commited { get; set; }

        static Field()
        {

        }

        public static void Init()
        {
            Commited = new bool[HEIGHT, WIDTH];
            getNextBrick();
        }

        static public Brick fallingBrick;
        static public void IncreaseSpeed()
        {
            Player.SpeedValue = Player.SpeedValue.Subtract(new TimeSpan((long)1E+5));
        }
        static public int Score { get; private set; }
        static private int сountLines = 0;

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public static void FallingBrick()
        {
            if (!IsDirection(Direction.Down))
            {
                SetCommited();
                //Thread threadCheckLine = new Thread(CheckLine);
                //threadCheckLine.Start();
                CheckLine();
                SetScore(SCORE_BRICK);
                getNextBrick();
            }
            else
            {
                fallingBrick.MoveTo(Direction.Down);
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
                        return CheckDownCommited();
                    }
                case (Direction.Left):
                    {
                        return CheckLeftCommited();
                    }
                case (Direction.Right):
                    {
                        return CheckRightCommited();
                    }
                case (Direction.Up):
                    {
                        return true;
                    }
                default: return false;
            }
        }

        private static void getNextBrick()
        {
            Random r = new Random();
            Field.fallingBrick = Bricks.AllBricks[r.Next(0, Bricks.AllBricks.Length - 1)];
            Field.fallingBrick.Position =
                new System.Drawing.Point(WIDTH / 2 - Field.fallingBrick.Figure.GetLength(1) / 2, 0);
        }

        private static bool CheckDownCommited()
        {
            int maxY = GetDownFigureEmpty();
            for (int y = 0; y < maxY && fallingBrick.Position.Y + maxY + 1 <= Commited.GetLength(0); y++)
            {
                for (int x = 0; x < fallingBrick.Figure.GetLength(1); x++)
                {
                    if (fallingBrick.Figure[y, x] && Commited[fallingBrick.Position.Y + y + 1, fallingBrick.Position.X + x])
                    {
                        return false;
                    }
                }
            }
            return fallingBrick.Position.Y + maxY + 1 <= Commited.GetLength(0);
        }

        private static bool CheckRightCommited()
        {
            int maxY = GetDownFigureEmpty();
            int maxX = GetRightFigureEmpty();
            for (int y = 0; y < maxY && fallingBrick.Position.Y + maxY <= Commited.GetLength(0); y++)
            {
                for (int x = 0; x < maxX && fallingBrick.Position.X + maxX + 1 <= Commited.GetLength(1); x++)
                {
                    if (fallingBrick.Figure[y, x] && Commited[fallingBrick.Position.Y + y, fallingBrick.Position.X + x + 1])
                    {
                        return false;
                    }
                }
            }
            return fallingBrick.Position.X + maxX + 1 <= Commited.GetLength(1);
        }

        private static bool CheckLeftCommited()
        {
            int maxY = GetDownFigureEmpty();
            int minX = GetLeftFigureEmpty();
            for (int y = 0; y < maxY && fallingBrick.Position.Y + maxY <= Commited.GetLength(0); y++)
            {
                for (int x = minX; x < fallingBrick.Figure.GetLength(1) && fallingBrick.Position.X + minX - 1 >= 0; x++)
                {
                    if (fallingBrick.Figure[y, x] && Commited[fallingBrick.Position.Y + y, fallingBrick.Position.X + x - 1])
                    {
                        return false;
                    }
                }
            }
            return fallingBrick.Position.X + minX - 1 >= 0;
        }

        private static void SetCommited()
        {
            int maxY = GetDownFigureEmpty();
            int minX = GetLeftFigureEmpty();
            int maxX = GetRightFigureEmpty();
            for (int y = 0; y < maxY; y++)
            {
                for (int x = minX; x < maxX; x++)
                {
                    if (fallingBrick.Figure[y, x])
                    {
                        Commited[fallingBrick.Position.Y + y, fallingBrick.Position.X + x] = true;
                    }
                }
            }

            //int n = fallingBrick.Figure.GetLength(0);
            //fallingBrick.Figure = new bool[n, n];
        }

        private static int GetDownFigureEmpty()
        {
            bool flag = true;
            for (int y = fallingBrick.Figure.GetLength(0) - 1; y >= 0; y--)
            {
                for (int x = 0; x < fallingBrick.Figure.GetLength(1); x++)
                {
                    if (fallingBrick.Figure[y, x])
                    {
                        flag = false;
                    }
                }
                if (!flag)
                {
                    return y + 1;
                }
            }
            return fallingBrick.Figure.GetLength(0) - 1;
        }

        private static int GetRightFigureEmpty()
        {
            bool flag = true;
            for (int x = fallingBrick.Figure.GetLength(1) - 1; x >= 0; x--)
            {
                for (int y = 0; y < fallingBrick.Figure.GetLength(0); y++)
                {
                    if (fallingBrick.Figure[y, x])
                    {
                        flag = false;
                    }
                }
                if (!flag)
                {
                    return x + 1;
                }
            }
            return fallingBrick.Figure.GetLength(1) - 1;
        }

        private static int GetLeftFigureEmpty()
        {
            bool flag = true;
            for (int x = 0; x < fallingBrick.Figure.GetLength(1); x++)
            {
                for (int y = 0; y < fallingBrick.Figure.GetLength(0); y++)
                {
                    if (fallingBrick.Figure[y, x])
                    {
                        flag = false;
                    }
                }
                if (!flag)
                {
                    return x;
                }
            }
            return 0;
        }

        /// <summary>
        /// Key interception
        /// </summary>
        /// <param name="e">Input key</param>
        public static void CatchKeyDirection(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Up):
                    {
                        fallingBrick.Rotate(Direction.Right);
                        break;
                    }
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
                case (Keys.S):
                    {
                        IncreaseSpeed();
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
            if (сountLines == 10)
                IncreaseSpeed();
            if (score == SCORE_LINE)
                сountLines = сountLines == 10 ? 0 : сountLines + 1;
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
                    y = Commited.GetLength(0);
                }
                flag = true;
            }
        }

        private static void SetFallingLine(int y)
        {
            for (int x = 0; x < Commited.GetLength(1); x++)
            {
                Commited[y, x] = false;
                Thread.Sleep(100);
                View.Render();
            }
            for (int _y = y - 1; _y > 0; _y--)
            {
                for (int x = 0; x < Commited.GetLength(1); x++)
                {
                    FallBlock(_y, x);
                }
            }
        }

        private static void FallBlock(int y, int x)
        {
            for (int i = y; i < Commited.GetLength(0) - 1; i++)
            {
                if (Commited[i, x] && !Commited[i + 1, x])
                {
                    Commited[i, x] = false;
                    Commited[i + 1, x] = true;
                }
            }
        }
    }
}
