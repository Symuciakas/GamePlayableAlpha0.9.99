using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Armor : Item
    {
        public int Class { get; set; }
        public int BonusArmor { get; set; }
        public int BonusMagicResistance { get; set; }
        public int Lvl { get; set; }
        public Armor(int cclass, int id, string name, string imageAdress, int bonusarmor, int bonusmagicresistance, int lvl, string info, string type, int price)
            : base(id, name, imageAdress, info, type, price)
        {
            Class = cclass;
            ID = id;
            Name = name;
            ImageAdress = imageAdress;
            Info = info;
            Lvl = lvl;
            BonusArmor = bonusarmor;
            BonusMagicResistance = bonusmagicresistance;
            Type = type;
            Price = price;
        }
    }
}
