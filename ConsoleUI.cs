#define CONSOLE_UI

using System;

namespace SQL_Devnote
{
    internal sealed class ConsoleUI
    {
        internal static readonly ConsoleUI Instance = new ConsoleUI();      // singleton

        #region Fields
        ConsoleColor logoColor = ConsoleColor.Green;
        ConsoleColor numColor = ConsoleColor.Magenta;        
        ConsoleColor menuColor = ConsoleColor.Cyan;
        ConsoleColor baseColor = ConsoleColor.White;
        ConsoleColor warnColor = ConsoleColor.Red;
        #endregion

        private ConsoleUI()     // close access for singleton
        {
            
        }

        #region Menu
        internal void MainMenu()
        {
            do
            {
                Console.Clear();
                Logo();
                NumMenu(1, "Manage Database");
                NumMenu(2, "Search Data");
                NumMenu(3, "Exit");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("    Enter the number: ");

                switch (GetIntInput())
                {
                    case 1:
                        DataMenu();
                        break;
                    case 2:
                        SearchMenu();
                        break;
                    case 3:
                        ExitApplication();
                        break;
                    default:
                        PrintError("Invalid input");
                        break;
                }
            } while (true);
        }

        private void DataMenu()
        {
            do
            {
                Console.Clear();
                Logo();
                NumMenu(1, "Add");
                NumMenu(2, "Update");
                NumMenu(3, "Remove");
                NumMenu(4, "Main Menu");

                switch (GetIntInput())
                {
                    case 1:
                        DataEditor.Instance.Add();
                        break;
                    case 2:
                        DataEditor.Instance.Update();
                        break;
                    case 3:
                        DataEditor.Instance.Remove();
                        break;
                    case 4:
                        return;
                    default:
                        PrintError("Invalid input");
                        break;
                }
            } while (true);
        }

        private void SearchMenu()
        {
            do
            {
                Console.Clear();
                Logo();
                NumMenu(1, "");
                NumMenu(2, "");
                NumMenu(3, "");
                NumMenu(4, "Main Menu");

                switch (GetIntInput())
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        return;
                    default:
                        PrintError("Invalid input");
                        break;
                }
            } while (true);
        }
        #endregion

        #region UserInput
        private int GetIntInput()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("    Enter the number: ");
            Console.ForegroundColor = baseColor;

            try
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
            }
            catch (Exception e)
            {
                PrintError(e.Message);
                Console.Clear();
            }

            return -1;
        }
        #endregion

        #region DisplayTemplates
        private void ExitApplication()
        {
            Console.WriteLine();
            Console.ForegroundColor = baseColor;
            Console.WriteLine("    See ya!");
            Environment.Exit(0);
        }

        private void PrintError(string msg)
        {
            Console.WriteLine();
            Console.ForegroundColor = warnColor;
            Console.Beep();
            Console.Error.WriteLine(msg);
            Console.ForegroundColor = baseColor;
            Console.Write("    Press Any Key to Continue . . .");
            Console.ReadKey();
        }

        private void NumMenu(int num, string text)
        {
            Console.ForegroundColor = numColor;
            Console.Write($"    {num}) ");
            Console.ForegroundColor = menuColor;
            Console.WriteLine($"{text}");
        }

        private void Logo()
        {
            Console.WriteLine();
            Console.ForegroundColor = logoColor;
            Console.WriteLine("     _____       ");
            Console.WriteLine("     |  _ \\  _____   ___ __   ___ | |_ ___ ");
            Console.WriteLine("     | | | |/ _ \\ \\ / / '_ \\ / _ \\| __/ _ \\");
            Console.WriteLine("     | |_| |  __/\\ V /| | | | (_) | || __ /");
            Console.WriteLine("     |____/ \\___| \\_/ |_| |_|\\___/ \\__\\___|");
            Console.WriteLine();
        }
        #endregion
    }
}
