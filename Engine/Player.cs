using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : Stats
    {
        public int Lvl { get; set; }
        public int CurrentHitPoints { get; set; }
        public int ExperiencePoints { get; set; }
        public int Gold { get; set; }
        public int GenderID { get; set; }
        public int ClassID { get; set; }
        public int RaceID { get; set; }
        public int MagicAffinityID { get; set; }
        public int Weapon { get; set; }
        public string GenderName { get; set; }
        public string RaceName { get; set; }
        public string ClassName { get; set; }
        public string MagicAffinityName { get; set; }
        public string WeaponAdress { get; set; }
        public Player(int lvl, int genderID, int classID, int raceID,
            int baseStrengh, int baseHp, int baseArmor, int baseAttackDamage,
            int baseAgility, int baseEvasion, int baseAttackSpeed, int baseArmorPenetration,
            int baseIntelligence, int baseMagicPower, int baseMagicDefense, int baseMagicPenetration, int weapon) : 
            base(baseStrengh, baseHp, baseArmor, baseAttackDamage,
            baseAgility, baseEvasion, baseAttackSpeed, baseArmorPenetration,
            baseIntelligence, baseMagicPower, baseMagicDefense, baseMagicPenetration)
        {
            Lvl = lvl;
            GenderID = genderID;
            ClassID = classID;
            RaceID = raceID;

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

            Weapon = weapon;
        }
        public void UpdateGender(int id)
        {
            GenderID = id;
        }
    }
}
