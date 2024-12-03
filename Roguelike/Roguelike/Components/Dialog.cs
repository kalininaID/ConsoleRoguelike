using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components
{
    internal class Dialog: PopUp
    {
        public bool flagOpen = false;
        public bool isOk = true;
        public bool esc = false;
        public Dialog(string title = "", int wight = 40, int hieght = 10, string Ok = "ОК", string Close = "ОТМЕНА") : base("", wight, hieght)
        {
            string[] text = title.Split("\n");

            for (int i = 0; i < text.Length; i++) {
                VisualArr = ArrFunc.TextInArr(VisualArr, text[i], i + 3, pos: Position.Center);
            }

            Frame btn1 = new Frame(8, 3);
            btn1.DrawBorders(typeBorder: TypeBorder.ROUNDED);
            btn1.VisualArr = ArrFunc.TextInArr(btn1.VisualArr, Ok, pos: Position.Center, line: 1);

            Frame btn2 = new Frame(8, 3);
            btn2.DrawBorders(typeBorder: TypeBorder.ROUNDED);
            btn2.VisualArr = ArrFunc.TextInArr(btn2.VisualArr, Close, pos: Position.Center, line: 1);

            VisualArr = ArrFunc.ArrInArr(VisualArr, btn1.VisualArr, hieght - 4, 8, Position.Left);
            VisualArr = ArrFunc.ArrInArr(VisualArr, btn2.VisualArr, hieght - 4, 8, Position.Right);
        }

        public void Update()
        {
            if (isOk)
            {
                VisualArr = ArrFunc.TextInArr(VisualArr, ">", pos: Position.Left, line: hieght - 3, margin: 6);
                VisualArr = ArrFunc.TextInArr(VisualArr, "<", pos: Position.Left, line: hieght - 3, margin: 17);
                VisualArr = ArrFunc.TextInArr(VisualArr, " ", pos: Position.Right, line: hieght - 3, margin: 6);
                VisualArr = ArrFunc.TextInArr(VisualArr, " ", pos: Position.Right, line: hieght - 3, margin: 17);
            }
            else
            {
                VisualArr = ArrFunc.TextInArr(VisualArr, " ", pos: Position.Left, line: hieght - 3, margin: 6);
                VisualArr = ArrFunc.TextInArr(VisualArr, " ", pos: Position.Left, line: hieght - 3, margin: 17);
                VisualArr = ArrFunc.TextInArr(VisualArr, "<", pos: Position.Right, line: hieght - 3, margin: 6);
                VisualArr = ArrFunc.TextInArr(VisualArr, ">", pos: Position.Right, line: hieght - 3, margin: 17);
            }
        }
        

        public void Controller(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                flagOpen = false;
            }
            if (key == ConsoleKey.Escape)
            {
                esc = true;
                isOk = true;
                flagOpen = false;
            }
            if (key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow || key == ConsoleKey.A || key == ConsoleKey.D)
            {
                if (isOk)
                {
                    isOk = false;
                } else
                {
                    isOk = true;
                }
            }
        }
    }
}
