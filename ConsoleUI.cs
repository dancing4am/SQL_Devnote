using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Devnote
{
    internal class ConsoleUI
    {
        ConsoleColor logoColor = ConsoleColor.Green;
        ConsoleColor numColor = ConsoleColor.Magenta;        
        ConsoleColor menuColor = ConsoleColor.Cyan;
        ConsoleColor baseColor = ConsoleColor.White;
        ConsoleColor warnColor = ConsoleColor.Red;

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

                switch (ValidateToInt(GetUserInput()))
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

        internal void DataMenu()
        {
            do
            {
                Console.Clear();
                Logo();
                NumMenu(1, "Add");
                NumMenu(2, "Update");
                NumMenu(3, "Remove");
                NumMenu(4, "Main Menu");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("    Enter the number: ");

                switch (ValidateToInt(GetUserInput()))
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

        internal void SearchMenu()
        {

        }

        private int ValidateToInt(string? input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        private string? GetUserInput()
        {
            Console.ForegroundColor = baseColor;
            string? input = "";

            try
            {
                input = Console.ReadLine();
            }
            catch (Exception e)
            {
                PrintError(e.Message);
                Console.Clear();
            }

            return input;
        }


        private void ExitApplication()
        {
            Console.WriteLine();
            Console.ForegroundColor = baseColor;
            Console.WriteLine(" See ya!");
            Environment.Exit(0);
        }

        private void PrintError(string msg)
        {
            Console.WriteLine();
            Console.ForegroundColor = warnColor;
            Console.Beep();
            Console.Error.WriteLine(msg);
            Console.ForegroundColor = baseColor;
            Console.Write(" Press Any Key to Continue . . .");
            Console.ReadKey();
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

        private void NumMenu(int num, string text)
        {
            Console.ForegroundColor = numColor;
            Console.Write($"    {num}) ");
            Console.ForegroundColor = menuColor;
            Console.WriteLine($"{text}");
        }
    }
}
