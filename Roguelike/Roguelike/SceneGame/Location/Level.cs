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
        private const int MIN_LEAF_SIZE = 10;

        private int levelWidth;
        private int levelHeight;

        private Frame map;
        private List<Room> rooms;
        private List<Room> halls;

        private Player player1;
        private Player player2;

        private int player1_X;
        private int player1_Y;

        private int player2_X;
        private int player2_Y;

        private bool playerSpawn = false;

        public Level(int levelWidth, int levelHeight, Player player1, Player? player2 = null)
        {
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;
            this.player1 = player1;
            if (player2 != null) 
            { 
                this.player2 = player2;
            }

            map = new Frame(levelWidth, levelHeight, "█", 2);
            map.DrawBorders(typeBorder: Frame.TypeBorder.EXRTABOLD);

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
                            if (l.Split(MIN_LEAF_SIZE))
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
            PrintRoom();
        }

        public string[][] PrintRoom()
        {
            // Заполняем комнаты на уровне
            foreach (var room in rooms)
            {
                for (int i = room.y; i < room.y + room.height; i++)
                {
                    for (int j = room.x; j < room.x + room.width; j++)
                    {
                        map.VisualArr[i][j] = " ";
                    }
                }
            }
            return map.VisualArr;
        }

        public void PrintLevel()
        {
            PrintPlayer();
            map.Draw();
        }

        public void PrintPlayer()
        {
            if (map.VisualArr[rooms[0].y][rooms[0].x] == " " && !playerSpawn)
            {
                player1_X = rooms[0].x;
                player1_Y = rooms[0].y;

                player2_X = rooms[0].x + 1;
                player2_Y = rooms[0].y;

                map.VisualArr[player1_Y][player1_X] = player1.DrawPlayer();
                map.VisualArr[player2_Y][player2_X] = player2.DrawPlayer();
                playerSpawn = true;
            }
        }

        public void MovePlayer(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow)
            {
                if (isRoom(player1_X, player1_Y + 1))
                {
                    player1_Y += 1;
                    map.VisualArr[player1_Y - 1][player1_X] = " ";
                }
            }
            if (key == ConsoleKey.UpArrow)
            {
                if (isRoom(player1_X, player1_Y - 1))
                {
                    player1_Y -= 1;
                    map.VisualArr[player1_Y + 1][player1_X] = " ";
                }
            }
            if (key == ConsoleKey.LeftArrow)
            {
                if (isRoom(player1_X - 1, player1_Y))
                {
                    player1_X -= 1;
                    map.VisualArr[player1_Y][player1_X + 1] = " ";
                }
            }
            if (key == ConsoleKey.RightArrow)
            {
                if (isRoom(player1_X + 1, player1_Y))
                {
                    player1_X += 1;
                    map.VisualArr[player1_Y][player1_X - 1] = " ";
                }
            }
            map.VisualArr[player1_Y][player1_X] = player1.DrawPlayer();




            if (key == ConsoleKey.S)
            {
                if (isRoom(player2_X, player2_Y + 1))
                {
                    player2_Y += 1;
                    map.VisualArr[player2_Y - 1][player2_X] = " ";
                }
            }
            if (key == ConsoleKey.W)
            {
                if (isRoom(player2_X, player2_Y - 1))
                {
                    player2_Y -= 1;
                    map.VisualArr[player2_Y + 1][player2_X] = " ";
                }
            }
            if (key == ConsoleKey.A)
            {
                if (isRoom(player2_X - 1, player2_Y))
                {
                    player2_X -= 1;
                    map.VisualArr[player2_Y][player2_X + 1] = " ";
                }
            }
            if (key == ConsoleKey.D)
            {
                if (isRoom(player2_X + 1, player2_Y))
                {
                    player2_X += 1;
                    map.VisualArr[player2_Y][player2_X - 1] = " ";
                }
            }
            map.VisualArr[player2_Y][player2_X] = player2.DrawPlayer();
        }

        public bool isRoom(int x, int y)
        {
            if (map.VisualArr[y][x] == " ")
            {
                return true;
            }
            return false;
        }
    }
}
