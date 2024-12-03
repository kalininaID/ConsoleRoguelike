using Roguelike.SceneGame.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class GameManager
    {
        private int widhtLevel = 60;
        private int heightLevel = 30;
       
        private int hpPlayer1 = 10;
        private int DamagePlayer1 = 2;

        public void Start()
        {
            Player player1 = new Player(hpPlayer1, DamagePlayer1);
            Level level = new Level(widhtLevel, heightLevel, player1);

            while (true)
            {
                Console.Clear();
                level.PrintLevel();
                //level.PrintPlayer();

                var key = Console.ReadKey(true).Key;
                level.MovePlayer(key);
            }
            

            /* 
             Level level = new Level(widhtLevel, heightLevel, player1);

             level.GenerateLevel(roomCount);

             while (true)
             {
                 Console.Clear();
                 level.PrintLevel();

                 var key = Console.ReadKey(true).Key;
                 level.MovePlayer(key);
             }*/
        }
        private void HandleInput(ConsoleKey key)
        {
        }
    }
}

