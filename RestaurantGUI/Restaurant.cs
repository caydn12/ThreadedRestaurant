using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadedRestaraunt
{
    public class Restaurant
    {
        Queue<Customer> _customerQueue = new Queue<Customer>();
        HashSet<Order> _orderSet = new HashSet<Order>();
        Queue<Order> _mealQueue = new Queue<Order>();
        HashSet<Customer> _customerSet = new HashSet<Customer>();

        CustomerLine _customerLine;
        OrderWall _orderWall;
        Meals _meals;
        CustomerSeating _customerSeating;

        List<IEmployee> _employees = new List<IEmployee>();

        public Restaurant()
        {
            _customerLine = new CustomerLine(_customerQueue);
            _orderWall = new OrderWall(_orderSet);
            _meals = new Meals(_mealQueue);
            _customerSeating = new CustomerSeating(_customerSet);

            LoadEmployees();
        }

        public void LoadEmployees()
        {
            _employees.Add(new TableCleaner(_customerSeating));
            _employees.Add(new Cashier(_customerLine, _orderWall, _customerSeating));
            _employees.Add(new OrderServer(_meals, _customerSeating));

            for (int i = 0; i < 5; i++)
            {
                _employees.Add(new Chef(_orderWall, _meals));
            }
        }

        public void GenerateCustomers()
        {
            while(true)
            {
                for (int i = 0; i < 100; i++)
                {
                    _customerLine.NewCustomer(new Customer());
                }

                Thread.Sleep(10000);
            }
        }

        public void StartRestaurant()
        {
            foreach(IEmployee employee in _employees)
            {
                Thread thread = new Thread(new ThreadStart(employee.Work));
                thread.Start();
            }

            GenerateCustomers();
        }

    }
}
