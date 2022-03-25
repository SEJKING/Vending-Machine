using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
   public class PurchaseMenu
    {
        //PROPERTY
        VendingMachine Machine { get; set; }
        string Selection { get; set; }
        bool selectionOk { get; set; }

        //CONSTRUCTOR
        public PurchaseMenu(VendingMachine vendingMachine)
        {
            this.Machine = vendingMachine;
        }

        //METHODS
        public void PurchaseMenuDisplay()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" |*************************************|");
            Console.WriteLine(" | * *                             * * |");
            Console.WriteLine(" |* *        Vendo-Matic 800        * *|");
            Console.WriteLine(" | * *                             * * |");
            Console.WriteLine(" |*************************************|");
            Console.WriteLine( );
            Console.WriteLine("    (1) Feed Money");
            Console.WriteLine();
            Console.WriteLine("    (2) Select Product");
            Console.WriteLine();
            Console.WriteLine("    (3) Finish Transaction");
            Console.WriteLine();
            Console.WriteLine($"    Balance: ${Machine.Balance}");
            Console.WriteLine();
            Console.Write("    Please make a *Selection: ");

            string myOptions2 = Console.ReadLine();

            switch(myOptions2)
            {
                case "1":                    
                    decimal depositAmount = 0;                   
                    bool isDepositingMoney = true;
                    while (isDepositingMoney)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine($"    Current Money Provided: ${Machine.Balance}");
                        Console.WriteLine();
                        Console.Write("    Insert Money: (0 to return) $ ");

                        try
                        {
                            depositAmount = decimal.Parse(Console.ReadLine());
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine($"    please enter a valid number. {ex.Message}");
                            Console.ReadLine();
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"    please enter a valid number. {ex.Message}");
                            Console.ReadLine();
                        }

                        if (depositAmount == 0)
                        {
                            isDepositingMoney = false;
                        }
                        else if(depositAmount > 0)
                        {
                        DepositMoney depositMoney = new DepositMoney(depositAmount, Machine);
                        depositMoney.Deposit();
                        }
                    }
                    PurchaseMenuDisplay();
                    break;
                case "2":
                    DisplayVendingMachineItems();
                    CheckSlotNumber checkSlotNumber = new CheckSlotNumber(Selection, Machine);
                    selectionOk = checkSlotNumber.MakeItemSelection();
                    CompletePurchase();
                    break;
                case "3":
                    Exit();
                    break;
                default:
                    PurchaseMenuDisplay();
                    break;
            }
        }
            
        //Option 2
        void DisplayVendingMachineItems()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" |*************************************|");
            Console.WriteLine(" | * *                             * * |");
            Console.WriteLine(" |* *     Vendo-Matic 800 : Menu    * *|");
            Console.WriteLine(" | * *                             * * |");
            Console.WriteLine(" |*************************************|");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Quantity  | Slot Number |   Price   |  Item");
            foreach (Item item in Machine.Items)
            {
                if (item.Remaining == 0)
                {
                    Console.WriteLine($" {item.Name} SOLD OUT");
                }
                else
                {
                    Console.WriteLine($"   {item.Remaining}      |     {item.SlotNumber}      |   ${item.Price}   |  {item.Name}");
                }
            }
            Console.WriteLine();
            Console.Write("    Please Enter Slot Number: ");
            Selection = Console.ReadLine().ToUpper();
        }

       public void CompletePurchase()
        {

            if(selectionOk == false)
            {
                Console.WriteLine("    Invalid Selection");
                Console.ReadLine();
                PurchaseMenuDisplay();
            }

           // if selection is correct, connect to item through index.
            int selectedItemIndex = -1;
                if (selectionOk)
                {
                    for (int i = 0; i < Machine.Items.Count; i++)
                    {
                        if (Machine.Items[i].SlotNumber == Selection)
                        {
                            selectedItemIndex = i;
                        }
                    }
                }


                Item selectedItem = Machine.Items[selectedItemIndex];
                // Check Machine balance
                bool checkTotal = false;

                if (Machine.Balance >= selectedItem.Price)
                {
                    checkTotal = true;
                }
                else
                {
                    checkTotal = false;
                    Console.WriteLine();
                    Console.WriteLine("    Insufficient Funds");
                    Console.ReadLine();
                    PurchaseMenuDisplay();
                }


                bool isInStock = false;
                if (selectedItem.Remaining > 0)
                {
                    isInStock = true;
                }
                else
                {
                    Console.WriteLine($"    {selectedItem.Name} SOLD OUT");
                    Console.ReadLine();
                    PurchaseMenuDisplay();
                }

                
                // assign comment based off of type.
                string message="";
                switch (selectedItem.Type)
                {
                    case "Chip":
                        message = ("crunch crunch, yum!");
                        break;
                    case "Candy":
                        message = "munch munch, yum!";
                        break;
                    case "Drink":
                        message = "glug glug, yum!";
                        break;
                    case "Gum":
                        message = "chew chew, yum!";
                        break;
                }
                        if (isInStock == true && checkTotal == true)
                {
                    Machine.Balance -= selectedItem.Price;
                    selectedItem.Remaining--;
                    Console.WriteLine();
                    Console.WriteLine($"    {selectedItem.Name} ${selectedItem.Price}");
                    Console.WriteLine($"    {message}");
                    Console.WriteLine();
                    Console.WriteLine($"    Remaining Balance: ${Machine.Balance}");
                    LogClass logClass = new LogClass();
                    logClass.PurchaseLog(selectedItem.Name, selectedItem.SlotNumber, (Machine.Balance + selectedItem.Price), Machine.Balance);
                    Console.ReadLine();
                    PurchaseMenuDisplay();
                }
            }
        

            //Option 3 EXIT
            //ADD LOG
            public void Exit()
            {
            Console.WriteLine();
            Console.WriteLine("    Successful Transaction");

            decimal finalChange = Machine.Balance * 100;

            //logic to make Quarters Dimes Nickles
            if(Machine.Balance > 0.00M)
            {

                decimal quarter = 25M;
                int quarterCount = 0;
                decimal dime = 10M;
                int dimeCount = 0;
                decimal nickel = 5M;
                int nickelCount = 0;

                //math logic to get change in quarters dimes and nickels
                if (finalChange >= quarter)
                {
                    quarterCount = (int)(finalChange / quarter);
                    dimeCount = (int)((finalChange % quarter) / dime);
                    nickelCount = (int)(((finalChange % quarter) % dime) / nickel);
                }
                else if (finalChange >= dime)
                {
                    dimeCount = (int)(finalChange / dime);
                    nickelCount = (int)((finalChange % dime) / nickel);
                }
                else if (finalChange > 0)
                {
                    nickelCount = (int)(finalChange / nickel);
                }
                Console.WriteLine($"    Your change: {quarterCount} Quarters, {dimeCount} Dimes, {nickelCount} Nickels.");
                Machine.Balance = 0;
                Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine(" |*************************************|");
                Console.WriteLine(" | * *                             * * |");
                Console.WriteLine(" |* *           Good-Bye!           * *|");
                Console.WriteLine(" | * *                             * * |");
                Console.WriteLine(" |*************************************|");
                Console.ReadLine();
                LogClass logClass = new LogClass();
                logClass.ExitLog(finalChange/ 100M, Machine.Balance);
                MainMenu mainMenu = new MainMenu(Machine);
                mainMenu.MainMenuDisplay();
             }
            else
            {
                Console.WriteLine(" |*************************************|");
                Console.WriteLine(" | * *                             * * |");
                Console.WriteLine(" |* *           Good-Bye!           * *|");
                Console.WriteLine(" | * *                             * * |");
                Console.WriteLine(" |*************************************|");
                Console.ReadLine();
                MainMenu mainMenu = new MainMenu(Machine);
                mainMenu.MainMenuDisplay();
            }
        }
    }
}