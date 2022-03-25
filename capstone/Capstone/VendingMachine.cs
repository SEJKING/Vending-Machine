using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        //PROPERTIES
        public decimal Balance { get; set; }
        public List<Item> Items { get; set; }

        //CONSTRUCTOR
        public VendingMachine(List<Item> vendingMachineItems)
        {
            this.Items = vendingMachineItems;
            this.Balance = 0.00M;
        }

    }
}
