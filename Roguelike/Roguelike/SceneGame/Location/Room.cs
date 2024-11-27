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
        public string[][] frame;

        public Room(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            frame = Frame.DrawFrame(width, height);
        }

        public bool Intersects(Room other)
        {
            int offset = 5;
            return !(x + width + offset <= other.x || 
                    y + height + offset <= other.y ||
                    x >= other.x + other.width + offset || 
                    y >= other.y + other.height + offset);
        }
    }
}
