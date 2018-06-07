using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageAdress { get; set; }
        public string Info { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public Item(int id, string name, string imageAdress, string info, string type, int price)
        {
            ID = id;
            Name = name;
            ImageAdress = imageAdress;
            Info = info;
            Type = type;
            Price = price;
        }
    }
}
