using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public int Class { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int Lvl { get; set; }
        public int CritChance { get; set; }
        public double CritMult { get; set; }
        public int Armor { get; set; }
        public int MagicDefense { get; set; }
        public int ArmorPenetration { get; set; }
        public Weapon(int cclass, int id, string name, string imageAdress, int mindmg, int maxdmg, int lvl, string info, string type, int critchance, double critmult, int armor, int magicdefense, int armorpenetration, int price) : base(id, name, imageAdress, info, type, price)
        {
            Class = cclass;
            ID = id;
            Name = name;
            ImageAdress = imageAdress;
            Info = info;
            Lvl = lvl;
            MinDmg = mindmg;
            MaxDmg = maxdmg;
            Type = type;
            CritChance = critchance;
            CritMult = critmult;
            Armor = armor;
            MagicDefense = magicdefense;
            ArmorPenetration = armorpenetration;
            Price = price;
        }
    }
}
