using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadedRestaraunt
{
    public class OrderTaker : IEmployee
    {
        CustomerLine _customerLine;
        OrderWall _orderWall;
        CustomerSeating _customerSeating;

        public OrderTaker(CustomerLine customerLine, OrderWall orderWall, CustomerSeating customerSeating)
        {
            _customerLine = customerLine;
            _orderWall = orderWall;
            _customerSeating = customerSeating;
        }

        public Customer GreetCustomer()
        {
            return _customerLine.NextCustomer();
        }

        public void PlaceOrder(Order order)
        {
            _orderWall.PlaceOrder(order);
        }

        public void SeatCustomer(Customer customer)
        {
            _customerSeating.SeatCustomer(customer);
        }

        public void Work()
        {
            Customer customer = null;
            while (true)
            {
                customer = GreetCustomer();
                PlaceOrder(customer.RequestOrder());
                SeatCustomer(customer);
            }
        }


    }
}
