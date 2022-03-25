using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class DepositMoney
    {
        //PROPERTIES
        decimal DepositAmount{ get; set; }
        VendingMachine Machine { get; set; }

        //CONSTRUCTOR
        public DepositMoney(decimal depositAmount, VendingMachine vendingMachine)
        {
            DepositAmount = depositAmount;
            Machine = vendingMachine;
        }

        //METHOD
        public Decimal Deposit()
        {
            bool isValid = false;
            // the only valid money entries $1, $2, $5, or $10.
            switch (DepositAmount)
            {
               
                case (1):
                    isValid = true;
                    break;
                case (2):
                    isValid = true;
                    break;
                case (5):
                    isValid = true;
                    break;
                case (10):
                    isValid = true;
                    break;
                default:
                    isValid = false;
                    break;
            }

            if (isValid == true)
            {
                Machine.Balance += DepositAmount;
                LogClass logClass = new LogClass();
                logClass.FeedMoneyLog(DepositAmount, Machine.Balance);
                return Machine.Balance;
            }
            else
            {
                Console.WriteLine("    Invalid entry");
                Console.ReadLine();
                return Machine.Balance;
            }           
        }
    }
}
