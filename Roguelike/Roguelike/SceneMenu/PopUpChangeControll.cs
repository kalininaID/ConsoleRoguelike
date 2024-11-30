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
        public string keyFrom { get; set; }  = "-";
        public string keyTo { get; set; }  = "-";
        public char[][] popUp {  get; set; }

        public void Create()
        {
            popUp = PopUp.Create(60, 12, titlePopUp);
            popUp = ArrFunc.TextInArr(popUp, "╔═══╗    ╔═══╗", 5);
            popUp = ArrFunc.TextInArr(popUp, $"║ {keyFrom} ║ ➨  ║ {keyTo} ║", 6);
            popUp = ArrFunc.TextInArr(popUp, "╚═══╝    ╚═══╝", 7);

            if (keyFrom != "-" && keyTo != "-")
            {
                popUp = ArrFunc.TextInArr(popUp, "Нажмите Enter, чтобы применить изменения", 9);
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
    }
}
