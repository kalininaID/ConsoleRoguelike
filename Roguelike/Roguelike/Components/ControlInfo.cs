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
        public static char[][] Create(Dictionary<string, string> setting) {

            string settingsPath = "settings.txt";

            char[][] window = new char[5][];

            for (int i = 0; i < window.Length; i++)
            {
                window[i] = new char[13];

                for (int j = 0; j < 13; j++)
                    window[i][j] = ' ';
            }

            window = ArrFunc.TextInArr(window, "╔═══╗", 0);
            window = ArrFunc.TextInArr(window, $"║{setting["up"]} ↑║", 1);
            window = ArrFunc.TextInArr(window, "╔═══╬═══╬═══╗", 2);
            window = ArrFunc.TextInArr(window, $"║{setting["left"]} ←║{setting["down"]} ↓║{setting["right"]} →║", 3);
            window = ArrFunc.TextInArr(window, "╚═══╩═══╩═══╝", 4);
            return window;
        }
    }
}
