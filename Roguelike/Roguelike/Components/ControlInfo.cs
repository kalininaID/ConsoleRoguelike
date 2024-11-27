using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Components;

namespace Roguelike
{
    internal class ControlInfo
    {
        public static char[][] Create() {
            char[][] window = new char[15][];

            char[][] btnUp = Frame.DrawFrame(5, 3);
            btnUp = ArrFunc.TextInArr(btnUp, "W ↑", 1);

            char[][] btnLeft = Frame.DrawFrame(5, 3);
            btnLeft = ArrFunc.TextInArr(btnLeft, "← A", 1);
            
            char[][] btnDown = Frame.DrawFrame(5, 3);
            btnDown = ArrFunc.TextInArr(btnDown, "S ↓", 1);

            char[][] btnRight = Frame.DrawFrame(5, 3);
            btnRight = ArrFunc.TextInArr(btnRight, "D →", 1);

            window = ArrFunc.Join(btnLeft, btnDown);
            window = ArrFunc.Join(window, btnRight);

            return window;
        }
    }
}
