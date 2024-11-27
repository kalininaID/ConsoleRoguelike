using Roguelike.SceneGame.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class GameManager
    {
        private int widhtLevel = 40;
        private int heightLevel = 20;
        private int roomCount = 3;
       
        private int hpPlayer1 = 10;
        private int DamagePlayer1 = 2;

        public void Start()
        {
            Player player1 = new Player(hpPlayer1, DamagePlayer1);
            Level level = new Level(widhtLevel, heightLevel, player1);

            level.GenerateLevel(roomCount);

            while (true)
            {
                Console.Clear();
                level.PrintLevel();
                
                var key = Console.ReadKey(true).Key;
                level.MovePlayer(key);
            }
        }
    }
}

