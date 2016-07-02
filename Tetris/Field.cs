using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    static class Field
    {
        /// <summary>
        /// Bricks that was fallen down
        /// </summary>
        public static bool[,] Commited { get; private set; }


        static Brick falling;
        static public int Speed { get; private set; }
        static public int Scoore { get; private set; }

        //проверка падания
        //отлов управления (движение, поворот)
        //проверка линий
        //подсчет очков

    }
}
