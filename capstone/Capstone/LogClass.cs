using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class LogClass
    {
        string directory { get; set; }
        string relativeFileName {get; set;}
        string filename { get; set; }
        string fullPath { get; set; }

        public LogClass()
        {
            directory = Environment.CurrentDirectory;
            relativeFileName = @"..\..\..\Log.txt";
            filename = Path.Combine(directory, relativeFileName);
            fullPath = Path.GetFullPath(filename);
        }
        //FEED MONEY LOG deposit amount + new balance//feedMoney Machine.Balance
        public string FeedMoneyLog(decimal feedMoneyAmount, decimal balanceAfterFeed)
            {
            string logMessage = DateTime.Now.ToString() + $" FEED MONEY: {feedMoneyAmount:C} {balanceAfterFeed:C}";
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(logMessage);
                }
            return logMessage;
            }

            //PURCHASE LOG name + slot + old balance + new balance  //selectedItem.Name.SlotNumber(oldBalance = Machine.Balance + selectedItem.Price) machine.Balance
            public void PurchaseLog( string name, string slotNumber, decimal balanceBeforePurchase, decimal balanceAfterPurchase)
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + $" {name} {slotNumber} {balanceBeforePurchase:C} {balanceAfterPurchase:C}");
                }
            }

            //GIVE CHANGE LOG return change in dollars(decimal) + final balance  // Give Change $ change 0
            public void ExitLog(decimal changeGiven, decimal remainingBalance)
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + $" GIVE CHANGE:{changeGiven:C} {remainingBalance:C} ");
                }
            }
        }

}


