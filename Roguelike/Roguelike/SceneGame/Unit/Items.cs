using Roguelike.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.SceneGame.Unit
{
    internal class Items
    {
        public int id;
        public string icon;
        public string name;


        public Items(int id)
        {
            this.id = id;

            switch (id)
            {
                case 1:
                    icon = "💊";
                    //icon = "Х";
                    name = "Лекарства";
                    break;
                case 2:
                    icon = "🏹";
                    //icon = "Л";
                    name = "Лук";
                    break;
                case 3:
                    icon = "👑";
                    //icon = "К";
                    name = "Корона";
                    break;
                case 4:
                    icon = "🎩";
                    //icon = "Ш";
                    name = "Шляпа невидимости";
                    break;
                case 5:
                    icon = "💉";
                    //icon = "Б";
                    name = "Бустер";
                    break;
                default:
                    icon = " ";
                    name = " ";
                    break;
            }
        }

        public string DrawItem()
        {
            return icon;
        }
    }
}
