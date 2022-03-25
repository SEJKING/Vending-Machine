using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Item
    {
        public string SlotNumber { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Type { get; private set; }
        public int Remaining { get; set; }
        public string Message { get; set; }

        public Item(string[] arrayOfAttributes)
        {
            this.SlotNumber = arrayOfAttributes[0];
            this.Name = arrayOfAttributes[1];
            this.Price = decimal.Parse(arrayOfAttributes[2]);
            this.Type = arrayOfAttributes[3];
            this.Remaining = 5;
        }
    }
}
