using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu
    {
        //PROPERTY
        VendingMachine Machine { get; set; }

        //CONSTRUCTOR
        public MainMenu(VendingMachine vendingMachine)
        {
            this.Machine = vendingMachine;
        }

        //METHODS
        public void MainMenuDisplay()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" |*************************************|");
            Console.WriteLine(" | * *                             * * |");
            Console.WriteLine(" |* *   Welcome to Vendo-Matic 800  * *|");
            Console.WriteLine(" | * *                             * * |");
            Console.WriteLine(" |*************************************|");
            Console.WriteLine();
            Console.WriteLine("    (1) Display Vending Machine Items");
            Console.WriteLine();
            Console.WriteLine("    (2) Purchase");
            Console.WriteLine( );
            Console.WriteLine("    (3) Exit");
            Console.WriteLine();
            Console.Write("    Please make a *Selection: ");
                      
            string myoptions;
            myoptions = Console.ReadLine();
            switch (myoptions)
            {
                case "1":
                    DisplayVendingMachineItems();
                    break;
                case "2":
                    Purchase();
                    break;
                case "3":
                    Exit();
                    break;
                default:
                    MainMenuDisplay();
                    break;               
            }
        }

        void DisplayVendingMachineItems()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" |*************************************|");
            Console.WriteLine(" | * *                             * * |");
            Console.WriteLine(" |* *  Vendo-Matic 800 : Inventory  * *|");
            Console.WriteLine(" | * *                             * * |");
            Console.WriteLine(" |*************************************|");
            Console.WriteLine();
            Console.WriteLine();
            //STEP 5
           foreach(Item item in Machine.Items)
            {
                if (item.Remaining == 0)
                {
                    Console.WriteLine($"    {item.Name} SOLD OUT");
                }
                else
                {
                    Console.WriteLine($"    {item.Name}");
                }
            }
            Console.WriteLine();
            Console.Write("    press enter to return: ");
            Console.ReadLine();
            MainMenuDisplay();
        }

         public void Purchase()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu(Machine);
            purchaseMenu.PurchaseMenuDisplay();
        }

        public void Exit()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" |*************************************|");
            Console.WriteLine(" | * *      Thank you for using    * * |");
            Console.WriteLine(" |* *         Vendo-Matic 800       * *|");
            Console.WriteLine(" | * *                             * * |");
            Console.WriteLine(" |*************************************|");

            Console.ReadLine();
            Console.Clear();
            Program.Main();
        }
    }
}
