using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadedRestaraunt
{
    public class OrderWall
    {
        private HashSet<Order> _orders;
        private Object wallLock = new Object();
        public OrderWall(HashSet<Order> orders)
        {
            _orders = orders;
        }

        public void PlaceOrder(Order order)
        {
            lock (wallLock)
            {
                Console.WriteLine("ORDER TAKER: Placing Order for customer: {0}", order.CustomerID);
                _orders.Add(order);
            }
        }

        public Order GrabOrder()
        {
            Order foundOrder = null;
            lock (wallLock)
            {
                Random rand = new Random();
                Order[] orderArr = _orders.ToArray();
                if (orderArr.Length > 0)
                {
                    int randomIndex = rand.Next(orderArr.Length);
                    foundOrder = orderArr.ElementAt(randomIndex);
                    Console.WriteLine("CHEF: Starting order for customer: {0}", foundOrder.CustomerID);
                    _orders.Remove(foundOrder);
                }
            }
            return foundOrder;
        }
    }
}
