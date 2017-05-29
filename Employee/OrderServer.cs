using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedRestaraunt
{
    public class OrderServer : IEmployee
    {
        CustomerSeating _customerSeating;
        Meals _meals;

        public OrderServer(Meals meals, CustomerSeating customerSeating)
        {
            _customerSeating = customerSeating;
            _meals = meals;
        }

        public Order GrabMeal()
        {
            Order order = _meals.GrabMeal();

            return order;
        }

        public void ServeMeal(Order meal)
        {
            if (meal != null)
            {
                _customerSeating.ServeCustomer(meal);
            }
        }

        public void Work()
        {
            while (true)
            {
                Order meal = GrabMeal();
                if (meal != null)
                {
                    ServeMeal(meal);
                }
            }
        }
    }
}
