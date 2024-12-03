using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components
{
    internal class Dialog: PopUp
    {
        public bool flagOpen = true;
        public bool cursor = true;
        public Dialog(string title = "", int wight = 40, int hieght = 10) : base(title, wight, hieght)
        {
            Frame btn1 = new Frame(8, 3);
            btn1.DrawBorders(typeBorder: TypeBorder.ROUNDED);
            btn1.VisualArr = ArrFunc.TextInArr(btn1.VisualArr, "OK", pos: Position.Center, line: 1);

            Frame btn2 = new Frame(8, 3);
            btn2.DrawBorders(typeBorder: TypeBorder.ROUNDED);
            btn2.VisualArr = ArrFunc.TextInArr(btn2.VisualArr, "ОТМЕНА", pos: Position.Center, line: 1);

            VisualArr = ArrFunc.ArrInArr(VisualArr, btn1.VisualArr, hieght - 4, 8, Position.Left);
            VisualArr = ArrFunc.ArrInArr(VisualArr, btn2.VisualArr, hieght - 4, 8, Position.Right);

            if (cursor)
            {
                VisualArr = ArrFunc.TextInArr(VisualArr, ">", pos: Position.Left, line: hieght - 3, margin: 6);
                VisualArr = ArrFunc.TextInArr(VisualArr, "<", pos: Position.Left, line: hieght - 3, margin: 17);
            } else
            {
                VisualArr = ArrFunc.TextInArr(VisualArr, "<", pos: Position.Right, line: hieght - 3, margin: 6);
                VisualArr = ArrFunc.TextInArr(VisualArr, ">", pos: Position.Right, line: hieght - 3, margin: 17);
            }
        }

        public void Controller(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {

            } else
            {
                cursor = !cursor;
            }
        }
    }
}
