using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadedRestaraunt
{
    public class Chef : IEmployee
    {
        private OrderWall _orderWall;
        private Meals _meals;

        public Chef(OrderWall orderWall, Meals meals)
        {
            _orderWall = orderWall;
            _meals = meals;
        }

        public Order GrabOrder()
        {
            Order order = null;

            order = _orderWall.GrabOrder();

            return order;
        }

        public void CookMeal()
        {
            Console.WriteLine("CHEF: Cooking Meal...");
        }

        public void PlaceMeal(Order order)
        {
            _meals.PlaceMeal(order);
        }

        public void Work()
        {
            while (true)
            {
                Order order = GrabOrder();
                if (order != null)
                {
                    CookMeal();
                    PlaceMeal(order);
                }
            }
        }
    }
}
