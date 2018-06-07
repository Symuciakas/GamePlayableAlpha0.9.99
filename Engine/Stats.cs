using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Stats
    {
        public int BaseStrengh { get; set; }
        public int BaseHp { get; set; }
        public int BaseArmor { get; set; }
        public int BaseAttackDamage { get; set; }

        public int BaseAgility { get; set; }
        public int BaseEvasion { get; set; }
        public int BaseAttackSpeed { get; set; }
        public int BaseArmorPenetration { get; set; }

        public int BaseIntelligence { get; set; }
        public int BaseMagicPower { get; set; }
        public int BaseMagicDefense { get; set; }
        public int BaseMagicPenetration { get; set; }
        public Stats(int baseStrengh, int baseHp, int baseArmor, int baseAttackDamage,
            int baseAgility, int baseEvasion, int baseAttackSpeed, int baseArmorPenetration,
            int baseIntelligence, int baseMagicPower, int baseMagicDefense, int baseMagicPenetration)
        {
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
        }
    }
}
