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
    public partial class Form1 : Form
    {
        private static string project_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private string[] lines = project_path.Split('\\');
        public string image_path = "";
        string save;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (save == "Yes")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to start a new game and delete save data?", "Warning!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    StreamWriter sws = new StreamWriter("Save.txt");
                    sws.WriteLine("No");
                    sws.Close();
                    CharacterCreator f2 = new CharacterCreator();
                    f2.StartPosition = FormStartPosition.CenterParent;
                    f2.ShowDialog(this);
                    StreamWriter sw = new StreamWriter("Save.txt");
                    sw.WriteLine("No");
                    sw.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do nothing lel
                }
            }
            else
            {
                //Cant close sad
                CharacterCreator f2 = new CharacterCreator();
                f2.StartPosition = FormStartPosition.CenterParent;
                f2.ShowDialog(this);
            }
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            if (save == "Yes")
            {
                //load save
                MainGameForm f1 = new MainGameForm();
                f1.StartPosition = FormStartPosition.CenterParent;
                f1.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No save found. Start new game.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("Save.txt");
            save = sr.ReadLine();
            sr.Close();
            for (int i = 0; i < lines.Length - 1; i++)
            {
                image_path = image_path + lines[i] + "\\";
            }
            image_path = image_path + "Engine\\Images\\";
            pbTitle.Image = new Bitmap(@image_path + "Name.png");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Use the arrow keys to move.\n 2. Press \"A\" to attack. Remember that while in combat you can not run away. \n 3. Press \"I\" to access Inventory. \n 4. Moving to another map requires you to agree with it. \n 5. Get quests from NPCs to receive rewards. \n 6. Talk to vendors to buy and sell items. \n 7. Press \"C\" to Clear game Monologue");
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Special thanks to: \n Kenney at http://kenney.nl/assets/roguelike-rpg-pack for the sprite sheet \n My teacher for helping me \n RedBull for reasons \n \n And my friend Andrius \n Check out his Rune Scape server at http://partyscape.org/\n ");
        }
    }
}
