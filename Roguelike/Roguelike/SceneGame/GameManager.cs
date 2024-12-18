﻿using Roguelike;
using Roguelike.Data;
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

        private int max_leaf = 25;
        private int min_leaf = 12;

        private int hpPlayer1 = 10;
        private int DamagePlayer1 = 2; 

        private int hpPlayer2 = 10;
        private int DamagePlayer2 = 2;

        private Level level;

        Dictionary<string, string> saveData = new Dictionary<string, string>();

        public bool twoPlayer = false;

        public GameManager() 
        {
            saveData = Save.Get();
            this.twoPlayer = saveData.ContainsKey("idPl2");
        }

        public void Start()
        {
            var player1Controls = Settings.Get("Player 1");
            var player2Controls = Settings.Get("Player 2");

            Player player1 = new Player(saveData["idPl1"]);

            if (twoPlayer)
            {
                Player player2 = new Player(saveData["idPl2"]);
                level = new Level(widhtLevel, heightLevel, max_leaf, min_leaf, player1, player2);
            } else
            {
                level = new Level(widhtLevel, heightLevel, max_leaf, min_leaf, player1);
            }


            while (true)
            {
                Console.Clear();
                level.PrintLevel();

                //var key = Console.ReadKey(true).Key;
                ConsoleKey key = Console.ReadKey().Key;

                level.MovePlayer1(key, player1Controls);
                if (twoPlayer) level.MovePlayer2(key, player2Controls);
            }
        }
    }
}

