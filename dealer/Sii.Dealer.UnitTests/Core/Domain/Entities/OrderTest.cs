using System;
using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.ValueObjects;
using Sii.Dealer.SharedKernel.Enums;

namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void Given_CarConfiguration_And_Customer_When_CreateOrder_Then_Creates_Valid_Order_Object()
        {
            var carConfiguration = new CarConfiguration()
            {
                BrandCode = "BC01",
                ModelCode = "MC01",
                EquipmentVersionCode = "EV01",
                CarClassCode = "CC01",
                EngineCode = "EC01",
                GearboxCode = "GC01",
                ColorCode = "CC01",
                InteriorCode = "IC01"
            };

            var customer = new Customer("Jane", "Doe", "jane.doe@example.email", "123456789");

            //act
            var order = Order.Create(carConfiguration, 100000M, customer);

            //assert
            Assert.AreEqual("jane.doe@example.email", order.Customer.Email);
            Assert.AreEqual(carConfiguration, order.Configuration);
            Assert.AreEqual(100000M, order.Price);
            Assert.AreEqual(OrderStatus.Created, order.Status);
        }

        [Test]
        public void Given_Null_CarConfiguration_When_CreateOrder_Then_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => Order.Create(null, 100000M, new Customer("Jane", "Doe", "jane.doe@example.email", "123456789")));
        }

        [Test]
        public void Given_Null_Customer_When_CreateOrder_Then_ThrowsException()
        {
            var configuration = new CarConfiguration()
            {
                BrandCode = "BC01",
                ModelCode = "MC01",
                EquipmentVersionCode = "EV01",
                CarClassCode = "CC01",
                EngineCode = "EC01",
                GearboxCode = "GC01",
                ColorCode = "CC01",
                InteriorCode = "IC01"
            };

            Assert.Throws<ArgumentException>(() => Order.Create(configuration, 50000M, null));

        }

        [Test]
        public void Given_Order_When_ApplyDiscount_Then_Update_Price()
        {
            //arrange
            var carConfiguration = new CarConfiguration()
            {
                BrandCode = "BC01",
                ModelCode = "MC01",
                EquipmentVersionCode = "EV01",
                CarClassCode = "CC01",
                EngineCode = "EC01",
                GearboxCode = "GC01",
                ColorCode = "CC01",
                InteriorCode = "IC01"
            };
            var customer = new Customer("Jane", "Doe", "jane.doe@example.email", "123456789");
            var order = Order.Create(carConfiguration, 100000M, customer);

            //act
            order.ApplyDiscount(20000M);

            //assert
            Assert.AreEqual(100000M, order.Price);
        }

        [Test]
        public void Given_Order_When_ApplyDiscount_Higher_Than_Possible_Then_Throws_Exception()
        {
            //arrange
            var carConfiguration = new CarConfiguration()
            {
                BrandCode = "BC01",
                ModelCode = "MC01",
                EquipmentVersionCode = "EV01",
                CarClassCode = "CC01",
                EngineCode = "EC01",
                GearboxCode = "GC01",
                ColorCode = "CC01",
                InteriorCode = "IC01"
            };
            var customer = new Customer("Jane", "Doe", "jane.doe@example.email", "123456789");
            var order = Order.Create(carConfiguration, 100000M, customer);

            //act & assert
            Assert.Throws<ArgumentException>(() => order.ApplyDiscount(100001M));
        }

        [Test]
        public void Given_Order_When_ApplyDiscount_Lower_Than_Zero_Then_Throws_Exception()
        {
            //arrange
            var carConfiguration = new CarConfiguration()
            {
                BrandCode = "BC01",
                ModelCode = "MC01",
                EquipmentVersionCode = "EV01",
                CarClassCode = "CC01",
                EngineCode = "EC01",
                GearboxCode = "GC01",
                ColorCode = "CC01",
                InteriorCode = "IC01"
            };
            var customer = new Customer("Jane", "Doe", "jane.doe@example.email", "123456789");
            var order = Order.Create(carConfiguration, 40000M, customer);

            //act & assert
            Assert.Throws<ArgumentException>(() => order.ApplyDiscount(-100M));
        }
    }
}
