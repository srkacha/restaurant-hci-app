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
    public partial class StaffForm : Form
    {
        private account loggedInStaff;
        private ItemUtil itemUtil = new ItemUtil();
        private OrderUtil orderUtil = new OrderUtil();

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
            List<order> orderList = orderUtil.getAllOrders();
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
    }
}
