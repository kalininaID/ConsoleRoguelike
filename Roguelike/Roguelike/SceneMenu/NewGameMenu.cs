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

        Dictionary<int, Dictionary<string, string>> characters;
        int cursorP1 = 0;
        int cursorP2 = 0;

        private string nameP1 = "Player 1";
        private string nameP2 = "Player 2";

        private int consoleWidth;
        private int consoleHeight;

        private bool readyP2 = false;

        private Art img = new Art();
        private bool flagChangeControll = false;

        PopUpChangeControll popUp = new PopUpChangeControll();

        public void Start()
        {
            while (true)
            {
                characters = Characters.Get();

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
                window = ArrFunc.TextInArr(window, namePlayer, 2);

                char[][] controlInfo;
                int cursor;
                if (nameP1 == namePlayer)
                {
                    cursor = cursorP1;
                    controlInfo = ControlInfo.Create(settingP1);

                }else
                {
                    cursor = cursorP2;
                    controlInfo = ControlInfo.Create(settingP2);
                }

                string emoji = characters[cursor]["Иконка"];
                window = ArrFunc.TextInArr(window, $"< {emoji} >", 4);

                string[] data = ["Имя", "Сила", "Скорость", "Живучесть"];
                for (int i = 0; i < data.Length; i++)
                {
                    window = ArrFunc.TextInArr(window, $"{data[i]}: {characters[cursor][data[i]]}", 6 + i);
                }

                window = ArrFunc.ArrInArr(window, controlInfo, line: window.Length - 8);
                window = ArrFunc.TextInArr(window, "Нажмите Space, если готов!", (window.Length - 2));
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
                popUp.Create();
                char[][] popUpArr = popUp.popUp;

                window = ArrFunc.ArrInArr(window, popUpArr, line: window.Length/2 - 7);
            }

            foreach (var row in window)
            {
                Console.WriteLine(new string(row));
            }
            
            string changeP2 = "";
            if (readyP2)
            {
               changeP2 = "E - удалить 2 игрока;";
            }
            Console.WriteLine($"0 - изменить управление; {changeP2} ");
        }

        private void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.E)
            {
                readyP2 = !readyP2;
                if (readyP2)
                    if (cursorP1 == cursorP2)
                        MoveCursorCharacter(false, false);
            }
            if (key == ConsoleKey.D0)
            {
                flagChangeControll = true;
            }

            if (key == ConsoleKey.A)
            {
                MoveCursorCharacter(true, true);

                if (cursorP1 == cursorP2)
                    MoveCursorCharacter(true, true);
            }
            if (key == ConsoleKey.D)
            {
                MoveCursorCharacter(true, false);

                if (cursorP1 == cursorP2)
                    MoveCursorCharacter(true, false);
            }

            if (key == ConsoleKey.LeftArrow)
            {
                MoveCursorCharacter(false, true);

                if (cursorP1 == cursorP2)
                    MoveCursorCharacter(false, true);
            }
            if (key == ConsoleKey.RightArrow)
            {
                MoveCursorCharacter(false, false);

                if (cursorP1 == cursorP2)
                    MoveCursorCharacter(false, false);
            }

        }

        private void MoveCursorCharacter(bool IsP1, bool IsLeft)
        {
            int cursor = 0;

            if (IsP1)
                cursor = cursorP1;
            else
                cursor = cursorP2;

            if (IsLeft)
                if (cursor > 0)
                    cursor -= 1;
                else
                    cursor = characters.Count - 1;
            else
                if (cursor < characters.Count - 1)
                    cursor += 1;
                else
                    cursor = 0;

            if (IsP1)
                cursorP1 = cursor;
            else
                cursorP2 = cursor;
        }

        private void ChangeControll(ConsoleKey key)
        {

            if (key == ConsoleKey.Escape)
            {
                flagChangeControll = false;
                popUp.Clear();
                return;
            }

            if (key == ConsoleKey.Enter && popUp.keyFrom != "-" && popUp.keyTo != "-")
            {
                Settings.Set(popUp.keyFrom, popUp.keyTo);

                flagChangeControll = false;
                popUp.Clear();
                return;
            }

            popUp.SetKey(key);
        }
    }
}
