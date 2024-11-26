using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Components;

namespace Roguelike.SceneMenu
{
    internal class NewGameMenu
    {

        public void Start()
        {
            while (true)
            {
                Console.Clear();

                Art img = new Art();
                img.NewGame(ArtPositions.Center, ConsoleColor.Gray);

                Console.Write("🧑‍🚀");

                var key = Console.ReadKey(true).Key;

            }

        }
    }
}
