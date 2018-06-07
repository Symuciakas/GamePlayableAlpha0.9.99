using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Race : Stats
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageAdress { get; set; }
        public string Description { get; set; }
        public Race(int id, string name, int baseStrengh, int baseHp, int baseArmor, int baseAttackDamage,
            int baseAgility, int baseEvasion, int baseAttackSpeed, int baseArmorPenetration,
            int baseIntelligence, int baseMagicPower, int baseMagicDefense, int baseMagicPenetration, string imageadress, string description) : 
            base(baseStrengh, baseHp, baseArmor, baseAttackDamage,
            baseAgility, baseEvasion, baseAttackSpeed, baseArmorPenetration,
            baseIntelligence, baseMagicPower, baseMagicDefense, baseMagicPenetration)
        {
            ID = id;

            Name = name;

            BaseStrengh = baseStrengh;
            BaseHp = baseHp;
            BaseArmor = baseArmor;
            BaseAttackDamage = baseAttackDamage;

            BaseAgility = baseAgility;
            BaseEvasion = baseEvasion;
            BaseAttackSpeed = baseAttackSpeed;
            BaseArmorPenetration = baseArmorPenetration;

            BaseIntelligence = baseIntelligence;
            BaseMagicPower = baseMagicPower;
            BaseMagicDefense = baseMagicDefense;
            BaseMagicPenetration = baseMagicPenetration;
            ImageAdress = imageadress;

            Description = description;
        }
    }
}
