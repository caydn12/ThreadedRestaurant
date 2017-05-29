using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ThreadedRestaraunt
{
    public class Order
    {
        private string _orderTitle;
        private string _customerId;
        private double _orderPrice;
        static Random _random;
        double _orderMin = 3.75;
        double _orderMax = 43.25;

        public string OrderTitle
        {
            get { return _orderTitle; }
        }

        public string CustomerID
        {
            get { return _customerId; }
        }

        public Order(string orderTitle, string customerId)
        {
            if (_random == null)
                _random = new Random();

            _orderTitle = orderTitle;
            _customerId = customerId;

            _orderPrice = _random.NextDouble() * (_orderMax - _orderMin) + _orderMin;
        }
    }
}
