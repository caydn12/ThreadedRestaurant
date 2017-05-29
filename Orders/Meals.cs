using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadedRestaraunt
{
    public class Meals
    {
        Queue<Order> _meals;
        private Object mealLock = new Object();

        public Meals(Queue<Order> meals)
        {
            _meals = meals;
        }

        public void PlaceMeal(Order order)
        {
            lock (mealLock)
            {
                Console.WriteLine("CHEF: Meal placed in Serving Queue for Customer: {0}", order.CustomerID);
                _meals.Enqueue(order);
            }
        }

        public Order GrabMeal()
        {
            Order order = null;

            lock (mealLock)
            {
                if (_meals.Count > 0)
                {
                    order = _meals.Dequeue();
                    Console.WriteLine("SERVER: Meal picked up to be served to customer: {0}", order.CustomerID);
                }
            }
            return order;
        }
    }
}
