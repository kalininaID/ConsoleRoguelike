using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Components;

namespace Roguelike.SceneMenu
{
    internal class NewGameMenu
    {
        private char[][] window;
        private char[][] fieldP1;
        private char[][] fieldP2;

        private Dictionary<string, string> settingP1;
        private Dictionary<string, string> settingP2;

        private string nameP1 = "Player 1";
        private string nameP2 = "Player 2";

        private int consoleWidth;
        private int consoleHeight;

        private bool readyP2 = false;

        private Art img = new Art();
        private bool flagChangeControll = false;

        private string keyFrom = "-";
        private string keyTo = "-";

        public void Start()
        {
            while (true)
            {
                settingP1 = Settings.Get(nameP1);
                settingP2 = Settings.Get(nameP2);

                consoleWidth = Console.WindowWidth;
                consoleHeight = Console.WindowHeight;
                int h = consoleHeight - 7;
                int w = consoleWidth / 2;
                fieldP1 = Frame.DrawFrame(w, h);
                fieldP2 = Frame.DrawFrame(w, h);

                fieldP1 = CreatePlayer(fieldP1, "Player 1", true);
                fieldP2 = CreatePlayer(fieldP2, "Player 2", readyP2, del: true);

                window = ArrFunc.Join(fieldP1, fieldP2);
                DisplayMenu();

                var key = Console.ReadKey(true).Key;

                if (flagChangeControll)
                {
                    ChangeControll(key);
                } else
                {
                    HandleInput(key);
                }
            }
        }

        public char[][] CreatePlayer(char[][] window, string namePlayer = "Player 1", bool inGame = false, bool del = false)
        {
            if (inGame)
            {
                if (del) {
                    window = ArrFunc.TextInArr(window, "Нажмите E, чтобы удалить игрока", (window.Length - 2));
                }
                
                window = ArrFunc.TextInArr(window, namePlayer, 2);
                
                string emoji = "👮";
                window = ArrFunc.TextInArr(window, $"< {emoji} >", 4);

                window = ArrFunc.TextInArr(window, "Имя: Александр   ", 6);
                window = ArrFunc.TextInArr(window, "Сила: 8          ", 7);
                window = ArrFunc.TextInArr(window, "Скорость: 2      ", 8);
                window = ArrFunc.TextInArr(window, "Живучесть: 9     ", 9);

                char[][] controlInfo;
                if (nameP1 == namePlayer)
                {
                    controlInfo = ControlInfo.Create(settingP1);
                }else
                {
                    controlInfo = ControlInfo.Create(settingP2);
                }

                window = ArrFunc.ArrInArr(window, controlInfo, line: window.Length - 7);
            } 
            else
            {
                window = ArrFunc.TextInArr(window, "Нажмите E, чтобы", (window.Length/2 - 1));
                window = ArrFunc.TextInArr(window, "добавить игрока", (window.Length / 2));
            }
            return window;
        }

        public void DisplayMenu()
        {
            Console.Clear();
            img.NewGame(Position.Center, ConsoleColor.Gray);

            if (flagChangeControll)
            {
                char[][] popUp = PopUp.Create(60, 12, "Нажмите клавишу, которую хотите изменить...");
                popUp = ArrFunc.TextInArr(popUp, "╔═══╗    ╔═══╗", 5);
                popUp = ArrFunc.TextInArr(popUp, $"║ {keyFrom} ║ ➨  ║ {keyTo} ║", 6);
                popUp = ArrFunc.TextInArr(popUp, "╚═══╝    ╚═══╝", 7);
                window = ArrFunc.ArrInArr(window, popUp, line: window.Length/2 - 7);
            }

            foreach (var row in window)
            {
                Console.WriteLine(new string(row));
            }
            
            string changeP2 = "";
            if (readyP2)
            {
               changeP2 = "2 - изменить имя 2 игрока;";
            }
            Console.WriteLine($"0 - изменить управление; 1 - изменить имя 1 игрока; {changeP2} ");
        }

        private void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.E)
            {
                readyP2 = !readyP2;
            }
            if (key == ConsoleKey.D0)
            {
                flagChangeControll = true;
            }
        }

        private void ChangeControll(ConsoleKey key)
        {
            if (key == ConsoleKey.Escape)
            {
                flagChangeControll = false;
            } else
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
                    keyFrom = "!";
                }
            }
        }
    }
}
