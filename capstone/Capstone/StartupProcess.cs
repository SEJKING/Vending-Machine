using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone;

namespace Capstone
{
    public class StartupProcess
    {
        //PROPERTY
        public List<Item> Items { get; set; }

        //CONSTRUCTOR
        public StartupProcess(string fileAddress)
        {
            //instantiate Items
            this.Items = new List<Item>();

            //for each line, create string[], and use to instaniate an Item object and add it to Items.
            try
            {
                using (StreamReader sr = new StreamReader(fileAddress))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] arrayOfAttributes = (sr.ReadLine()).Split('|');

                        this.Items.Add(new Item(arrayOfAttributes));
                    }
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Unfortunately VendingMachine Directory was not found:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Unfortunately VendingMachine File was not found:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
