using System;

namespace Roguelike.Components
{
    enum ArtPositions
    {
        Left,
        Center,
        Right
    }
    class Art
    {
        ArtPositions pos = ArtPositions.Left;
        ConsoleColor color = ConsoleColor.White;

        public void Rogalick(ArtPositions pos = ArtPositions.Left)
        {
            this.pos = pos;
            int consoleWidth = Console.WindowWidth;
            int whight = 68;
            string buffer = "";

            if (pos == ArtPositions.Center)
            {
                buffer = new string(' ', (consoleWidth - whight) / 2);
            }

            if (pos == ArtPositions.Right)
            {
                buffer = new string(' ', consoleWidth - whight);
            }

            Console.WriteLine(buffer + "____________________________________________________________________");
            Console.Write(buffer + "|   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("__________                            .__  .__ __              ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|\n");
            Console.Write(buffer + "|   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\\______   \\ ____   ____  __ __   ____ |  | |__|  | __ ____     ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|\n");
            Console.Write(buffer + "|    ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("|       _//  _ \\ / ___\\|  |  \\_/ __ \\|  | |  |  |/ // __ \\    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|\n");
            Console.Write(buffer + "|    ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("|    |   (  <_> ) /_/  >  |  /\\  ___/|  |_|  |    <\\  ___/    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|\n");
            Console.Write(buffer + "|    ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("|____|_  /\\____/\\___  /|____/  \\___  >____/__|__|_ \\\\___  >   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|\n");
            Console.Write(buffer + "|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("           \\/      /_____/             \\/             \\/    \\/    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|\n");
            Console.Write(buffer + "|__________________________________________________________________|");
            Console.ResetColor();
        }

        public void NewGame(ArtPositions pos = ArtPositions.Left, ConsoleColor color = ConsoleColor.White)
        {
            this.pos = pos;
            this.color = color;

            int consoleWidth = Console.WindowWidth;
            int whight = 67;
            string buffer = "";

            if (pos == ArtPositions.Center)
            {
                buffer = new string(' ', (consoleWidth - whight) / 2);
            }

            if (pos == ArtPositions.Right)
            {
                buffer = new string(' ', consoleWidth - whight);
            }

            Console.ForegroundColor = color;
            Console.WriteLine("");
            Console.WriteLine(buffer + "███    ██ ███████ ██     ██      ██████   █████  ███    ███ ███████");
            Console.WriteLine(buffer + "████   ██ ██      ██     ██     ██       ██   ██ ████  ████ ██     ");
            Console.WriteLine(buffer + "██ ██  ██ █████   ██  █  ██     ██   ███ ███████ ██ ████ ██ █████  ");
            Console.WriteLine(buffer + "██  ██ ██ ██      ██ ███ ██     ██    ██ ██   ██ ██  ██  ██ ██     ");
            Console.WriteLine(buffer + "██   ████ ███████  ███ ███       ██████  ██   ██ ██      ██ ███████");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
