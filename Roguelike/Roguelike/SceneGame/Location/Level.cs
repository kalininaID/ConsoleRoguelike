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

        private string[][] map;
        private List<Room> rooms;
        private List<Room> halls;

        private Player player1;
        private int playerStartX;
        private int playerStartY;
        private bool playerSpawn = false;

        public Level(int levelWidth, int levelHeight, Player player1)
        {
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;
            this.player1 = player1;

           // map = new Frame(levelWidth, levelHeight);
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
             map = new string[levelHeight][];

            for (int i = 0; i < levelHeight; i++)
            {
                map[i] = new string[levelWidth];

                for (int j = 0; j < levelWidth; j++)
                    map[i][j] = " ";
            }

            for (int x = 0; x < levelHeight; x++)
            {
                for (int y = 0; y < levelWidth; y++)
                {
                    if (y == 0 || y == levelWidth - 1)
                    {
                        if (x != 0 && x != levelHeight - 1)
                        {
                            map[x][y] = "|";
                        }
                    }
                    else
                    {
                        if (x == 0)
                        {
                            map[x][y] = "─";
                        }
                        if (x == levelHeight - 1)
                        {
                            map[x][y] = "─";
                        }
                    }
                }
            }

            // Заполняем комнаты на уровне
            foreach (var room in rooms)
            {
                for (int i = room.y; i < room.y + room.height; i++)
                {
                    for (int j = room.x; j < room.x + room.width; j++)
                    {
                        map[i][j] = "█";
                    }
                }
            }

            // Печатаем уровень с комнатами
            foreach (var row in map)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell); // Выводим каждый элемент без переноса строки
                }
                Console.WriteLine(); // Переход на новую строку после вывода всей строки
            }
        }

        public void PrintPlayer()
        {
            if (map[rooms[0].y][rooms[0].x] == "█" && !playerSpawn)
            {
                playerStartX = rooms[0].x;
                playerStartY = rooms[0].y;

                map[playerStartY][playerStartX] = player1.DrawPlayer();
                playerSpawn = true;
            }
        }
            public void MovePlayer(ConsoleKey key)
        {

            if (key == ConsoleKey.DownArrow)
            {
                if (isRoom(playerStartX, playerStartY + 1))
                {
                    playerStartY += 1;
                    map[playerStartY - 1][playerStartX] = "█";
                    map[playerStartY][playerStartX] = player1.DrawPlayer();
                }
            }
            if (key == ConsoleKey.UpArrow)
            {
                if (isRoom(playerStartX, playerStartY - 1))
                {
                    playerStartY -= 1;
                    map[playerStartY + 1][playerStartX] = "█";
                    map[playerStartY][playerStartX] = player1.DrawPlayer();
                }
            }
            if (key == ConsoleKey.LeftArrow)
            {
                if (isRoom(playerStartX - 1, playerStartY))
                {
                    playerStartX -= 1;
                    map[playerStartY][playerStartX + 1] = "█";
                    map[playerStartY][playerStartX] = player1.DrawPlayer();
                }
            }
            if (key == ConsoleKey.RightArrow)
            {
                if (isRoom(playerStartX + 1, playerStartY))
                {
                    playerStartX += 1;
                    map[playerStartY][playerStartX - 1] = "█";
                    map[playerStartY][playerStartX] = player1.DrawPlayer(); ;
                }
            }
        }

        public bool isRoom(int x, int y)
        {
            if (map[y][x] == "█")
            {
                return true;
            }
            return false;
        }
    }
}
