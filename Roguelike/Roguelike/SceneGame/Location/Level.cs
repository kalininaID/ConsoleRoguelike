using Roguelike.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.SceneGame.Location
{
    internal class Level
    {
        private const int MAX_LEAF_SIZE = 20;

        private int levelWidth;
        private int levelHeight;

        public Frame map;
        public List<Room> rooms;
        public List<Room> halls;

        public Level(int levelWidth, int levelHeight)
        {
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;

            map = new Frame(levelWidth, levelHeight);
            Generate();
        }


        public void Generate()
        {
            List<Leaf> leafs = new List<Leaf>();
            Leaf root = new Leaf(0, 0, levelWidth, levelHeight);
            leafs.Add(root);

            bool didSplit = true;

            while (didSplit)
            {
                didSplit = false;
                // Сохраняем текущее количество листьев
                int currentCount = leafs.Count;

                for (int i = 0; i < currentCount; i++)
                {
                    Leaf l = leafs[i];
                    if (l.leftChild == null && l.rightChild == null)
                    {
                        if (l.width > MAX_LEAF_SIZE || l.height > MAX_LEAF_SIZE)
                        {
                            if (l.Split())
                            {
                                leafs.Add(l.leftChild);
                                leafs.Add(l.rightChild);
                                didSplit = true;
                            }
                        }
                    }
                }
            }
            rooms = root.CreateRooms();
        }


        public void PrintLevel()
        {
            // Создаем рамку уровня
            //Frame frame = new Frame(levelWidth, levelHeight);

            string[][] frame = new string[levelHeight][];

            for (int i = 0; i < levelHeight; i++)
            {
                frame[i] = new string[levelWidth];

                for (int j = 0; j < levelWidth; j++)
                    frame[i][j] = " ";
            }


            for (int x = 0; x < levelHeight; x++)
            {
                for (int y = 0; y < levelWidth; y++)
                {
                    if (y == 0 || y == levelWidth - 1)
                    {
                        if (x != 0 && x != levelHeight - 1)
                        {
                            frame[x][y] = "|";
                        }
                    }
                    else
                    {
                        if (x == 0)
                        {
                            frame[x][y] = "─";
                        }
                        if (x == levelHeight - 1)
                        {
                            frame[x][y] = "─";
                        }
                    }
                }
            }


            // Заполняем комнаты на уровне только точками
            foreach (var room in rooms)
            {
                for (int i = room.y; i < room.y + room.height; i++)
                {
                    for (int j = room.x; j < room.x + room.width; j++)
                    {
                        frame[i][j] = "█"; // Заполняем всю область комнаты точками
                    }
                }
            }
            // Печатаем уровень с комнатами
            foreach (var row in frame)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell); // Выводим каждый элемент без переноса строки
                }
                Console.WriteLine(); // Переход на новую строку после вывода всей строки
            }
        }
    }
}
