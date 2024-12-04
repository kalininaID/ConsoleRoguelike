using Roguelike.SceneGame.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Player : Unit
    {
        public int level;
        public int experience;
        public List<Items> Inventory;

        public Player(string id)
        {
            Dictionary<string, string> data = Characters.GetById(id);

            this.hp = int.Parse(data["Живучесть"]);
            this.damage = int.Parse(data["Сила"]);
            icon = data["Иконка"];
            level = 1;
            experience = 0;
            Inventory = new List<Items>();
        }

        public string DrawPlayer()
        {
            return icon;
        }
        public void AddToInventory(Items item)
        {
            Inventory.Add(item);
        }

        public void UseItem(Items item)
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

    }
}
