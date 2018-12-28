using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Model;
using Restaurant.Util;

namespace Restaurant.View
{
    public partial class ClientForm : Form
    {
        private ItemUtil itemUtil = new ItemUtil();
        private table loggedInTable = null;

        public ClientForm()
        {
            InitializeComponent();
            LoginForm login = new LoginForm();
            if(login.ShowDialog() == DialogResult.OK)
            {
                loggedInTable = login.loggedInTable;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlSelection.Location = new Point(pnlSelection.Location.X, btnMenu.Location.Y);
            tcTabs.SelectedIndex = 0;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            pnlSelection.Location = new Point(pnlSelection.Location.X, btnOrder.Location.Y);
            tcTabs.SelectedIndex = 1;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            pnlSelection.Location = new Point(pnlSelection.Location.X, btnInfo.Location.Y);
            tcTabs.SelectedIndex = 2;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            loadItems();
            lvFood.Select();
        }

        private void loadItems()
        {
            lblTableNumber.Text = $"Sto broj {loggedInTable.number}";

            lvFood.Items.Clear();
            List<item> items = itemUtil.getAllItems();
            foreach(var item in items)
            {
                ListViewItem lvitem = new ListViewItem(item.name);
                lvitem.Tag = item;
                switch (item.ItemType_id)
                {
                    case 1:
                        lvitem.Group = lvFood.Groups[0];
                        break;
                    case 2:
                        lvitem.Group = lvFood.Groups[1];
                        break;
                    case 3:
                        lvitem.Group = lvFood.Groups[2];
                        break;
                }
                lvFood.Items.Add(lvitem);
            }

            //selecting the first item if possible
            if (lvFood.Items.Count > 0) lvFood.Items[0].Selected = true;
        }

        private void lvFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvFood.SelectedItems.Count == 1)
            {
                nudItemQuantity.Value = 1;
                item selectedItem = (item)lvFood.SelectedItems[0].Tag;
                lblItemName.Text = selectedItem.name;
                txtItemDescription.Clear();
                txtItemDescription.Text = selectedItem.description;
                lblItemPrice.Text = $"Cijena: {selectedItem.price} KM";
                try
                {
                    pbItemImage.Image = Image.FromFile(selectedItem.image_path);
                }catch(Exception ex)
                {

                }

            }
        }
    }
}
