using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Enemy : Unit
    {
        public int x;
        public int y;

        public Enemy(int hp, int damage, int x, int y) { 
            this.hp = hp;
            this.damage = damage;
            this.x = x;
            this.y = y;
            img = "🧟";
        }
        public string DrawEnemy()
        {
            return img;
        }
    }
}
