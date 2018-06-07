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

using Engine;

namespace Game
{
    public partial class CharacterCreator : Form
    {
        private static string project_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private string[] lines = project_path.Split('\\');
        public string image_path = "";
        private Player _player;
        private int GenderIDHighest = 3;
        private int GenderID = 1;
        private int RaceIDHighest = 16;
        private int RaceID = 1;
        private int ClassIDHighest = 16;
        private int ClassID = 1;
        private bool[] AvailableClasses = { true, false, true, false, true, true, true, true, true, false, true, false, false, false, true, false };
        private bool[] AvailableRaces = { true, true, true, true, true, true, false, false, true, false, true, true, true, true, true, false };
        public CharacterCreator()
        {
            InitializeComponent();
            _player = new Player(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                image_path = image_path + lines[i] + "\\";
            }
            image_path = image_path + "Engine\\Images\\";
            UpdateGender();
            UpdateRace();
            UpdateClass();
        }

        void UpdatePlayerStats()
        {
            foreach (Race s1 in World.Races)
            {
                if (s1.ID == RaceID)
                {
                    foreach (Class s2 in World.Classes)
                    {
                        if (s2.ID == ClassID)
                        {
                            _player.BaseStrengh = s1.BaseStrengh + s2.BaseStrengh;
                            _player.BaseHp = s1.BaseHp + s2.BaseHp;
                            _player.BaseArmor = s1.BaseArmor + s2.BaseArmor;
                            _player.BaseAttackDamage = s1.BaseAttackDamage + s2.BaseAttackDamage;
                            _player.BaseAgility = s1.BaseAgility + s2.BaseAgility;
                            _player.BaseEvasion = s1.BaseEvasion + s2.BaseEvasion;
                            _player.BaseAttackSpeed = s1.BaseAttackSpeed + s2.BaseAttackSpeed;
                            _player.BaseArmorPenetration = s1.BaseArmorPenetration + s2.BaseArmorPenetration;
                            _player.BaseIntelligence = s1.BaseIntelligence + s2.BaseIntelligence;
                            _player.BaseMagicPower = s1.BaseMagicPower + s2.BaseMagicPower;
                            _player.BaseMagicDefense = s1.BaseMagicDefense + s2.BaseMagicDefense;
                            _player.BaseMagicPenetration = s1.BaseMagicPenetration + s2.BaseMagicPenetration;

                            tbStrengh.Text = _player.BaseStrengh.ToString();
                            tbHp.Text = _player.BaseHp.ToString();
                            tbArmor.Text = _player.BaseArmor.ToString();
                            tbAttackDamage.Text = _player.BaseAttackDamage.ToString();
                            tbAgility.Text = _player.BaseAgility.ToString();
                            tbEvasion.Text = _player.BaseEvasion.ToString();
                            tbAttackSpeed.Text = _player.BaseAttackSpeed.ToString();
                            tbArmorPenetration.Text = _player.BaseArmorPenetration.ToString();
                            tbIntelligence.Text = _player.BaseIntelligence.ToString();
                            tbMagicPower.Text = _player.BaseMagicPower.ToString();
                            tbMagicDefense.Text = _player.BaseMagicDefense.ToString();
                            tbMagicPenetration.Text = _player.BaseMagicPenetration.ToString();
                        }
                    }
                }
            }
        }

        private void btnGenderLeft_Click(object sender, EventArgs e)
        {
            if (GenderID == 1)
            {
                GenderID = GenderIDHighest;
                UpdateGender();
            }
            else
            {
                GenderID--;
                UpdateGender();
            }
        }
        private void btnGenderRight_Click(object sender, EventArgs e)
        {
            if (GenderID == GenderIDHighest)
            {
                GenderID = 1;
                UpdateGender();
            }
            else
            {
                GenderID++;
                UpdateGender();
            }
        }
        void UpdateGender()
        {
            foreach (Gender s in World.Genders)
            {
                if (s.ID == GenderID)
                {
                    tbGender.Text = s.Name;
                    _player.UpdateGender(GenderID);
                    _player.GenderName = s.Name;
                }
            }
        }

        private void btnRaceLeft_Click(object sender, EventArgs e)
        {
            if (RaceID == 1)
            {
                RaceID = RaceIDHighest;
                UpdateRace();
            }
            else
            {
                RaceID--;
                UpdateRace();
            }
        }
        private void btnRaceRight_Click(object sender, EventArgs e)
        {
            if (RaceID == RaceIDHighest)
            {
                RaceID = 1;
                UpdateRace();
            }
            else
            {
                RaceID++;
                UpdateRace();
            }
        }
        void UpdateRace()
        {
            foreach (Race s in World.Races)
            {
                if (s.ID == RaceID)
                {
                    tbRace.Text = s.Name;
                    UpdatePlayerStats();
                    tbStrenghRace.Text = s.BaseStrengh.ToString();
                    tbHpRace.Text = s.BaseHp.ToString();
                    tbArmorRace.Text = s.BaseArmor.ToString();
                    tbAttackDamageRace.Text = s.BaseAttackDamage.ToString();
                    tbAgilityRace.Text = s.BaseAgility.ToString();
                    tbEvasionRace.Text = s.BaseEvasion.ToString();
                    tbAttackSpeedRace.Text = s.BaseAttackSpeed.ToString();
                    tbArmorPenetrationRace.Text = s.BaseArmorPenetration.ToString();
                    tbIntelligenceRace.Text = s.BaseIntelligence.ToString();
                    tbMagicPowerRace.Text = s.BaseMagicPower.ToString();
                    tbMagicDefenseRace.Text = s.BaseMagicDefense.ToString();
                    tbMagicPenetrationRace.Text = s.BaseMagicPenetration.ToString();
                    _player.RaceID = s.ID;
                    _player.RaceName = s.Name;
                    if (AvailableRaces[RaceID - 1])
                    {
                        pbCharacter.BackgroundImage = new Bitmap(@image_path + s.ImageAdress);
                        rtbRaceDesc.Text = s.Description;
                    }
                    else
                    {
                        pbCharacter.BackgroundImage = new Bitmap(@image_path + "UnavailableRace.png");
                        rtbRaceDesc.Text = "None";
                    }
                }
            }
        }

