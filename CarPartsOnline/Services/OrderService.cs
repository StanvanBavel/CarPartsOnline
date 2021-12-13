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
            Order order = new Order();
            order.userId = Convert.ToInt32(userId);
            order.orderDate = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }

        public bool CreateOrderItems(Order order, List<ShoppingCart> cart)
        {
            foreach (ShoppingCart shoppingcart in cart)
            {
                OrderProduct orderproduct = new OrderProduct();
                orderproduct.amount = shoppingcart.amount;
                orderproduct.productId = shoppingcart.product.productID;
                orderproduct.OrderId = order.orderId;

                db.OrderProducts.Add(orderproduct);
            }
            db.SaveChanges();
            return true;
        }
    }
}
