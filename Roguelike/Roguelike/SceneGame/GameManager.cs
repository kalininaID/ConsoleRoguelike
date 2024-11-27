﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class GameManager
    {
        public int hpPlayer = 10;
        public int damagePlayer = 2;

        public int widhtLevel = 80;
        public int heightLevel = 20;
        public int roomCount = 3;

        
        public GameManager() {
            
            Player player1 = new Player(hpPlayer, damagePlayer);
            Level level = new Level(widhtLevel, heightLevel);
            level.GenerateLevel(roomCount);
            level.PrintLevel();
        }
    }
}
