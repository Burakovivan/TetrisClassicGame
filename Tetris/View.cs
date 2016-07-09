using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    public static class View
    {
        public static int x = 0;
        public static int y = 0;
        private enum Color { Gray, LigtGray, Black, _8E9F97 }
        public static OpenGL Canvas { get; set; }

        public static void Render()
        {

            Canvas.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            Canvas.LoadIdentity();

            Canvas.Translate(0.0f, -1.0f, -25.0f);
            for (int i = 0; i < Field.Commited.GetLength(0); i++)
            {
                for (int j = 0; j < Field.Commited.GetLength(1); j++)
                {
                    drawBrick(j, i, Field.Commited[i, j]);
                }
            }

            for (int i = 0; i < Field.fallingBrick.Figure.GetLength(0); i++)
            {
                for (int j = 0; j < Field.fallingBrick.Figure.GetLength(1); j++)
                {
                    if (Field.fallingBrick.Figure[i, j])
                        drawBrick(j + Field.fallingBrick.Position.X, i + Field.fallingBrick.Position.Y, true);
                }
            }


            Canvas.Flush();
        }

        /// <summary>
        /// Draw rectangle in specified place with specified color
        /// </summary>
        /// <param name="x">top-left corner X coord</param>
        /// <param name="y">top-left corner Y coord</param>
        /// <param name="widht">width of rect</param>
        /// <param name="height">height of rect</param>
        /// <param name="color">color of rect</param>
        private static void fillRect(double x, double y, double widht, double height, Color color)
        {

            Canvas.Begin(OpenGL.GL_QUADS);

            switch (color)
            {
                case Color.Gray:
                    Canvas.Color((byte)128, (byte)128, (byte)128);
                    break;
                case Color.LigtGray:
                    Canvas.Color((byte)211, (byte)211, (byte)211);
                    break;
                case Color.Black:
                    Canvas.Color((byte)0, (byte)0, (byte)0);
                    break;
                case Color._8E9F97:
                    Canvas.Color((byte)142, (byte)159, (byte)151);
                    break;
                default:
                    break;
            }

            Canvas.Vertex(x, y, 0);                     //top-left
            Canvas.Vertex(x + widht, y, 0);             //top-right
            Canvas.Vertex(x + widht, y + height, 0);    //bottom-right
            Canvas.Vertex(x, y + height, 0);            //bottom-left

            Canvas.End();
        }

        private static void drawRect(double x, double y, double width, double height, Color color)
        {
            switch (color)
            {
                case Color.Gray:
                    Canvas.Color((byte)128, (byte)128, (byte)128);
                    break;
                case Color.LigtGray:
                    Canvas.Color((byte)211, (byte)211, (byte)211);
                    break;
                case Color.Black:
                    Canvas.Color((byte)0, (byte)0, (byte)0);
                    break;
                case Color._8E9F97:
                    Canvas.Color((byte)142, (byte)159, (byte)151);
                    break;
                default:
                    break;
            }
            Canvas.Begin(SharpGL.Enumerations.BeginMode.LineLoop);
            Canvas.Vertex(x, y);
            Canvas.Vertex(x + width, y);
            Canvas.Vertex(x + width, y + width);
            Canvas.Vertex(x, y + width);
            Canvas.End();
        }

        private static void drawBrick(double coll, double row, bool Commited)
        {
            coll *= 1.5;
            row *= 1.5;
            coll -= 14.5;
            row -= 15;
            fillRect(coll + 0.2, row + 0.2, 0.6, 0.6, Commited ? Color.Black : Color._8E9F97);
            drawRect(coll, row, 1, 1, Commited ? Color.Black : Color._8E9F97);
        }
    }

}
