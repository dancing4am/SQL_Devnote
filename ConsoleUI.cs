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
            Logo();
            NumMenu(1, "Manage Database");
            NumMenu(2, "Search Data");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the number: ");
            GetUserInput();
        }

        internal void DataMenu()
        {

        }

        internal void SearchMenu()
        {

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
                Console.WriteLine();
                Console.ForegroundColor = warnColor;
                Console.Beep();
                Console.Error.WriteLine(e);
                Console.ForegroundColor = baseColor;
                Console.Write("Press Any Key to Continue . . .");
                Console.ReadKey();
                Console.Clear();
            }

            return input;
        }

        private void Logo()
        {
            Console.WriteLine();
            Console.ForegroundColor = logoColor;
            Console.WriteLine(" _____       ");
            Console.WriteLine(" |  _ \\  _____   ___ __   ___ | |_ ___ ");
            Console.WriteLine(" | | | |/ _ \\ \\ / / '_ \\ / _ \\| __/ _ \\");
            Console.WriteLine(" | |_| |  __/\\ V /| | | | (_) | || __ /");
            Console.WriteLine(" |____/ \\___| \\_/ |_| |_|\\___/ \\__\\___|");
            Console.WriteLine();
        }

        private void NumMenu(int num, string text)
        {
            Console.ForegroundColor = numColor;
            Console.Write($"{num}) ");
            Console.ForegroundColor = menuColor;
            Console.WriteLine($"{text}");
        }
    }
}
