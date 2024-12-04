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
            File.WriteAllText(filePath, "");
        }

        public static bool HasData()
        {
            return File.Exists(filePath) && new FileInfo(filePath).Length > 2;
        }

        public static void Set(int idPlayer1, int idPlayer2 = -1)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using (StreamWriter writer = new StreamWriter(filePath, true)) // Открываем файл для добавления
            {
                writer.WriteLine($"lvl: 1");
                writer.WriteLine($"idPl1: {idPlayer1}");

                if (idPlayer2 != -1)
                {
                    writer.WriteLine($"idPl2: {idPlayer2}");
                }
            }
        }

        public static Dictionary<string, string> Get()
        {
            Dictionary<string, string> saveData = new Dictionary<string, string>();

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var parts = line.Split(new[] { ':' }, 2);
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    saveData[key] = value;
                }
            }

            return saveData;
        }
    }
}
