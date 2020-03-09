using S2.MegaCorp.Entities;
using System;
using Xunit;

namespace S2.MegaCorp.Tests
{
    public class OrderTests
    {
        [Fact]
        public void ShipmentDateGreaterThanOrderDate()
        {
            // Arrange:
            int id = 1;
            DateTime orderDate = new DateTime(2019, 03, 09);
            DateTime shipmentDate = new DateTime(2021, 03, 13);

            // Act:
            Order order = new Order(id, orderDate, shipmentDate);


            // Assert:
            Assert.True(order.ShipmentDate > order.OrderDate);
        }

        [Fact]
        public void ShipmentDatePreceedsOrderDateThrows()
        {
            // Arrange:
            int id = 1;
            DateTime orderDate = new DateTime(2020, 03, 09);
            DateTime shipmentDate = orderDate.AddDays(-1);
            Order order;

            // Actsert:
            Assert.Throws<ArgumentException>(
                () => order = new Order(id, orderDate, shipmentDate));
        }

        [Fact]
        public void OrderMutatesToValidState()
        {
            // Arrange:
            int id = 1;
            DateTime orderDate = new DateTime(2020, 03, 09);
            DateTime shipmentDate = orderDate.AddDays(-1);

            DateTime newShipmentDate = shipmentDate.AddDays(3);

            Order order = new Order(id, orderDate, newShipmentDate);

            // Act:
            order.ShipmentDate = newShipmentDate;

            // Assert:
            Assert.True(order.OrderDate < order.ShipmentDate);
        }

        [Fact]
        public void OrderMutatesToInValidState()
        {
            // Arrange:
            int id = 1;
            DateTime orderDate = new DateTime(2020, 03, 09);
            DateTime shipmentDate = orderDate.AddDays(1);

            Order order = new Order(id, orderDate, shipmentDate);

            DateTime newShipmentDate = shipmentDate.AddDays(-2);

            // Act:
            shipmentDate = newShipmentDate;

            // Assert:
            Assert.Throws<ArgumentException>(
                () => order = new Order(id, orderDate, shipmentDate));
        }
    }
}