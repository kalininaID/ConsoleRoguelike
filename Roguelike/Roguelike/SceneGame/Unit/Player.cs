using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Player : Unit
    {
        public int level;
        public int experience;
        public List<string> Inventory;

        public Player(int hp, int damage)
        {
            this.hp = hp;
            this.damage = damage;
            img = "*";
            level = 1;
            experience = 0;
            Inventory = [];
        }

        public string DrawPlayer()
        {
            return img;
        }

        public void UseItem(string item)
        {
            if (Inventory.Contains(item))
            {
                // Логика использования предмета
                Inventory.Remove(item);
                // Можно добавить эффект использования предмета (восстановление здоровья и т.д.)
            }
        }

        public void GainExperience(int amount)
        {
            experience += amount;
            if (experience >= level * 100) 
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            level++;
            // Логика повышения уровня (например, увеличение hp или damage)
        }

        private void Move()
        {
        }
    }
}
