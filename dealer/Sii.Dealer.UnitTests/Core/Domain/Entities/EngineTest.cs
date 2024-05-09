using System;
using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.SharedKernel.Enums;

namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    [TestFixture]
    public class EngineTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Should_Throw_ArgumentException_When_Creating_Engine_With_Code_Equal_Null_Or_Empty(string code)
        {
            //Arrange : 
            const string ENGINE_NAME = "EngineName";
            const int ENGINE_CAPACITY = 1000;
            const int ENGINE_POWER = 200;
            const EngineType ENGINE_TYPE = EngineType.Petrol;
            const bool ENGINE_AVAILABILITY = true;
            const decimal ENGINE_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Engine(code, ENGINE_NAME, ENGINE_CAPACITY, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY, ENGINE_PRICE));
        }

        [Test]
        [TestCase("EC0")]
        public void Should_Throw_ArgumentException_When_Creating_Engine_With_Code_That_Has_Less_Than_4_Characters(string code)
        {
            //Arrange : 
            const string ENGINE_NAME = "EngineName";
            const int ENGINE_CAPACITY = 1000;
            const int ENGINE_POWER = 200;
            const EngineType ENGINE_TYPE = EngineType.Petrol;
            const bool ENGINE_AVAILABILITY = true;
            const decimal ENGINE_PRICE = 2000;

            //Act :


            //Assert:
            Assert.Throws<ArgumentException>(() => new Engine(code, ENGINE_NAME, ENGINE_CAPACITY, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY, ENGINE_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Should_Throw_ArgumentException_When_Creating_Engine_With_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string ENGINE_CODE = "EC01";
            const int ENGINE_CAPACITY = 1000;
            const int ENGINE_POWER = 200;
            const EngineType ENGINE_TYPE = EngineType.Petrol;
            const bool ENGINE_AVAILABILITY = true;
            const decimal ENGINE_PRICE = 2000;

            //Act :
            var ex = Assert.Throws<ArgumentException>(() => new Engine(ENGINE_CODE, name, ENGINE_CAPACITY, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY, ENGINE_PRICE));

            //Assert:
            Assert.That(ex.Message, Is.EqualTo("Name is not valid. (Parameter 'name')"));
        }

        [Test]
        [TestCase(-65)]
        [TestCase(0)]
        [TestCase(64)]
        [TestCase(651)]
        public void Should_Throw_ArgumentException_When_Changing_Engine_Power_To_Out_Of_Limit_Values(int power)
        {
            //Arrange : 
            const string ENGINE_CODE = "EC01";
            const string ENGINE_NAME = "EngineName";
            const int ENGINE_CAPACITY = 1000;
            const int ENGINE_POWER = 200;
            const EngineType ENGINE_TYPE = EngineType.Petrol;
            const bool ENGINE_AVAILABILITY = true;
            const decimal ENGINE_PRICE = 2000;

            //Act :
            Engine engine = new(ENGINE_CODE, ENGINE_NAME, ENGINE_CAPACITY, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY, ENGINE_PRICE);

           //Assert:
           Assert.Throws<ArgumentException>(() => engine.Update(ENGINE_NAME, ENGINE_CAPACITY, power, ENGINE_TYPE, ENGINE_AVAILABILITY)); 
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Changing_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string ENGINE_CODE = "EC01";
            const string ENGINE_NAME = "EngineName";
            const int ENGINE_CAPACITY = 1000;
            const int ENGINE_POWER = 200;
            const EngineType ENGINE_TYPE = EngineType.Petrol;
            const bool ENGINE_AVAILABILITY = true;
            const decimal ENGINE_PRICE = 2000;

            //Act :
            Engine engine = new(ENGINE_CODE, ENGINE_NAME, ENGINE_CAPACITY, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY, ENGINE_PRICE);


            //Assert:
            Assert.Throws<ArgumentException>(() => engine.Update(name, ENGINE_CAPACITY, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY));

        }

        [Test]
        [TestCase( -800)]
        [TestCase(0)]
        [TestCase(799)]
        [TestCase(6001)]
        public void Should_Throw_ArgumentException_When_Changing_Capacity_To_Out_Of_Limit_Values(int capacity)
        {
            //Arrange : 
            const string ENGINE_CODE = "EC01";
            const string ENGINE_NAME = "EngineName";
            const int ENGINE_CAPACITY = 1000;
            const int ENGINE_POWER = 200;
            const EngineType ENGINE_TYPE = EngineType.Petrol;
            const bool ENGINE_AVAILABILITY = true;
            const decimal ENGINE_PRICE = 2000;

            //Act :
            Engine engine = new(ENGINE_CODE, ENGINE_NAME, ENGINE_CAPACITY, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY, ENGINE_PRICE);

            //Assert:
           Assert.Throws<ArgumentException>(() => engine.Update(ENGINE_NAME, capacity, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY));
            
        }

        [Test]
        [TestCase(-800, 100)]
        [TestCase(0,100)]
        [TestCase(799,100)]
        [TestCase(6001,100)]
        [TestCase(1000, -65)]
        [TestCase(1000, 0)]
        [TestCase(1000, 64)]
        [TestCase(1000, 651)]
        [TestCase(-800, -65)]
        public void Should_Throw_ArgumentException_When_Changing_Engine_Force_To_Out_Of_Limit_Value (int capacity, int power)
        {
            //Arrange : 
            const string ENGINE_CODE = "EC01";
            const string ENGINE_NAME = "EngineName";
            const int ENGINE_CAPACITY = 1000;
            const int ENGINE_POWER = 200;
            const EngineType ENGINE_TYPE = EngineType.Petrol;
            const bool ENGINE_AVAILABILITY = true;
            const decimal ENGINE_PRICE = 2000;

            //Act :
            Engine engine = new(ENGINE_CODE, ENGINE_NAME, ENGINE_CAPACITY, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY, ENGINE_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => engine.Update(ENGINE_NAME, capacity, power, ENGINE_TYPE, ENGINE_AVAILABILITY));

        }

        [Test]
        [TestCase(99)]
        public void Should_Throw_ArgumentException_When_Changing_Engine_Type_To_Undefined_Enums(EngineType type)
        { 
            //Arrange : 
            const string ENGINE_CODE = "EC01";
            const string ENGINE_NAME = "EngineName";
            const int ENGINE_CAPACITY = 1000;
            const int ENGINE_POWER = 200;
            const EngineType ENGINE_TYPE = EngineType.Petrol;
            const bool ENGINE_AVAILABILITY = true;
            const decimal ENGINE_PRICE = 2000;

            //Act :
            Engine engine = new(ENGINE_CODE, ENGINE_NAME, ENGINE_CAPACITY, ENGINE_POWER, ENGINE_TYPE, ENGINE_AVAILABILITY, ENGINE_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => engine.Update(ENGINE_NAME, ENGINE_CAPACITY, ENGINE_POWER, type, ENGINE_AVAILABILITY));

        }
    }   
}
