using System;
using System.Runtime.InteropServices;
using Roguelike.Components;
using Roguelike.Data;
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
        private bool isSave;
        public void Start()
        {
            isSave = Save.HasData();

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

                if (!isSave && i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(centeredLine);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }
        }

        private void OnClickBtn()
        {
            if (selectLine == 0)
            {
                GameManager manager = new GameManager();
                manager.Start();
            }

            if (selectLine == 1) {

                Lore lore = new Lore();
                lore.Start();
            }


            if (selectLine == 2)
            {
            }
        }

        private void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                selectLine = (selectLine < 2) ? selectLine + 1 : 0;
            }
            if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                selectLine = (selectLine > 0) ? selectLine - 1 : 2;
            }
            if (key == ConsoleKey.Enter)
            {
                if (!isSave && selectLine == 0)
                { } else
                {
                    endWhile = true;
                }
            }
        }
    }
}
