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
    public partial class ItemForm : Form
    {
        private ItemUtil itemUtil = new ItemUtil();
        private ItemTypeUtil itemTypeUtil = new ItemTypeUtil();

        private bool addNewItemFlag = false;
        private item myItem = null;
        private Image itemImage = null;
        private String imagePath = null;

        public ItemForm()
        {
            InitializeComponent();
            addNewItemFlag = true;
            hideAllValidationMessages();
            btnReset.Visible = false;
            loadItemTypes();
        }

        public ItemForm(item myItem)
        {
            InitializeComponent();
            this.myItem = myItem;
            addNewItemFlag = false;
            hideAllValidationMessages();
            loadItemTypes();

            this.Text = "Azuriranje stavke";
            btnActivateItem.Text = "Azuriraj stavku";

            //loading the existing item attributes
            loadExistingItemAttributes();
        }

        private void loadExistingItemAttributes()
        {
            txtItemName.Text = myItem.name;
            txtItemDescription.Text = myItem.description;
            nudItemPrice.Value = myItem.price;
            itemtype item = null;
            foreach(var choice in cmbItemType.Items)
            {
                if(((itemtype)choice).id == myItem.ItemType_id)
                {
                    item = (itemtype)choice;
                }
            }
            if (item != null) cmbItemType.SelectedItem = item;
            if(myItem.image_path != null)
            {
                try
                {
                    itemImage = Image.FromFile(myItem.image_path);
                    pbItemImage.Image = itemImage;
                    imagePath = myItem.image_path;
                }
                catch { }
            }

        }

        private void loadItemTypes()
        {
            List<itemtype> itemTypes = itemTypeUtil.getAllItemTypes();
            if(itemTypes != null)
            {
                foreach(var it in itemTypes)
                {
                    cmbItemType.Items.Add(it);
                }
            }
        }

        private void pbItemImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Izaberite sliku";
            openFileDialog.Filter = "Image Files (*.jpg)|*.jpg";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                itemImage = Image.FromFile(openFileDialog.FileName);
                pbItemImage.Image = itemImage;
                imagePath = openFileDialog.FileName;
            }
            else
            {
                pbItemImage.Image = null;
                itemImage = null;
                imagePath = null;
            }
        }

        private bool isInputValid()
        {
            hideAllValidationMessages();
            bool valid = true;
            if (txtItemName.Text.Equals(""))
            {
                lblNameValid.Text = "Polje ne smije ostati prazno";
                lblNameValid.Visible = true;
                valid = false;
            }
            if (itemUtil.nameExists(txtItemName.Text) && !txtItemName.Text.Equals(myItem!=null?myItem.name:""))
            {
                lblNameValid.Text = "Stavka sa datim nazivom vec postoji";
                lblNameValid.Visible = true;
                valid = false;
            }
            if (txtItemDescription.Text.Equals(""))
            {
                lblDescValid.Visible = true;
                valid = false;
            }
            if (nudItemPrice.Value<=0)
            {
                lblPriceValid.Visible = true;
                valid = false;
            }
            if (cmbItemType.Text.Equals(""))
            {
                lblTypeValid.Visible = true;
                valid = false;
            }
            if (itemImage == null)
            {
                lblImageValid.Visible = true;
                valid = false;
            }

            return valid;
        }

        private void hideAllValidationMessages()
        {
            lblDescValid.Visible = false;
            lblImageValid.Visible = false;
            lblNameValid.Visible = false;
            lblPriceValid.Visible = false;
            lblTypeValid.Visible = false;
        }

        private void btnActivateItem_Click(object sender, EventArgs e)
        {
            if(addNewItemFlag == true)
            {
                addNewItem();
            }
            else
            {
                updateExistingItem();
            }
        }

        private void addNewItem()
        {
            if (isInputValid())
            {
                hideAllValidationMessages();

                int typeId = ((itemtype)cmbItemType.SelectedItem).id;
                if (itemUtil.addItem(txtItemName.Text, txtItemDescription.Text, typeId, nudItemPrice.Value, imagePath))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void updateExistingItem()
        {
            if (isInputValid())
            {
                hideAllValidationMessages();

                int typeId = ((itemtype)cmbItemType.SelectedItem).id;
                if (itemUtil.updateItem(myItem.id, txtItemName.Text, txtItemDescription.Text, typeId, nudItemPrice.Value, imagePath))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            loadExistingItemAttributes();
        }
    }
}
