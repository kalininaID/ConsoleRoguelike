using Roguelike.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Room
    {
        public int x;
        public int y;
        public int width;
        public int height;
        private Frame roomFrame;

        public Room(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            roomFrame = new Frame(width, height);
        }

        public int Left => x;
        public int Top => y;
        public int Right => x + width;
        public int Bottom => y + height;
    }
}
