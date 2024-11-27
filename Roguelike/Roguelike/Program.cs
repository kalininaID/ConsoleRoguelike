using Roguelike;
using System;

namespace Roguelike
{

    class Program
    {
        static void Main(string[] args)
        {
            // Кодировка на UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            GameManager gameManager = new GameManager();
        }
    }
}
