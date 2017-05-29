using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadedRestaraunt
{
    public class TableCleaner : IEmployee
    {
        CustomerSeating _customerSeating;

        public TableCleaner(CustomerSeating customerSeating)
        {
            _customerSeating = customerSeating;
        }

        public void Clean()
        {
            _customerSeating.CleanTables();
        }

        public void Work()
        {
            while (true)
            {
                Clean();
            }
        }
    }
}
