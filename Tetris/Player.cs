using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tetris
{
    public static class Player
    {
        static bool IsPause { get; set; }
        static bool IsGame{ get; set; }

        public static void CatchKey(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.P:
                    IsPause = !IsPause;
                    break;
                default:
                    Field.CatchKeyDirection(e);
                    break;
            }
        }
        public static void Start()
        {
            IsPause =   false;
            IsGame =    true;
            Field.Init();
            View.Render();
            while (IsGame)
            {
                while (IsPause) { }
                View.Render();
                Field.FallingBrick();
                View.Render();
                Thread.Sleep(1000);
            }
        }

        public static void Terminate()
        {
            IsGame = false;
        }

        

        
    }
}
