using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class World
    {
        //Stuff list
        public static readonly List<Gender> Genders = new List<Gender>();
        public static readonly List<Race> Races = new List<Race>();
        public static readonly List<Class> Classes = new List<Class>();
        public static readonly List<Terrain> Terrains = new List<Terrain>();
        public static readonly List<Map> Maps = new List<Map>();
        public static readonly List<UpperMap> UpperMaps = new List<UpperMap>();
        public static readonly List<UpperMap> Objects = new List<UpperMap>();
        public static readonly List<Connection> Connections = new List<Connection>();
        public static readonly List<Enemy> Enemies = new List<Enemy>();
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Weapon> Weapons = new List<Weapon>();
        public static readonly List<Armor> Armors = new List<Armor>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<NPC> NPCs = new List<NPC>();
        public static readonly List<RandomObject> BonusTerrain = new List<RandomObject>();
        public static readonly List<RandomObject> RandomObjects = new List<RandomObject>();
        public static readonly List<Fireplace> Fireplaces = new List<Fireplace>();
        public static readonly List<Container> Containers = new List<Container>();
        public static readonly List<Vendor> Vendors = new List<Vendor>();

        public const int UNSELLABLE_ITEM_PRICE = -1;
        public const int NO_ITEM_ID = -1;
        public const int NO_MONSTER_ID = -1;
        public const int NO_ITEMS = -1;
        public const int NO_MONSTERS = -1;
        public const int TALK_TO_NOONE = -1;
        public const int NO_REWARD_ITEM = -1;
        public const int NO_REWARD_ITEMS = -1;
        public const int NO_REWARD_EXP = -1;
        public const int NO_REWARD_GOLD = -1;

        //Gender ID
        public const int GENDER_ID_MALE = 1;
        public const int GENDER_ID_FEMALE = 2;
        public const int GENDER_ID_RETARDED = 3;

        //Race ID
        public const int RACE_ID_ANGELS = 1;
        public const int RACE_ID_DEMONS = 2;
        public const int RACE_ID_ELFS = 3;
        public const int RACE_ID_DWARFS = 4;
        public const int RACE_ID_NEKOA = 5;
        public const int RACE_ID_WARHOGS = 6;
        public const int RACE_ID_FAIRIES = 7;
        public const int RACE_ID_DRAQUAS = 8;
        public const int RACE_ID_MINOTAURS = 9;
        public const int RACE_ID_SPIRITS = 10;
        public const int RACE_ID_TREANTS = 11;
        public const int RACE_ID_SEAKIN = 12;
        public const int RACE_ID_UNBURNT = 13;
        public const int RACE_ID_HUMANS = 14;
        public const int RACE_ID_GOBLINS = 15;
        public const int RACE_ID_UPOS = 16;

        //Class ID
        public const int CLASS_ID_SWORDSMAN = 1;    //Sword
        public const int CLASS_ID_ARCHER = 2;       //Bow
        public const int CLASS_ID_ROGUE = 3;        //Knives
        public const int CLASS_ID_MAGE = 4;         //Staff
        public const int CLASS_ID_MONK = 5;         //Bo
        public const int CLASS_ID_PALADIN = 6;      //Shield
        public const int CLASS_ID_BRAWLER = 7;      //Knuckles
        public const int CLASS_ID_EXECUTIONER = 8;  //Axe
        public const int CLASS_ID_REAPER = 9;       //Scythe
        public const int CLASS_ID_GUNSLINGER = 10;  //Gun
        public const int CLASS_ID_ENGINEER = 11;    //Hammer
        public const int CLASS_ID_BEASTMASTER = 12; //Whip
        public const int CLASS_ID_JIHADIST = 13;    //Bomb
        public const int CLASS_ID_BARD = 14;        //Guitar
        public const int CLASS_ID_VILLAGER = 15;    //Hoe
        public const int CLASS_ID_NONE = 16;        //ANY

        //Magic Affinity ID
        public const int MAGICAFFINITY_ID_NONE = 0;
        public const int MAGICAFFINITY_ID_FIRE = 1;
        public const int MAGICAFFINITY_ID_WATER = 2;
        public const int MAGICAFFINITY_ID_EARTH = 3;
        public const int MAGICAFFINITY_ID_AIR = 4;
        public const int MAGICAFFINITY_ID_LIGHTNING = 5;
        public const int MAGICAFFINITY_ID_ICE = 6;
        public const int MAGICAFFINITY_ID_METAL = 7;
        public const int MAGICAFFINITY_ID_NATURE = 8;
        public const int MAGICAFFINITY_ID_DUST = 9;
        public const int MAGICAFFINITY_ID_LAVA = 10;
        public const int MAGICAFFINITY_ID_VACUUM = 11;
        public const int MAGICAFFINITY_ID_PLASMA = 12;
        public const int MAGICAFFINITY_ID_LIQUID = 13;
        public const int MAGICAFFINITY_ID_SOLID = 14;
        public const int MAGICAFFINITY_ID_GAS = 15;
        public const int MAGICAFFINITY_ID_ENERGY = 16;
        public const int MAGICAFFINITY_ID_DARK = 17;
        public const int MAGICAFFINITY_ID_LIGHT = 18;
        public const int MAGICAFFINITY_ID_TIME = 19;
        public const int MAGICAFFINITY_ID_SPACE = 20;
        public const int MAGICAFFINITY_ID_SPACETIME = 21;
        public const int MAGICAFFINITY_ID_EXPLOSION = 22;
        public const int MAGICAFFINITY_ID_FORCE = 23;
        public const int MAGICAFFINITY_ID_BLOOD = 24;
        public const int MAGICAFFINITY_ID_BALANCE = 25;

        static World()
        {
            PopulateGenders();
            PopulateRaces();
            PopulateClasses();
            PopulateTerrains();
            PopulateMaps();
            PopulateConnections();
            PopulateEnemies();
            PopulateItems();
            PopulateWeapons();
            PopulateNPCs();
            PopulateQuests();
            PopulateArmors();
            PopulateUpperMaps();
            PopulateBonusTerrain();
            PopulateRandomObjects();
            PopulateObjects();
            PopulateFireplaces();
            PopulateContainers();
            PopulateVendors();
        }
        private static void PopulateGenders()
        {
            Genders.Add(new Gender(GENDER_ID_MALE, "Male"));
            Genders.Add(new Gender(GENDER_ID_FEMALE, "Female"));
            Genders.Add(new Gender(GENDER_ID_RETARDED, "Retarded"));
        }
        private static void PopulateRaces()
        {
            Races.Add(new Race(RACE_ID_ANGELS, "Angel", 6, 30, 20, 10, 4, 20, 10, 10, 18, 60, 60, 60, "Angel.png", "Holy beings that descended from heaven to find the World Fruit."));
            Races.Add(new Race(RACE_ID_DEMONS, "Demon", 10, 50, 10, 40, 10, 30, 30, 40, 9, 30, 20, 40, "Demon.png", "Twisted and furious demons came from the depths of hell to steal the World Fruit to themselves"));
            Races.Add(new Race(RACE_ID_ELFS, "Elf", 6, 20, 20, 20, 7, 20, 20, 30, 12, 50, 30, 40, "Elf.png", "High race that lives in the forests and rarely makes contacts with other races."));
            Races.Add(new Race(RACE_ID_DWARFS, "Dvarf", 15, 60, 60, 30, 4, 10, 10, 20, 4, 0, 40, 0, "Dwarf.png", "Dwarfs spend most of their living underground and searching for gold. Their greed does not have bounds."));
            Races.Add(new Race(RACE_ID_NEKOA, "Nekoa", 8, 30, 20, 30, 9, 40, 20, 30, 6, 20, 20, 20, "Nekoa.png", "Swift, Catlike creatures. Efficient hunters. Ussually act like stupid little shits. Cute tho."));
            Races.Add(new Race(RACE_ID_WARHOGS, "Warhog", 14, 60, 50, 30, 6, 10, 30, 20, 2, 0, 20, 0, "Warhog.png", "Piglike creatures. Good Warriors that only like food more than fighting."));
            Races.Add(new Race(RACE_ID_FAIRIES, "Fairie", 3, 10, 10, 10, 3, 20, 10, 0, 14, 50, 50, 40, "", ""));
            Races.Add(new Race(RACE_ID_DRAQUAS, "Draqua", 8, 30, 20, 30, 6, 20, 20, 20, 6, 20, 20, 20, "", ""));
            Races.Add(new Race(RACE_ID_MINOTAURS, "Minotaur", 13, 60, 40, 30, 4, 10, 10, 20, 1, 0, 10, 0, "Minotaur.png", "Minotaurs are a race that is quite calm despite their looks. They are really hard workers."));
            Races.Add(new Race(RACE_ID_SPIRITS, "Spirit", 3, 10, 10, 10, 8, 50, 20, 10, 6, 20, 20, 20, "", ""));
            Races.Add(new Race(RACE_ID_TREANTS, "Treant", 10, 40, 40, 20, 2, 10, 10, 0, 3, 10, 10, 10, "Treant.png", "Magical wood peaople. They live for hundreds of years and tend to remain neutral in wars."));
            Races.Add(new Race(RACE_ID_SEAKIN, "Seakin", 4, 20, 10, 10, 4, 20, 20, 0, 6, 20, 20, 20, "Seakin.png", "Underwater creatures that were once banished from the surface. They are always looking for opportunities to return."));
            Races.Add(new Race(RACE_ID_UNBURNT, "Unburnt", 4, 20, 10, 10, 3, 10, 20, 0, 6, 20, 20, 20, "Unburnt.png", "Race that evolved from monsters taht were created from ashes of dead warriors."));
            Races.Add(new Race(RACE_ID_HUMANS, "Human", 6, 20, 20, 20, 3, 10, 20, 0, 2, 0, 20, 0, "Human.png", "Advanced monkeys. Humans are everywhere despite being one of the weakest."));
            Races.Add(new Race(RACE_ID_GOBLINS, "Goblin", 4, 10, 10, 20, 4, 10, 20, 10, 1, 0, 10, 0, "Goblin.png", "Sneaky little shits."));
            Races.Add(new Race(RACE_ID_UPOS, "UPOS", 4, 10, 10, 20, 3, 10, 20, 0, 10, 0, 10, 0, "", ""));
        }
        private static void PopulateClasses()
        {
            //info unfinished
            Classes.Add(new Class(CLASS_ID_SWORDSMAN, "Swordsman", 11, 40, 40, 30, 2, 10, 10, 0, 2, 10, 10, 0, "This class uses a sword to figh. Swordsmen have high Strengh stats but not a lot of Agility or Intelligence."));
            Classes.Add(new Class(CLASS_ID_ARCHER, "Archer", 4, 0, 0, 40, 6, 20, 20, 20, 3, 20, 0, 10, ""));
            Classes.Add(new Class(CLASS_ID_ROGUE, "Rogue", 4, 10, 0, 30, 9, 30, 30, 30, 2, 10, 10, 0, "Fast, silent and deadly. Good for assassinations and quick bursts of damage. High agility stats."));
            Classes.Add(new Class(CLASS_ID_MAGE, "Mage", 0, 0, 0, 0, 0, 0, 0, 0, 13, 50, 40, 40, ""));
            Classes.Add(new Class(CLASS_ID_MONK, "Monk", 7, 40, 0, 30, 4, 30, 10, 0, 2, 10, 10, 0, "Calm and disciplined. Quick to dodge and hard to kill."));
            Classes.Add(new Class(CLASS_ID_PALADIN, "Paladin", 11, 60, 40, 10, 0, 0, 0, 0, 4, 10, 30, 10, "Hardest to ill. Pure tanks. Can take both physical and magical attacks."));
            Classes.Add(new Class(CLASS_ID_BRAWLER, "Brawler", 9, 30, 30, 30, 4, 20, 20, 0, 2, 10, 10, 0, "Balanced meelee fighters that can take anyone 1v1."));
            Classes.Add(new Class(CLASS_ID_EXECUTIONER, "Executioner", 6, 10, 10, 40, 4, 0, 10, 30, 2, 10, 10, 0, "High Damage and barely any defenses. Can tae a few hits but go down easy."));
            Classes.Add(new Class(CLASS_ID_REAPER, "Reaper", 4, 0, 0, 40, 9, 30, 30, 30, 2, 10, 0, 10, "Has no defenses but are Hard to deal with because of their evasion. Biggest damage out of everyone"));
            Classes.Add(new Class(CLASS_ID_GUNSLINGER, "Gunslinger", 3, 0, 0, 30, 7, 0, 40, 30, 2, 10, 10, 0, ""));
            Classes.Add(new Class(CLASS_ID_ENGINEER, "Engineer", 8, 40, 20, 20, 2, 0, 0, 20, 4, 20, 0, 20, "Ussually do not fight themselves but can 1v1"));
            Classes.Add(new Class(CLASS_ID_BEASTMASTER, "Beastmaster", 8, 40, 20, 0, 1, 0, 10, 0, 4, 40, 0, 0, ""));
            Classes.Add(new Class(CLASS_ID_BARD, "Bard", 4, 20, 10, 10, 1, 0, 0, 10, 7, 40, 20, 10, ""));
            Classes.Add(new Class(CLASS_ID_JIHADIST, "Jihadist", 8, 0, 0, 80, 0, 0, 0, 0, 4, 20, 0, 20, ""));
            Classes.Add(new Class(CLASS_ID_VILLAGER, "Villager", 4, 20, 5, 5, 1, 0, 0, 0, 0, 0, 0, 0, "They arent fighters. Low stats. Do not pick this ffs."));
            Classes.Add(new Class(CLASS_ID_NONE, "None", 5, 20, 10, 20, 3, 10, 10, 10, 3, 10, 10, 10, ""));
        }
        private static void PopulateTerrains()
        {
            Terrains.Add(new Terrain(1, "Plane", "Planes1.jpg", true));
            Terrains.Add(new Terrain(2, "Water", "Water1.jpg", false));
            Terrains.Add(new Terrain(3, "Floor", "Floor1.jpg", true));
            Terrains.Add(new Terrain(4, "Black", "Black.jpg", false));
            Terrains.Add(new Terrain(5, "Wood house part", "Wood1Bottom.png", false));
            Terrains.Add(new Terrain(6, "Wood house part", "Wood1BottomLeftCorner.png", false));
            Terrains.Add(new Terrain(7, "Wood house part", "Wood1BottomRightCorner.png", false));
            Terrains.Add(new Terrain(8, "Wood house part", "Wood1DoorMiddle.png", true));
            Terrains.Add(new Terrain(9, "Wood house part", "Wood1Left.png", false));
            Terrains.Add(new Terrain(10, "Wood house part", "Wood1Middle.png", false));
            Terrains.Add(new Terrain(11, "Wood house part", "Wood1Right.png", false));
            Terrains.Add(new Terrain(12, "Wood house part", "Wood1Top.png", false));
            Terrains.Add(new Terrain(13, "Path", "Planes1Path3RightBottomLeft.jpg", true));
            Terrains.Add(new Terrain(14, "Path", "Planes1Path3TopBottomLeft.jpg", true));
            Terrains.Add(new Terrain(15, "Path", "Planes1Path3TopRightBottom.jpg", true));
            Terrains.Add(new Terrain(16, "Path", "Planes1Path3TopRightLeft.jpg", true));
            Terrains.Add(new Terrain(17, "Path", "Planes1Path4Way.jpg", true));
            Terrains.Add(new Terrain(18, "Path", "Planes1PathEndBottom.jpg", true));
            Terrains.Add(new Terrain(19, "Path", "Planes1PathEndLeft.jpg", true));
            Terrains.Add(new Terrain(20, "Path", "Planes1PathEndRight.jpg", true));
            Terrains.Add(new Terrain(21, "Path", "Planes1PathEndTop.jpg", true));
            Terrains.Add(new Terrain(22, "Path", "Planes1PathHorizontal.jpg", true));
            Terrains.Add(new Terrain(23, "Path", "Planes1PathTurnBottomLeft.jpg", true));
            Terrains.Add(new Terrain(24, "Path", "Planes1PathTurnBottomRight.jpg", true));
            Terrains.Add(new Terrain(25, "Path", "Planes1PathTurnTopLeft.jpg", true));
            Terrains.Add(new Terrain(26, "Path", "Planes1PathTurnTopRight.jpg", true));
            Terrains.Add(new Terrain(27, "Path", "Planes1PathVertical.jpg", true));
            Terrains.Add(new Terrain(28, "Wood house part", "Wood1DoorDouble1.png", true));
            Terrains.Add(new Terrain(29, "Wood house part", "Wood1DoorDouble2.png", true));
            Terrains.Add(new Terrain(30, "Damaged Grass", "Planes1Damaged.jpg", true));
        }
        private static void PopulateMaps()
        {
            int[,] M1 = {   {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
            Maps.Add(new Map(1, "Starting Place", M1));
            int[,] M2 = {   {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 11, 10, 9, 1, 1, 1, 1, 1},
                            {1, 11, 10, 10, 9, 1, 7, 8, 6, 1, 11, 10, 9, 1},
                            {1, 7, 29, 28, 6, 1, 1, 21, 1, 1, 7, 8, 6, 1},
                            {1, 1, 23, 19, 1, 1, 1, 27, 1, 1, 1, 21, 1, 1},
                            {1, 1, 27, 1, 1, 1, 1, 27, 1, 1, 1, 27, 1, 1},
                            {1, 1, 27, 1, 1, 1, 1, 27, 1, 1, 1, 27, 1, 1},
                            {1, 1, 25, 22, 22, 22, 22, 16, 22, 22, 22, 26, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
            Maps.Add(new Map(2, "Planes", M2));
            int[,] M3 = {   {4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                            {4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                            {4, 4, 4, 7, 5, 5, 5, 5, 5, 6, 4, 4, 4, 4},
                            {4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4},
                            {4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4},
                            {4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4},
                            {4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4},
                            {4, 4, 4, 7, 5, 5, 8, 5, 5, 6, 4, 4, 4, 4},
                            {4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                            {4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4}};
            Maps.Add(new Map(3, "House1", M3));
            Maps.Add(new Map(4, "House2", M3));
            int[,] M5 = {   {4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                            {4, 4, 11, 10, 10, 10, 10, 10, 10, 10, 10, 9, 4, 4},
                            {4, 4, 7, 5, 5, 5, 5, 5, 5, 5, 5, 6, 4, 4},
                            {4, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4},
                            {4, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4},
                            {4, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4},
                            {4, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4},
                            {4, 4, 7, 5, 5, 5, 29, 28, 5, 5, 5, 6, 4, 4},
                            {4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                            {4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4}};
            Maps.Add(new Map(5, "TownHall", M5));
            int[,] M6 = {   {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 21, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 27, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 27, 1, 1, 1, 1, 1, 1, 21, 1, 1, 1},
                            {1, 1, 1, 27, 1, 1, 1, 1, 1, 1, 27, 1, 1, 1},
                            {1, 1, 1, 25, 22, 22, 22, 22, 22, 22, 16, 22, 19, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
            Maps.Add(new Map(6, "Path", M6));
            int[,] M7 = {   {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 30, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 30, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 30, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 30, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
            Maps.Add(new Map(7, "Forest", M7));
        }
        private static void PopulateConnections()
        {
            Connections.Add(new Connection(1, 2, 7, 133, 0, 0));
            Connections.Add(new Connection(1, 2, 8, 134, 0, 0));
            Connections.Add(new Connection(2, 1, 133, 7, 0, 0));
            Connections.Add(new Connection(2, 1, 134, 8, 0, 0));
            Connections.Add(new Connection(2, 3, 68, 91, 0, 0));
            Connections.Add(new Connection(3, 2, 105, 82, 0, 0));
            Connections.Add(new Connection(2, 4, 50, 91, 0, 0));
            Connections.Add(new Connection(4, 2, 105, 64, 0, 0));
            Connections.Add(new Connection(2, 6, 71, 83, 0, 0));
            Connections.Add(new Connection(6, 2, 84, 71, 0, 0));
            Connections.Add(new Connection(6, 7, 4, 130, 0, 0));
            Connections.Add(new Connection(7, 6, 130, 4, 0, 0));
            Connections.Add(new Connection(2, 5, 59, 91, 0, 0));
            Connections.Add(new Connection(2, 5, 60, 92, 0, 0));
            Connections.Add(new Connection(5, 2, 105, 73, 0, 0));
            Connections.Add(new Connection(5, 2, 106, 74, 0, 0));
        }
        private static void PopulateEnemies()
        {
            //Slimes
            Enemies.Add(new Enemy(1, 50, 10, 5, 171, "Slime", "Slime1.png", "Slime2.png", "Slime3.png", "Slime4.png", 28, 100, 10, 10, 6, 10, 10, 10, 0, 0, 0, 0, 12, 2, 2));
            Enemies.Add(new Enemy(1, 50, 10, 5, 171, "Slime", "Slime2.png", "Slime3.png", "Slime4.png", "Slime1.png", 28, 100, 10, 10, 6, 10, 10, 10, 0, 0, 0, 0, 3, 2, 2));
            Enemies.Add(new Enemy(1, 50, 10, 5, 171, "Slime", "Slime3.png", "Slime4.png", "Slime1.png", "Slime2.png", 28, 100, 10, 10, 6, 10, 10, 10, 0, 0, 0, 0, 10, 7, 2));
            Enemies.Add(new Enemy(1, 50, 10, 5, 171, "Slime", "Slime4.png", "Slime1.png", "Slime2.png", "Slime3.png", 28, 100, 10, 10, 6, 10, 10, 10, 0, 0, 0, 0, 5, 8, 2));
            Enemies.Add(new Enemy(1, 50, 10, 5, 171, "Slime", "Slime1.png", "Slime2.png", "Slime3.png", "Slime4.png", 28, 100, 10, 10, 6, 10, 10, 10, 0, 0, 0, 0, 9, 7, 1));
            Enemies.Add(new Enemy(1, 50, 10, 5, 171, "Slime", "Slime1.png", "Slime2.png", "Slime3.png", "Slime4.png", 28, 100, 10, 10, 6, 10, 10, 10, 0, 0, 0, 0, 12, 8, 6));
            //Bats
            Enemies.Add(new Enemy(2, 150, 25, 15, 172, "Bat", "Bat1.png", "Bat2.png", "Bat3.png", "Bat4.png", 38, 150, 20, 20, 9, 10, 20, 15, 0, 0, 0, 0, 3, 7, 6));
            Enemies.Add(new Enemy(2, 150, 25, 15, 172, "Bat", "Bat2.png", "Bat3.png", "Bat4.png", "Bat1.png", 38, 150, 20, 20, 9, 10, 20, 15, 0, 0, 0, 0, 6, 5, 6));
            Enemies.Add(new Enemy(2, 150, 25, 15, 172, "Bat", "Bat3.png", "Bat4.png", "Bat1.png", "Bat2.png", 38, 150, 20, 20, 9, 10, 20, 15, 0, 0, 0, 0, 5, 3, 6));
            //Toxic Slimes
            Enemies.Add(new Enemy(3, 450, 50, 40, 174, "ToxicSlime", "ToxicSlime3.png", "ToxicSlime4.png", "ToxicSlime1.png", "ToxicSlime2.png", 101, 450, 30, 25, 16, 25, 30, 25, 0, 0, 0, 0, 12, 6, 7));
            Enemies.Add(new Enemy(3, 450, 50, 40, 174, "ToxicSlime", "ToxicSlime4.png", "ToxicSlime1.png", "ToxicSlime2.png", "ToxicSlime3.png", 101, 450, 30, 25, 16, 25, 30, 25, 0, 0, 0, 0, 6, 3, 7));
            Enemies.Add(new Enemy(3, 450, 50, 40, 174, "ToxicSlime", "ToxicSlime1.png", "ToxicSlime2.png", "ToxicSlime3.png", "ToxicSlime4.png", 101, 450, 30, 25, 16, 25, 30, 25, 0, 0, 0, 0, 4, 5, 7));
            Enemies.Add(new Enemy(3, 450, 50, 40, 174, "ToxicSlime", "ToxicSlime2.png", "ToxicSlime3.png", "ToxicSlime4.png", "ToxicSlime1.png", 101, 450, 30, 25, 16, 25, 30, 25, 0, 0, 0, 0, 8, 8, 7));
        }
        private static void PopulateItems()
        {
            Items.Add(new Item(1, "Iron Sword", "Sword1transparent.png", "An ordinary sword made of iron. Even a newbie can use it.", "Sword", 10));
            Items.Add(new Item(3, "Iron Knife", "IronKnife.png", "Higher class adventurers use this knife to shave.", "Knife", 10));
            Items.Add(new Item(4, "Wooden bo", "WoodenBo.png", "Pretty much a stick.", "Bo", 10));
            Items.Add(new Item(6, "Wooden Shield", "WoodenShield.png", "Same amount of armor as a bucked lid.", "Shield", 10));
            Items.Add(new Item(7, "Iron Knuckles", "IronKnuckles.png", "Buy theese and get a portion of dumplings and an adidas tracksuit for free.", "Knuckles", 10));
            Items.Add(new Item(8, "Iron Axe", "IronAxe.png", "Chopping a head off will take a bit of time with this.", "Axe", 10));
            Items.Add(new Item(9, "Iron Scythe", "IronScythe.png", "Hay is super scared of this.", "Scythe", 10));
            Items.Add(new Item(11, "Iron Hammer", "IronHammer.png", "+5 in building.", "Hammer", 10));
            Items.Add(new Item(15, "Iron Hoe", "IronHoe.png", "For 5 gold a min I will plow you away.", "Hoe", 10));

            Items.Add(new Item(17, "Red Sword", "Sword1Red.png", "Demon blade from adventure time.", "Sword", 100));
            Items.Add(new Item(19, "Red Knife", "IronKnifeRed.png", "1000 degrees Celsius.", "Knife", 100));
            Items.Add(new Item(20, "Red bo", "WoodenBoRed.png", "Looks like a dark stick", "Bo", 100));
            Items.Add(new Item(22, "Red Shield", "WoodenShieldRed.png", "Looks like something from a crusade.", "Shield", 100));
            Items.Add(new Item(23, "Red Knuckles", "IronKnucklesRed.png", "When you are a real hood gangster.", "Knuckles", 100));
            Items.Add(new Item(24, "Red Axe", "IronAxeRed.png", "A lot of head were chopped using this.", "Axe", 100));
            Items.Add(new Item(25, "Red Scythe", "IronScytheRed.png", "There was someone in the hay.", "Scythe", 100));
            Items.Add(new Item(27, "Red Hammer", "IronHammerRed.png", "Our Hammer.", "Hammer", 100));
            Items.Add(new Item(31, "Red Hoe", "IronHoeRed.png", "Her name is Melisandre", "Hoe", 100));

            Items.Add(new Item(170, "Rusty Armor", "RustyArmor.png", "There is a hole because of rust. Better than nothing tho.", "Armor", 10));
            Items.Add(new Item(171, "Slime ball", "SlimeBall.png", "It is a slimeball. Useless", "Item", 1));
            Items.Add(new Item(172, "Bat wing", "BatWing.png", "People use bat wings as medicine.", "Item", 12));
            Items.Add(new Item(173, "Blue Armor", "BluePlate.png", "Quite the piece of armor.", "Armor", 100));
            Items.Add(new Item(174, "Toxic ball", "SlimeBall.png", "This ball is quite valuable since people make weapons out of theese.", "Item", 50));
        }
        private static void PopulateWeapons()
        {
            //Tier1
            Weapons.Add(new Weapon(1, 1, "Iron Sword", "Sword1transparent.png", 10, 20, 1, "An ordinary sword made of iron. Even a newbie can use it.", "Sword", 0, 1, 0, 0, 0, 10));
            Weapons.Add(new Weapon(3, 3, "Iron Knife", "IronKnife.png", 5, 15, 1, "Higher class adventurers use this knife to shave.", "Knife", 10, 2.0, 0, 0, 10, 10));
            Weapons.Add(new Weapon(5, 5, "Wooden Bo", "WoodenBo.png", 10, 15, 1, "Pretty much a stick.", "Bo", 15, 1.8, 5, 0, 5, 10));
            Weapons.Add(new Weapon(6, 6, "Wooden Shield", "WoodenShield.png", 0, 10, 1, "Same amount of armor as a bucked lid.", "Shield", 0, 1, 20, 10, 5, 10));
            Weapons.Add(new Weapon(7, 7, "Iron Knuckles", "IronKnuckles.png", 10, 15, 1, "Buy theese and get a portion of dumplings and an adidas tracksuit for free.", "Knuckles", 50, 1.2, 0, 0, 5, 10));
            Weapons.Add(new Weapon(8, 8, "Iron Axe", "IronAxe.png", 0, 20, 1, "Chopping a head off will take a bit of time with this.", "Axe", 40, 1.3, 10, 10, 0, 10));
            Weapons.Add(new Weapon(9, 9, "Iron Scythe", "IronScythe.png", 0, 30, 1, "Hay is super scared of this.", "Scythe", 5, 5.0, 0, 0, 10, 10));
            Weapons.Add(new Weapon(11, 11, "Iron Hammer", "IronHammer.png", 5, 10, 1, "+5 in building.", "Hammer", 0, 0, 5, 0, 10, 10));
            Weapons.Add(new Weapon(15, 15, "Iron Hoe", "IronHoe.png", 0, 5, 1, "For 5 gold a min I will plow you away.", "Hoe", 1, 2, 0, 0, 0, 10));
            //Tier2
            Weapons.Add(new Weapon(1, 17, "Red Sword", "Sword1Red.png", 20, 40, 5, "Demon blade from adventure time.", "Sword", 0, 1, 0, 0, 0, 20));
            Weapons.Add(new Weapon(3, 19, "Red Knife", "IronKnifeRed.png", 10, 30, 5, "1000 degrees Celsius.", "Knife", 15, 2.2, 0, 0, 15, 20));
            Weapons.Add(new Weapon(5, 20, "Steel Bo", "WoodenBoRed.png", 20, 30, 5, "Looks like a dark stick", "Bo", 20, 1.9, 10, 0, 10, 20));
            Weapons.Add(new Weapon(6, 22, "Red Shield", "WoodenShieldRed.png", 0, 15, 5, "Looks like something from a crusade.", "Shield", 0, 1, 50, 20, 5, 20));
            Weapons.Add(new Weapon(7, 23, "Red Knuckles", "IronKnucklesRed.png", 15, 25, 5, "When you are a real hood gangster.", "Knuckles", 50, 1.3, 0, 0, 10, 20));
            Weapons.Add(new Weapon(8, 24, "Red Axe", "IronAxeRed.png", 0, 45, 5, "A lot of head were chopped using this.", "Axe", 40, 1.3, 10, 10, 5, 20));
            Weapons.Add(new Weapon(9, 25, "Red Scythe", "IronScytheRed.png", 0, 60, 5, "There was someone in the hay.", "Scythe", 7, 7.5, 0, 0, 10, 20));
            Weapons.Add(new Weapon(11, 27, "Red Hammer", "IronHammerRed.png", 10, 25, 5, "Our Hammer.", "Hammer", 0, 0, 10, 0, 10, 20));
            Weapons.Add(new Weapon(15, 31, "Red Hoe", "IronHoeRed.png", 0, 10, 5, "Her name is Melisandre", "Hoe", 1, 5, 0, 0, 0, 20));
        }
        private static void PopulateQuests()
        {
            Quests.Add(new Quest(1, "Slime slaying", 1, 3, NO_ITEM_ID, NO_ITEMS, TALK_TO_NOONE, "",  170, 1, 20, 30));
            Quests.Add(new Quest(2, "Talk to Steve", NO_MONSTER_ID, NO_MONSTERS, NO_ITEM_ID, NO_ITEMS, 1, "Steve: Oh thanks for telling me. I am glad she is alright.",  NO_REWARD_ITEM, NO_REWARD_ITEMS, 20, 40));
        }
        private static void PopulateNPCs()
        {
            NPCs.Add(new NPC(1, "Steve", "Steve.png", "Those stupid slimes are everywhere. Please do something about it.", 1, "Thanks for slaying those bastards. Here is the reward.", "I heard there are free items in the smithery.", 3, 46));
            NPCs.Add(new NPC(2, "Alex", "Alex.png", "I haven't been back in a while. Can you tell Steve that I am all right.", 2, "Great. Now he doesn't need to worry..", "Beware of the bats here. They will dish out quite the damage.", 6, 107));
            NPCs.Add(new NPC(3, "Simon", "Character2Transparent.png", "The path ahead will be harder.", 0, "The path ahead will be harder.", "The path ahead will be harder.  I just gotta build it first.", 2, 100));
            NPCs.Add(new NPC(4, "Mayor", "Mayor.png", "", 0, "", "Welcome to our town adventurer. Please look around", 2, 75));
            NPCs.Add(new NPC(5, "Adventurer", "Character3Transparent.png", "", 0, "", "Those slimes over there are quite dangerous", 7, 86));
        }
        private static void PopulateArmors()
        {
            Armors.Add(new Armor(0, 170, "Rusty Armor", "RustyArmor.png", 30, 15, 3, "Terrible piece of armor. Better than nothing tho.", "Armor", 20));
            Armors.Add(new Armor(0, 173, "Blue Armor", "BluePlate.png", 100, 50, 5, "Quite the piece of armor.", "Armor", 100));
        }
        private static void PopulateBonusTerrain()
        {
            BonusTerrain.Add(new RandomObject(1, "Upper Tree", "Tree1Top.png"));
            BonusTerrain.Add(new RandomObject(2, "Bottom Tree", "Tree1Bottom.png"));
            BonusTerrain.Add(new RandomObject(3, "Tree on tree", "Tree1OnTree.png"));
            BonusTerrain.Add(new RandomObject(4, "Wood Roof", "Wood1RoofBottomLeft.png"));
            BonusTerrain.Add(new RandomObject(5, "Wood Roof", "Wood1RoofBottomRight.png"));
            BonusTerrain.Add(new RandomObject(6, "Wood Roof", "Wood1RoofTopLeft.png"));
            BonusTerrain.Add(new RandomObject(7, "Wood Roof", "Wood1RoofTopRight.png"));
            BonusTerrain.Add(new RandomObject(8, "Wood Roof", "Wood1RoofMiddleBottom.png"));
            BonusTerrain.Add(new RandomObject(9, "Wood Roof", "Wood1RoofMiddleTop.png"));
            BonusTerrain.Add(new RandomObject(10, "Window", "Window1.png"));
            BonusTerrain.Add(new RandomObject(11, "Table", "Table1Full.png"));
            BonusTerrain.Add(new RandomObject(12, "Bed", "Bed1.png"));
            BonusTerrain.Add(new RandomObject(13, "Anvil", "Anvil1.png"));
            BonusTerrain.Add(new RandomObject(14, "Stump", "Stump1Axe.png"));
            BonusTerrain.Add(new RandomObject(15, "Vendor Stall", "Vendor1Left.png"));
            BonusTerrain.Add(new RandomObject(16, "Vendor Stall", "Vendor1Middle.png"));
            BonusTerrain.Add(new RandomObject(17, "Vendor Stall", "Vendor1Right.png"));
            BonusTerrain.Add(new RandomObject(18, "Vendor Stall", "Vendor2Left.png"));
            BonusTerrain.Add(new RandomObject(19, "Vendor Stall", "Vendor2Middle.png"));
            BonusTerrain.Add(new RandomObject(20, "Vendor Stall", "Vendor2Right.png"));
            BonusTerrain.Add(new RandomObject(21, "Vendor Stall", "VendorBottomLeftEmpty.png"));
            BonusTerrain.Add(new RandomObject(22, "Vendor Stall", "VendorBottomLeftGold.png"));
            BonusTerrain.Add(new RandomObject(23, "Vendor Stall", "VendorBottomRightEmpty.png"));
            BonusTerrain.Add(new RandomObject(24, "Vendor Stall", "VendorBottomRightGold.png"));
            BonusTerrain.Add(new RandomObject(25, "Banner", "Banner1Top.png"));
            BonusTerrain.Add(new RandomObject(26, "Banner", "Banner1Bottom.png"));
            BonusTerrain.Add(new RandomObject(27, "Vendor Stall", "VendorBottomMiddleEmpty.png"));
            BonusTerrain.Add(new RandomObject(28, "Vendor Stall", "VendorBottomMiddleGold.png"));
            BonusTerrain.Add(new RandomObject(29, "Table", "Table1Left.png"));
            BonusTerrain.Add(new RandomObject(30, "Table", "Table1Middle.png"));
            BonusTerrain.Add(new RandomObject(31, "Table", "Table1Right.png"));
        }
        private static void PopulateUpperMaps()
        {
            int[,] M1 = {   {3, 3, 3, 3, 3, 3, 0, 0, 3, 3, 3, 3, 3, 3},
                            {3, 3, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 3, 3},
                            {3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14, 0, 0, 3},
                            {3, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3},
                            {3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3},
                            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}};
            UpperMaps.Add(new UpperMap(1, "Starting PlaceU", M1));
            int[,] M2 = {   {3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3},
                            {3, 2, 0, 0, 0, 0, 7, 9, 6, 0, 0, 0, 2, 3},
                            {3, 7, 9, 9, 6, 0, 5, 8, 4, 0, 7, 9, 6, 3},
                            {3, 5, 8, 8, 4, 0, 10, 0, 10, 0, 5, 8, 4, 3},
                            {2, 10, 0, 0, 10, 0, 0, 0, 0, 0, 10, 0, 10, 3},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3},
                            {3, 3, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 3, 3}};
            UpperMaps.Add(new UpperMap(2, "Village", M2));
            int[,] M3 = {   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 12, 0, 0, 11, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            UpperMaps.Add(new UpperMap(3, "House1", M3));
            int[,] M4 = {   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 13, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            UpperMaps.Add(new UpperMap(4, "House2", M4));
            int[,] M5 = {   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 25, 0, 0, 0, 0, 0, 0, 0, 0, 25, 0, 0},
                            {0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 26, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 31, 30, 30, 30, 30, 30, 30, 29, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            UpperMaps.Add(new UpperMap(5, "TownHall", M5));
            int[,] M6 = {   {3, 3, 3, 0, 3, 3, 3, 3, 3, 2, 2, 2, 3, 3},
                            {3, 3, 2, 0, 2, 2, 2, 2, 2, 17, 16, 15, 3, 3},
                            {3, 2, 0, 0, 0, 0, 0, 0, 0, 23, 27, 22, 2, 3},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                            {3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3},
                            {3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3},
                            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}};
            UpperMaps.Add(new UpperMap(6, "Path", M6));
            int[,] M7 = {   {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                            {3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3},
                            {3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                            {3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3},
                            {3, 3, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3},
                            {2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}};
            UpperMaps.Add(new UpperMap(7, "Path", M7));
        }
        private static void PopulateRandomObjects()
        {
            RandomObjects.Add(new RandomObject(1, "Chair", "Chair1Front.png"));
            RandomObjects.Add(new RandomObject(2, "Chair", "Chair1Back.png"));
            RandomObjects.Add(new RandomObject(3, "Chair", "Chair1Right.png"));
            RandomObjects.Add(new RandomObject(4, "Chair", "Chair1Left.png"));
            RandomObjects.Add(new RandomObject(5, "Pans", "Pans1.png"));
            RandomObjects.Add(new RandomObject(6, "Pan", "Pan1.png"));
            RandomObjects.Add(new RandomObject(7, "Mittens", "Mittens1.png"));
            RandomObjects.Add(new RandomObject(8, "Barrel", "Barrel1.png"));
            RandomObjects.Add(new RandomObject(9, "Sink", "Sink1.png"));
            RandomObjects.Add(new RandomObject(10, "Cover", "Cover1.png"));
            RandomObjects.Add(new RandomObject(11, "Cover", "Cover1OpenBottles.png"));
            RandomObjects.Add(new RandomObject(12, "Cover", "Cover1OpenPlates.png"));
            RandomObjects.Add(new RandomObject(13, "Flower", "Flower1.png"));
            RandomObjects.Add(new RandomObject(14, "Flower", "Flower2.png"));
            RandomObjects.Add(new RandomObject(15, "Flower", "Flower3.png"));
            RandomObjects.Add(new RandomObject(16, "Flower", "Flower4.png"));
        }
        private static void PopulateObjects()
        {
            int[,] M2 = {   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 13, 0, 0, 0, 0, 0, 13, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 16, 0, 0, 0, 0, 14, 0, 15, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Objects.Add(new UpperMap(2, "Village", M2));
            int[,] M3 = {   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 10, 11, 9, 0, 7, 6, 5, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 4, 0, 3, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Objects.Add(new UpperMap(3, "House1", M3));
            int[,] M4 = {   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 2, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Objects.Add(new UpperMap(4, "House2", M4));
            int[,] M5 = {   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0},
                            {0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0},
                            {0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Objects.Add(new UpperMap(5, "TownHall", M5));
            int[,] M6 = {   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 16, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Objects.Add(new UpperMap(6, "Forest1", M6));
        }
        private static void PopulateFireplaces()
        {
            Fireplaces.Add(new Fireplace(1, 4, 37, "Fireplace1.png", "Fireplace12.png"));
        }
        private static void PopulateContainers()
        {
            int[] C0 = { 173 };
            int[] C1 = {0};
            Containers.Add(new Container(1, "Chest", 4, 52, 0, 0, false, false, "Chest1Unoppened.png", "Chest1Oppened.png", C0, 10));
            Containers.Add(new Container(2, "Chest", 5, 45, 0, 0, false, false, "Chest1Unoppened.png", "Chest1Oppened.png", C1, 12));
            Containers.Add(new Container(3, "Chest", 5, 54, 0, 0, false, false, "Chest1Unoppened.png", "Chest1Oppened.png", C1, 15));
        }
        private static void PopulateVendors()
        {
            int[] I1 = { 17, 19, 20, 22, 23, 24, 25, 27, 31 };
            int[] P1 = { 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Vendors.Add(new Vendor(1, "Khajit", 6, 53, "Khajit has wares if you have coin ", I1, P1, "Khajit.png"));
        }
    }
}
