using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Vendor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LocationMap { get; set; }
        public int LocationXY { get; set; }
        public string Dialogue { get; set; }
        public int[] Items4Sale { get; set; }
        public int[] ItemPrices { get; set; }
        public string ImageAdress { get; set; }
        public Vendor(int id, string name, int locationmap, int locationxy, string dialogue, int[] items4sale, int[] itemprices, string imageadress)
        {
            ID = id;
            Name = name;
            LocationXY = locationxy;
            LocationMap = locationmap;
            Dialogue = dialogue;
            Items4Sale = items4sale;
            ItemPrices = itemprices;
            ImageAdress = imageadress;
        }
    }
}
