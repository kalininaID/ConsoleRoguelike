using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Settings
    {
        private static string filePath = "..\\..\\..\\Data\\settings.txt";

        public static Dictionary<string, string> Get(string playerName) {
            bool playerFound = false;

            Dictionary<string, string> playersSettings = new Dictionary<string, string>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) && playerFound)
                    break;

                if (line.StartsWith(playerName))
                {
                    playerFound = true;
                    continue;
                }
                else
                {
                    var parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        playersSettings[key] = value;
                    }
                }
            }

            return playersSettings;
        }

        public static void Set(string keyFrom, string keyTo)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден: " + filePath);
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            List<string> updatedLines = new List<string>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    updatedLines.Add(line);
                    continue;
                }

                string updatedLine = line.Replace(keyFrom, "!")
                                          .Replace(keyTo, keyFrom)
                                          .Replace("!", keyTo);

                updatedLines.Add(updatedLine);
            }

            File.WriteAllLines(filePath, updatedLines);
        }
    }
}
