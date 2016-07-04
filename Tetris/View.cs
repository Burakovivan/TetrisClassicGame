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
        private enum Color { Gray, LigtGray, Black }
        public static OpenGL Canvas { get; set; }

        public static void Render()
        {
           
            Canvas.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            Canvas.LoadIdentity();

            //below u can define position of screen manualy
            //string[] arr = Console.ReadLine().Split(' ');
            //Canvas.Translate(double.Parse(arr[0]), double.Parse(arr[1]), double.Parse(arr[2]));
            Canvas.Translate(0.0f, -1.0f, -25.0f);

            drawRect(x, y, 1, 1, Color.LigtGray);

            //Canvas.Begin(OpenGL.GL_QUADS);

            //Canvas.Color(1.0, 0, 0);
            //Canvas.Vertex(-1, -1, 0);
            //Canvas.Color(1.0, 1.0, 0);
            //Canvas.Vertex(-1, 1, 0);
            //Canvas.Color(0.0, 1.0, 1.0);
            //Canvas.Vertex(1, 1, 0);
            //Canvas.Color(0.0, 0.0, 1.0);
            //Canvas.Vertex(1, -1, 0);

            //Canvas.End();


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
        private static void drawRect(double x, double y, double widht, double height, Color color)
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
                default:
                    break;
            }

            Canvas.Vertex(x, y, 0);         //top-left
            Canvas.Vertex(x+widht, y, 0);   //top-right
            Canvas.Vertex(x+widht, y+height, 0);         //bottom-right
            Canvas.Vertex(x, y+height, 0);        //bottom-left

            Canvas.End();
            
        }
    }

}
