using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    public static class View
    {
        public static OpenGL context;


        public void Draw()
        {
            
        }

        static class Field
        {
            public static bool[,] Commited { get; private set; }
            public static bool[,] InTransit { get; private set; }
            Brick falling;
            public int Speed { get; private set; }
            public int Scoore { get; private set; }
        }

    }
    
}
