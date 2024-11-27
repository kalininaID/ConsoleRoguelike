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

        bool readyP2 = false;

        Art img = new Art();

        public void Start()
        {
            while (true)
            {
                int consoleWidth = Console.WindowWidth;
                int consoleHeight = Console.WindowHeight;
                int h = consoleHeight - 7;
                int w = consoleWidth / 2;
                fieldP1 = Frame.DrawFrame(w, h);
                fieldP2 = Frame.DrawFrame(w, h);

                Console.Clear();

                img.NewGame(Position.Center, ConsoleColor.Gray);

                fieldP1 = CreatePlayer(fieldP1, "Player 1", true);
                fieldP2 = CreatePlayer(fieldP2, "Player 2", readyP2, del: true);

                window = ArrFunc.Join(fieldP1, fieldP2);
                DisplayMenu();

                var key = Console.ReadKey(true).Key;

                HandleInput(key);
            }

        }

        public char[][] CreatePlayer(char[][] window, string namePlayer = "Player 1", bool inGame = false, bool del = false)
        {
            if (inGame)
            {
                if (del) {
                    window = ArrFunc.TextInArr(window, "Нажмите E, чтобы удалить игрока", (window.Length - 3));
                }
                
                window = ArrFunc.TextInArr(window, namePlayer, 2);

                window = ArrFunc.TextInArr(window, "< :) >", 4);

                window = ArrFunc.TextInArr(window, "Имя: Александр   ", 6);
                window = ArrFunc.TextInArr(window, "Сила: 8          ", 7);
                window = ArrFunc.TextInArr(window, "Скорость: 2      ", 8);
                window = ArrFunc.TextInArr(window, "Живучесть: 9     ", 9);
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

            foreach (var row in window)
            {
                Console.WriteLine(new string(row));
            }
        }

        private void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.E)
            {
                readyP2 = !readyP2;
            }
        }
    }
}
