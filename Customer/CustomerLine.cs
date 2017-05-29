using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedRestaraunt
{
    public class CustomerLine
    {
        Queue<Customer> _customerLine;

        public CustomerLine(Queue<Customer> customerLine)
        {
            _customerLine = customerLine;
        }

        public void NewCustomer(Customer customer)
        {
            _customerLine.Enqueue(customer);
        }

        public Customer NextCustomer()
        {
            Customer customer = null;

            while (customer == null)
            {
                if (_customerLine.Count > 0)
                {
                    customer = _customerLine.Dequeue();
                }
            }

            return customer;
        }
    }
}
