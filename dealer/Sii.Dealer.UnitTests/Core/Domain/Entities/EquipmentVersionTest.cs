using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;
using System;

namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    [TestFixture]
    public class EquipmentVersionTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_EquipmentVersion_With_Code_Equal_Null_Or_Empty(string code)
        {
            //Arrange : 
            const string EQUIPMENT_VERSION_NAME = "EC01";
            const bool EQUIPMENT_VERSION_AVAILABILITY = true;
            const decimal EQUIPMENT_VERSION_PRICE = 2000;

            //Act :

            //Assert
            Assert.Throws<ArgumentException>(() => new EquipmentVersion(code, EQUIPMENT_VERSION_NAME, EQUIPMENT_VERSION_AVAILABILITY, EQUIPMENT_VERSION_PRICE));
        }

        [Test]
        [TestCase("EC0")]
        public void Should_Throw_ArgumentException_When_Creating_EquipmentVersion_With_Code_That_Has_Less_Than_4_Characters(string code)
        {
            //Arrange : 
            const string EQUIPMENT_VERSION_NAME = "EquipmentVersionName";
            const bool EQUIPMENT_VERSION_AVAILABILITY = true;
            const decimal EQUIPMENT_VERSION_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new EquipmentVersion(code, EQUIPMENT_VERSION_NAME, EQUIPMENT_VERSION_AVAILABILITY, EQUIPMENT_VERSION_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_EquipmentVersion_With_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string EQUIPMENT_VERSION_CODE = "EC01";
            const bool EQUIPMENT_VERSION_AVAILABILITY = true;
            const decimal EQUIPMENT_VERSION_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new EquipmentVersion(EQUIPMENT_VERSION_CODE, name, EQUIPMENT_VERSION_AVAILABILITY, EQUIPMENT_VERSION_PRICE));
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Changing_EquipmentVersion_Name_To_Null_Or_Empty_Value(string name)
        {
            //Arrange :
            const string EQUIPMENT_VERSION_CODE = "EC01";
            const string EQUIPMENT_VERSION_NAME = "EquipmentVersionName";
            const bool EQUIPMENT_VERSION_AVAILABILITY = true;
            const decimal EQUIPMENT_VERSION_PRICE = 2000;

            //Act :
            EquipmentVersion equipmentVersion = new(EQUIPMENT_VERSION_CODE, EQUIPMENT_VERSION_NAME, EQUIPMENT_VERSION_AVAILABILITY, EQUIPMENT_VERSION_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => equipmentVersion.Update(name, EQUIPMENT_VERSION_AVAILABILITY));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Update_EquipmentVersion_Availabiliy(bool availability)
        {
            //Arrange :
            const string EQUIPMENT_VERSION_CODE = "EC01";
            const string EQUIPMENT_VERSION_NAME = "EquipmentVersionName";
            const bool EQUIPMENT_VERSION_AVAILABILITY = true;
            const decimal EQUIPMENT_VERSION_PRICE = 2000;

            //Act :
            EquipmentVersion equipmentVersion = new(EQUIPMENT_VERSION_CODE, EQUIPMENT_VERSION_NAME, EQUIPMENT_VERSION_AVAILABILITY, EQUIPMENT_VERSION_PRICE);
            equipmentVersion.Update(EQUIPMENT_VERSION_NAME, availability);

            //Assert:
            Assert.That(equipmentVersion.Availability, Is.EqualTo(availability));
        }
    }
}
