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

        public Level(int levelWidth, int levelHeight)
        {
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;

            map = new char[levelHeight][];

            for (int i = 0; i < levelHeight; i++)
            {
                map[i] = new char[levelWidth];
                for (int j = 0; j < levelWidth; j++)
                {
                    map[i][j] = ' '; // Заполняем стены
                }
            }


            rooms = new List<Room>();
        }

        public void GenerateLevel(int roomCount)
        {
            Random rand = new Random();

            for (int i = 0; i < roomCount; i++)
            {
                int roomWidth = rand.Next(3, 6);
                int roomHeight = rand.Next(3, 6);
                int x = rand.Next(1, levelWidth - roomWidth - 1);
                int y = rand.Next(1, levelHeight - roomHeight - 1);

                Room newRoom = new Room(x, y, roomWidth, roomHeight);
                if (TryAddRoom(newRoom))
                {
                    rooms.Add(newRoom);
                    DrawRoom(newRoom);
                    if (rooms.Count > 1)
                    {
                        ConnectRooms(rooms[rooms.Count - 2], newRoom);
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
                    return false; // Пересечение с другой комнатой
                }
            }
            return true;
        }

        private void DrawRoom(Room room)
        {
            for (int i = room.Y; i < room.Y + room.Height; i++)
            {
                for (int j = room.X; j < room.X + room.Width; j++)
                {
                    map[i][j] = '.'; // Пол комнаты
                }
            }
        }

        private void ConnectRooms(Room roomA, Room roomB)
        {
            Random rand = new Random();
            int x1 = roomA.X + roomA.Width / 2;
            int y1 = roomA.Y + roomA.Height / 2;
            int x2 = roomB.X + roomB.Width / 2;
            int y2 = roomB.Y + roomB.Height / 2;

            if (rand.Next(0, 2) == 0) // Случайный выбор направления
            {
                // Горизонтальный проход
                DrawHorizontalTunnel(x1, x2, y1);
                // Вертикальный проход
                DrawVerticalTunnel(y1, y2, x2);
            }
            else
            {
                // Вертикальный проход
                DrawVerticalTunnel(y1, y2, x1);
                // Горизонтальный проход
                DrawHorizontalTunnel(x1, x2, y2);
            }
        }
        private void DrawHorizontalTunnel(int x1, int x2, int y)
        {
            for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
            {
                map[y][x] = '.'; // Проход
            }
        }

        private void DrawVerticalTunnel(int y1, int y2, int x)
        {
            for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
            {
                map[y][x] = '.'; // Проход
            }
        }

        public void PrintLevel()
        {
            foreach (var row in map)
            {
                Console.WriteLine(new string(row));
            }
        }
    }

    internal class Room
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public Room(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Intersects(Room other)
        {
            return !(X + Width <= other.X || X >= other.X + other.Width || Y + Height <= other.Y || Y >= other.Y + other.Height);
        }
    }

}
