using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine;
using System.IO;
using System.Threading;

namespace Game
{
    public partial class Inventory : Form
    {
        private static string project_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private string[] lines = project_path.Split('\\');
        public string image_path = "";
        public int[] ItemIDList = new int[35];
        public int[] ItemQList = new int[35];
        public int SelectedItem = 0;
        public int CurrentWeaponID = -1;
        public int CurrentArmorID = -1;
        public int Gold;
        public int ExperiencePoints;
        public int Lvl;
        public BackgroundWorker InventoryRefresher = new BackgroundWorker();
        public Inventory(int[] Items, int[] ItemQ)
        {
            ItemIDList = Items;
            ItemQList = ItemQ;
            InitializeComponent();
            
            for (int i = 0; i < lines.Length - 1; i++)
            {
                image_path = image_path + lines[i] + "\\";
            }
            image_path = image_path + "Engine\\Images\\";

            string temp;
            StreamReader sr = new StreamReader("EquipedWeapon.txt");
            temp = sr.ReadLine();//Class
            temp = sr.ReadLine();//ID
            CurrentWeaponID = Int32.Parse(temp);
            temp = sr.ReadLine();//Image
            temp = sr.ReadLine();//Info
            temp = sr.ReadLine();//Lvl
            temp = sr.ReadLine();//Maxdmg
            temp = sr.ReadLine();//Mindmg
            temp = sr.ReadLine();//Name
            temp = sr.ReadLine();//CritChance
            temp = sr.ReadLine();//CritMult
            sr.Close();

            StreamReader sr1 = new StreamReader("GoldExp.txt");
            Gold = Int32.Parse(sr1.ReadLine());
            ExperiencePoints = Int32.Parse(sr1.ReadLine());
            Lvl = Int32.Parse(sr1.ReadLine());
            InventoryRefresher.DoWork += (obj, ea) => RefreshInventoryGui();
            InventoryRefresher.RunWorkerAsync();
        }

        void RefreshInventoryGui()
        {
            while (true)
            {
                int z = 0;
                foreach (int i in ItemIDList)
                {
                    z++;

                    if (i > 0)
                    {
                        foreach (Item s in World.Items)
                        {
                            if (i == s.ID)
                            {
                                ((PictureBox)this.Controls["pictureBox" + (z).ToString()]).Image = new Bitmap(@image_path + s.ImageAdress);
                                ((Label)this.Controls["label" + (z).ToString()]).Text = ItemQList[z - 1].ToString();
                            }
                        }
                    }
                    else
                    {
                        ((PictureBox)this.Controls["pictureBox" + (z).ToString()]).Image = null;
                        ((Label)this.Controls["label" + (z).ToString()]).Text = "0";
                    }
                }
                z = 0;
                Thread.Sleep(10);
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            gbEditItemProperties.Enabled = false;
            gbEditItemProperties.Visible = false;
            gbEditItemProperties.Location = new Point(13, 270);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this iotem?", "Warning!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (ItemIDList[SelectedItem - 1] == CurrentWeaponID)
                {
                    StreamWriter sw = new StreamWriter("EquipedWeapon.txt");
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.Close();
                }
                if (ItemIDList[SelectedItem - 1] == CurrentArmorID)
                {
                    StreamWriter sw = new StreamWriter("EquipedArmor.txt");
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.WriteLine(0);
                    sw.Close();
                }
                ItemIDList[SelectedItem - 1] = 0;
                ItemQList[SelectedItem - 1] = 0;
            }
            else
            {
                // nothing
            }
        }

