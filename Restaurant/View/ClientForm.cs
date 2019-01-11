using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Model;
using Restaurant.Util;

namespace Restaurant.View
{
    public partial class ClientForm : Form
    {
        List<OrderItemCustom> orderItems = new List<OrderItemCustom>();
        private ItemUtil itemUtil = new ItemUtil();
        private OrderUtil orderUtil = new OrderUtil();
        private table loggedInTable = null;

        private static int lastOrderId = -1;
        private static bool orderAcceptedPollingThreadActive = true;

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

            //starting the order checker thread
            startOrderCheckerThread();
        }

        public void startOrderCheckerThread()
        {
            new Thread(() =>
            {
                while (orderAcceptedPollingThreadActive)
                {
                    if (orderUtil.isOrderAccepted(lastOrderId))
                    {
                        new InfoForm($"Narudzba sa brojem {lastOrderId} je prihvacena.").ShowDialog();

                        //invoke calls a delegate on the thread that controls the label, the main UI thread
                        lblOrderStatus.Invoke((MethodInvoker)delegate
                        {
                            lblOrderStatus.Text = "Status narudzbe: Izrada";
                        });
                        lastOrderId = -1;
                    }
                    Thread.Sleep(1000);
                }
            }).Start();
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
            updateTotalPrice();
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
            List<item> items = itemUtil.getAllActiveItems();
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
                lblItemPrice.Text = $"Cijena: {selectedItem.price} KM/kom";
                try
                {
                    pbItemImage.Image = Image.FromFile(selectedItem.image_path);
                }catch(Exception ex)
                {

                }

            }
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            addOrderItem();
        }

        private void addOrderItem()
        {
            if (lvFood.SelectedItems.Count == 1)
            {
                item selectedItem = (item)lvFood.SelectedItems[0].Tag;
                int quantity = (int)nudItemQuantity.Value;
                bool itemFound = false;
                foreach(var item in orderItemCustomBindingSource)
                {
                    if(((OrderItemCustom)item).id == selectedItem.id)
                    {
                        ((OrderItemCustom)item).quantity += quantity;
                        ((OrderItemCustom)item).totalPrice += quantity * ((OrderItemCustom)item).price;
                        itemFound = true;
                    }
                }

                if (!itemFound)
                {
                    OrderItemCustom newItem = new OrderItemCustom
                    {
                        id = selectedItem.id,
                        name = selectedItem.name,
                        price = selectedItem.price,
                        quantity = quantity,
                        totalPrice = selectedItem.price * quantity
                    };
                    orderItemCustomBindingSource.Add(newItem);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvOrderItems.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvOrderItems.SelectedRows[0];
                OrderItemCustom selectedItem = (OrderItemCustom)selectedRow.DataBoundItem;
                nudOrderQuantity.Value = selectedItem.quantity;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvOrderItems.SelectedRows[0];
                OrderItemCustom selectedItem = (OrderItemCustom)selectedRow.DataBoundItem;
                selectedItem.quantity = (int)nudOrderQuantity.Value;
                selectedItem.totalPrice = selectedItem.price * selectedItem.quantity;
                dgvOrderItems.Refresh();

                updateTotalPrice();
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvOrderItems.SelectedRows[0];
                OrderItemCustom selectedItem = (OrderItemCustom)selectedRow.DataBoundItem;
                orderItemCustomBindingSource.Remove(selectedItem);
                dgvOrderItems.Refresh();

                updateTotalPrice();
            }
        }

        private void updateTotalPrice()
        {
            //updating the total price label
            decimal totalPrice = getTotalPrice();
            lblTotalPrice.Text = $"{totalPrice} KM";
        }

        private decimal getTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in orderItemCustomBindingSource)
            {
                totalPrice += ((OrderItemCustom)item).totalPrice;
            }
            return totalPrice;
        }

        private List<OrderItemCustom> getOrderItemsAsList()
        {
            List<OrderItemCustom> result = new List<OrderItemCustom>();
            foreach(var item in orderItemCustomBindingSource)
            {
                result.Add((OrderItemCustom)item);
            }
            return result;
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (orderItemCustomBindingSource.Count > 0)
            {
                if (!lblOrderStatus.Text.Contains("Obrada"))
                {
                    int orderNumber = 0;
                    if ((orderNumber = createOrder()) > 0)
                    {
                        new InfoForm($"Broj vase narudzbe je {orderNumber}. Prijatno!").ShowDialog();
                        lblOrderStatus.Text = "Status narudzbe: Obrada";
                        //setting the last order id
                        lastOrderId = orderNumber;
                        orderItemCustomBindingSource.Clear();
                        updateTotalPrice();
                        nudOrderQuantity.Value = 1;
                    }
                    else new InfoForm("Desio se problem sa kreiranjem narudzbe, molimo Vas pokusajte ponovno.").ShowDialog();
                }
                else new InfoForm("Prethodna narudzba jos nije obradjena, molimo Vas da sacekate.").ShowDialog();
                
            }
            else new InfoForm("Morate imati bar jednu stavku narudzbe da biste uspjesno kreirali narudzbu.").ShowDialog();
        }

        private int createOrder()
        {
            //first we create the list
            List<OrderItemCustom> orderItems = getOrderItemsAsList();
            decimal totalPrice = getTotalPrice();
            int tableId = loggedInTable.id;
            return orderUtil.addOrder(orderItems, totalPrice, tableId);
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            orderAcceptedPollingThreadActive = false;
        }
    }
}
