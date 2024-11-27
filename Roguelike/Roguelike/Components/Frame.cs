using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components
{
    internal class Frame
    {
        public static char[][] DrawFrame(int width, int height)
        {
            char[][] frame = new char[height][];

            for (int i = 0; i < height; i++)
            {
                frame[i] = new char[width];

                for (int j = 0; j < width; j++)
                    frame[i][j] = ' ';
            }


            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (y == 0 || y == width - 1)
                    {
                        if (x != 0 && x != height - 1)
                        {
                            frame[x][y] = '|';
                        }
                    }
                    else
                    {
                        if (x == 0)
                        {
                            frame[x][y] = '_';
                        }
                        if (x == height - 1)
                        {
                            frame[x][y] = '‾';
                        }
                    }
                }
            }
            return frame;
        }

        public static void PrintRoom(char[][] frame)
        {
            foreach (var row in frame)
            {
                Console.WriteLine(new string(row));
            }
        }
    }
}