        private void bEquip_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("PlayerInfo.txt");
            Player _player = new Player(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
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
            foreach (Weapon s in World.Weapons)
            {

                if (s.Class == _player.RaceID && s.ID == ItemIDList[SelectedItem - 1] && Lvl >= s.Lvl)
                {
                    bool yes = true;
                    while (yes)
                    {
                        try
                        {
                            using (StreamWriter sw = new StreamWriter("EquipedWeapon.txt"))
                            {

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
                                sw.Close();
                                yes = false;
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                if (s.Class != _player.RaceID && s.ID == ItemIDList[SelectedItem - 1])
                {
                    MessageBox.Show("Can not equip this weapon. Wrong class.");
                }
                if (s.Class == _player.RaceID && s.ID == ItemIDList[SelectedItem - 1] && Lvl < s.Lvl)
                {
                    MessageBox.Show("Level too low. You need level " + s.Lvl + " to wear this");
                }
            }
            foreach (Armor s in World.Armors)
            {
                if (s.Type == "Armor" && s.ID == ItemIDList[SelectedItem - 1] && Lvl >= s.Lvl)
                {
                    bool yes = true;
                    while (yes)
                    {
                        try
                        {
                            using (StreamWriter sw = new StreamWriter("EquipedArmor.txt"))
                            {
                                sw.WriteLine(s.Class);
                                sw.WriteLine(s.ID);
                                sw.WriteLine(s.ImageAdress);
                                sw.WriteLine(s.Info);
                                sw.WriteLine(s.Lvl);
                                sw.WriteLine(s.BonusArmor);
                                sw.WriteLine(s.BonusMagicResistance);
                                sw.WriteLine(s.Name);
                                sw.Close();
                                yes = false;
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                if (s.Type == "Armor" && s.ID == ItemIDList[SelectedItem - 1] && Lvl < s.Lvl)
                {
                    MessageBox.Show("Level too low. You need level " + s.Lvl + " to wear this");
                }
            }
            gbEditItemProperties.Enabled = false;
            gbEditItemProperties.Visible = false;
            gbEditItemProperties.Location = new Point(13, 270);
        }

        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter("Inventory.txt");
            for (int i = 0; i < 35; i++)
            {
                sw.WriteLine(ItemIDList[i]);
                sw.WriteLine(ItemQList[i]);
            }
            sw.Close();
        }

        private void Inventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
            {
                this.Close();
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[0] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox1.Location.X + 20, pictureBox1.Location.Y + 20);
                SelectedItem = 1;
            }
        }

        private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[1] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox2.Location.X + 20, pictureBox2.Location.Y + 20);
                SelectedItem = 2;
            }
        }

        private void pictureBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[2] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox3.Location.X + 20, pictureBox3.Location.Y + 20);
                SelectedItem = 3;
            }
        }

