using System;
using System.IO;

namespace Capstone
{
    public class Program
    {
        public static void Main()
        {
            //assign fileAddress
            string directory = Environment.CurrentDirectory;
            string relativeFileName = @"..\..\..\..\vendingmachine.csv";
            string filename = Path.Combine(directory, relativeFileName);
            string fullPath = Path.GetFullPath(filename);
            
            //Run StartupProcess
            StartupProcess startup = new StartupProcess(fullPath);

            //Create Vending Machine
            VendingMachine vendingMachine = new VendingMachine(startup.Items);
                        
            Console.WriteLine("  _____________________________________");
            Console.WriteLine(" |*************************************|");
            Console.WriteLine(" | * * * * *               * * * * * * |");
            Console.WriteLine(" |* * * * *     WELCOME!    * * * * * *|");
            Console.WriteLine(" | * * * * *               * * * * * * |");
            Console.WriteLine(" |*************************************|");
            Console.WriteLine(" |                                     |");
            Console.WriteLine(" |    |   |   |   |   |   |   |   |    |");
            Console.WriteLine(" |    |___|   |___|   |___|   |___|    |");
            Console.WriteLine(" |     A1      A2      A3      A4      |");
            Console.WriteLine(" |                                     |");
            Console.WriteLine(" |    |   |   |   |   |   |   |   |    |");
            Console.WriteLine(" |    |___|   |___|   |___|   |___|    |");
            Console.WriteLine(" |     B1      B2      B3      B4      |");
            Console.WriteLine(" |                                     |");
            Console.WriteLine(" |    |   |   |   |   |   |   |   |    |");
            Console.WriteLine(" |    |___|   |___|   |___|   |___|    |");
            Console.WriteLine(" |     C1      C2      C3      C4      |");
            Console.WriteLine(" |                                     |");
            Console.WriteLine(" |    |   |   |   |   |   |   |   |    |");
            Console.WriteLine(" |    |___|   |___|   |___|   |___|    |");
            Console.WriteLine(" |     D1      D2      D3      D4      |");
            Console.WriteLine(" |                                     |");
            Console.WriteLine(" |    _____________________________    |");
            Console.WriteLine(" |   |                             |   |");
            Console.WriteLine(" |   |   press enter to begin      |   |");
            Console.WriteLine(" |   |_____________________________|   |");
            Console.WriteLine(" |                                     |");
            Console.WriteLine(" |_____________________________________|");
            Console.WriteLine(" |* * * * * * * * * * * * * * * * * * *|");
            Console.WriteLine(" | * * * * * * * * * * * * * * * * * * |");
            Console.WriteLine(" |-------------------------------------|");
            Console.WriteLine();
            Console.ReadLine();

            //Go to main menu
            MainMenu mainMenu = new MainMenu(vendingMachine);
            mainMenu.MainMenuDisplay();
        }
    }
}
