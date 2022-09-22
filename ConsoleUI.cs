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

        readonly string[] mainMenu = { "Manage Database", "Search Data", "Exit" };
        readonly string[] dataMenu = { "Add", "Update", "Remove", "Back" };
        readonly string[] addMenu = { "Namespace", "Class", "Interface", "Field", "Property", "Method", "Struct", "Enum", "Back" };
        readonly string[] classMenu = { "Namespace", "Class name", "Definition", "Assembly", "Interface", "Description", "Constructor", "Fields", "Properties", "Methods", "Operators", "Extension Methods", "Tags", "Back"};
        #endregion

        /*
            parent namespace

            parent right above to create a hierarchy

            class name

            definition
                e.g. 
                public abstract class Delegate : ICloneable, System.Runtime.Serialization.ISerializable

            assembly

            interface implements

            description

            ‘Remarks’ in the official documentation

            do not just copy-and-paste but abstract

            tags

            string array

            constructors

            fields

            properties

            methods

            operators

            extension methods
        */


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
                NumMenu(dataMenu);

                switch (GetIntInput())
                {
                    case 1:
                        AddMenu();
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
//                NumMenu();

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

        private void AddMenu()
        {
            do
            {
                Console.Clear();
                Logo();
                NumMenu(addMenu);

                switch (GetIntInput())
                {
                    case 1:
                        break;
                    case 2:
                        ClassMenu();
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
                        return;
                    default:
                        PrintError("Invalid input");
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
                switch (GetIntInput())
                {
                    case 1:
                        break;
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
                Console.ForegroundColor = menuColor;
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
