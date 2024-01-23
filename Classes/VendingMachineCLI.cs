using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vending_Machine.Classes;

namespace Vending_Machine.Classes
{
    public class VendingMachineCLI
    {
        public void Calculate()
        {
            List<Item> list = new List<Item>();
            string fileName = "Inventory.txt";
            string filePath = "C:\\repo\\Vending-Machine";
            string fileWhatever = Path.Combine(filePath, fileName);
            try
            {
                using (var sr = new StreamReader(fileWhatever))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        string[] items = line.Split('|');
                        for (int i = 0; i < items.Length; i += 4)
                        {
                            string code = items[0];
                            string name = items[1];
                            string price = items[2];
                            string description = items[3];
                            decimal cost = decimal.Parse(price);

                            Item item = new Item(code,name,cost,description);
                            list.Add(item);
                            
                        }
                    }
                }
            }

            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
                return;
            }
            Dispense(list);
            return;
        }
            
        public void PurchaseUI()
        {
            Console.WriteLine("1. Display Items");
            Console.WriteLine("2. Purchase Items");
            Console.WriteLine("3. Exit");
            Console.WriteLine("4. Sales Report");
            char input;
            do
            {
                input = Console.ReadLine()[0];
                switch (input)
                {
                    case '1':
                        Calculate();
                        break;
                    case '2':
                        Console.WriteLine("Please insert money");
                        decimal balance = 0;
                        Decimal.TryParse(Console.ReadLine(), out balance);
                        Console.WriteLine("Your new balance is " + balance + "$");
                        Console.WriteLine("A1|Potato Crisps|2.00|Chip\r\nA2|Pringles|3.05|Chip\r\nA3|Grain Waves|2.75|Chip\r\nA4|Puff Corn|3.55|Chip\r\nB1|Moonpie|1.80|Candy\r\nB2|Cowtail|1.50|Candy\r\nB3|Wonka Bar|1.50|Candy\r\nB4|Krunch|1.75|Candy\r\nC1|Coke|1.25|Drink\r\nC2|Dr.P|1.35|Drink\r\nC3|Mountain Dew|1.65|Drink\r\nC4|Pepsi|1.55|Drink\r\nD1|U-Chews|0.85|Gum\r\nD2|Little League Chew|1.00|Gum\r\nD3|Chiclets|0.75|Gum\r\nD4|Double Mint|0.75|Gum");
                        Console.WriteLine("Type in the code for the item you want to buy");
                        string item = Console.ReadLine();

                        break;
                    case '3':
                        return;
                    case '4':
                        Console.WriteLine("it works");
                        break;
                     default:
                        Console.Clear();
                        Console.WriteLine("Try again");
                        break;
                }

            } while (input != 3);
        }
        public void Dispense(List<Item> items)
        {
            Console.WriteLine("Enter an item code");
            string searchCode = Console.ReadLine();
            Item foundItem = items.Find(item => item.Location == searchCode);
            if (foundItem != null)
            {
                Console.WriteLine($"Item Found: {foundItem.Name}, Price: {foundItem.Price}, Description: {foundItem.Type}");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }
}
    