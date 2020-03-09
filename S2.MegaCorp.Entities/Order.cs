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

            (bool datesAreValid, string message) = ValidateDates(orderDate, shipmentDate);
            if(!datesAreValid)
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
                id = value;
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
                if(shipmentDate != default)
                {
                    (bool datesAreValid, string message) = ValidateDates(orderDate, shipmentDate);
                    if(!datesAreValid)
                    {
                        throw new InvalidOperationException(message);
                    }
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
                if(orderDate != default)
                {
                    (bool datesAreValid, string message) datesValidationresult = ValidateDates(orderDate, shipmentDate);
                    if(!datesValidationresult.datesAreValid)
                    {
                        throw new InvalidOperationException(datesValidationresult.message);
                    }
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
