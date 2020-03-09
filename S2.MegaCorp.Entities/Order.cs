using System;

namespace S2.MegaCorp.Entities
{
    public class Order
    {
        int id;
        DateTime orderDate;
        DateTime shipmentDate;

        public Order(int id, DateTime orderDate, DateTime shipmentDate)
        {
            Id = id;
            OrderDate = orderDate;
            ShipmentDate = shipmentDate;

            (bool datesAreValid, string message) datesValidationresult = ValidateDates(orderDate, shipmentDate);
            if(!datesValidationresult.datesAreValid)
            {
                throw new ArgumentException(datesValidationresult.message);
            }

        }

        public int Id
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

        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                if(shipmentDate != default)
                {
                    (bool datesAreValid, string message) datesValidationresult = ValidateDates(orderDate, shipmentDate);
                    if(!datesValidationresult.datesAreValid)
                    {
                        throw new InvalidOperationException(datesValidationresult.message);
                    }
                    orderDate = value;
                }
            }
        }

        public DateTime ShipmentDate
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
                return (true, String.Empty);
            }
            else
            {
                return (false, "Invalid dates");
            }
        }
    }
}
