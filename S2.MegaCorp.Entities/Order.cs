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
                (bool datesAreValid, string message) datesValidationresult = ValidateDates(value, shipmentDate);
                if(!datesValidationresult.datesAreValid)
                {
                    throw new InvalidOperationException(datesValidationresult.message);
                }
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
                (bool datesAreValid, string message) datesValidationresult = ValidateDates(orderDate, value);
                if(!datesValidationresult.datesAreValid)
                {
                    throw new InvalidOperationException(datesValidationresult.message);
                }
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