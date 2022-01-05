using CarPartsOnline.Data;
using CarPartsOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsOnline.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext db;

        public OrderService(DataContext db)
        {
            this.db = db;
        }

        public Order CreateOrder(string userId)
        {
            Order o = new Order();
            o.userId = Convert.ToInt32(userId);
            o.orderDate = DateTime.Now;
            db.Orders.Add(o);
            db.SaveChanges();
            return o;
        }

        public bool CreateOrderItems(Order o, List<ShoppingCart> cart)
        {
            foreach (ShoppingCart sc in cart)
            {
                OrderProduct op = new OrderProduct();
                op.amount = sc.amount;
                op.productId = sc.product.productID;
                op.OrderId = o.orderId;

                db.OrderProducts.Add(op);
            }
            db.SaveChanges();
            return true;
        }

        public bool deleteOrders(int orderId)
        {
            try
            {
                Order o = (from Order in db.Orders
                           where Order.orderId == orderId
                           select Order).FirstOrDefault();
                db.Orders.Remove(o);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Order> getOrders(string userId)
        {
            List<Order> orders = (from Order in db.Orders
                                  where Order.userId == Convert.ToInt32(userId)
                                  select Order).ToList();

            return orders;

        }
    }
}
