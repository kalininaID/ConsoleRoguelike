using Roguelike.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class EnemySpawner
    {
        private int hp = 10;
        private int damage = 2;

        private List<Enemy> enemies;
        private Random random;

        public EnemySpawner()
        {
            enemies = new List<Enemy>();
            random = new Random();
        }

        public void SpawnEnemies(Frame map, List<Room> rooms, int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Room room = rooms[random.Next(rooms.Count)];

                int x = random.Next(room.x, room.x + room.width);
                int y = random.Next(room.y, room.y + room.height);

                if (map.VisualArr[y][x] == "  ")
                {
                    Enemy enemy = new Enemy(hp, damage, x, y); 
                    enemies.Add(enemy);

                    map.VisualArr[y][x] = enemy.DrawEnemy();
                }
                else 
                {
                    numberOfEnemies++;
                }
            }
        }

        public List<Enemy> GetEnemies()
        {
            return enemies;
        }
    }
}
