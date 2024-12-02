using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Components;

namespace Roguelike.SceneMenu
{
    internal class PopUpChangeControll : PopUp
    {
        public string keyFrom { get; set; } = "-";
        public string keyTo { get; set; } = "-";

        public bool isClose = false;

        public PopUpChangeControll() : base("Нажмите клавишу, которую хотите изменить...", 60, 12) {
        }

        public void Update()
        {
            isClose = false;
            VisualArr = ArrFunc.TextInArr(VisualArr, "╔═══╗    ╔═══╗", 5);
            VisualArr = ArrFunc.TextInArr(VisualArr, $"║ {keyFrom} ║ ➨  ║ {keyTo} ║", 6);
            VisualArr = ArrFunc.TextInArr(VisualArr, "╚═══╝    ╚═══╝", 7);
            if (keyFrom != "-" && keyTo != "-")
            {
                VisualArr = ArrFunc.TextInArr(VisualArr, "Нажмите Enter, чтобы применить изменения", 9);
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

                title = $"Нажмите клавишу, на которую хотите изменить {keyFrom}";
            }
        }

        public void Clear()
        {
            title = "Нажмите клавишу, которую хотите изменить...";
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
    }
}
