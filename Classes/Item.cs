using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine.Classes
{
    public class Item
    {
        public string Location { get; set; }
       
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public string PurchaseMessage { get; set; }

        public Item(string location, string name, decimal price, string type) 
        {
            this.Location = location;
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }
    }
}
