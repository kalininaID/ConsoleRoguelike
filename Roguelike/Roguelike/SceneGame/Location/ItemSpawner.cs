using Roguelike.Components;
using Roguelike.SceneGame.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Roguelike.SceneGame.Location
{
    internal class ItemSpawner
    {
        private List<Items> items;
        private Random random;

        public ItemSpawner()
        {
            items = new List<Items>();
            random = new Random();
        }

        public void SpawnItems(Frame map, List<Room> rooms, int numberOfItems)
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                Room room = rooms[random.Next(1, rooms.Count)];

                int x = random.Next(room.x, room.x + room.width);
                int y = random.Next(room.y, room.y + room.height);

                int itmID = random.Next(1, 6);

                if (map.VisualArr[y][x] == "  ")
                {
                    Items item = new Items(itmID);
                    items.Add(item);
                    map.VisualArr[y][x] = item.DrawItem();
                }
                else
                {
                    numberOfItems++;
                }
            }
        }

        /* public List<Enemy> GetEnemies()
        {
            return enemies;
        }*/
    }
}
