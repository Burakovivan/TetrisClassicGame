using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    public static class View
    {
        public static OpenGL Canvas { get; set; }

        static class Field 
        {
            public static bool[,] Commited { get; private set; }
            public static bool[,] InTransit { get; private set; }

            static Brick falling;
            static public int Speed { get; private set; }
            static public int Scoore { get; private set; }


            //проверка падания
            //отлов управления (движение, поворот)
            //проверка линий
            //подсчет очков
            
        }

    }
    
}
