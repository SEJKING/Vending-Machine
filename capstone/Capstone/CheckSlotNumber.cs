using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class CheckSlotNumber
    {
        //PROPERTY
        string Selection { get; set; }
        VendingMachine Machine { get; set; }

        //CONSTRUCTOR
        public CheckSlotNumber(string selection, VendingMachine vendingMachine)
        {
            Selection = selection.ToUpper();
            Machine = vendingMachine;
        }

        //METHOD
        public bool MakeItemSelection()
        {
            bool selectionOk = false;
            foreach (Item item in Machine.Items)
            {
                if (Selection == item.SlotNumber)
                {
                    selectionOk = true;
                }
            }
            return selectionOk;
        }
    }
}

