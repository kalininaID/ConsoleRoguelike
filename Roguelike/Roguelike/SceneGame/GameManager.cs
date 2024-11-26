using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class GameManager
    {
        public int hpPlayer = 10;
        public int damagePlayer = 2;

        public int widhtLevel = 80;
        public int heightLevel = 20;
        public int roomCount = 3;

        public GameManager() {
            
            Player player1 = new Player(hpPlayer, damagePlayer);
            Level level = new Level(widhtLevel, heightLevel, player1);
            level.GenerateLevel(roomCount);
            level.PrintLevel();
        }
    }
}
