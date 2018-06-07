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
    public partial class TalkingToVendor : Form
    {
        public int VendorID;
        public int[] ItemIDs = new int[35];
        public int[] ItemQs = new int[35];
        public string image_path;
        public int CurrentWeaponID = -1;
        public int CurrentArmorID = -1;
        public int Lvl;
        public TalkingToVendor(int[] items, int[] itemq, int vendorid)
        {
            VendorID = vendorid;
            ItemIDs = items;
            ItemQs = itemq;
            InitializeComponent();
        }

        private void TalkingToVendor_Load(object sender, EventArgs e)
        {
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

            StreamReader sr1 = new StreamReader("EquipedArmor.txt");
            temp = sr1.ReadLine();//Class
            temp = sr1.ReadLine();//ID
            CurrentArmorID = Int32.Parse(temp);
            temp = sr1.ReadLine();//Image
            temp = sr1.ReadLine();//Info
            temp = sr1.ReadLine();//Lvl
            temp = sr1.ReadLine();//Maxdmg
            temp = sr1.ReadLine();//Mindmg
            temp = sr1.ReadLine();//Name
            sr.Close();

            dgvYourItems.RowHeadersVisible = false;
            dgvYourItems.AutoGenerateColumns = false;
            dgvYourItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Item Name",
                Width = 100,
                DataPropertyName = "Item Name"
            });
            dgvYourItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Description",
                Width = 350,
                DataPropertyName = "Description"
            });
            dgvYourItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                Width = 55,
                DataPropertyName = "Quantity"
            });
            dgvYourItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                Width = 50,
                DataPropertyName = "Price"
            });
            for (int i = 0; i < 35; i++)
            {
                if (ItemIDs[i] != 0 && ItemQs[i] != 0)
                {
                    foreach(Item I in World.Items)
                    {
                        if(I.ID == ItemIDs[i])
                        {
                            this.dgvYourItems.Rows.Add(I.Name, I.Info, ItemQs[i], I.Price);
                        }
                    }
                }
            }
            dgvVendorsItems.RowHeadersVisible = false;
            dgvVendorsItems.AutoGenerateColumns = false;
            dgvVendorsItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Item Name",
                Width = 100,
                DataPropertyName = "Item Name"
            });
            dgvVendorsItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Description",
                Width = 350,
                DataPropertyName = "Description"
            });
            dgvVendorsItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                Width = 55,
                DataPropertyName = "Quantity"
            });
            dgvVendorsItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                Width = 50,
                DataPropertyName = "Price"
            });
            int z = 0;
            foreach (Vendor v in World.Vendors)
            {
                if (v.ID == VendorID)
                {
                    for (int i = 0; i < v.Items4Sale.Length; i++)
                    {
                        foreach(Item I in World.Items)
                        {
                            if(I.ID == v.Items4Sale[i])
                            {
                                this.dgvVendorsItems.Rows.Insert(z, I.Name, I.Info, "Unlimited", v.ItemPrices[i]);
                                z++;
                            }
                        }
                    }
                }
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to sell this item? This can not be reverted.", "Warning!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < ItemIDs.Length; i++)
                {
                    if (ItemIDs[i] != 0)
                    {
                        if (i == dgvYourItems.CurrentCell.RowIndex)
                        {
                            foreach (Item I in World.Items)
                            {
                                if (I.ID == ItemIDs[i])
                                {
                                    int Gold = 0;
                                    int Exp = 0;
                                    bool yes = true;
                                    while (yes)
                                    {
                                        try
                                        {
                                            using (StreamReader srGoldExp = new StreamReader("GoldExp.txt"))
                                            {

                                                Gold = Int32.Parse(srGoldExp.ReadLine());
                                                Exp = Int32.Parse(srGoldExp.ReadLine());
                                                Lvl = Int32.Parse(srGoldExp.ReadLine());
                                                srGoldExp.Close();
                                                yes = false;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    yes = true;
                                    while (yes)
                                    {
                                        try
                                        {
                                            using (StreamWriter swGoldExp = new StreamWriter("GoldExp.txt"))
                                            {
                                                Gold = Gold + I.Price;
                                                swGoldExp.WriteLine(Gold);
                                                swGoldExp.WriteLine(Exp);
                                                swGoldExp.WriteLine(Lvl);
                                                swGoldExp.Close();
                                                yes = false;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                            }
                            bool YES = true;
                            if (ItemIDs[i] == CurrentWeaponID && CurrentWeaponID != 0)
                            {
                                YES = true;
                                while (YES)
                                {
                                    try
                                    {
                                        using (StreamWriter swW = new StreamWriter("EquipedWeapon.txt"))
                                        {

                                            swW.WriteLine(0);
                                            swW.WriteLine(0);
                                            swW.WriteLine(0);
                                            swW.WriteLine(0);
                                            swW.WriteLine(0);
                                            swW.WriteLine(0);
                                            swW.WriteLine(0);
                                            swW.WriteLine(0);
                                            swW.WriteLine(0);
                                            swW.WriteLine(0);
                                            swW.Close();
                                            YES = false;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            if (ItemIDs[i] == CurrentArmorID && CurrentArmorID != 0)
                            {
                                YES = true;
                                while (YES)
                                {
                                    try
                                    {
                                        using (StreamWriter swA = new StreamWriter("EquipedArmor.txt"))
                                        {
                                            swA.WriteLine(0);
                                            swA.WriteLine(0);
                                            swA.WriteLine(0);
                                            swA.WriteLine(0);
                                            swA.WriteLine(0);
                                            swA.WriteLine(0);
                                            swA.WriteLine(0);
                                            swA.WriteLine(0);
                                            swA.Close();
                                            YES = false;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            if (ItemQs[i] <= 1)
                            {
                                ItemIDs[i] = 0;
                                dgvYourItems.Rows.Clear();
                                for (int z = 0; z < 35; z++)
                                {
                                    if (ItemIDs[z] != 0 && ItemQs[z] != 0)
                                    {
                                        foreach (Item I in World.Items)
                                        {
                                            if (I.ID == ItemIDs[z])
                                            {
                                                this.dgvYourItems.Rows.Insert(0, I.Name, I.Info, ItemQs[z], I.Price);
                                            }
                                        }
                                    }
                                }
                                ItemQs[i] = 1;
                            }
                            ItemQs[i]--;
                            YES = true;
                            while (YES)
                            {
                                try
                                {
                                    using (StreamWriter swI = new StreamWriter("Inventory.txt"))
                                    {
                                        for (int j = 0; j < 35; j++)
                                        {
                                            swI.WriteLine(ItemIDs[j]);
                                            swI.WriteLine(ItemQs[j]);
                                        }
                                        swI.Close();
                                        YES = false;
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
            }
        }

        void AddItem(int a)
        {
            bool Yes = false;
            for (int i = 0; i < 20; i++)
            {
                if (ItemIDs[i] == a)
                {
                    Yes = true;
                    ItemQs[i]++;
                    break;
                }
            }
            if (Yes == false)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (ItemIDs[i] == 0)
                    {
                        ItemIDs[i] = a;
                        ItemQs[i] = 1;
                        break;
                    }
                }
            }
            Yes = false;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            foreach(Vendor v in World.Vendors)
            {
                if (v.ID == VendorID)
                {
                    for (int i = 0; i < v.Items4Sale.Length; i++)
                    {
                        if(i == dgvVendorsItems.CurrentCell.RowIndex)
                        {
                            int Gold = 0;
                            int Exp = 0;
                            bool yes = true;
                            while (yes)
                            {
                                try
                                {
                                    using (StreamReader srGoldExp2 = new StreamReader("GoldExp.txt"))
                                    {

                                        Gold = Int32.Parse(srGoldExp2.ReadLine());
                                        Exp = Int32.Parse(srGoldExp2.ReadLine());
                                        Lvl = Int32.Parse(srGoldExp2.ReadLine());
                                        srGoldExp2.Close();
                                        yes = false;
                                    }
                                }
                                catch
                                {

                                }
                            }
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to buy this for " + v.ItemPrices[i] + " gold ?", "Warning!!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (Gold >= v.ItemPrices[i])
                                {
                                    AddItem(v.Items4Sale[i]);
                                    yes = true;
                                    while (yes)
                                    {
                                        try
                                        {
                                            using (StreamWriter swGoldExp2 = new StreamWriter("GoldExp.txt"))
                                            {

                                                swGoldExp2.WriteLine(Gold - v.ItemPrices[i]);
                                                Gold = Gold - v.ItemPrices[i];
                                                swGoldExp2.WriteLine(Exp);
                                                swGoldExp2.WriteLine(Lvl);
                                                swGoldExp2.Close();
                                                yes = false;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    while (yes)
                                    {
                                        try
                                        {
                                            using (StreamWriter swI1 = new StreamWriter("Inventory.txt"))
                                            {
                                                for (int j = 0; j < 35; j++)
                                                {
                                                    swI1.WriteLine(ItemIDs[j]);
                                                    swI1.WriteLine(ItemQs[j]);
                                                }
                                                swI1.Close();
                                                yes = false;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Insufficient funds.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
