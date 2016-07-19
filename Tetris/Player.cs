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
        static bool isPause { get; set; }
        static bool isGame{ get; set; }
        public static TimeSpan SpeedValue;


        public static void CatchKey(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.P:
                    isPause = !isPause;
                    break;
                default:
                    Field.CatchKeyDirection(e);
                    break;
            }
        }
        public static void Start()
        {
            isPause =   false;
            isGame =    true;
            Field.Init();
            View.Render();
            SpeedValue = new TimeSpan((long)1E+7);
            while (isGame)
            {
                while (isPause) { }
                //View.Render();
                Field.FallingBrick();
                //View.Render();
                Thread.Sleep(SpeedValue);
            }
        }

        public static void Terminate()
        {
            isGame = false;
        }

        

        
    }
}
