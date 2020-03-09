using System;

namespace S2.MegaCorp.Entities
{
    public class Order
    {
        protected int id;
        protected DateTime orderDate;
        protected DateTime shipmentDate;

        public Order(int id, DateTime orderDate, DateTime shipmentDate)
        {
            Id = id;
            OrderDate = orderDate;
            ShipmentDate = shipmentDate;

            (bool isValid, string message) = ValidateDates(orderDate, shipmentDate);
            if(!isValid)
            {
                throw new ArgumentException(message);
            }
        }

        public virtual int Id
        {
            get
            {
                return id;
            }

            set
            {
                if(value != id)
                {
                    id = value;
                }
            }
        }

        public virtual DateTime OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                if(value != orderDate)
                {
                    orderDate = value;
                }

            }
        }

        public virtual DateTime ShipmentDate
        {
            get
            {
                return shipmentDate;
            }

            set
            {
                if(value != shipmentDate)
                {
                   shipmentDate = value;
                }

            }
        }

        public static (bool, string) ValidateDates(DateTime orderDate, DateTime shipmentDate)
        {
            if(shipmentDate > orderDate)
            {
                return (true, string.Empty);
            }
            else
            {
                return (false, "Invalid dates.");
            }
        }
    }
}