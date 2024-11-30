using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components
{
    internal class PopUp : Frame
    {
        public PopUp(string title, int wight, int hieght) : base(wight, hieght)
        {
            VisualArr = ArrFunc.TextInArr(VisualArr, "⌧", pos: Position.Right, line: 1, margin: 2);
            VisualArr = ArrFunc.TextInArr(VisualArr, title, 3);
        }
    }
}
