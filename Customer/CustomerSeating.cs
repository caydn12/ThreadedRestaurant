using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadedRestaraunt
{
    public class CustomerSeating
    {
        private HashSet<Customer> _customerSeating;
        private Object seatLock = new Object();
        private int cleanCount = 0;

        public CustomerSeating(HashSet<Customer> customerSeating)
        {
            _customerSeating = customerSeating;
        }

        public void SeatCustomer(Customer customer)
        {
            lock (seatLock)
            {
                Console.WriteLine("ORDER TAKER: Seating customer: {0}", customer.CustomerID);
                _customerSeating.Add(customer);
            }
        }

        public void ServeCustomer(Order order)
        {
            lock (seatLock)
            {
                if (order != null)
                {
                    foreach (Customer customer in _customerSeating)
                    {
                        if (customer.CustomerID == order.CustomerID)
                        {
                            Console.WriteLine("SERVER: Serving Customer: {0}", customer.CustomerID);
                            customer.Feed(order);
                        }
                    }
                }
            }
        }

        public void CleanTables()
        {
            Queue<Customer> removableCustomers = new Queue<Customer>();
            lock (seatLock)
            {
                cleanCount++;

                if (cleanCount > 100)
                {
                    if (_customerSeating.Count > 0)
                    {
                        foreach (Customer customer in _customerSeating)
                        {
                            if (customer.isFull)
                            {
                                removableCustomers.Enqueue(customer);
                                Console.WriteLine("CLEANER: Table Cleaned Up and Customer {0} Gone.", customer.CustomerID);
                            }
                        }
                    }

                    foreach(Customer customer in removableCustomers)
                    {
                        _customerSeating.Remove(customer);
                    }
                }
            }
        }
    }
}
