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
    public partial class StaffForm : Form
    {
        private account loggedInStaff;
        private ItemUtil itemUtil = new ItemUtil();
        private OrderUtil orderUtil = new OrderUtil();

        private static bool orderPollingThreadActive = true;

        public StaffForm()
        {
            InitializeComponent();
            StaffLoginForm login = new StaffLoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                loggedInStaff = login.loggedInAccount;
            }
            else
            {
                Environment.Exit(0);
            }

            //loading the food data
            loadFoodData();

            //loading the order data
            loadOrderData();

            //starting the order polling thread
            startOrderPollingThread();
        }

        private void startOrderPollingThread()
        {
            new Thread(() =>
            {
                while (orderPollingThreadActive)
                {
                    try
                    {
                        List<order> orders = orderUtil.getNotAcceptedOrders();
                        if (orders != null)
                        {
                            foreach (var order in orders)
                            {
                                bool found = false;
                                foreach(var item in orderBindingSource)
                                {
                                    if (((order)item).id == order.id)
                                    {
                                        found = true;
                                        break;
                                    }
                                    
                                }
                                if (!found)
                                {
                                    orderBindingSource.Add(order);
                                }
                            }
                        }
                        Thread.Sleep(1000);
                    }
                    catch
                    {

                    }
                }
            }).Start();
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlSelection.Location = new Point(pnlSelection.Location.X, btnMenu.Location.Y);
            tcTabs.SelectedIndex = 0;
            lblTabInfo.Text = "Pristigle narudzbe";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            pnlSelection.Location = new Point(pnlSelection.Location.X, btnOrder.Location.Y);
            tcTabs.SelectedIndex = 1;
            lblTabInfo.Text = "Menadzment hrane";
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            pnlSelection.Location = new Point(pnlSelection.Location.X, btnInfo.Location.Y);
            tcTabs.SelectedIndex = 2;
            lblTabInfo.Text = "Menadzment naloga";
        }

        private void loadFoodData()
        {
            List<item> foodList = itemUtil.getAlItems();
            if(foodList != null)
            {
                foreach(var item in foodList)
                {
                    itemBindingSource.Add(item);
                }
            }
        }

        private void loadOrderData()
        {
            List<order> orderList = orderUtil.getNotAcceptedOrders();
            if(orderList != null)
            {
                foreach(var order in orderList)
                {
                    orderBindingSource.Add(order);
                }
            }
        }

        private void dgvFood_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvFood.SelectedRows[0];
                item selectedItem = (item)selectedRow.DataBoundItem;
                if (selectedItem.active == 1)
                {
                    btnActivateItem.Text = "Deaktiviraj stavku";
                }
                else btnActivateItem.Text = "Aktiviraj stavku";
            }
        }

        private void btnActivateItem_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvFood.SelectedRows[0];
                item selectedItem = (item)selectedRow.DataBoundItem;
                if (selectedItem.active == 1)
                {
                    if (itemUtil.changeActiveStatus(selectedItem.id, 0))
                    {
                        selectedItem.active = 0;
                        dgvFood.Refresh();
                        btnActivateItem.Text = "Aktiviraj stavku";
                    }
                }
                else
                {
                    if(itemUtil.changeActiveStatus(selectedItem.id, 1))
                    {
                        selectedItem.active = 1;
                        dgvFood.Refresh();
                        btnActivateItem.Text = "Deaktiviraj stavku";
                    }
                }

            }
        }

        private void btnAcceptOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvOrders.SelectedRows[0];
                order selectedItem = (order)selectedRow.DataBoundItem;
                if (orderUtil.acceptOrder(selectedItem.id))
                {
                    orderBindingSource.Remove(selectedItem);
                }
            }
        }

        private void StaffForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            orderPollingThreadActive = false;
        }

        private void btnOrderDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvOrders.SelectedRows[0];
                order selectedItem = (order)selectedRow.DataBoundItem;
                new OrderDetailsForm(selectedItem).ShowDialog();
            }
        }

        private void dgvFood_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "Aktivan")
            {
                e.Value = (sbyte)e.Value == 1 ? "Da" : "Ne";
                e.FormattingApplied = true;
            }
        }

        private void refreshItemData()
        {
            itemBindingSource.Clear();
            loadFoodData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemForm form = new ItemForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                refreshItemData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvFood.SelectedRows[0];
                item selectedItem = (item)selectedRow.DataBoundItem;
                ItemForm form = new ItemForm(selectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    refreshItemData();
                }
            }
        }
    }
}
