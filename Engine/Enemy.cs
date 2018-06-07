using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Enemy : Stats
    {
        public int ID { get; set; }
        public int CurrentHitPoints { get; set; }
        public int DroppedExp { get; set; }
        public int DroppedGold { get; set; }
        public int DroppedItem { get; set; }
        public string Name { get; set; }
        public string ImageAdress1 { get; set; }
        public string ImageAdress2 { get; set; }
        public string ImageAdress3 { get; set; }
        public string ImageAdress4 { get; set; }
        public int PossitionX { get; set; }
        public int PossitionY { get; set; }
        public int PossitionMap { get; set; }
        public Enemy(int id, int currentHitPoints, int droppedExp, int droppedgold, int droppedItem, string name, string imageAdress1, string imageAdress2, string imageAdress3, string imageAdress4,
            int baseStrengh, int baseHp, int baseArmor, int baseAttackDamage,
            int baseAgility, int baseEvasion, int baseAttackSpeed, int baseArmorPenetration,
            int baseIntelligence, int baseMagicPower, int baseMagicDefense, int baseMagicPenetration,
            int possitionX, int possitionY, int possitionMap) :
            base(baseStrengh, baseHp, baseArmor, baseAttackDamage,
            baseAgility, baseEvasion, baseAttackSpeed, baseArmorPenetration,
            baseIntelligence, baseMagicPower, baseMagicDefense, baseMagicPenetration)
        {
            ID = id;
            Name = name;
            CurrentHitPoints = currentHitPoints;
            DroppedExp = droppedExp;
            DroppedGold = droppedgold;
            DroppedItem = droppedItem;
            ImageAdress1 = imageAdress1;
            ImageAdress2 = imageAdress2;
            ImageAdress3 = imageAdress3;
            ImageAdress4 = imageAdress4;

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

            PossitionX = possitionX;
            PossitionY = possitionY;
            PossitionMap = possitionMap;
        }
    }
}
