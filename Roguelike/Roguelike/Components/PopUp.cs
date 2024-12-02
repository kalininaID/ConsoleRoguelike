using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components
{
    internal class PopUp : Frame
    {
        public string title;
        public int wight;
        public int hieght;
        public PopUp(string title, int wight, int hieght) : base(wight, hieght)
        {
            DrawBorders();
            this.title = title;
            this.wight = wight;
            this.hieght = hieght;
            VisualArr = ArrFunc.TextInArr(VisualArr, "⌧", pos: Position.Right, line: 1, margin: 3);
            VisualArr = ArrFunc.TextInArr(VisualArr, title, 3);
        }
    }
}
