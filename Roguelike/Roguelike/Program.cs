using Roguelike.SceneGame.Location;
using System;

namespace Roguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            // Кодировка на UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Menu menu = new Menu();
            menu.Run();

            /*char [][] room1 = Room.DrawFrame(20, 15);
            Room.PrintRoom(room1);*/
/*
            Level level = new Level(80, 40);
            level.GenerateLevel(2); // Генерируем 5 комнат
            level.PrintLevel();*/
        }
    }
}
