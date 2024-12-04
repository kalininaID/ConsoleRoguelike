using Roguelike;
using System;

namespace Roguelike
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            SceneManager sceneManager = new SceneManager();
            sceneManager.Start();
        }
    }
}
