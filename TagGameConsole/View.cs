using System;
using System.Collections.Generic;
using System.Text;
using TagGameBLL.Exceptions;

namespace TagGameConsole
{
    public class View : IView
    {
        public int FieldSize { get; private set; }
        public int Difficult { get; private set; }
        public int Direction { get; private set; }

        public delegate void Handler();
        public event Handler OnGameStarted;
        public event Handler OnMoveSelected;
        public event Handler OnUndoMove;

        public View() { }

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
                    System.Environment.Exit(0);
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
            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                for (int column = 0; column < numbers.GetLength(1); column++)
                {
                    Console.Write(numbers[row, column] + " ");
                }
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
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                continue;
            }
            ShowMenu();
        }

        private void ShowPlayConfig()
        {
            Console.Clear();
            Console.WriteLine("Okey, lets choose some important thinks first\n" +
                              "Write the field size \n(for example, if you will write 5, field will be 5x5)");
            var size = Console.ReadLine();
            try
            {
                if (Convert.ToInt32(size) >= 0)
                {
                    FieldSize = Convert.ToInt32(size);
                }
                else
                {
                    Console.WriteLine("Wrong number! Try again");
                    ShowPlayConfig();
                }

                Console.WriteLine("Choose your difficult level:\n" +
                                  "1. Easy\n" +
                                  "2. Medium\n" +
                                  "3. Hard\n" +
                                  "4. Bonus Game");
                var difficult = Console.ReadLine();
            
                if (Convert.ToInt32(difficult) > 0 && Convert.ToInt32(difficult) < 5)
                {
                    Difficult = Convert.ToInt32(difficult) - 1;
                }
                else
                {
                    Console.WriteLine("Wrong number! Try again");
                    ShowPlayConfig();
                }

                Console.WriteLine("Good! Press any key to continue :)");
                Console.ReadKey();
                OnGameStarted.Invoke();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Wrong number! Try again!");
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
                        OnMoveSelected.Invoke();
                        break;
                    case ConsoleKey.RightArrow:
                        Direction = 1;
                        OnMoveSelected.Invoke();
                        break;
                    case ConsoleKey.UpArrow:
                        Direction = 2;
                        OnMoveSelected.Invoke();
                        break;
                    case ConsoleKey.DownArrow:
                        Direction = 3;
                        OnMoveSelected.Invoke();
                        break;
                    case ConsoleKey.Backspace:
                        OnUndoMove.Invoke();
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
            
        }

    }
}
