using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Unit
    {
        public int hp;
        public int damage;
        public string img;

        public void Die()
        {
        }

        public void TakeHit(int damage)
        {
            hp -= damage;

            if (hp < 0)
            {
                Die();
            }
        }
        public void Attack()
        {
        }
        public void Draw()
        {
        }
    }
}
