using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components
{
    internal class PopUp
    {
        public static char[][] Create(int wight = 18, int hieght = 10, string title = "")
        {
            char[][] popUp = Frame.DrawFrame(wight, hieght);
            popUp = ArrFunc.TextInArr(popUp, "⌧", pos: Position.Right, line: 1, margin: 2);
            popUp = ArrFunc.TextInArr(popUp, title, 3);
            return popUp;
        }

    }
}
