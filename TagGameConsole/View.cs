using System;
using TagGameBLL.Exceptions;

namespace TagGameConsole
{
    public class View : IView
    {
        public delegate void Handler();

        public int FieldSize { get; private set; }
        public int Difficult { get; private set; }
        public int Direction { get; private set; }
        public event Handler OnGameStarted;
        public event Handler OnMoveSelected;
        public event Handler OnUndoMove;

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Hello!\n " +
                              "Welcome to TagGame!\n" +
                              "What you wanna do?\n" +
                              "1. Start game\n" +
                              "2. Read rules\n" +
                              "3. Exit");
            var number = Console.Read();
            switch (number)
            {
                case '1':
                    ShowPlayConfig();
                    break;
                case '2':
                    ShowRules();
                    break;
                case '3':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Try again");
                    ShowMenu();
                    break;
            }
        }

        public void ShowField(int[,] numbers)
        {
            Console.Clear();
            Console.WriteLine("Field:");
            for (var row = 0; row < numbers.GetLength(0); row++)
            {
                for (var column = 0; column < numbers.GetLength(1); column++)
                    Console.Write($"{numbers[row, column],3}" + " ");
                Console.Write("\n");
            }

            Console.WriteLine("Press any -> to do move.\n" +
                              "Press Backspace to undo last move\n" +
                              "Press Esc to exit to the Main Menu");

            ListenKey();
        }

        public void ShowWinMenu()
        {
            Console.WriteLine("You Win!\n" +
                              "Press Esc to exit to main menu");
            while (Console.ReadKey().Key != ConsoleKey.Escape) continue;
            ShowMenu();
        }

        private void ShowPlayConfig()
        {
            Console.Clear();
            Console.WriteLine("Okey, lets choose some important thinks first\n" +
                              "Write the field size \n(for example, if you will write 5, field will be 5x5)");
            try
            {
                var size = Console.ReadLine();
                FieldSize = Convert.ToInt32(size);

                Console.WriteLine("Choose your difficult level:\n" +
                                  "1. Easy\n" +
                                  "2. Medium\n" +
                                  "3. Hard\n" +
                                  "4. Bonus Game");

                var difficult = Console.ReadLine();

                Difficult = Convert.ToInt32(difficult) - 1;

                Console.WriteLine("Good! Press any key to continue :)");
                Console.ReadKey();
                OnGameStarted?.Invoke();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Wrong number! Try again!");
                ShowPlayConfig();
            }
            catch (WrongSizeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Wrong number! Try again");
                ShowPlayConfig();
            }
            catch (WrongDifficultException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Wrong number! Try again");
                ShowPlayConfig();
            }
        }

        private void ShowRules()
        {
            Console.WriteLine("Rules will be there soon :)\n" +
                              "Press any key to return to start menu");
            Console.ReadKey();
            ShowMenu();
        }

        private void ListenKey()
        {
            var keyKode = Console.ReadKey();
            try
            {
                switch (keyKode.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Direction = 0;
                        OnMoveSelected?.Invoke();
                        break;
                    case ConsoleKey.RightArrow:
                        Direction = 1;
                        OnMoveSelected?.Invoke();
                        break;
                    case ConsoleKey.UpArrow:
                        Direction = 2;
                        OnMoveSelected?.Invoke();
                        break;
                    case ConsoleKey.DownArrow:
                        Direction = 3;
                        OnMoveSelected?.Invoke();
                        break;
                    case ConsoleKey.Backspace:
                        OnUndoMove?.Invoke();
                        break;
                    case ConsoleKey.Escape:
                        ShowMenu();
                        break;
                }
            }
            catch (WrongMoveDirectionException e)
            {
                Console.WriteLine(e.Message +
                                  "\nYou can't do this move. Try another");
                ListenKey();
            }
            catch (EmptyHistoryException e)
            {
                Console.WriteLine(e.Message +
                                  "\nHistory is empty. You can't undo action now");
                ListenKey();
            }
        }
    }
}