using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Data
{
    internal class Save
    {
        private static string filePath = "..\\..\\..\\Data\\Save.txt";

        public static void ClearFile()
        {
            File.WriteAllText(filePath, string.Empty);
        }

        public static bool HasData()
        {
            return File.Exists(filePath) && new FileInfo(filePath).Length > 0;
        }

        public static void Set(int idPlayer1, int idPlayer2 = -1)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using (StreamWriter writer = new StreamWriter(filePath, true)) // Открываем файл для добавления
            {
                writer.WriteLine($"Player 1");
                writer.WriteLine($"id: {idPlayer1}");

                if (idPlayer2 != -1)
                {
                    writer.WriteLine($"Player 2");
                    writer.WriteLine($"id: {idPlayer2}");
                }
            }
        }
    }
}
