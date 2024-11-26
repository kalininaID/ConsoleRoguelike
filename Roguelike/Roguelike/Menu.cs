using System;

class Menu {
    private string[] options = { "Продолжить игру", "Новая игра", "Выйти" };
    private string login = string.Empty;
    private string password = string.Empty;
    private int selectLine = 0;
    public void Run() {
        while (true) {
            Console.Clear();
            DisplayMenu();

            var key = Console.ReadKey(true).Key;

            HandleInput(key);

            if (key == ConsoleKey.Enter) // Принять
            {
                Console.Clear();
                Console.WriteLine($"Данные приняты.\nНажато:");
                break;
            }
        }
    }

    private void DisplayMenu() {

        ArtDisplay img = new ArtDisplay();

        img.DrawRogalick();

        Console.WriteLine("");
        Console.WriteLine("");
        if (selectLine == 0) {
            Console.WriteLine("                                     ⚔️  Продолжить  ⚔️");
        } else {
            Console.WriteLine("                                         Продолжить");
        }
        Console.WriteLine("");
        if (selectLine == 1) {
            Console.WriteLine("                                     ⚔️  Новая игра  ⚔️");
        } else {
            Console.WriteLine("                                         Новая игра");
        }
        Console.WriteLine("");
        if (selectLine == 2) {
            Console.WriteLine("                                       ⚔️  Выход  ⚔️");
        } else {
            Console.WriteLine("                                           Выход");
        }

    }

    private void HandleInput(ConsoleKey key) {
        if (key == ConsoleKey.UpArrow) {
            selectLine = (selectLine < 2) ? selectLine + 1 : 0;
        } 
        if (key == ConsoleKey.DownArrow) {
            selectLine = (selectLine > 0) ? selectLine - 1 : 2;
        }
    }
}
