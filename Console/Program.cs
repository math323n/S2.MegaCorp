using S2.MegaCorp.Entities;
using System;

namespace Console
{
    class Program
    {
        static void Main()
        {
            Order order = new Order(1, new DateTime(1992, 01, 03), new DateTime(1993, 04, 09));

            if(order.ShipmentDate > order.OrderDate)
            {
                System.Console.WriteLine("true");   
            }
            else
            {
                System.Console.WriteLine("false");
            }

        }
    }
}