        private void btnClassLeft_Click(object sender, EventArgs e)
        {
            if (ClassID == 1)
            {
                ClassID = ClassIDHighest;
                UpdateClass();
            }
            else
            {
                ClassID--;
                UpdateClass();
            }
        }
        private void btnClassRight_Click(object sender, EventArgs e)
        {
            if (ClassID == ClassIDHighest)
            {
                ClassID = 1;
                UpdateClass();
            }
            else
            {
                ClassID++;
                UpdateClass();
            }
        }
        void UpdateClass()
        {
             foreach (Class s in World.Classes)
            {
                if (s.ID == ClassID)
                {
                    tbClass.Text = s.Name;
                    UpdatePlayerStats();
                    tbStrenghClass.Text = s.BaseStrengh.ToString();
                    tbHpClass.Text = s.BaseHp.ToString();
                    tbArmorClass.Text = s.BaseArmor.ToString();
                    tbAttackDamageClass.Text = s.BaseAttackDamage.ToString();
                    tbAgilityClass.Text = s.BaseAgility.ToString();
                    tbEvasionClass.Text = s.BaseEvasion.ToString();
                    tbAttackSpeedClass.Text = s.BaseAttackSpeed.ToString();
                    tbArmorPenetrationClass.Text = s.BaseArmorPenetration.ToString();
                    tbIntelligenceClass.Text = s.BaseIntelligence.ToString();
                    tbMagicPowerClass.Text = s.BaseMagicPower.ToString();
                    tbMagicDefenseClass.Text = s.BaseMagicDefense.ToString();
                    tbMagicPenetrationClass.Text = s.BaseMagicPenetration.ToString();
                    _player.ClassID = s.ID;
                    _player.ClassName = s.Name;
                    foreach (Weapon w in World.Weapons)
                    {
                        if (w.ID == ClassID)
                        {
                            if (AvailableClasses[ClassID - 1])
                            {
                                pbWeapon.BackgroundImage = new Bitmap(@image_path + w.ImageAdress);
                                rtbClassDesc.Text = s.Description;
                            }
                        }
                    }
                    if (!AvailableClasses[ClassID - 1])
                    {
                        pbWeapon.BackgroundImage = new Bitmap(@image_path + "Black.jpg");
                        rtbClassDesc.Text = "None";
                    }
                }
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to start the game as a " + _player.GenderName + " " + _player.MagicAffinityName + _player.RaceName + " " + _player.ClassName + "?", "Warning!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (AvailableClasses[_player.ClassID - 1] && AvailableRaces[_player.RaceID - 1])
                {
                    StreamWriter sw = new StreamWriter("PlayerInfo.txt");

                    sw.WriteLine(_player.GenderID.ToString());
                    sw.WriteLine(_player.ClassID.ToString());
                    sw.WriteLine(_player.RaceID.ToString());

                    sw.WriteLine(_player.BaseStrengh.ToString());
                    sw.WriteLine(_player.BaseHp.ToString());
                    sw.WriteLine(_player.BaseArmor.ToString());
                    sw.WriteLine(_player.BaseAttackDamage.ToString());

                    sw.WriteLine(_player.BaseAgility.ToString());
                    sw.WriteLine(_player.BaseEvasion.ToString());
                    sw.WriteLine(_player.BaseAttackSpeed.ToString());
                    sw.WriteLine(_player.BaseArmorPenetration.ToString());

                    sw.WriteLine(_player.BaseIntelligence.ToString());
                    sw.WriteLine(_player.BaseMagicDefense.ToString());
                    sw.WriteLine(_player.BaseMagicPenetration.ToString());
                    sw.WriteLine(_player.BaseMagicPower.ToString());

                    sw.WriteLine(_player.ClassName.ToString());
                    sw.WriteLine(_player.GenderName.ToString());
                    sw.WriteLine(_player.RaceName.ToString());

                    sw.Close();

                    foreach (Weapon s in World.Weapons)
                    {
                        if (s.ID == _player.ClassID)
                        {
                            StreamWriter sw1 = new StreamWriter("EquipedWeapon.txt");
                            sw1.WriteLine(s.Class);
                            sw1.WriteLine(s.ID);
                            sw1.WriteLine(s.ImageAdress);
                            sw1.WriteLine(s.Info);
                            sw1.WriteLine(s.Lvl);
                            sw1.WriteLine(s.MaxDmg);
                            sw1.WriteLine(s.MinDmg);
                            sw1.WriteLine(s.Name);
                            sw1.WriteLine(s.CritChance);
                            sw1.WriteLine(s.CritMult);
                            sw1.WriteLine(s.Armor);
                            sw1.WriteLine(s.MagicDefense);
                            sw1.WriteLine(s.ArmorPenetration);
                            sw1.Close();
                        }
                    }

                    StreamWriter sw2 = new StreamWriter("EquipedArmor.txt");
                    sw2.WriteLine("0");
                    sw2.WriteLine("0");
                    sw2.WriteLine("0");
                    sw2.WriteLine("0");
                    sw2.WriteLine("0");
                    sw2.WriteLine("0");
                    sw2.WriteLine("0");
                    sw2.WriteLine("0");
                    sw2.Close();

                    MainGameForm f = new MainGameForm();
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("Unavailable class or Race");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing lel
            }
        }
    }
}
