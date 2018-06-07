using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Threading;
using Engine;

namespace Game
{
    public partial class MainGameForm : Form
    {
        private string save;
        private int CurrentMapID = 1;
        private int CurrentVendor = -1;
        private int[,] CurrentMap = new int[14, 10];
        private static string project_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private string[] lines = project_path.Split('\\');
        public string image_path = "";
        public int characterPossitionY = 7;
        public int characterPossitionX = 7;
        private Player _player;
        private int[] Items = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] ItemQ = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private BackgroundWorker PassiveCounter = new BackgroundWorker();
        private bool[] PassiveCounterActive = { true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        private int[] PassiveCounterStart = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] PassiveCounterFinish = { 1, 5, 20, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private bool[] PassiveCounterCompleted = { false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        private BackgroundWorker Attacker0 = new BackgroundWorker();
        private BackgroundWorker Attacker1 = new BackgroundWorker();
        private BackgroundWorker Attacker2 = new BackgroundWorker();
        private BackgroundWorker Attacker3 = new BackgroundWorker();
        private int EnemyNumber = 0;
        private bool AvailableWalking = true;
        private int WeaponMaxDamage = 0;
        private int WeaponMinDamage = 0;
        private int WeaponCritChance = 0;
        private double WeaponCritMult = 0;
        private int BonusArmor = 0;
        private int BonusMagicResistance = 0;
        private int WeaponArmor = 0;
        private int WeaponMagicResistance = 0;
        private int WeaponArmorPenetration = 0;
        private int[] CompletedQuests = new int[100];
        
        private int CompletedQuestn = 0;
        private int[] CurrentQuests = { 0, 0, 0, 0, 0 };
        private int[] CurrentQuestO = { 0, 0, 0, 0, 0 };
        private int NPCQuest = 0;
        private int[] Spells = { 0, 0, 0, 0, 0 };
        private bool Fireplace = false;
        private int[] Levels = new int[100];
        private bool AvailableToChangeMaps = true;
        private bool[] ContainersOppened = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        private int BoutToChange = 0;

        public bool[] EnemyPresent = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public bool[] EnemyEngaged = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public int[] EnemyID = new int[15];
        public int[] EnemyLocations = new int[15];
        public int[] EnemyCurrentHP = new int[15];
        public int[] EnemyMaxHP = new int[15];
        public int[] EnemyDamage = new int[15];
        public int[] EnemyArmor = new int[15];
        public int[] EnemyArmorPenetration = new int[15];
        public int[] EnemyDroppedExp = new int[15];
        public int[] EnemyDroppedItem = new int[15];
        public int[] EnemyDroppedGold = new int[15];
        public int[] EnemyAttackSpeed = new int[15];
        public int[] EnemyEvasion = new int[15];
        public string[] EnemyImagess1 = new string[15];
        public string[] EnemyImagess2 = new string[15];
        public string[] EnemyImagess3 = new string[15];
        public string[] EnemyImagess4 = new string[15];
        public int[] EnemyImage = new int[15];
        public string[] EnemyName = new string[15];
        
        public MainGameForm()
        {
            InitializeComponent();
        }


        private void MainGameForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < CompletedQuests.Length; i++)
            {
                CompletedQuests[i] = 0;
            }
            StreamReader srS = new StreamReader("Save.txt");
            save = srS.ReadLine();
            Levels[0] = 50;
            for (int i = 1; i < 100; i++)
            {
                Levels[i] = (int)(Levels[i-1] * 1.1);
            }
            for (int i = 0; i < 140; i++)
            {
                ((PictureBox)this.Controls["pictureBox" + (i + 141).ToString()]).Location = new Point(0, 0);
            }
            for (int i = 0; i < 140; i++)
            {
                ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).Controls.Add(((PictureBox)this.Controls["pictureBox" + (i + 141).ToString()]));
            }
            for (int i = 0; i < lines.Length - 1; i++)
            {
                image_path = image_path + lines[i] + "\\";
            }
            image_path = image_path + "Engine\\Images\\";

            if (save == "No")
            {
                srS.Close();
                pbCharacter.Image = null;

                pictureBox231.Controls.Add(pbCharacter);
                pbCharacter.Location = new Point(0, 0);
                pbCharacter.BackColor = Color.Transparent;
                pbCharacter.Controls.Add(pbWeapon);
                pbWeapon.Location = new Point(0, 0);
                pbWeapon.BackColor = Color.Transparent;
                RefreshMap();

                StreamReader sr = new StreamReader("PlayerInfo.txt");
                _player = new Player(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                _player.GenderID = int.Parse(sr.ReadLine());
                _player.ClassID = int.Parse(sr.ReadLine());
                _player.RaceID = int.Parse(sr.ReadLine());

                _player.BaseStrengh = int.Parse(sr.ReadLine());
                _player.BaseHp = int.Parse(sr.ReadLine());
                _player.CurrentHitPoints = _player.BaseHp;
                _player.BaseArmor = int.Parse(sr.ReadLine());
                _player.BaseAttackDamage = int.Parse(sr.ReadLine());

                _player.BaseAgility = int.Parse(sr.ReadLine());
                _player.BaseEvasion = int.Parse(sr.ReadLine());
                _player.BaseAttackSpeed = int.Parse(sr.ReadLine());
                _player.BaseArmorPenetration = int.Parse(sr.ReadLine());

                _player.BaseIntelligence = int.Parse(sr.ReadLine());
                _player.BaseMagicDefense = int.Parse(sr.ReadLine());
                _player.BaseMagicPenetration = int.Parse(sr.ReadLine());
                _player.BaseMagicPower = int.Parse(sr.ReadLine());

                _player.ClassName = sr.ReadLine();
                _player.GenderName = sr.ReadLine();
                _player.RaceName = sr.ReadLine();

                sr.Close();

                StreamWriter swGE = new StreamWriter("GoldExp.txt");
                swGE.WriteLine(0);
                swGE.WriteLine(0);
                swGE.WriteLine(1);
                swGE.Close();

                if (_player.ClassID == 1)
                {
                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.Type == "Weapon" && s.ID == 1)
                        {
                            StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                            sw.WriteLine(s.Class);
                            sw.WriteLine(s.ID);
                            sw.WriteLine(s.ImageAdress);
                            sw.WriteLine(s.Info);
                            sw.WriteLine(s.Lvl);
                            sw.WriteLine(s.MaxDmg);
                            sw.WriteLine(s.MinDmg);
                            sw.WriteLine(s.Name);
                            sw.WriteLine(s.CritChance);
                            sw.WriteLine(s.CritMult);
                            sw.WriteLine(s.Armor);
                            sw.WriteLine(s.MagicDefense);
                            sw.WriteLine(s.ArmorPenetration);
                            sw.Close();
                        }
                    }
                    AddItem(1);
                }

