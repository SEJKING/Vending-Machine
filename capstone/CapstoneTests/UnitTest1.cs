using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Collections.Generic;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class PurchaseMenuTest
    {

        [TestMethod]
        public void MakeItemSelectionTest()
        {
            //Arange 

            //Create Vending Machine Object
            string directory = Environment.CurrentDirectory;
            string relativeFileName = @"..\..\..\..\vendingmachine.csv";
            string filename = Path.Combine(directory, relativeFileName);
            string fullPath = Path.GetFullPath(filename);
            StartupProcess startup = new StartupProcess(fullPath);

            List<Item> testingIt = new List<Item>();
            testingIt = startup.Items;

            VendingMachine vendingMachine = new VendingMachine(testingIt);

            //Using Vending Machine Object to call classes.
            string selection = "a1";
            string selection2 = "1";

            CheckSlotNumber checkSlotNumber = new CheckSlotNumber(selection, vendingMachine);
            CheckSlotNumber checkSlotNumber2 = new CheckSlotNumber(selection2, vendingMachine);

            bool expectedValue = true;
            bool expectedValue2 = false;

            //Act
            bool actualValue = checkSlotNumber.MakeItemSelection();
            bool actualValue2 = checkSlotNumber2.MakeItemSelection();

            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Testing if slot-numbers are valid.");
            Assert.AreEqual(expectedValue2, actualValue2, "Testing if slot-numbers are valid.");
        }


        [TestMethod]
        public void AddingFundsUpdatesBalance()
        {   
            //Arrange
            string directory = Environment.CurrentDirectory;
            string relativeFileName = @"..\..\..\..\vendingmachine.csv";
            string filename = Path.Combine(directory, relativeFileName);
            string fullPath = Path.GetFullPath(filename);
            StartupProcess startup = new StartupProcess(fullPath);

            List<Item> testingIt = new List<Item>();
            testingIt = startup.Items;

            VendingMachine vendingMachine = new VendingMachine(testingIt);

            decimal money = 3M;
            decimal money2 = 5M;

            decimal expectedValue = 0M;
            decimal expectedValue2 = 5M;

           DepositMoney depositMoney = new DepositMoney(money, vendingMachine);
            DepositMoney depositMoney2 = new DepositMoney(money2, vendingMachine);

            //Act
            decimal actualValue = depositMoney.Deposit();
            decimal actualValue2 = depositMoney2.Deposit();

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedValue2, actualValue2);
        }


        [TestMethod]
        public void FeedMoneyLogTest()
        {
            //Arrange
            LogClass logClass = new LogClass();

            decimal feedMoneyAmount = 5M;
            decimal feedMoneyAmount2 = 10M;

            decimal balanceAfterFeed = 5M;
            decimal balanceAfterFeed2 = 10M;
            
            string expectedValue = DateTime.Now.ToString() + $" FEED MONEY: {feedMoneyAmount:C} {balanceAfterFeed:C}";       
            string expectedValue2 = DateTime.Now.ToString() + $" FEED MONEY: {feedMoneyAmount2:C} {balanceAfterFeed2:C}";

            //Act
            string actualValue = logClass.FeedMoneyLog(feedMoneyAmount, balanceAfterFeed);
            string actualValue2 = logClass.FeedMoneyLog(feedMoneyAmount2, balanceAfterFeed2);

            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Only passes on a fast computer. The expectedValue and actualValue have to happen within the same second.");
            Assert.AreEqual(expectedValue2, actualValue2, "Only passes on a fast computer. The expectedValue and actualValue have to happen within the same second.");

        }

    }
    
}
