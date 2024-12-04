using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Components;

namespace Roguelike.SceneMenu
{
    internal class Lore
    {
        private Frame window;

        public void Start()
        {
            window = new Frame(Console.WindowWidth, Console.WindowHeight - 2);

            Frame btn = new Frame(14, 3);
            btn.DrawBorders();
            btn.VisualArr = ArrFunc.TextInArr(btn.VisualArr, "Продолжить", 1, pos: Position.Center);

            window.VisualArr = ArrFunc.TextInArr(window.VisualArr, "Наступили тяжелые времена.", 4, pos: Position.Center);
            window.VisualArr = ArrFunc.TextInArr(window.VisualArr, "Каждый день тысячи людей умирают от невиданной ранее болезни.", 6, pos: Position.Center);
            window.VisualArr = ArrFunc.TextInArr(window.VisualArr, "Наш город был в безопасности и о беде в королевстве мы узнавали только из газет.", 7, pos: Position.Center);
            window.VisualArr = ArrFunc.TextInArr(window.VisualArr, "Но вот и наступил наш черед. За одну ночь все жители города подцепили эту заразу.", 8, pos: Position.Center);
            window.VisualArr = ArrFunc.TextInArr(window.VisualArr, "Но нам повезло. В городе нашлись люди с иммунитетом к этой болезни.", 9, pos: Position.Center);
            window.VisualArr = ArrFunc.TextInArr(window.VisualArr, "В их руках лежит судьба нашего королевства.", 10, pos: Position.Center);
            window.VisualArr = ArrFunc.TextInArr(window.VisualArr, "А может быть и целого мира...", 11, pos: Position.Center);
            window.VisualArr = ArrFunc.ArrInArr(window.VisualArr, btn.VisualArr, 15, pos: Position.Center);

            window.Draw();

            var key = Console.ReadKey(true).Key;

            NewGameMenu manager = new NewGameMenu();
            manager.Start();

            //window = ArrFunc.ArrInArr
        }
    }
}
