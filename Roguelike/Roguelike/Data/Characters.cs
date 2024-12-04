using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Characters
    {
        private static string filePath = "..\\..\\..\\Data\\Сharacters.txt";

        public static Dictionary<int, Dictionary<string, string>> Get()
        {
            Dictionary<int, Dictionary<string, string>> characters = new Dictionary<int, Dictionary<string, string>>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден: " + filePath);
                return characters;
            }

            string[] lines = File.ReadAllLines(filePath);
            Dictionary<string, string> currentCharacter = null;

            foreach (string line in lines)
            {
                if (line.Trim() == "_____________")
                {
                    if (currentCharacter != null && currentCharacter.Count > 0)
                    {
                        characters[characters.Count] = currentCharacter;
                        currentCharacter = null;
                    }
                    continue;
                }

                if (currentCharacter == null)
                {
                    currentCharacter = new Dictionary<string, string>();
                }

                var parts = line.Split(new[] { ": " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    currentCharacter[parts[0].Trim()] = parts[1].Trim();
                }
            }

            return characters;
        }

        public static Dictionary<string, string> GetById(string id)
        {
            Dictionary<string, string> character = new Dictionary<string, string>();
            Dictionary<int, Dictionary<string, string>> characters = Get();

            character = characters[int.Parse(id)];

            return character;
        }
    }
}