        private void pictureBox4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[3] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox4.Location.X + 20, pictureBox4.Location.Y + 20);
                SelectedItem = 4;
            }
        }

        private void pictureBox5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[4] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox5.Location.X + 20, pictureBox5.Location.Y + 20);
                SelectedItem = 5;
            }
        }

        private void pictureBox6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[5] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox6.Location.X + 20, pictureBox6.Location.Y + 20);
                SelectedItem = 6;
            }
        }

        private void pictureBox7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[6] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox7.Location.X + 20, pictureBox7.Location.Y + 20);
                SelectedItem = 7;
            }
        }

        private void pictureBox8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[7] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox8.Location.X + 20, pictureBox8.Location.Y + 20);
                SelectedItem = 8;
            }
        }

        private void pictureBox9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[8] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox9.Location.X + 20, pictureBox9.Location.Y + 20);
                SelectedItem = 9;
            }
        }

        private void pictureBox10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[9] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox10.Location.X + 20, pictureBox10.Location.Y + 20);
                SelectedItem = 10;
            }
        }

        private void pictureBox11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[10] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox11.Location.X + 20, pictureBox11.Location.Y + 20);
                SelectedItem = 11;
            }
        }

        private void pictureBox12_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[11] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox12.Location.X + 20, pictureBox12.Location.Y + 20);
                SelectedItem = 12;
            }
        }

        private void pictureBox13_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[12] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox13.Location.X + 20, pictureBox13.Location.Y + 20);
                SelectedItem = 13;
            }
        }

        private void pictureBox14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[13] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox14.Location.X + 20, pictureBox14.Location.Y + 20);
                SelectedItem = 14;
            }
        }

        private void pictureBox15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[14] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox15.Location.X + 20, pictureBox15.Location.Y + 20);
                SelectedItem = 15;
            }
        }

        private void pictureBox16_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[15] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox16.Location.X + 20, pictureBox16.Location.Y + 20);
                SelectedItem = 16;
            }
        }

        private void pictureBox17_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[16] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox17.Location.X + 20, pictureBox17.Location.Y + 20);
                SelectedItem = 17;
            }
        }

        private void pictureBox18_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[17] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox18.Location.X + 20, pictureBox18.Location.Y + 20);
                SelectedItem = 18;
            }
        }

        private void pictureBox19_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[18] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox19.Location.X + 20, pictureBox19.Location.Y + 20);
                SelectedItem = 19;
            }
        }

        private void pictureBox20_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[19] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox20.Location.X + 20, pictureBox20.Location.Y + 20);
                SelectedItem = 20;
            }
        }

        private void pictureBox21_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[20] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox21.Location.X + 20, pictureBox21.Location.Y + 20);
                SelectedItem = 21;
            }
        }

        private void pictureBox22_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[21] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox22.Location.X + 20, pictureBox22.Location.Y + 20);
                SelectedItem = 22;
            }
        }

        private void pictureBox23_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[22] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox23.Location.X + 20, pictureBox23.Location.Y + 20);
                SelectedItem = 23;
            }
        }

        private void pictureBox24_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[23] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox24.Location.X + 20, pictureBox24.Location.Y + 20);
                SelectedItem = 24;
            }
        }

        private void pictureBox25_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[24] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox25.Location.X + 20, pictureBox25.Location.Y + 20);
                SelectedItem = 25;
            }
        }

        private void pictureBox26_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[25] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox26.Location.X + 20, pictureBox26.Location.Y + 20);
                SelectedItem = 26;
            }
        }

        private void pictureBox27_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[26] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox27.Location.X + 20, pictureBox27.Location.Y + 20);
                SelectedItem = 27;
            }
        }

        private void pictureBox28_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[27] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox28.Location.X + 20, pictureBox28.Location.Y + 20);
                SelectedItem = 28;
            }
        }

        private void pictureBox29_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[28] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox29.Location.X + 20, pictureBox29.Location.Y + 20);
                SelectedItem = 29;
            }
        }

        private void pictureBox30_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[29] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox30.Location.X + 20, pictureBox30.Location.Y + 20);
                SelectedItem = 30;
            }
        }

        private void pictureBox31_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[30] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox31.Location.X + 20, pictureBox31.Location.Y + 20);
                SelectedItem = 31;
            }
        }

        private void pictureBox32_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[31] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox32.Location.X + 20, pictureBox32.Location.Y + 20);
                SelectedItem = 32;
            }
        }

        private void pictureBox33_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[32] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox33.Location.X + 20, pictureBox33.Location.Y + 20);
                SelectedItem = 33;
            }
        }

        private void pictureBox34_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[33] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox34.Location.X + 20, pictureBox34.Location.Y + 20);
                SelectedItem = 34;
            }
        }

        private void pictureBox35_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ItemIDList[34] > 0)
            {
                gbEditItemProperties.Enabled = true;
                gbEditItemProperties.Visible = true;
                gbEditItemProperties.Location = new Point(pictureBox35.Location.X + 20, pictureBox35.Location.Y + 20);
                SelectedItem = 35;
            }
        }

        private void bViewInfo_Click(object sender, EventArgs e)
        {
            foreach (Item i in World.Items)
            {
                if (i.ID == ItemIDList[SelectedItem - 1])
                {
                    MessageBox.Show(i.Info);
                }
            }
        }
    }
}
