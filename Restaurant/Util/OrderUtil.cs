using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;

namespace Restaurant.Util
{
    class OrderUtil
    {
        public int addOrder(List<OrderItemCustom> orderItems, decimal totalPrice, int tableId)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    //first we create the order object
                    order newOrder = new order
                    {
                        date = DateTime.Now,
                        time = DateTime.Now.TimeOfDay,
                        total = totalPrice,
                        accepted = 0,
                        Table_id = tableId
                    };
                    context.order.Add(newOrder);
                    context.SaveChanges();

                    //creating order items
                    foreach(var item in orderItems)
                    {
                        orderitem newOrderItem = new orderitem
                        {
                            Order_id = newOrder.id,
                            Item_id = item.id,
                            quantity = item.quantity,
                            price = item.price
                        };
                        context.orderitem.Add(newOrderItem);
                    }
                    context.SaveChanges();

                    return newOrder.id;
                }
                catch(Exception ex)
                {

                    return 0;
                }
            }
        }

        public List<order> getAllOrders()
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.order.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool isOrderAccepted(int orderId)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    order requested = context.order.Where(o => o.id == orderId).First();
                    if (requested != null && requested.accepted == 1)
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
