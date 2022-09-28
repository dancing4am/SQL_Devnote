﻿#define CONSOLE_UI

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

        const string BACK_STR = "Back";
        readonly string[] mainMenu = { "Manage Database", "Search Data", "Exit" };
        readonly string[] dataMenu = { BACK_STR, "Add", "Update", "Remove" };
        readonly string[] addMenu = { BACK_STR, "Namespace", "Class", "Interface", "Field", "Property", "Method", "Struct", "Enum"};
        readonly string[] classMenu = { BACK_STR, "Namespace", "Class name", "Definition", "Assembly", "Interface", "Description", "Constructor", "Fields", "Properties", "Methods", "Operators", "Extension Methods", "Tags"};
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
                NumMenu(mainMenu);

                GetIntInput(out int result);
                switch (result)
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
                }
            } while (true);
        }

        private void DataMenu()
        {
            do
            {
                Console.Clear();
                Logo();
                NumMenu(dataMenu);
                GetIntInput(out int result);
                switch (result)
                {
                    case 1:
                        return;
                    case 2:
                        AddMenu();
                        break;
                    case 3:
                        DataEditor.Instance.Update();
                        break;
                    case 4:
                        DataEditor.Instance.Remove();
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
                //                NumMenu();
                GetIntInput(out int result);
                switch (result)
                {
                    case 1:
                        return;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
            } while (true);
        }

        private void AddMenu()
        {
            do
            {
                Console.Clear();
                Logo();
                NumMenu(addMenu);
                GetIntInput(out int result);
                switch (result)
                {
                    case 1:
                        return;
                    case 2:
                        break;
                    case 3:
                        ClassMenu();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                }
            } while (true);
        }

        private void ClassMenu()
        {
            do
            {
                Console.Clear();
                Logo();
                NumMenu(classMenu);
                // https://stackoverflow.com/questions/60767909/c-sharp-console-app-how-do-i-make-an-interactive-menu
                GetIntInput(out int result);
                switch (result)
                {
                    case 1:
                        return;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                }
            } while (true);
        }
        #endregion

        #region UserInput
        private void GetIntInput(out int result)   // using return value for both error code and a valid result is not the best option
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("    Enter the number: ");
            Console.ForegroundColor = baseColor;

            try
            {
                string? input = Console.ReadLine();
                if (!int.TryParse(input, out result))
                {
                    throw new Exception("Invalid input");
                }
            }
            catch (Exception e)
            {
                result = int.MinValue;
                PrintError(e.Message);
                Console.Clear();
            }
        }

        private string GetStringInput()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("    ");
            Console.ForegroundColor = baseColor;

            try
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    //return result;
                }
            }
            catch (Exception e)
            {
                PrintError(e.Message);
                Console.Clear();
            }

            return "";
        }
        #endregion



        #region DisplayTemplates
        private void AddClass()
        {
            try
            {
               // DataEditor.Instance.Add();
            }
            catch (Exception e)
            {
                PrintError(e.Message);
            }
        }


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
            Console.Error.WriteLine("    " + msg);
            Console.ForegroundColor = baseColor;
            Console.Write("    Press Any Key to Continue . . .");
            Console.ReadKey();
        }

        private void NumMenu(in string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.ForegroundColor = numColor;
                Console.Write($"    {i + 1}) ");
                if (menu[i].Equals(BACK_STR))
                {
                    Console.ForegroundColor = baseColor;
                }
                else
                {
                    Console.ForegroundColor = menuColor;
                }
                Console.WriteLine($"{menu[i]}");
            }
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
