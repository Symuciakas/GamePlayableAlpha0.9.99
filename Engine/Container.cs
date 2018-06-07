using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Container
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LocationMap { get; set; }
        public int LocationXY { get; set; }
        public int LevelRequirement { get; set; }
        public int ItemRequirement { get; set; }
        public bool ItemConsuming { get; set; }
        public bool Repeated { get; set; }
        public string Unopened { get; set; }
        public string Oppened { get; set; }
        public int[] ContainsItems { get; set; }
        public int ContainsGold { get; set; }
        public Container(int id,string name, int locationmap, int locationxy, int levelreq, int itemreq, bool itemconsuming, bool repeated, string unopened, string opened, int[] containsitems, int containsgold)
        {
            ID = id;
            Name = name;
            LocationMap = locationmap;
            LocationXY = locationxy;
            LevelRequirement = levelreq;
            ItemRequirement = itemreq;
            ItemConsuming = itemconsuming;
            Repeated = repeated;
            Unopened = unopened;
            Oppened = opened;
            ContainsItems = containsitems;
            ContainsGold = containsgold;
        }
    }
}
