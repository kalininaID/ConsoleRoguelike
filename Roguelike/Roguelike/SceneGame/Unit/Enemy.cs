using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Enemy : Unit
    {
        public Enemy(int hp, int damage) { 
            this.hp = hp;
            this.damage = damage;
        }

        private void Move()
        {
        }
    }
}
