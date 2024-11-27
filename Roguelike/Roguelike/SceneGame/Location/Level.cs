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
        private int levelWidth;
        private int levelHeight;
        private char[][] map;

        private List<Room> rooms;
        private Player player1;

        public int playerStartX;
        public int playerStartY;

        bool playerSpawn = false;

        public Level(int levelWidth, int levelHeight, Player player1)
        {
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;
            this.player1 = player1;

            map = Frame.DrawFrame(levelWidth, levelHeight);
            rooms = new List<Room>();
        }

        public void GenerateLevel(int roomCount)
        {
            Random rand = new Random();

            for (int i = 0; i < roomCount; i++)
            {
                int roomWidth = rand.Next(6, 15);
                int roomHeight = rand.Next(6, 10);

                Room newRoom = null;

                for (int attempts = 0; attempts < 100; attempts++)
                {
                    //определяем случайные позиции для верхнего левого угла
                    int x = rand.Next(1, levelWidth - roomWidth - 1);
                    int y = rand.Next(1, levelHeight - roomHeight - 1);

                    newRoom = new Room(x, y, roomWidth, roomHeight);

                    //проверяем возможность добавление новой комнаты
                    if (TryAddRoom(newRoom))
                    {
                        rooms.Add(newRoom);
                        DrawRoom(newRoom);
                        if (rooms.Count > 1)
                        {
                            ConnectRooms(rooms[rooms.Count - 2], newRoom);
                        }
                        break;
                    }
                }
            }
        }
        private bool TryAddRoom(Room room)
        {
            foreach (var r in rooms)
            {
                if (room.Intersects(r))
                {
                    return false;
                }
            }
            return true;
        }

        private void DrawRoom(Room room)
        {
            for (int i = 0; i < room.height; i++)
            {
                for (int j = 0; j < room.width; j++)
                {
                    // Проверяем, что координаты не выходят за пределы массива map
                    int mapX = room.x + j;
                    int mapY = room.y + i;

                    if (mapY >= 0 && mapY < map.Length && mapX >= 0 && mapX < map[0].Length)
                    {
                        // Заполняем массив map символами из рамки комнаты
                        if (map[mapY][mapX] != player1.DrawPlayer())
                        {
                            map[mapY][mapX] = room.frame[i][j];
                        }

                        if (!playerSpawn)
                        {
                            playerStartX = mapX + 2;
                            playerStartY = mapY + 2;

                            map[playerStartY][playerStartX] = player1.DrawPlayer();
                            playerSpawn = true;

                        }
                    }
                }
            }
        }
        private void ConnectRooms(Room roomA, Room roomB)
        {
            
        }

        private void DrawHorizontalTunnel(int xStart, int xEnd, int y)
        {
           
        }

        private void DrawVerticalTunnel(int yStart, int yEnd, int x)
        {
           
        }

        public void MovePlayer(ConsoleKey key)
        {

            if (key == ConsoleKey.DownArrow)
            {
                if (!isBoard(playerStartX, playerStartY + 1))
                {
                    playerStartY += 1;
                    map[playerStartY - 1][playerStartX] = ' ';
                    map[playerStartY][playerStartX] = player1.DrawPlayer();
                }
            }
            if (key == ConsoleKey.UpArrow)
            {
                if (!isBoard(playerStartX, playerStartY - 1))
                {
                    playerStartY -= 1;
                    map[playerStartY + 1][playerStartX] = ' ';
                    map[playerStartY][playerStartX] = player1.DrawPlayer();
                }
            }
            if (key == ConsoleKey.LeftArrow)
            {
                if (!isBoard(playerStartX - 1, playerStartY))
                {
                    playerStartX -= 1;
                    map[playerStartY][playerStartX + 1] = ' ';
                    map[playerStartY][playerStartX] = player1.DrawPlayer();
                }
            }
            if (key == ConsoleKey.RightArrow)
            {
                if (!isBoard(playerStartX + 1, playerStartY))
                {
                    playerStartX += 1;
                    map[playerStartY][playerStartX - 1] = ' ';
                    map[playerStartY][playerStartX] = player1.DrawPlayer(); ;
                }
            }
        }

        public bool isBoard(int x, int y)
        {
            if (map[y][x] == '|' ||
                map[y][x] == '_' ||
                map[y][x] == '‾')
            {
                return true;
            }
            return false;
        }

        public void PrintLevel()
        {

            foreach (var row in map)
            {
                Console.WriteLine(new string(row));
            }
        }
    }
}
