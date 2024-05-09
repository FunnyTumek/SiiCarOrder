using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;
using System;

namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    [TestFixture]
    public class AdditionalEquipmentTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_AdditionalEquipment_With_Code_Equal_Null_Or_Empty(string code)
        {
            //Arrange : 
            const string ADDITIONAL_EQUIPMENT_CODE = "AC01";
            const bool ADDITIONAL_EQUIPMENT_AVAILABILITY = true;
            const decimal ADDITIONAL_EQUIPMENT_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new AdditionalEquipment(ADDITIONAL_EQUIPMENT_CODE, code, ADDITIONAL_EQUIPMENT_AVAILABILITY, ADDITIONAL_EQUIPMENT_PRICE));
        }

        [Test]
        [TestCase("BC0")]
        public void Should_Throw_ArgumentException_When_Creating_AdditionalEquipment_With_Code_That_Has_Less_Than_4_Characters(string code)
        {
            //Arrange : 
            const string ADDITIONAL_EQUIPMENT_NAME = "AdditionalEquipmentName";
            const bool ADDITIONAL_EQUIPMENT_AVAILABILITY = true;
            const decimal ADDITIONAL_EQUIPMENT_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new AdditionalEquipment(code, ADDITIONAL_EQUIPMENT_NAME, ADDITIONAL_EQUIPMENT_AVAILABILITY, ADDITIONAL_EQUIPMENT_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_AdditionalEquipment_With_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string ADDITIONAL_EQUIPMENT_CODE = "AC01";
            const bool ADDITIONAL_EQUIPMENT_AVAILABILITY = true;
            const decimal ADDITIONAL_EQUIPMENT_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new AdditionalEquipment(ADDITIONAL_EQUIPMENT_CODE, name, ADDITIONAL_EQUIPMENT_AVAILABILITY, ADDITIONAL_EQUIPMENT_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Changing_AdditionalEquipment_Name_To_Null_Or_Empty_Value(string name)
        {
            //Arrange :
            const string ADDITIONAL_EQUIPMENT_CODE = "AC01";
            const string ADDITIONAL_EQUIPMENT_NAME = "AdditionalEquipmentName";
            const bool ADDITIONAL_EQUIPMENT_AVAILABILITY = true;
            const decimal ADDITIONAL_EQUIPMENT_PRICE = 2000;

            //Act :
            AdditionalEquipment additionalEquipment = new (ADDITIONAL_EQUIPMENT_CODE, ADDITIONAL_EQUIPMENT_NAME, ADDITIONAL_EQUIPMENT_AVAILABILITY, ADDITIONAL_EQUIPMENT_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => additionalEquipment.Update(name, ADDITIONAL_EQUIPMENT_AVAILABILITY));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Update_AdditionalEquipment_Availabiliy(bool availability)
        {
            //Arrange :
            const string ADDITIONAL_EQUIPMENT_CODE = "AC01";
            const string ADDITIONAL_EQUIPMENT_NAME = "AdditionalEquipmentName";
            const bool ADDITIONAL_EQUIPMENT_AVAILABILITY = true;
            const decimal ADDITIONAL_EQUIPMENT_PRICE = 2000;

            //Act :
            AdditionalEquipment additionalEquipment = new AdditionalEquipment(ADDITIONAL_EQUIPMENT_CODE, ADDITIONAL_EQUIPMENT_NAME, ADDITIONAL_EQUIPMENT_AVAILABILITY, ADDITIONAL_EQUIPMENT_PRICE);
            additionalEquipment.Update(ADDITIONAL_EQUIPMENT_NAME, availability);

            //Assert:
            Assert.That(additionalEquipment.Availability, Is.EqualTo(availability));
        }
    }
}
