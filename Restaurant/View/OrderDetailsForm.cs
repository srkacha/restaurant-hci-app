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
    public partial class OrderDetailsForm : Form
    {
        private order myOrder;
        private OrderUtil orderUtil = new OrderUtil();
        private ItemUtil itemUtil = new ItemUtil();

        public OrderDetailsForm()
        {
            InitializeComponent();
        }

        public OrderDetailsForm(order order)
        {
            InitializeComponent();
            myOrder = order;

            //loading the data
            loadOrderItemData();

            updateTotalPrice();
        }

        private void loadOrderItemData()
        {
            List<orderitem> orderItems = orderUtil.getOrderItemsForOrderId(myOrder.id);
            if(orderItems != null && orderItems.Count > 0)
            {
                foreach(var orderItem in orderItems)
                {
                    String itemName = itemUtil.getItemNameForId(orderItem.Item_id);
                    if (itemName == null) itemName = $"Item id: {orderItem.Item_id}";
                    OrderItemCustom oic = new OrderItemCustom
                    {
                        name = itemName,
                        price = orderItem.price,
                        quantity = orderItem.quantity,
                        totalPrice = orderItem.price * orderItem.quantity
                    };
                    orderItemCustomBindingSource.Add(oic);
                }
            }
        }

        private void updateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach(var item in orderItemCustomBindingSource)
            {
                totalPrice += ((OrderItemCustom)item).totalPrice;
            }
            lblTotalPrice.Text = $"{totalPrice} KM";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
