using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    enum StateScaneManager
    {
        None,
        Menu,
        Game
    }
    class SceneManager
    {
        private StateScaneManager state = StateScaneManager.Menu;

        public void Start()
        {
            Menu menu = new Menu();
            menu.Start();
        }
    }
}
