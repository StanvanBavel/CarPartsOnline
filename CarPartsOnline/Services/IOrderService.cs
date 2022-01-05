using CarPartsOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsOnline.Services
{
    public interface IOrderService
    {
        public Order CreateOrder(string userId);
        public bool CreateOrderItems(Order order, List<ShoppingCart> cart);
        public List<Order> getOrders(string userId);
        public bool deleteOrders(int orderId);
    }
}
