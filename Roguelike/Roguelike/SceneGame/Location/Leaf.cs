using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.SceneGame.Location
{
    internal class Leaf
    {
        private const int MIN_LEAF_SIZE = 6;

        public int x;
        public int y;
        public int width;
        public int height;

        public Leaf? leftChild;
        public Leaf? rightChild;

        public Room room; // комната, находящаяся внутри листа
        public List<Room> halls; // коридоры, соединяющие этот лист с другими листьями

        public bool IsLeaf => leftChild == null && rightChild == null;

        public Leaf(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public bool Split()
        {
            if (leftChild != null || rightChild != null)
            {
                return false;
            }
            // Определяем направление разрезания
            // если ширина более чем на 25% больше высоты, то разрезаем вертикально
            // если высота более чем на 25% больше ширины, то разрезаем горизонтально
            // иначе выбираем направление разрезания случайным образом
            bool splitH = new Random().NextDouble() > 0.5;
            if (width > height && (width / (double)height) >= 1.25)
            {
                splitH = false;
            }
            else if (height > width && (height / (double)width) >= 1.25)
            {
                splitH = true;
            }

            int max = (splitH ? height : width) - MIN_LEAF_SIZE; // Определяем максимальную высоту или ширину
            if (max <= MIN_LEAF_SIZE)
            {
                return false; // область слишком мала, больше её делить нельзя...
            }

            int split = RandomNumber(MIN_LEAF_SIZE, max); // Определяемся, где будем разрезать

            if (splitH)
            {
                leftChild = new Leaf(x, y, width, split);
                rightChild = new Leaf(x, y + split, width, height - split);
            }
            else
            {
                leftChild = new Leaf(x, y, split, height);
                rightChild = new Leaf(x + split, y, width - split, height);
            }
            return true; // Разрезание выполнено!
        }

        public List<Room> CreateRooms()
        {
            List<Room> roomsList = new List<Room>();

            if (leftChild != null || rightChild != null)
            {
                // Этот лист был разрезан, поэтому переходим к его дочерним листьям
                if (leftChild != null)
                {
                    roomsList.AddRange(leftChild.CreateRooms());
                }
                if (rightChild != null)
                {
                    roomsList.AddRange(rightChild.CreateRooms());
                }
                // если у этого листа есть и левый, и правый дочерние листья, то создаём между ними коридор
                if (leftChild != null && rightChild != null)
                {
                    List<Room> hallRooms = CreateHall(leftChild.GetRoom(), rightChild.GetRoom());
                    roomsList.AddRange(hallRooms);
                }
            }
            else
            {
                Point roomSize;
                Point roomPos;

                roomSize = new Point(RandomNumber(4, width - 2), RandomNumber(3, height - 3));
                roomPos = new Point(RandomNumber(1, width - roomSize.X - 1), RandomNumber(1, height - roomSize.Y - 1));

                room = new Room(x + roomPos.X, y + roomPos.Y, roomSize.X, roomSize.Y);
                roomsList.Add(room); // Добавляем созданную комнату в список
            }
            return roomsList; // Возвращаем список комнат
        }

        public Room GetRoom()
        {
            // Если у текущего листа есть комната, возвращаем её
            if (room != null)
            {
                return room;
            }
            else
            {
                Room? lRoom = null;
                Room? rRoom = null;

                // Проверяем левого дочернего листа
                if (leftChild != null)
                {
                    lRoom = leftChild.GetRoom();
                }
                // Проверяем правого дочернего листа
                if (rightChild != null)
                {
                    rRoom = rightChild.GetRoom();
                }
                // Если ни один из дочерних листьев не имеет комнаты, возвращаем null
                if (lRoom == null && rRoom == null)
                {
                    return null;
                }
                else if (rRoom == null)
                {
                    return lRoom; // Возвращаем комнату из левого дочернего листа
                }
                else if (lRoom == null)
                {
                    return rRoom; // Возвращаем комнату из правого дочернего листа
                }
                else
                {
                    // Если обе комнаты существуют, выбираем одну случайным образом
                    return new Random().NextDouble() > 0.5 ? lRoom : rRoom;
                }
            }
        }

        public List<Room> CreateHall(Room l, Room r)
        {
            halls = new List<Room>();

            Random random = new Random();

            Point point1 = new Point(
                random.Next(l.Left + 1, l.Right - 1),
                random.Next(l.Top + 1, l.Bottom - 1)
            );

            Point point2 = new Point(
                random.Next(r.Left + 1, r.Right - 1),
                random.Next(r.Top + 1, r.Bottom - 1)
            );

            int w = point2.X - point1.X;
            int h = point2.Y - point1.Y;

            if (w < 0)
            {
                if (h < 0)
                {
                    if (random.NextDouble() < 0.5)
                    {
                        halls.Add(new Room(point2.X, point1.Y, Math.Abs(w - 1), 1));
                        halls.Add(new Room(point2.X, point2.Y, 1, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Room(point2.X, point2.Y, Math.Abs(w - 1), 1));
                        halls.Add(new Room(point1.X, point2.Y, 1, Math.Abs(h)));
                    }
                }
                else if (h > 0)
                {
                    if (random.NextDouble() < 0.5)
                    {
                        halls.Add(new Room(point2.X, point1.Y, Math.Abs(w - 1), 1));
                        halls.Add(new Room(point2.X, point1.Y, 1, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Room(point2.X, point2.Y, Math.Abs(w - 1), 1));
                        halls.Add(new Room(point1.X, point1.Y, 1, Math.Abs(h)));
                    }
                }
                else // если (h == 0)
                {
                    halls.Add(new Room(point2.X, point2.Y, Math.Abs(w), 1));
                }
            }
            else if (w > 0)
            {
                if (h < 0)
                {
                    if (random.NextDouble() < 0.5)
                    {
                        halls.Add(new Room(point1.X, point2.Y, Math.Abs(w + 1), 1));
                        halls.Add(new Room(point1.X, point2.Y, 1, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Room(point1.X, point1.Y, Math.Abs(w + 1), 1));
                        halls.Add(new Room(point2.X, point2.Y, 1, Math.Abs(h)));
                    }
                }
                else if (h > 0)
                {
                    if (random.NextDouble() < 0.5)
                    {
                        halls.Add(new Room(point1.X, point1.Y, Math.Abs(w + 1), 1));
                        halls.Add(new Room(point2.X, point1.Y, 1, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Room(point1.X, point2.Y, Math.Abs(w + 1), 1));
                        halls.Add(new Room(point1.X, point1.Y, 1, Math.Abs(h)));
                    }
                }
                else // если (h == 0)
                {
                    halls.Add(new Room(point1.X, point1.Y, Math.Abs(w), 1));
                }
            }
            else // если (w == 0)
            {
                if (h < 0)
                {
                    halls.Add(new Room(point2.X, point2.Y, 1, Math.Abs(h)));
                }
                else if (h > 0)
                {
                    halls.Add(new Room(point1.X, point1.Y, 1, Math.Abs(h)));
                }
            }
            return halls;
        }

        private int RandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}
