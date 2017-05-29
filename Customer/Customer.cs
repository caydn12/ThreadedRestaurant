using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedRestaraunt
{
    public class Customer
    {
        private Order _order;
        private string _customerId;
        private static Random _random;
        private bool _isFull;

        public string CustomerID
        {
            get { return _customerId; }
        }

        public bool isFull
        {
            get { return _isFull; }
        }

        public Customer()
        {
            _isFull = false;

            if (_random == null)
                _random = new Random();

            _customerId = Guid.NewGuid().ToString();

            _order = new Order(ORDERS[_random.Next(ORDERS.Length)], _customerId);
        }

        public void Feed(Order order)
        {
            if (order.OrderTitle == _order.OrderTitle)
            {
                Console.WriteLine("CUSTOMER: Yay, I am full!");
                _isFull = true;
            }
            else
            {
                throw new Exception("Customer got the wrong order!!");
            }
        }

        public Order RequestOrder()
        {
            return _order;
        }

        public string[] ORDERS =
        {
            "Salt Cod Braised with Vegetables",
            "Spring Paella",
            "Greek-Style Pasta Salad",
            "Vietnamese Beef, Green Papaya, and Noodle Salad",
            "Italian sausage stew with rosemary garlic mash",
            "Lemon & rosemary halloumi skewers",
            "Spanish pepper & potato omelette",
            "Pork Vindaloo",
            "Cheese Tortellini with a Fresh Tomato and Artichoke Slaw",
            "Toulouse sausage & butter bean casserole",
            "Grilled Leg of Lamb with Greek Chimichurri Sauce"
        };
    }
}