                if (_player.ClassID == 3)
                {
                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.Type == "Weapon" && s.ID == 3)
                        {
                            StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                            sw.WriteLine(s.Class);
                            sw.WriteLine(s.ID);
                            sw.WriteLine(s.ImageAdress);
                            sw.WriteLine(s.Info);
                            sw.WriteLine(s.Lvl);
                            sw.WriteLine(s.MaxDmg);
                            sw.WriteLine(s.MinDmg);
                            sw.WriteLine(s.Name);
                            sw.WriteLine(s.CritChance);
                            sw.WriteLine(s.CritMult);
                            sw.WriteLine(s.Armor);
                            sw.WriteLine(s.MagicDefense);
                            sw.WriteLine(s.ArmorPenetration);
                            sw.Close();
                        }
                    }
                    AddItem(3);
                }

                if (_player.ClassID == 5)
                {
                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.Type == "Weapon" && s.ID == 5)
                        {
                            StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                            sw.WriteLine(s.Class);
                            sw.WriteLine(s.ID);
                            sw.WriteLine(s.ImageAdress);
                            sw.WriteLine(s.Info);
                            sw.WriteLine(s.Lvl);
                            sw.WriteLine(s.MaxDmg);
                            sw.WriteLine(s.MinDmg);
                            sw.WriteLine(s.Name);
                            sw.WriteLine(s.CritChance);
                            sw.WriteLine(s.CritMult);
                            sw.WriteLine(s.Armor);
                            sw.WriteLine(s.MagicDefense);
                            sw.WriteLine(s.ArmorPenetration);
                            sw.Close();
                        }
                    }
                    AddItem(5);
                }

                if (_player.ClassID == 6)
                {
                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.Type == "Weapon" && s.ID == 6)
                        {
                            StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                            sw.WriteLine(s.Class);
                            sw.WriteLine(s.ID);
                            sw.WriteLine(s.ImageAdress);
                            sw.WriteLine(s.Info);
                            sw.WriteLine(s.Lvl);
                            sw.WriteLine(s.MaxDmg);
                            sw.WriteLine(s.MinDmg);
                            sw.WriteLine(s.Name);
                            sw.WriteLine(s.CritChance);
                            sw.WriteLine(s.CritMult);
                            sw.WriteLine(s.Armor);
                            sw.WriteLine(s.MagicDefense);
                            sw.WriteLine(s.ArmorPenetration);
                            sw.Close();
                        }
                    }
                    AddItem(6);
                }

                if (_player.ClassID == 7)
                {
                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.Type == "Weapon" && s.ID == 7)
                        {
                            StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                            sw.WriteLine(s.Class);
                            sw.WriteLine(s.ID);
                            sw.WriteLine(s.ImageAdress);
                            sw.WriteLine(s.Info);
                            sw.WriteLine(s.Lvl);
                            sw.WriteLine(s.MaxDmg);
                            sw.WriteLine(s.MinDmg);
                            sw.WriteLine(s.Name);
                            sw.WriteLine(s.CritChance);
                            sw.WriteLine(s.CritMult);
                            sw.WriteLine(s.Armor);
                            sw.WriteLine(s.MagicDefense);
                            sw.WriteLine(s.ArmorPenetration);
                            sw.Close();
                        }
                    }
                    AddItem(7);
                }

                if (_player.ClassID == 8)
                {
                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.Type == "Weapon" && s.ID == 8)
                        {
                            StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                            sw.WriteLine(s.Class);
                            sw.WriteLine(s.ID);
                            sw.WriteLine(s.ImageAdress);
                            sw.WriteLine(s.Info);
                            sw.WriteLine(s.Lvl);
                            sw.WriteLine(s.MaxDmg);
                            sw.WriteLine(s.MinDmg);
                            sw.WriteLine(s.Name);
                            sw.WriteLine(s.CritChance);
                            sw.WriteLine(s.CritMult);
                            sw.WriteLine(s.Armor);
                            sw.WriteLine(s.MagicDefense);
                            sw.WriteLine(s.ArmorPenetration);
                            sw.Close();
                        }
                    }
                    AddItem(8);
                }

                if (_player.ClassID == 9)
                {
                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.Type == "Weapon" && s.ID == 9)
                        {
                            StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                            sw.WriteLine(s.Class);
                            sw.WriteLine(s.ID);
                            sw.WriteLine(s.ImageAdress);
                            sw.WriteLine(s.Info);
                            sw.WriteLine(s.Lvl);
                            sw.WriteLine(s.MaxDmg);
                            sw.WriteLine(s.MinDmg);
                            sw.WriteLine(s.Name);
                            sw.WriteLine(s.CritChance);
                            sw.WriteLine(s.CritMult);
                            sw.WriteLine(s.Armor);
                            sw.WriteLine(s.MagicDefense);
                            sw.WriteLine(s.ArmorPenetration);
                            sw.Close();
                        }
                    }
                    AddItem(9);
                }

                if (_player.ClassID == 11)
                {
                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.Type == "Weapon" && s.ID == 11)
                        {
                            StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                            sw.WriteLine(s.Class);
                            sw.WriteLine(s.ID);
                            sw.WriteLine(s.ImageAdress);
                            sw.WriteLine(s.Info);
                            sw.WriteLine(s.Lvl);
                            sw.WriteLine(s.MaxDmg);
                            sw.WriteLine(s.MinDmg);
                            sw.WriteLine(s.Name);
                            sw.WriteLine(s.CritChance);
                            sw.WriteLine(s.CritMult);
                            sw.WriteLine(s.Armor);
                            sw.WriteLine(s.MagicDefense);
                            sw.WriteLine(s.ArmorPenetration);
                            sw.Close();
                        }
                    }
                    AddItem(11);
                }

                if (_player.ClassID == 15)
                {
                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.Type == "Weapon" && s.ID == 15)
                        {
                            StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                            sw.WriteLine(s.Class);
                            sw.WriteLine(s.ID);
                            sw.WriteLine(s.ImageAdress);
                            sw.WriteLine(s.Info);
                            sw.WriteLine(s.Lvl);
                            sw.WriteLine(s.MaxDmg);
                            sw.WriteLine(s.MinDmg);
                            sw.WriteLine(s.Name);
                            sw.WriteLine(s.CritChance);
                            sw.WriteLine(s.CritMult);
                            sw.WriteLine(s.Armor);
                            sw.WriteLine(s.MagicDefense);
                            sw.WriteLine(s.ArmorPenetration);
                            sw.Close();
                        }
                    }
                    AddItem(15);
                }

                PassiveCounter.DoWork += (obj, ea) => PassiveCounterVoid();
                PassiveCounter.RunWorkerAsync();

                dgvQuests.RowHeadersVisible = false;
                dgvQuests.AutoGenerateColumns = false;
                dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Name",
                    Width = 96,
                    DataPropertyName = "Name"
                });
                dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Objective",
                    Width = 96,
                    DataPropertyName = "Objective"
                });
                dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Done?",
                    Width = 45,
                    DataPropertyName = "IsCompleted"
                });
                this.dgvQuests.Rows.Insert(0, "", "", "");
                this.dgvQuests.Rows.Insert(1, "", "", "");
                this.dgvQuests.Rows.Insert(2, "", "", "");
                this.dgvQuests.Rows.Insert(3, "", "", "");
                this.dgvQuests.Rows.Insert(4, "", "", "");
                dgvQuests.ClearSelection();

                foreach (Race s in World.Races)
                {
                    if (s.ID == _player.RaceID)
                    {
                        pbCharacter.BackgroundImage = new Bitmap(@image_path + s.ImageAdress);
                    }
                }
            }
            else
            {
                CurrentMapID = Int32.Parse(srS.ReadLine());
                characterPossitionX = Int32.Parse(srS.ReadLine());
                characterPossitionY = Int32.Parse(srS.ReadLine());

                srS.Close();
                _player = new Player(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                StreamReader srGE = new StreamReader("GoldExp.txt");
                _player.Gold = Int32.Parse(srGE.ReadLine());
                _player.ExperiencePoints = Int32.Parse(srGE.ReadLine());
                _player.Lvl = Int32.Parse(srGE.ReadLine());
                srGE.Close();

                pbCharacter.Image = null;

                pictureBox231.Controls.Add(pbCharacter);
                pbCharacter.Location = new Point(0, 0);
                pbCharacter.BackColor = Color.Transparent;
                pbCharacter.Controls.Add(pbWeapon);
                pbWeapon.Location = new Point(0, 0);
                pbWeapon.BackColor = Color.Transparent;

                StreamReader sr = new StreamReader("PlayerInfo.txt");
                _player = new Player(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                _player.GenderID = int.Parse(sr.ReadLine());
                _player.ClassID = int.Parse(sr.ReadLine());
                _player.RaceID = int.Parse(sr.ReadLine());

                _player.BaseStrengh = int.Parse(sr.ReadLine());
                _player.BaseHp = int.Parse(sr.ReadLine());
                _player.CurrentHitPoints = _player.BaseHp;
                _player.BaseArmor = int.Parse(sr.ReadLine());
                _player.BaseAttackDamage = int.Parse(sr.ReadLine());

                _player.BaseAgility = int.Parse(sr.ReadLine());
                _player.BaseEvasion = int.Parse(sr.ReadLine());
                _player.BaseAttackSpeed = int.Parse(sr.ReadLine());
                _player.BaseArmorPenetration = int.Parse(sr.ReadLine());

                _player.BaseIntelligence = int.Parse(sr.ReadLine());
                _player.BaseMagicDefense = int.Parse(sr.ReadLine());
                _player.BaseMagicPenetration = int.Parse(sr.ReadLine());
                _player.BaseMagicPower = int.Parse(sr.ReadLine());

                _player.ClassName = sr.ReadLine();
                _player.GenderName = sr.ReadLine();
                _player.RaceName = sr.ReadLine();

                sr.Close();

                _player.BaseAgility = _player.BaseAgility + _player.BaseAgility / (_player.Lvl + 4);
                _player.BaseArmor = _player.BaseArmor + _player.BaseArmor / (_player.Lvl + 4);
                _player.BaseArmorPenetration = _player.BaseArmorPenetration + _player.BaseArmorPenetration / (_player.Lvl + 4);
                _player.BaseAttackDamage = _player.BaseAttackDamage + _player.BaseAttackDamage / (_player.Lvl + 4);
                _player.BaseAttackSpeed = _player.BaseAttackSpeed + _player.BaseAttackSpeed / (_player.Lvl + 4);
                _player.BaseEvasion = _player.BaseEvasion + _player.BaseEvasion / (_player.Lvl + 4);
                _player.BaseHp = _player.BaseHp + _player.BaseHp / (_player.Lvl + 4);
                _player.BaseIntelligence = _player.BaseIntelligence + _player.BaseIntelligence / (_player.Lvl + 4);
                _player.BaseMagicDefense = _player.BaseMagicDefense + _player.BaseMagicDefense / (_player.Lvl + 4);
                _player.BaseMagicPenetration = _player.BaseMagicPenetration + _player.BaseMagicPenetration / (_player.Lvl + 4);
                _player.BaseMagicPower = _player.BaseMagicPower + _player.BaseMagicPower / (_player.Lvl + 4);
                _player.BaseStrengh = _player.BaseStrengh + _player.BaseStrengh / (_player.Lvl + 4);
                _player.CurrentHitPoints = _player.CurrentHitPoints + _player.CurrentHitPoints / (_player.Lvl + 4);

                PassiveCounter.DoWork += (obj, ea) => PassiveCounterVoid();
                PassiveCounter.RunWorkerAsync();

                dgvQuests.RowHeadersVisible = false;
                dgvQuests.AutoGenerateColumns = false;
                dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Name",
                    Width = 96,
                    DataPropertyName = "Name"
                });
                dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Objective",
                    Width = 96,
                    DataPropertyName = "Objective"
                });
                dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Done?",
                    Width = 45,
                    DataPropertyName = "IsCompleted"
                });
                this.dgvQuests.Rows.Insert(0, "", "", "");
                this.dgvQuests.Rows.Insert(1, "", "", "");
                this.dgvQuests.Rows.Insert(2, "", "", "");
                this.dgvQuests.Rows.Insert(3, "", "", "");
                this.dgvQuests.Rows.Insert(4, "", "", "");
                dgvQuests.ClearSelection();

                foreach (Race s in World.Races)
                {
                    if (s.ID == _player.RaceID)
                    {
                        pbCharacter.BackgroundImage = new Bitmap(@image_path + s.ImageAdress);
                    }
                }

                StreamReader srI = new StreamReader("Inventory.txt");
                for (int i = 0; i < 35; i++)
                {
                    Items[i] = Int32.Parse(srI.ReadLine());
                    ItemQ[i] = Int32.Parse(srI.ReadLine());
                }
                srI.Close();

                StreamReader srQ = new StreamReader("QuestsCompleted.txt");
                for (int i = 0; i < CompletedQuests.Length; i++)
                {
                    CompletedQuests[i] = Int32.Parse(srQ.ReadLine());
                }
                srQ.Close();

                StreamReader srC = new StreamReader("ContainersOppened.txt");
                for (int i = 0; i < ContainersOppened.Length; i++)
                {
                    int temp = Int32.Parse(srC.ReadLine());
                    if(temp == 1)
                    {
                        ContainersOppened[i] = true;
                        CompletedQuestn++;
                    }
                    else if (temp == 0)
                    {
                        ContainersOppened[i] = false;
                    }
                }
                srC.Close();

                UpdatePossition(characterPossitionX, characterPossitionY);
                RefreshMap();
            }
        }

        string FindTerrainAdress(int id)
        {
            string str = "";
            foreach (Terrain s in World.Terrains)
            {
                if (s.ID == id)
                {
                    str = s.ImageAdress;
                }
            }
            return str;
        }

        bool FindTerrainAccessibility(int id)
        {
            bool b = true;
            foreach (Terrain s in World.Terrains)
            {
                if (s.ID == id)
                {
                    b = s.Walkable;
                }
            }
            return b;
        }

        void RefreshMap()
        {
            foreach (Map s in World.Maps)
            {
                if (s.ID == CurrentMapID)
                {
                    EnemyLocations = new int [150];
                    for (int i = 0; i < 140; i++)
                    {
                        ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).BackgroundImage = new Bitmap(@image_path + FindTerrainAdress(s.TerrainID[i/14, i%14]));
                        ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = null;
                    }
                    for (int i = 0; i < 140; i++)
                    {
                        ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = null;
                    }
                    for (int i = 0; i < 15; i++)
                    {
                        EnemyPresent[i] = false;
                    }
                    for (int i = 0; i < 140; i++)
                    {
                        ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).Image = null;
                    }
                    UpdateObjects();
                    UpdateFireplaces();
                    PlaceContainers();
                    PlaceVendors();
                    FindEnemies(s.ID);
                    if (EnemyPresent[0])
                    {

                        Attacker0.DoWork += (obj, ea) => EnemyLocateAndAttackPlayer(0);
                        Attacker0.RunWorkerAsync();
                    }
                    if (EnemyPresent[1])
                    {
                        Attacker1.DoWork += (obj, ea) => EnemyLocateAndAttackPlayer(1);
                        Attacker1.RunWorkerAsync();
                    }
                    if (EnemyPresent[2])
                    {

                        Attacker2.DoWork += (obj, ea) => EnemyLocateAndAttackPlayer(2);
                        Attacker2.RunWorkerAsync();
                    }
                    if (EnemyPresent[3])
                    {

                        Attacker3.DoWork += (obj, ea) => EnemyLocateAndAttackPlayer(3);
                        Attacker3.RunWorkerAsync();
                    }
                    int z = 0;
                    while(EnemyLocations[z] > 0)
                    {
                        ((PictureBox)this.Controls["pictureBox" + (EnemyLocations[z]).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = new Bitmap(@image_path + EnemyImagess1[z]);
                        z++;
                    }
                    EnemyNumber = z;
                    foreach (NPC n in World.NPCs)
                    {
                        if (n.LocationMap == CurrentMapID)
                        {
                            int meh = n.LocationXY;
                            ((PictureBox)this.Controls["pictureBox" + (n.LocationXY).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = new Bitmap(@image_path + n.ImageAdress);
                        }
                    }
                }
            }
        }

        private void MainGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                richTextBox1.Text = "";
            }
            if (e.KeyCode == Keys.Up && characterPossitionY > 1 && AvailableWalking && AvailableToChangeMaps)
            {
                if (FindTerrainAccessibility(World.Maps[CurrentMapID - 1].TerrainID[characterPossitionY - 2, characterPossitionX - 1]) == true && CheckForObject(characterPossitionX, characterPossitionY - 1) == true)
                {
                    AvailableWalking = false;
                    characterPossitionY--;
                    UpdatePossition(characterPossitionX, characterPossitionY);
                    int z = CheckConnection(characterPossitionX + (characterPossitionY - 1) * 14);
                    if (z != -1 )
                    {
                        for (int i = 0; i < EnemyPresent.Length; i++)
                        {
                            EnemyPresent[i] = false;
                        }
                        /*var w = new Form() { Size = new Size(0, 0) };               //Alternative map change
                        Task.Delay(TimeSpan.FromSeconds(0.01))
                            .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show(w, "", "");
                        CurrentMapID = BoutToChange;
                        RefreshMap();
                        characterPossitionY = z / 14 + 1;
                        characterPossitionX = z % 14;
                        UpdatePossition(characterPossitionX, characterPossitionY);*/
                        for (int i = 0; i < EnemyPresent.Length; i++)
                        {
                            EnemyPresent[i] = false;
                        }
                        foreach (Map m in World.Maps)
                        {
                            if (m.ID == BoutToChange)
                            {
                                DialogResult dialogResult = MessageBox.Show("Go to another map?", "Warning!!", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    CurrentMapID = BoutToChange;
                                    RefreshMap();
                                    characterPossitionY = z / 14 + 1;
                                    characterPossitionX = z % 14;
                                    UpdatePossition(characterPossitionX, characterPossitionY);
                                }
                                else
                                {
                                    FindEnemies(CurrentMapID);
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Down && characterPossitionY < 10 && AvailableWalking && AvailableToChangeMaps)
            {
                if (FindTerrainAccessibility(World.Maps[CurrentMapID - 1].TerrainID[characterPossitionY, characterPossitionX - 1]) == true && CheckForObject(characterPossitionX, characterPossitionY + 1) == true)
                {
                    AvailableWalking = false;
                    characterPossitionY++;
                    UpdatePossition(characterPossitionX, characterPossitionY);
                    int z = CheckConnection(characterPossitionX + (characterPossitionY - 1) * 14);
                    if (z != -1)
                    {
                        for (int i = 0; i < EnemyPresent.Length; i++)
                        {
                            EnemyPresent[i] = false;
                        }
                        foreach (Map m in World.Maps)
                        {
                            if (m.ID == BoutToChange)
                            {
                                DialogResult dialogResult = MessageBox.Show("Go to another map?", "Warning!!", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    CurrentMapID = BoutToChange;
                                    RefreshMap();
                                    characterPossitionY = z / 14 + 1;
                                    characterPossitionX = z % 14;
                                    UpdatePossition(characterPossitionX, characterPossitionY);
                                }
                                else
                                {
                                    FindEnemies(CurrentMapID);
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Left && characterPossitionX < 14 && AvailableWalking && AvailableToChangeMaps)
            {
                if (FindTerrainAccessibility(World.Maps[CurrentMapID - 1].TerrainID[characterPossitionY - 1, characterPossitionX]) == true && CheckForObject(characterPossitionX + 1, characterPossitionY) == true)
                {
                    AvailableWalking = false;
                    characterPossitionX++;
                    UpdatePossition(characterPossitionX, characterPossitionY);
                    int z = CheckConnection(characterPossitionX + (characterPossitionY - 1) * 14);
                    if (z != -1 )
                    {
                        for (int i = 0; i < EnemyPresent.Length; i++)
                        {
                            EnemyPresent[i] = false;
                        }
                        foreach (Map m in World.Maps)
                        {
                            if (m.ID == BoutToChange)
                            {
                                DialogResult dialogResult = MessageBox.Show("Go to another map?", "Warning!!", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    CurrentMapID = BoutToChange;
                                    RefreshMap();
                                    characterPossitionY = z / 14 + 1;
                                    characterPossitionX = z % 14;
                                    UpdatePossition(characterPossitionX, characterPossitionY);
                                }
                                else
                                {
                                    FindEnemies(CurrentMapID);
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Right && characterPossitionX > 1 && AvailableWalking && AvailableToChangeMaps)
            {
                if (FindTerrainAccessibility(World.Maps[CurrentMapID - 1].TerrainID[characterPossitionY - 1, characterPossitionX - 2]) == true && CheckForObject(characterPossitionX - 1, characterPossitionY) == true)
                {
                    AvailableWalking = false;
                    characterPossitionX--;
                    UpdatePossition(characterPossitionX, characterPossitionY);
                    int z = CheckConnection(characterPossitionX + (characterPossitionY - 1) * 14);
                    if (z != -1)
                    {
                        for (int i = 0; i < EnemyPresent.Length; i++)
                        {
                            EnemyPresent[i] = false;
                        }
                        foreach (Map m in World.Maps)
                        {
                            if (m.ID == BoutToChange)
                            {
                                DialogResult dialogResult = MessageBox.Show("Go to another map?", "Warning!!", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    CurrentMapID = BoutToChange;
                                    RefreshMap();
                                    characterPossitionY = z / 14 + 1;
                                    characterPossitionX = z % 14;
                                    UpdatePossition(characterPossitionX, characterPossitionY);
                                }
                                else
                                {
                                    FindEnemies(CurrentMapID);
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.I)
            {
                Inventory f = new Inventory(Items, ItemQ);
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
            if (e.KeyCode == Keys.A)
            {
                if (PassiveCounterCompleted[10])
                {
                    PassiveCounterCompleted[10] = false;
                    PassiveCounterActive[10] = true;
                    PassiveCounterFinish[10] = (int)(25 * Math.Pow(0.99, Math.Sqrt(_player.BaseAttackSpeed)));
                    for (int i = 0; i < EnemyNumber; i++)
                    {
                        Random rnd = new Random();
                        int WeaponDamage = rnd.Next(WeaponMinDamage, WeaponMaxDamage+1);
                        int Critical = rnd.Next(0, 100);
                        if (Critical <= WeaponCritChance)
                        {
                            WeaponDamage = (int)(WeaponDamage * WeaponCritMult);
                        }
                        if (EnemyLocations[i] + 1 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[i] > 0 || EnemyLocations[i] - 1 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[i] > 0 || EnemyLocations[i] + 1 - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[i] > 0 || EnemyLocations[i] - 1 - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[i] > 0 || EnemyLocations[i] - 1 + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[i] > 0 || EnemyLocations[i] - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[i] > 0 || EnemyLocations[i] + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[i] > 0 || EnemyLocations[i] + 1 + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[i] > 0)
                        {
                            int z = rnd.Next(1, 100);
                            if (z > (100 * Math.Pow(0.99, Math.Sqrt(EnemyEvasion[i]))))
                            {
                                richTextBox1.Text = "The enemy evaded.\n" + richTextBox1.Text;
                            }
                            else
                            {
                                if (EnemyArmor[i] > _player.BaseArmorPenetration + WeaponArmorPenetration)
                                {
                                    EnemyCurrentHP[i] = EnemyCurrentHP[i] - (int)((_player.BaseAttackDamage + WeaponDamage) * Math.Pow(0.99, Math.Sqrt(EnemyArmor[i] - _player.BaseArmorPenetration - WeaponArmorPenetration)));
                                    richTextBox1.Text = "You have dealt " + ((int)((_player.BaseAttackDamage + WeaponDamage) * Math.Pow(0.99, Math.Sqrt(EnemyArmor[i] - _player.BaseArmorPenetration - WeaponArmorPenetration)))).ToString() + " to the " + EnemyName[i] + " \n" + richTextBox1.Text;
                                }
                                else
                                {
                                    EnemyCurrentHP[i] = EnemyCurrentHP[i] - _player.BaseAttackDamage - WeaponDamage;
                                    richTextBox1.Text = "You have dealt " + (_player.BaseAttackDamage + WeaponDamage).ToString() + " to the " + EnemyName[i] + " \n" + richTextBox1.Text;
                                }
                                EnemyEngaged[i] = true;
                                if (EnemyCurrentHP[i] <= 0)
                                {
                                    _player.ExperiencePoints = _player.ExperiencePoints + EnemyDroppedExp[i];
                                    _player.Gold = _player.Gold + EnemyDroppedGold[i];
                                    StreamWriter swGoldExp = new StreamWriter("GoldExp.txt");
                                    swGoldExp.WriteLine(_player.Gold);
                                    swGoldExp.WriteLine(_player.ExperiencePoints);
                                    swGoldExp.WriteLine(_player.Lvl);
                                    swGoldExp.Close();
                                    ((PictureBox)this.Controls["pictureBox" + (EnemyLocations[i]).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = null;
                                    richTextBox1.Text = "You have slayed the " + EnemyName[i] + "\n" + richTextBox1.Text;
                                    UpdateMonsterSlayingQuests(EnemyID[i]);
                                    PassiveCounterActive[7] = true;
                                    PassiveCounterFinish[7] = 25;
                                    EnemyPresent[i] = false;
                                    int DroppedItem = rnd.Next(0, 100);
                                    if (DroppedItem > 80 && EnemyDroppedItem[i] != 0)
                                    {
                                        AddItem(EnemyDroppedItem[i]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                if (CurrentQuests[i] == 0)
                {
                    CurrentQuests[i] = NPCQuest;
                    foreach (Quest s in World.Quests)
                    {
                        if (s.IDOfItemsToCollect != World.NO_ITEM_ID && NPCQuest == s.ID)
                        {
                            dgvQuests.Rows.RemoveAt(i);
                            CurrentQuestO[i] = s.NumberOfItemsToCollect;
                            this.dgvQuests.Rows.Insert(i, s.Name.ToString(), "Collect " + s.NumberOfItemsToCollect.ToString(), "Nope");
                        }
                        if (s.IDOfMonstersToSlay != World.NO_MONSTER_ID && NPCQuest == s.ID)
                        {
                            dgvQuests.Rows.RemoveAt(i);
                            CurrentQuestO[i] = s.NumberOfMonstersToSlay;
                            this.dgvQuests.Rows.Insert(i, s.Name.ToString(), "Slay " + s.NumberOfMonstersToSlay.ToString(), "Nope");
                        }
                        if (s.IDOfNPCToSpeak != World.TALK_TO_NOONE && NPCQuest == s.ID)
                        {
                            dgvQuests.Rows.RemoveAt(i);
                            CurrentQuestO[i] = 1;
                            this.dgvQuests.Rows.Insert(i, s.Name.ToString(), "Find the person", "Nope");
                        }
                    }
                    break;
                }
            }
            btnDecline.Visible = false;
            btnAccept.Visible = false;
            btnAccept.Enabled = false;
            btnDecline.Enabled = false;
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            btnDecline.Visible = false;
            btnAccept.Visible = false;
            btnDecline.Enabled = false;
            btnAccept.Enabled = false;
        }

        private void btnTalkToVendor_Click(object sender, EventArgs e)
        {
            btnPass.Enabled = false;
            btnPass.Visible = false;
            btnTalkToVendor.Enabled = false;
            btnTalkToVendor.Visible = false;
            TalkingToVendor f = new TalkingToVendor(Items, ItemQ, CurrentVendor);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            btnPass.Enabled = false;
            btnPass.Visible = false;
            btnTalkToVendor.Enabled = false;
            btnTalkToVendor.Visible = false;
        }

        void UpdatePossition(int posx, int posy)
        {
            LocateAndEngageNPC();
            LocateAndEngageVendor();
            ((PictureBox)this.Controls["pictureBox" + (posx + (posy - 1) * 14).ToString()]).GetChildAtPoint(new Point(0, 0), 0).Controls.Add(pbCharacter);
            pbCharacter.Location = new Point(0, 0);
            pbCharacter.BackColor = Color.Transparent;
            pbCharacter.Controls.Add(pbArmor);
            pbArmor.Location = new Point(0, 0);
            pbArmor.BackColor = Color.Transparent;
            pbArmor.Controls.Add(pbWeapon);
            pbWeapon.Location = new Point(0, 0);
            pbWeapon.BackColor = Color.Transparent;
            CheckForContainer();
        }

        int CheckConnection(int id)
        {
            int z = -1;
            foreach (var s in World.Connections)
            {
                if (s.Map1 == CurrentMapID && id == s.Terrain1)
                {
                    BoutToChange = s.Map2;
                    z = s.Terrain2;
                }
            }
            return z;
        }

        /*void UpdateWeapon(int id) // Does nothing rn
        {
            foreach (Weapon s in World.Weapons)
            {
                if (s.ID == id)
                {
                    _player.Weapon = id;
                    pbWeapon.Image = new Bitmap(@image_path + s.ImageAdress);
                }
            }
        }*/

        void AddItem(int a)
        {
            bool Yes = false;
            for (int i = 0; i < 20; i++)
            {
                if (Items[i] == a)
                {
                    Yes = true;
                    ItemQ[i]++;
                    break;
                }
            }
            if (Yes == false)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (Items[i] == 0)
                    {
                        Items[i] = a;
                        ItemQ[i] = 1;
                        break;
                    }
                }
            }
            Yes = false;
        }

        void FindEnemies(int a)
        {
            int z = 0;
            foreach (Enemy s in World.Enemies)
            {
                if (s.PossitionMap == a)
                {
                    EnemyPresent[z] = true;
                    EnemyID[z] = s.ID;
                    EnemyDroppedItem[z] = s.DroppedItem;
                    EnemyLocations[z] = (s.PossitionY - 1) * 14 + s.PossitionX;
                    EnemyImagess1[z] = s.ImageAdress1;
                    EnemyImagess2[z] = s.ImageAdress2;
                    EnemyImagess3[z] = s.ImageAdress3;
                    EnemyImagess4[z] = s.ImageAdress4;
                    EnemyArmor[z] = s.BaseArmor;
                    EnemyArmorPenetration[z] = s.BaseArmorPenetration;
                    EnemyCurrentHP[z] = s.BaseHp;
                    EnemyDamage[z] = s.BaseAttackDamage;
                    EnemyName[z] = s.Name;
                    EnemyMaxHP[z] = s.BaseHp;
                    EnemyDroppedExp[z] = s.DroppedExp;
                    EnemyDroppedGold[z] = s.DroppedGold;
                    EnemyDroppedItem[z] = s.DroppedItem;
                    EnemyAttackSpeed[z] = s.BaseAttackSpeed;
                    EnemyEvasion[z] = s.BaseEvasion;
                    EnemyImage[z] = 1;
                    z++;
                }
            }
        }

        void UpdatePlayerStatus()
        {
            this.hpBar.Value = _player.CurrentHitPoints * 100 / _player.BaseHp;
            lblCurrentHp.Text = _player.CurrentHitPoints.ToString();
            lblMaxHP.Text = _player.BaseHp.ToString();
            string temp;
            try
            {
                using (StreamReader sr = new StreamReader("EquipedWeapon.txt"))
                {
                    temp = sr.ReadLine();//Class
                    temp = sr.ReadLine();//ID
                    temp = sr.ReadLine();//Image
                    if (temp == "0")
                    {
                        pbEquipedWeapon.Image = null;//WeaponImage
                        pbWeapon.Image = null;
                    }
                    else
                    {
                        pbEquipedWeapon.Image = new Bitmap(@image_path + temp);//Image
                        pbWeapon.Image = new Bitmap(@pbEquipedWeapon.Image);
                    }
                    temp = sr.ReadLine();//Info
                    temp = sr.ReadLine();//Lvl
                    temp = sr.ReadLine();//Maxdmg
                    WeaponMaxDamage = Int32.Parse(temp);
                    temp = sr.ReadLine();//Mindmg
                    WeaponMinDamage = Int32.Parse(temp);
                    temp = sr.ReadLine();//Name
                    temp = sr.ReadLine();//CritChance
                    WeaponCritChance = Int32.Parse(temp);
                    temp = sr.ReadLine();//CritChance
                    WeaponCritMult = Convert.ToDouble(temp);
                    temp = sr.ReadLine();//Armor
                    WeaponArmor = Int32.Parse(temp);
                    temp = sr.ReadLine();//MagicResistance
                    WeaponMagicResistance = Int32.Parse(temp);
                    temp = sr.ReadLine();//ArmorPenetration
                    WeaponArmorPenetration = Int32.Parse(temp);
                    sr.Close();
                }
            }
            catch
            {

            }

            try
            {
                using (StreamReader sr1 = new StreamReader("EquipedArmor.txt"))
                {
                    temp = sr1.ReadLine();//Class
                    temp = sr1.ReadLine();//ID
                    temp = sr1.ReadLine();//Image
                    if (temp == "0")
                    {
                        pbEquipedArmor.Image = null;//ArmorImage
                        pbArmor.Image = null;
                    }
                    else
                    {
                        pbEquipedArmor.Image = new Bitmap(@image_path + temp);//Image
                        pbArmor.Image = new Bitmap(@pbEquipedArmor.Image);
                    }
                    temp = sr1.ReadLine();//Info
                    temp = sr1.ReadLine();//Lvl
                    temp = sr1.ReadLine();//BonusArmor
                    BonusArmor = Int32.Parse(temp);
                    temp = sr1.ReadLine();//BonusMagicResistance
                    BonusMagicResistance = Int32.Parse(temp);
                    temp = sr1.ReadLine();//Name
                    sr1.Close();
                }
            }
            catch
            {

            }
            lblExp.Text = _player.ExperiencePoints.ToString();
            lblExpReq.Text = Levels[_player.Lvl - 1].ToString();
            if (_player.ExperiencePoints >= Levels[_player.Lvl - 1])
            {
                _player.BaseAgility = _player.BaseAgility + _player.BaseAgility / (_player.Lvl + 4);
                _player.BaseArmor = _player.BaseArmor + _player.BaseArmor / (_player.Lvl + 4);
                _player.BaseArmorPenetration = _player.BaseArmorPenetration + _player.BaseArmorPenetration / (_player.Lvl + 4);
                _player.BaseAttackDamage = _player.BaseAttackDamage + _player.BaseAttackDamage / (_player.Lvl + 4);
                _player.BaseAttackSpeed = _player.BaseAttackSpeed + _player.BaseAttackSpeed / (_player.Lvl + 4);
                _player.BaseEvasion = _player.BaseEvasion + _player.BaseEvasion / (_player.Lvl + 4);
                _player.BaseHp = _player.BaseHp + _player.BaseHp / (_player.Lvl + 4);
                _player.BaseIntelligence = _player.BaseIntelligence + _player.BaseIntelligence / (_player.Lvl + 4);
                _player.BaseMagicDefense = _player.BaseMagicDefense + _player.BaseMagicDefense / (_player.Lvl + 4);
                _player.BaseMagicPenetration = _player.BaseMagicPenetration + _player.BaseMagicPenetration / (_player.Lvl + 4);
                _player.BaseMagicPower = _player.BaseMagicPower + _player.BaseMagicPower / (_player.Lvl + 4);
                _player.BaseStrengh = _player.BaseStrengh + _player.BaseStrengh / (_player.Lvl + 4);
                _player.CurrentHitPoints = _player.CurrentHitPoints + _player.CurrentHitPoints / (_player.Lvl + 4);
                _player.Lvl++;
                _player.ExperiencePoints = _player.ExperiencePoints - Levels[_player.Lvl - 2];
                bool yes = true;
                while(yes)
                {
                    try
                    {
                        using (StreamWriter swGE = new StreamWriter("GoldExp.txt"))
                        {
                            swGE.WriteLine(_player.Gold);
                            swGE.WriteLine(_player.ExperiencePoints);
                            swGE.WriteLine(_player.Lvl);
                            yes = false;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            lblLvl.Text = _player.Lvl.ToString();
            lblGold.Text = _player.Gold.ToString();
            try
            {
                using (StreamReader srGE = new StreamReader("GoldExp.txt"))
                {
                    temp = srGE.ReadLine();
                    _player.Gold = Int32.Parse(temp);
                    temp = srGE.ReadLine();
                    _player.ExperiencePoints = Int32.Parse(temp);
                    temp = srGE.ReadLine();
                    _player.Lvl = Int32.Parse(temp);
                    srGE.Close();
                }
            }
            catch
            {

            }
            bool needed = false;
            for (int i = 0; i < Items.Length-1; i++)
            {
                for (int j = i; j < Items.Length; j++)
                {
                    if (Items[i] == 0 && Items[j] != 0)
                    {
                        needed = true;
                        Items[i] = Items[j];
                        Items[j] = 0;
                        ItemQ[i] = ItemQ[j];
                        ItemQ[j] = 0;
                    }
                }
            }
            if (needed)
            {
                bool yes = true;
                while (yes)
                {
                    try
                    {
                        using (StreamWriter swInv = new StreamWriter("Inventory.txt"))
                        {
                            for (int i = 0; i < Items.Length; i++)
                            {
                                swInv.WriteLine(Items[i]);
                                swInv.WriteLine(ItemQ[i]);
                            }
                            swInv.Close();
                            yes = false;
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        void EnemyLocateAndAttackPlayer(int XY)
        {
            while (EnemyPresent[XY])
            {
                if (EnemyLocations[XY] + 1 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[XY] > 0 || EnemyLocations[XY] - 1 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[XY] > 0 || EnemyLocations[XY] + 1 - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[XY] > 0 || EnemyLocations[XY] - 1 - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[XY] > 0 || EnemyLocations[XY] + 1 + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[XY] > 0 || EnemyLocations[XY] - 1 + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[XY] > 0 || EnemyLocations[XY] - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[XY] > 0 || EnemyLocations[XY] + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) && EnemyCurrentHP[XY] > 0)
                {
                    AvailableToChangeMaps = false;
                    EnemyEngaged[XY] = true;
                    Random rnd = new Random();
                    int z = rnd.Next(1, 100);
                    if (z > (100 * Math.Pow(0.99, Math.Sqrt(_player.BaseEvasion))))
                    {
                        richTextBox1.Text = "You evaded.\n" + richTextBox1.Text;
                    }
                    else
                    {
                        if (_player.BaseArmor + BonusArmor + WeaponArmor > EnemyArmorPenetration[XY])
                        {
                            _player.CurrentHitPoints = _player.CurrentHitPoints - (int)(EnemyDamage[XY] * Math.Pow(0.99, Math.Sqrt(_player.BaseArmor + BonusArmor + WeaponArmor - EnemyArmorPenetration[XY])));
                            richTextBox1.Text = EnemyName[XY] + " has dealt " + ((int)(EnemyDamage[XY] * Math.Pow(0.99, Math.Sqrt(_player.BaseArmor + BonusArmor + WeaponArmor - EnemyArmorPenetration[XY])))).ToString() + " damage to you.\n" + richTextBox1.Text;
                        }
                        else
                        {
                            _player.CurrentHitPoints = _player.CurrentHitPoints - EnemyDamage[XY];
                            richTextBox1.Text = EnemyName[XY] + " has dealt " + EnemyDamage[XY].ToString() + " damage to you.\n" + richTextBox1.Text;
                        }
                        if (_player.CurrentHitPoints <= 0)
                        {
                            Environment.Exit(1);
                        }
                    }
                    Thread.Sleep((int)(2500 * Math.Pow(0.99, Math.Sqrt(EnemyAttackSpeed[XY]))));
                }
                else
                {
                    Thread.Sleep(15);
                }
            }
        }

        bool CheckForObject(int x, int y)
        {
            if (((PictureBox)this.Controls["pictureBox" + (x + (y - 1) * 14).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage != null)
            {
                
                return false;
            }
            else
            {
                return true;
            }
        }

        void RegenStats()
        {
            if (_player.CurrentHitPoints < _player.BaseHp)
            {
                if (_player.CurrentHitPoints + _player.CurrentHitPoints / 20 < _player.BaseHp)
                {
                    _player.CurrentHitPoints = _player.CurrentHitPoints + _player.BaseHp / 20;
                }
                else
                {
                    _player.CurrentHitPoints = _player.BaseHp;
                }
            }
        }

        void LocateAndEngageNPC()
        {
            foreach (NPC s in World.NPCs)
            {
                if (s.LocationMap == CurrentMapID)
                {
                    if (s.LocationXY + 1 == (characterPossitionX + (characterPossitionY - 1) * 14) || s.LocationXY + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || s.LocationXY - 1 == (characterPossitionX + (characterPossitionY - 1) * 14) || s.LocationXY + 1 - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || s.LocationXY - 1 - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || s.LocationXY + 1 + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || s.LocationXY - 1 + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || s.LocationXY - 14 == (characterPossitionX + (characterPossitionY - 1) * 14))
                    {
                        if (s.OfferedQuest != 0)
                        {
                            UpdateTalkToQuest(s.ID);
                            bool QuestAvailable = true;
                            bool QuestTaken = false;
                            for (int i = 0; i < CompletedQuests.Length; i++)
                            {
                                if (CompletedQuests[i] == s.OfferedQuest)
                                {
                                    QuestAvailable = false;
                                }
                            }
                            for (int i = 0; i < 5; i++)
                            {
                                if (CurrentQuests[i] == s.OfferedQuest)
                                {
                                    QuestTaken = true;
                                    if (CurrentQuestO[i] <= 0)
                                    {
                                        richTextBox1.Text = s.Name + ": " + s.MonologueAfterQuest1 + "\n" + richTextBox1.Text;
                                        CompletedQuests[CompletedQuestn] = s.OfferedQuest;
                                        CompletedQuestn++;
                                        foreach (Quest q in World.Quests)
                                        {
                                            if (q.ID == s.OfferedQuest)
                                            {
                                                if (q.IDOfItemsToCollect > 0)
                                                {
                                                    for (int It = 0; It < Items.Length; i++)
                                                    {
                                                        if (Items[It] == q.IDOfItemsToCollect)
                                                        {
                                                            ItemQ[It] = ItemQ[It] - q.NumberOfItemsToCollect;
                                                            if (ItemQ[It] <= 0)
                                                            {
                                                                Items[It] = 0;
                                                            }
                                                        }
                                                    }
                                                }
                                                _player.ExperiencePoints = _player.ExperiencePoints + q.RewardExp;
                                                _player.Gold = _player.Gold + q.RewardGold;
                                                StreamWriter swGoldExp = new StreamWriter("GoldExp.txt");
                                                swGoldExp.WriteLine(_player.Gold);
                                                swGoldExp.WriteLine(_player.ExperiencePoints);
                                                swGoldExp.WriteLine(_player.Lvl);
                                                swGoldExp.Close();
                                                CurrentQuestO[i] = 0;
                                                CurrentQuests[i] = 0;
                                                dgvQuests.Rows.RemoveAt(i);
                                                this.dgvQuests.Rows.Insert(i, "", "", "");
                                                if (q.IDOfRewardItems > -1)
                                                {
                                                    for (int j = 0; j < q.NumberOfRewardItems; j++)
                                                    {
                                                        AddItem(q.IDOfRewardItems);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (QuestAvailable)
                            {
                                if (QuestTaken == false)
                                {
                                    richTextBox1.Text = s.Name + ": " + s.Monologue + "\n" + richTextBox1.Text;
                                    NPCQuest = s.OfferedQuest;
                                    btnAccept.Visible = true;
                                    btnDecline.Visible = true;
                                    btnAccept.Enabled = true;
                                    btnDecline.Enabled = true;
                                }
                            }
                            else
                            {
                                richTextBox1.Text = s.Name + ": " + s.MonologueAfterQuest + "\n" + richTextBox1.Text;
                            }
                        }
                        else
                        {
                            richTextBox1.Text = s.Name + ": " + s.MonologueAfterQuest + "\n" + richTextBox1.Text;
                        }
                    }
                }
            }
        }

        void UpdateMonsterSlayingQuests(int id)
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (Quest s in World.Quests)
                {
                    if (CurrentQuests[i] == s.ID && id == s.IDOfMonstersToSlay)
                    {
                        CurrentQuestO[i]--;
                        dgvQuests.Rows.RemoveAt(i);
                        this.dgvQuests.Rows.Insert(i, s.Name.ToString(), CurrentQuestO[i].ToString(), "Nope");
                        if (CurrentQuestO[i] <= 0)
                        {
                            dgvQuests.Rows.RemoveAt(i);
                            this.dgvQuests.Rows.Insert(i, s.Name.ToString(), "0", "Yep");
                        }
                    }
                }
            }
        }

        void UpdateItemCollectionQuest(int id)
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (Quest s in World.Quests)
                {
                    if (CurrentQuests[i] == s.ID && id == s.IDOfItemsToCollect)
                    {
                        CurrentQuestO[i]--;
                        dgvQuests.Rows.RemoveAt(i);
                        this.dgvQuests.Rows.Insert(i, s.Name.ToString(), CurrentQuestO[i].ToString(), "Nope");
                        if (CurrentQuestO[i] <= 0)
                        {
                            dgvQuests.Rows.RemoveAt(i);
                            this.dgvQuests.Rows.Insert(i, s.Name.ToString(), "0", "Yep");
                        }
                    }
                }
            }
        }

        void UpdateTalkToQuest(int id)
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (Quest s in World.Quests)
                {
                    if (CurrentQuests[i] == s.ID && id == s.IDOfNPCToSpeak)
                    {
                        richTextBox1.Text = s.DialogueOfNPCToSpeak + "\n" + richTextBox1.Text;
                        CurrentQuestO[i] = 0;
                        dgvQuests.Rows.RemoveAt(i);
                        this.dgvQuests.Rows.Insert(i, s.Name.ToString(), "0", "Yep");
                    }
                }
            }
        }

        void PassiveCounterVoid()
        {
            int z = 0;
            while (true)
            {
                for (int i = 0; i < PassiveCounterActive.Length; i++)
                {
                    if (PassiveCounterActive[i])
                    {
                        PassiveCounterStart[i]++;
                        if (PassiveCounterStart[i] >= PassiveCounterFinish[i] && i > 4)
                        {
                            PassiveCounterActive[i] = false;
                            PassiveCounterFinish[i] = 0;
                            PassiveCounterStart[i] = 0;
                            PassiveCounterCompleted[i] = true;
                        }
                        if (PassiveCounterCompleted[7])
                        {
                            PassiveCounterCompleted[7] = false;
                            AvailableToChangeMaps = true;
                        }
                        if (PassiveCounterStart[i] >= PassiveCounterFinish[i] && i < 5)
                        {
                            PassiveCounterStart[i] = 0;
                            if (i == 0)
                            {
                                UpdatePlayerStatus();
                            }
                            if (i == 1)
                            {
                                AvailableWalking = true;
                            }
                            if(i == 2)
                            {
                                RegenStats();
                            }
                            if (i == 3)
                            {
                                UpdateFireplaces();
                            }
                            if (i == 4)
                            {
                                UpdateMonsterImages();
                                PassiveCounterStart[4] = 0;
                            }
                        }
                    }
                }
                z++;
                Thread.Sleep(100);
            }
        }

        void UpdateFireplaces()
        {
            foreach(Fireplace s in World.Fireplaces)
            {
                if (s.LocationMap == CurrentMapID)
                {
                    if (Fireplace)
                    {
                        Fireplace = false;
                        ((PictureBox)this.Controls["pictureBox" + (s.LocationXY).ToString()]).Image = new Bitmap(@image_path + s.Image2);
                    }
                    else
                    {
                        Fireplace = true;
                        ((PictureBox)this.Controls["pictureBox" + (s.LocationXY).ToString()]).Image = new Bitmap(@image_path + s.Image1);
                    }
                }
            }
        }

        string FindBonusTerrainAdress(int id)
        {
            string str = "";
            foreach (RandomObject s in World.BonusTerrain)
            {
                if (s.ID == id)
                {
                    str = s.ImageAdress;
                }
            }
            return str;
        }

        string FindRandomObjectAdress(int id)
        {
            string str = "";
            foreach (RandomObject s in World.RandomObjects)
            {
                if (s.ID == id)
                {
                    str = s.ImageAdress;
                }
            }
            return str;
        }

        void UpdateObjects()
        {
            foreach (UpperMap s in World.UpperMaps)
            {
                if (s.ID == CurrentMapID)
                {
                    for (int i = 0; i < 140; i++)
                    {
                        foreach (RandomObject r in World.BonusTerrain)
                        {
                            if (r.ID == s.TerrainID[i / 14, i % 14])
                            {
                                ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = new Bitmap(@image_path + FindBonusTerrainAdress(s.TerrainID[i / 14, i % 14]));
                            }
                        }
                    }
                }
            }
            foreach (UpperMap s in World.Objects)
            {
                if (s.ID == CurrentMapID)
                {
                    for (int i = 0; i < 140; i++)
                    {
                        foreach (RandomObject r in World.RandomObjects)
                        {
                            if (r.ID == s.TerrainID[i / 14, i % 14])
                            {
                                ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).Image = new Bitmap(@image_path + FindRandomObjectAdress(s.TerrainID[i / 14, i % 14]));
                            }
                        }
                    }
                }
            }
        }

        void PlaceContainers()
        {
            foreach (Engine.Container c in World.Containers)
            {
                if (c.LocationMap == CurrentMapID)
                {
                    if (ContainersOppened[c.ID - 1] == false)
                    {
                        ((PictureBox)this.Controls["pictureBox" + (c.LocationXY).ToString()]).Image = new Bitmap(@image_path + c.Unopened);
                    }
                    else
                    {
                        ((PictureBox)this.Controls["pictureBox" + (c.LocationXY).ToString()]).Image = new Bitmap(@image_path + c.Oppened);
                    }
                }
            }
        }

        bool CheckForItem(int id)
        {
            bool z = false;
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == id)
                {
                    z = true;
                }
            }
            return z;
        }

        string LocateItemName(int id)
        {
            foreach (Item i in World.Items)
            {
                if (i.ID == id)
                {
                    return i.Name;
                }
            }
            return "Invalid item";
        }

        void CheckForContainer()
        {
            foreach (Engine.Container c in World.Containers)
            {
                if (c.LocationMap == CurrentMapID)
                {
                    if (c.LocationXY == characterPossitionX + (characterPossitionY - 1) * 14 && ContainersOppened[c.ID - 1] == false && c.LevelRequirement <= _player.Lvl)
                    {
                        if (c.ItemRequirement == 0)
                        {
                            _player.Gold = _player.Gold + c.ContainsGold;
                            StreamWriter swGoldExp = new StreamWriter("GoldExp.txt");
                            swGoldExp.WriteLine(_player.Gold);
                            swGoldExp.WriteLine(_player.ExperiencePoints);
                            swGoldExp.WriteLine(_player.Lvl);
                            swGoldExp.Close();
                            for (int i = 0; i < c.ContainsItems.Length; i++)
                            {
                                if (c.ContainsItems[i] != 0)
                                {
                                    AddItem(c.ContainsItems[i]);
                                }
                            }
                            if (c.Repeated == false)
                            {
                                ContainersOppened[c.ID - 1] = true;
                                ((PictureBox)this.Controls["pictureBox" + (c.LocationXY).ToString()]).Image = null;
                                ((PictureBox)this.Controls["pictureBox" + (c.LocationXY).ToString()]).Image = new Bitmap(@image_path + c.Oppened);
                            }
                        }
                        else
                        {
                            if (CheckForItem(c.ItemRequirement))
                            {
                                if (c.ItemConsuming)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to open this container? You will lose your" + LocateItemName(c.ItemRequirement) + " in the process.", "Warning!!", MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        for (int i = 0; i < Items.Length; i++)
                                        {
                                            if (Items[i] == c.ItemRequirement)
                                            {
                                                ItemQ[i]--;
                                                if (ItemQ[i] <= 0)
                                                {
                                                    Items[i] = 0;
                                                }
                                            }
                                        }
                                        _player.Gold = _player.Gold + c.ContainsGold;
                                        StreamWriter swGoldExp = new StreamWriter("GoldExp.txt");
                                        swGoldExp.WriteLine(_player.Gold);
                                        swGoldExp.WriteLine(_player.ExperiencePoints);
                                        swGoldExp.WriteLine(_player.Lvl);
                                        swGoldExp.Close();
                                        for (int i = 0; i < c.ContainsItems.Length; i++)
                                        {
                                            if (c.ContainsItems[i] != 0)
                                            {
                                                AddItem(c.ContainsItems[i]);
                                            }
                                        }
                                        if (c.Repeated == false)
                                        {
                                            ContainersOppened[c.ID - 1] = true;
                                            ((PictureBox)this.Controls["pictureBox" + (c.LocationXY).ToString()]).Image = null;
                                            ((PictureBox)this.Controls["pictureBox" + (c.LocationXY).ToString()]).Image = new Bitmap(@image_path + c.Oppened);
                                        }
                                    }
                                }
                                else
                                {
                                    _player.Gold = _player.Gold + c.ContainsGold;
                                    StreamWriter swGoldExp = new StreamWriter("GoldExp.txt");
                                    swGoldExp.WriteLine(_player.Gold);
                                    swGoldExp.WriteLine(_player.ExperiencePoints);
                                    swGoldExp.WriteLine(_player.Lvl);
                                    swGoldExp.Close();
                                    for (int i = 0; i < c.ContainsItems.Length; i++)
                                    {
                                        if (c.ContainsItems[i] != 0)
                                        {
                                            AddItem(c.ContainsItems[i]);
                                        }
                                    }
                                    if (c.Repeated == false)
                                    {
                                        ContainersOppened[c.ID - 1] = true;
                                        ((PictureBox)this.Controls["pictureBox" + (c.LocationXY).ToString()]).Image = null;
                                        ((PictureBox)this.Controls["pictureBox" + (c.LocationXY).ToString()]).Image = new Bitmap(@image_path + c.Oppened);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        void PlaceVendors()
        {
            foreach (Vendor v in World.Vendors)
            {
                if(v.LocationMap == CurrentMapID)
                {
                    ((PictureBox)this.Controls["pictureBox" + (v.LocationXY).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = new Bitmap(@image_path + v.ImageAdress);
                }
            }
        }

        void LocateAndEngageVendor()
        {
            foreach (Vendor v in World.Vendors)
            {
                if (v.LocationMap == CurrentMapID)
                {
                    if (v.LocationXY + 1 == (characterPossitionX + (characterPossitionY - 1) * 14) || v.LocationXY + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || v.LocationXY - 1 == (characterPossitionX + (characterPossitionY - 1) * 14) || v.LocationXY + 1 - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || v.LocationXY - 1 - 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || v.LocationXY + 1 + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || v.LocationXY - 1 + 14 == (characterPossitionX + (characterPossitionY - 1) * 14) || v.LocationXY - 14 == (characterPossitionX + (characterPossitionY - 1) * 14))
                    {
                        richTextBox1.Text = v.Dialogue + richTextBox1.Text;
                        CurrentVendor = v.ID;
                        btnTalkToVendor.Enabled = true;
                        btnTalkToVendor.Visible = true;
                        btnPass.Enabled = true;
                        btnPass.Visible = true;
                    }
                    else
                    {
                        btnTalkToVendor.Enabled = false;
                        btnTalkToVendor.Visible = false;
                        btnPass.Enabled = false;
                        btnPass.Visible = false;
                    }
                }
            }
        }

        void UpdateMonsterImages()
        {
            for (int i = 0; i < EnemyEngaged.Length; i++)
            {
                if (EnemyPresent[i])
                {
                    if (EnemyImage[i] == 4)
                    {
                        EnemyImage[i] = 1;
                        ((PictureBox)this.Controls["pictureBox" + (EnemyLocations[i]).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = new Bitmap(@image_path + EnemyImagess1[i]);
                    }
                    else if (EnemyImage[i] == 3)
                    {
                        EnemyImage[i] = 4;
                        ((PictureBox)this.Controls["pictureBox" + (EnemyLocations[i]).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = new Bitmap(@image_path + EnemyImagess4[i]);
                    }else if (EnemyImage[i] == 2)
                    {
                        EnemyImage[i] = 3;
                        ((PictureBox)this.Controls["pictureBox" + (EnemyLocations[i]).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = new Bitmap(@image_path + EnemyImagess3[i]);
                    }else if (EnemyImage[i] == 1)
                    {
                        EnemyImage[i] = 2;
                        ((PictureBox)this.Controls["pictureBox" + (EnemyLocations[i]).ToString()]).GetChildAtPoint(new Point(0, 0), 0).BackgroundImage = new Bitmap(@image_path + EnemyImagess2[i]);
                    }
                }
            }
        }

        private void MainGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Save game?", "???", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                StreamWriter sw = new StreamWriter("Save.txt");
                sw.WriteLine("Yes");
                sw.WriteLine(CurrentMapID);
                sw.WriteLine(characterPossitionX);
                sw.WriteLine(characterPossitionY);
                sw.Close();
                StreamWriter sw1 = new StreamWriter("QuestsCompleted.txt");
                {
                    for (int i = 0; i < CompletedQuests.Length; i++)
                    {
                        sw1.WriteLine(CompletedQuests[i]);
                    }
                }
                sw1.Close();
                StreamWriter sw2 = new StreamWriter("ContainersOppened.txt");
                {
                    for (int i = 0; i < ContainersOppened.Length; i++)
                    {
                        if (ContainersOppened[i])
                        {
                            sw2.WriteLine("1");
                        }
                        else
                        {
                            sw2.WriteLine("0");
                        }
                    }
                }
                sw2.Close();
                bool Yes = true;
                while (Yes)
                {
                    try
                    {
                        using (StreamWriter swItem = new StreamWriter("Inventory.txt"))
                        {
                            for(int i = 0; i < Items.Length; i++)
                            {
                                swItem.WriteLine(Items[i]);
                                swItem.WriteLine(ItemQ[i]);
                            }
                            swItem.Close();
                            Yes = false;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter("Save.txt");
                sw.WriteLine("No");
                sw.Close();
            }
            Environment.Exit(1);
        }
    }
}
