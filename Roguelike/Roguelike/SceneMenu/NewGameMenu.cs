﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Roguelike.Components.Frame;

namespace Roguelike.SceneMenu
{


    internal class NewGameMenu
    {
        private Frame window;

        private Frame fieldP1;
        private Frame fieldP2;

        private Dictionary<string, string> settingP1;
        private Dictionary<string, string> settingP2;

        Dictionary<int, Dictionary<string, string>> characters;
        int cursorP1 = 0;
        int cursorP2 = 0;

        private string nameP1 = "Player 1";
        private string nameP2 = "Player 2";

        private int consoleWidth;
        private int consoleHeight;

        private bool readyP1 = false;
        private bool readyP2 = false;

        private bool existsP2 = false;

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

                window = new Frame(consoleHeight - 7, consoleWidth);

                int h = consoleHeight - 7;
                int w = consoleWidth / 2;

                fieldP1 = new Frame(w, h);
                fieldP2 = new Frame(w, h);

                fieldP1.DrawBorders(colorBorder: Colors.GRAY);
                fieldP2.DrawBorders(colorBorder: Colors.GRAY);

                fieldP1 = CreatePlayer(fieldP1, "Player 1", true);
                fieldP2 = CreatePlayer(fieldP2, "Player 2", existsP2, del: true);

                if (readyP1)
                    PlayerReady(fieldP1, readyP1);

                if (readyP2)
                    PlayerReady(fieldP2, readyP2);

                DisplayMenu();

                if (readyP1)
                {
                    if (existsP2 && !readyP2)
                    {
                    }
                    else
                    {
                        break;
                    }
                }

                var key = Console.ReadKey(true).Key;

                if (flagChangeControll)
                {
                    popUp.ChangeControll(key);

                    if (popUp.isClose)
                    {
                        flagChangeControll = false;
                        popUp.Clear();
                    }
                } else
                {
                    HandleInput(key);
                }
            }

            GameManager manager = new GameManager(true);
            manager.Start();
        }

        public Frame CreatePlayer(Frame playerWindow, string namePlayer = "Player 1", bool inGame = false, bool del = false)
        {
            string[][] visualPW = playerWindow.VisualArr;
            int[][] colorsPW = playerWindow.ColorsArr;

            if (inGame)
            {
                visualPW = ArrFunc.TextInArr(visualPW, namePlayer, 2);

                string[][] controlInfo;
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
                visualPW = ArrFunc.TextInArr(visualPW, $"< {emoji} >", 4);

                string[] data = ["Имя", "Сила", "Скорость", "Живучесть"];
                for (int i = 0; i < data.Length; i++)
                {
                    visualPW = ArrFunc.TextInArr(visualPW, $"{data[i]}: {characters[cursor][data[i]]}", 6 + i);
                }

                visualPW = ArrFunc.ArrInArr(visualPW, controlInfo, line: visualPW.Length - 8);

                if (nameP1 == namePlayer)
                {
                    if (!readyP1)
                    {
                        visualPW = ArrFunc.TextInArr(visualPW, "Нажми Space, если готов!", (visualPW.Length - 2));
                    } else
                    {
                        visualPW = ArrFunc.TextInArr(visualPW, "Готов!", (visualPW.Length - 2));
                    }
                }
                else
                {
                    if (!readyP2)
                    {
                        visualPW = ArrFunc.TextInArr(visualPW, "Нажми Enter, если готов!", (visualPW.Length - 2));
                    }
                    else
                    {
                        visualPW = ArrFunc.TextInArr(visualPW, "Готов!", (visualPW.Length - 2));
                    }
                }

            }
            else
            {
                visualPW = ArrFunc.TextInArr(visualPW, "Нажмите E, чтобы", (visualPW.Length/2 - 1));
                visualPW = ArrFunc.TextInArr(visualPW, "добавить игрока", (visualPW.Length / 2));
            }

            playerWindow.VisualArr = visualPW;
            playerWindow.ColorsArr = colorsPW;

            return playerWindow;
        }

        public void DisplayMenu()
        {
            Console.Clear();
            img.NewGame(Position.Center, ConsoleColor.Gray);

            window.VisualArr = ArrFunc.Join(fieldP1.VisualArr, fieldP2.VisualArr);
            window.ColorsArr = ArrFunc.Join(fieldP1.ColorsArr, fieldP2.ColorsArr);

            if (flagChangeControll)
            {
                popUp.Update();

                window.VisualArr = ArrFunc.ArrInArr(window.VisualArr, popUp.VisualArr, line: window.VisualArr.Length / 2 - 7);
                window.ColorsArr = ArrFunc.ArrInArr(window.ColorsArr, popUp.ColorsArr, line: window.ColorsArr.Length / 2 - 7);
            }

            window.Draw();

            string changeP2 = "";
            if (existsP2)
            {
               changeP2 = "E - удалить 2 игрока; ";
            }
            Console.WriteLine($"0 - изменить управление; {changeP2}");
        }

        private void PlayerReady(Frame field, bool ready)
        {
            if (ready)
            {
                field.Paint(Colors.GREEN);
            }
        }

        private void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Spacebar)
            {
                int a = 2;

                readyP1 = !readyP1;
                //
                //закрыть возможности для 1 перснажа пометить что он готов
            }
            if (key == ConsoleKey.Enter)
            {
                int a = 2;

                readyP2 = !readyP2;
                //fieldP1.Array = PlayerReady(fieldP2.Array);
                //закрыть возможности для 1 перснажа пометить что он готов
            }

            if (key == ConsoleKey.E && !readyP2)
            {
                existsP2 = !existsP2;
                if (existsP2)
                    if (cursorP1 == cursorP2)
                        MoveCursorCharacter(false, false);
            }
            if (key == ConsoleKey.D0)
            {
                flagChangeControll = true;
            }

            if (key == ConsoleKey.A && !readyP1)
            {
                MoveCursorCharacter(true, true);

                if (cursorP1 == cursorP2 && existsP2)
                    MoveCursorCharacter(true, true);
            }
            if (key == ConsoleKey.D && !readyP1)
            {
                MoveCursorCharacter(true, false);

                if (cursorP1 == cursorP2)
                    MoveCursorCharacter(true, false);
            }

            if (key == ConsoleKey.LeftArrow && !readyP2)
            {
                MoveCursorCharacter(false, true);

                if (cursorP1 == cursorP2)
                    MoveCursorCharacter(false, true);
            }
            if (key == ConsoleKey.RightArrow && !readyP2)
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

        
    }
}
