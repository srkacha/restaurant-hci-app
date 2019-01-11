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
        private AccountUtil accountUtil = new AccountUtil();
        private AccountTypeUtil accountTypeUtil = new AccountTypeUtil();
        private TableUtil tableUtil = new TableUtil();

        private List<accounttype> accounttypes = new List<accounttype>();
        private List<table> tables = new List<table>();

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

            //loading the account data
            loadAccountData();

            //loading account types
            loadAccountTypes();

            //loading the table data
            loadTableData();

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
                                foreach (var item in orderBindingSource)
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
            if (foodList != null)
            {
                foreach (var item in foodList)
                {
                    itemBindingSource.Add(item);
                }
            }
        }

        private void loadOrderData()
        {
            List<order> orderList = orderUtil.getNotAcceptedOrders();
            if (orderList != null)
            {
                foreach (var order in orderList)
                {
                    orderBindingSource.Add(order);
                }
            }
        }

        private void loadAccountData()
        {
            List<account> accounts = accountUtil.getAllAccounts();
            if (accounts != null)
            {
                foreach (var acc in accounts)
                {
                    accountBindingSource.Add(acc);
                }
            }
        }

        private void loadAccountTypes()
        {
            List<accounttype> acctypes = accountTypeUtil.getAllAccountTypes();
            if (acctypes != null)
            {
                foreach (var acc in acctypes)
                {
                    accounttypes.Add(acc);
                }
            }
        }

        private void loadTableData()
        {
            List<table> tableData = tableUtil.getAllTables();
            if(tableData != null)
            {
                foreach(var table in tableData)
                {
                    tables.Add(table);
                    cmbTableNumber.Items.Add(table);
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
                    if (itemUtil.changeActiveStatus(selectedItem.id, 1))
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
                if(selectedItem.accepted == 0)
                {
                    if (orderUtil.acceptOrder(selectedItem.id))
                    {
                        selectedItem.accepted = 1;
                        if(chbAcceptedOrders.Checked == false)
                        {
                            orderBindingSource.Remove(selectedItem);
                        }
                        dgvOrders.Refresh();

                    }
                }
                else
                {
                    new InfoForm("Narudzba je vec prihvacena.").ShowDialog();
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
            if (form.ShowDialog() == DialogResult.OK)
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

        private void dgvAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (accounttypes.Count > 0)
            {
                var grid = (DataGridView)sender;
                if (grid.Columns[e.ColumnIndex].Name == "VrstaNaloga")
                {
                    e.Value = accounttypes.Where(a => a.id == (int)e.Value).First().name;
                    e.FormattingApplied = true;
                }
                if (grid.Columns[e.ColumnIndex].Name == "active")
                {
                    e.Value = (sbyte)e.Value == 1 ? "Da" : "Ne";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnActivateAccount_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvAccounts.SelectedRows[0];
                account selectedItem = (account)selectedRow.DataBoundItem;
                if (selectedItem.id != loggedInStaff.id)
                {
                    if (selectedItem.active == 1)
                    {
                        if (accountUtil.changeActiveStatus(selectedItem.id, 0))
                        {
                            selectedItem.active = 0;
                            dgvAccounts.Refresh();
                            btnActivateAccount.Text = "Aktiviraj nalog";
                        }
                    }
                    else
                    {
                        if (accountUtil.changeActiveStatus(selectedItem.id, 1))
                        {
                            selectedItem.active = 1;
                            dgvAccounts.Refresh();
                            btnActivateAccount.Text = "Deaktiviraj nalog";
                        }
                    }
                }
                else new InfoForm("Ne mozete deaktivirati vlastiti nalog.").ShowDialog();
            }
        }

        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvAccounts.SelectedRows[0];
                account selectedItem = (account)selectedRow.DataBoundItem;
                if (selectedItem.active == 1)
                {
                    btnActivateAccount.Text = "Deaktiviraj nalog";
                }
                else btnActivateAccount.Text = "Aktiviraj nalog";
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm();
            if(accountForm.ShowDialog() == DialogResult.OK)
            {
                refreshAccountData();
            }
        }

        private void refreshAccountData()
        {
            accountBindingSource.Clear();
            loadAccountData();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvAccounts.SelectedRows[0];
                account selectedItem = (account)selectedRow.DataBoundItem;
                PasswordForm form = new PasswordForm(selectedItem);
                if(form.ShowDialog() == DialogResult.OK)
                {
                    refreshAccountData();
                }
            }
        }

        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "accepted")
            {
                e.Value = (sbyte)e.Value == 1 ? "Da" : "Ne";
                e.FormattingApplied = true;
            }
            if (grid.Columns[e.ColumnIndex].Name == "Table_id")
            {
                e.Value = $"{tableUtil.getTableNumberForTableId((int)e.Value)}";
                e.FormattingApplied = true;
            }
        }

        private void chbAcceptedOrders_CheckedChanged(object sender, EventArgs e)
        {
            orderBindingSource.Clear();
            loadFilteredOrders();
        }

        private void cmbTableNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderBindingSource.Clear();
            loadFilteredOrders();
        }

        private void loadFilteredOrders()
        {
            List<order> orders = orderUtil.getAllOrders();
            if(orders != null)
            {
                if(chbAcceptedOrders.Checked == false)
                {
                    orders = orders.Where(o => o.accepted == 0).ToList();
                }

                //table filtering
                if(!cmbTableNumber.Text.Equals("Svi stolovi") && !cmbTableNumber.Text.Equals(""))
                {
                    table selectedTable = (table)cmbTableNumber.SelectedItem;
                    orders = orders.Where(o => o.Table_id == selectedTable.id).ToList();
                }

                foreach(var o in orders)
                {
                    orderBindingSource.Add(o);
                }
            }
        }
    }
}
