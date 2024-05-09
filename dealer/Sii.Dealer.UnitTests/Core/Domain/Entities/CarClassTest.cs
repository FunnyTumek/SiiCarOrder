using System;
using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;

namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    [TestFixture]
    public class CarClassTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_CarClass_With_Code_Equal_Null_Or_Empty(string code)
        {
            //Arrange : 
            const string CARCLASS_NAME = "CarClassName";
            const bool CARCLASS_AVAILABILITY = true;
            const decimal CARCLASS_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new CarClass(code, CARCLASS_NAME, CARCLASS_AVAILABILITY, CARCLASS_PRICE));
        }

        [Test]
        [TestCase("CC0")]
        public void Should_Throw_ArgumentException_When_Creating_CarClass_With_Code_That_Has_Less_Than_4_Characters(string code)
        {
            //Arrange : 
            const string CARCLASS_NAME = "CarClassName";
            const bool CARCLASS_AVAILABILITY = true;
            const decimal CARCLASS_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new CarClass(code, CARCLASS_NAME, CARCLASS_AVAILABILITY, CARCLASS_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_CarClass_With_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string CARCLASS_CODE = "CC01";
            const bool CARCLASS_AVAILABILITY = true;
            const decimal CARCLASS_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new CarClass(CARCLASS_CODE, name, CARCLASS_AVAILABILITY, CARCLASS_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Changing_CarClass_Name_To_Null_Or_Empty_Value(string name)
        {
            //Arrange :
            const string CARCLASS_CODE = "CC01";
            const string CARCLASS_NAME = "CarClassName";
            const bool CARCLASS_AVAILABILITY = true;
            const decimal CARCLASS_PRICE = 2000;

            //Act :
            CarClass carClass = new (CARCLASS_CODE, CARCLASS_NAME, CARCLASS_AVAILABILITY, CARCLASS_PRICE);
           
            //Assert:
            Assert.Throws<ArgumentException>(() => carClass.Update(name, CARCLASS_AVAILABILITY));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Update_Availabiliy(bool availability)
        {
            const string CARCLASS_CODE = "CC01";
            const string CARCLASS_NAME = "CarClassName";
            const bool CARCLASS_AVAILABILITY = true;
            const decimal CARCLASS_PRICE = 2000;

            //Act :
            CarClass carClass = new (CARCLASS_CODE, CARCLASS_NAME, CARCLASS_AVAILABILITY, CARCLASS_PRICE);
            carClass.Update(CARCLASS_NAME, availability);

            //Assert:
            Assert.That(carClass.Availability, Is.EqualTo(availability));
        }
    }
}
