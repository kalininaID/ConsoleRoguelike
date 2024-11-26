using System;
using Roguelike.Components;
using Roguelike.SceneMenu;


namespace Roguelike
{
    class Menu
    {
        private string[] options = { "Продолжить игру", "Новая игра", "Выйти" };
        private int selectLine = 0;
        int consoleWidth = Console.WindowWidth;
        bool endWhile = false;
        Art img = new Art();

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                DisplayMenu();

                var key = Console.ReadKey(true).Key;

                HandleInput(key);

                if (endWhile)
                {
                    Console.Clear();
                    break;
                }
            }

            if (endWhile)
            {
                OnClickBtn();
            }
            
        }

        private void DisplayMenu()
        {
            img.Rogalick(Position.Center);

            Console.Write("\n\n\n");

            string chooseSymbol = "⚔️";

            for (int i = 0; i < options.Length; i++) {
                string line = $"{(i == selectLine ? chooseSymbol : " ")} {options[i]} {(i == selectLine ? chooseSymbol : " ")}";
                int lineLength = line.Length;
                int spacesToAdd = (consoleWidth - lineLength) / 2;

                string centeredLine = new string(' ', spacesToAdd) + line;

                Console.WriteLine(centeredLine);
                Console.WriteLine("");
            }
        }

        private void OnClickBtn()
        {
            if (options[selectLine + 1] == "Новая игра") {
                NewGameMenu manager = new NewGameMenu();
                manager.Start();
            }
        }

        private void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow)
            {
                selectLine = (selectLine < 2) ? selectLine + 1 : 0;
            }
            if (key == ConsoleKey.UpArrow)
            {
                selectLine = (selectLine > 0) ? selectLine - 1 : 2;
            }
            if (key == ConsoleKey.Enter)
            {
                selectLine = (selectLine > 0) ? selectLine - 1 : 2;
                endWhile = true;
            }
        }
    }
}
