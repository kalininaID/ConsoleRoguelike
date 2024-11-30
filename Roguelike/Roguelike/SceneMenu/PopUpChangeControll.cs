using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Components;

namespace Roguelike.SceneMenu
{
    internal class PopUpChangeControll
    {
        public string titlePopUp = "Нажмите клавишу, которую хотите изменить...";
        public string keyFrom { get; set; } = "-";
        public string keyTo { get; set; } = "-";
        public PopUp popUp { get; set; }

        int w = 60;
        int h = 12;

        public bool isClose = false;
        public void Create()
        {
            isClose = false;
            popUp = new PopUp(titlePopUp, w, h);
            popUp.VisualArr = ArrFunc.TextInArr(popUp.VisualArr, "╔═══╗    ╔═══╗", 5);
            popUp.VisualArr = ArrFunc.TextInArr(popUp.VisualArr, $"║ {keyFrom} ║ ➨  ║ {keyTo} ║", 6);
            popUp.VisualArr = ArrFunc.TextInArr(popUp.VisualArr, "╚═══╝    ╚═══╝", 7);

            if (keyFrom != "-" && keyTo != "-")
            {
                popUp.VisualArr = ArrFunc.TextInArr(popUp.VisualArr, "Нажмите Enter, чтобы применить изменения", 9);
            }
        }

        public void SetKey(ConsoleKey key)
        {
            if (keyFrom != "-")
            {
                keyTo = key.ToString();

                switch (keyTo)
                {
                    case "UpArrow":
                        keyTo = "⇧";
                        break;
                    case "LeftArrow":
                        keyTo = "⇦";
                        break;
                    case "DownArrow":
                        keyTo = "⇩";
                        break;
                    case "RightArrow":
                        keyTo = "⇨";
                        break;
                }

                if (keyTo.Length > 1)
                {
                    keyTo = "-";
                }
            }
            else
            {
                keyFrom = key.ToString();

                switch (keyFrom)
                {
                    case "UpArrow":
                        keyFrom = "⇧";
                        break;
                    case "LeftArrow":
                        keyFrom = "⇦";
                        break;
                    case "DownArrow":
                        keyFrom = "⇩";
                        break;
                    case "RightArrow":
                        keyFrom = "⇨";
                        break;
                }

                if (keyFrom.Length > 1)
                {
                    keyFrom = "-";
                }

                titlePopUp = $"Нажмите клавишу, на которую хотите изменить {keyFrom}";
            }
        }

        public void Clear()
        {
            titlePopUp = "Нажмите клавишу, которую хотите изменить...";
            keyFrom = "-";
            keyTo = "-";
        }

        public void ChangeControll(ConsoleKey key)
        {

            if (key == ConsoleKey.Escape)
            {
                isClose = true;
                return;
            }

            if (key == ConsoleKey.Enter && keyFrom != "-" && keyTo != "-")
            {
                Settings.Set(keyFrom, keyTo);
                isClose = true;
                return;
            }

            SetKey(key);
        }
        public int[][] GetColors()
        {
            return ArrFunc.CreateEmptyArray(w, h, 0);
        }
    }
}
