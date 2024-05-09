
using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.SharedKernel.Enums;
using System;

namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    [TestFixture]
    public class GearboxTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Gearbox_With_Code_Equal_Null_Or_Empty(string code)
        {
            //Arrange : 
            const string GEARBOX_NAME = "GearboxName";
            const GearboxType GEARBOX_TYPE = GearboxType.Manual;
            const int GEARS_COUNT = 5;
            const bool BRAND_AVAILABILITY = true;
            const decimal GEARBOX_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Gearbox(code, GEARBOX_NAME, GEARBOX_TYPE, GEARS_COUNT, BRAND_AVAILABILITY, GEARBOX_PRICE));
        }

        [Test]
        [TestCase("BC0")]
        public void Should_Throw_ArgumentException_When_Creating_Gearbox_With_Code_That_Has_Less_Than_4_Characters(string code)
        {
            //Arrange : 
            const string GEARBOX_NAME = "GearboxName";
            const GearboxType GEARBOX_TYPE = GearboxType.Manual;
            const int GEARS_COUNT = 5;
            const bool BRAND_AVAILABILITY = true;
            const decimal GEARBOX_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Gearbox(code, GEARBOX_NAME, GEARBOX_TYPE, GEARS_COUNT, BRAND_AVAILABILITY, GEARBOX_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Gearbox_With_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string GEARBOX_CODE = "GC01";
            const GearboxType GEARBOX_TYPE = GearboxType.Manual;
            const int GEARS_COUNT = 5;
            const bool BRAND_AVAILABILITY = true;
            const decimal GEARBOX_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Gearbox(GEARBOX_CODE, name, GEARBOX_TYPE, GEARS_COUNT, BRAND_AVAILABILITY, GEARBOX_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Changing_Gearbox_Name_To_Null_Or_Empty_Value(string name)
        {
            //Arrange :
            const string GEARBOX_CODE = "GC01";
            const string GEARBOX_NAME = "GearboxName";
            const GearboxType GEARBOX_TYPE = GearboxType.Manual;
            const int GEARS_COUNT = 5;
            const bool GEARBOX_AVAILABILITY = true;
            const decimal GEARBOX_PRICE = 2000;

            //Act :
            Gearbox gearbox = new Gearbox(GEARBOX_CODE, GEARBOX_NAME, GEARBOX_TYPE, GEARS_COUNT, GEARBOX_AVAILABILITY, GEARBOX_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => gearbox.Update(name, GEARBOX_TYPE, GEARS_COUNT,GEARBOX_AVAILABILITY));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(4)]
        [TestCase(8)]
        public void Should_Throw_ArgumentException_When_Changing_GearboxCount_To_Out_Of_Limit_Value(int gearsCount)
        {
            //Arrange :
            const string GEARBOX_CODE = "GC01";
            const string GEARBOX_NAME = "GearboxName";
            const GearboxType GEARBOX_TYPE = GearboxType.Manual;
            const int GEARS_COUNT = 5;
            const bool GEARBOX_AVAILABILITY = true;
            const decimal GEARBOX_PRICE = 2000;

            //Act :
            Gearbox gearbox = new(GEARBOX_CODE, GEARBOX_NAME, GEARBOX_TYPE, GEARS_COUNT, GEARBOX_AVAILABILITY, GEARBOX_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => gearbox.Update(GEARBOX_NAME, GEARBOX_TYPE, gearsCount, GEARBOX_AVAILABILITY));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Update_Availabiliy(bool availability)
        {
            //Arrange :
            const string BRAND_CODE = "BC01";
            const string BRAND_NAME = "BrandName";
            const bool BRAND_AVAILABILITY = true;
            const decimal BRAND_PRICE = 2000;

            //Act :
            Brand brand = new Brand(BRAND_CODE, BRAND_NAME, BRAND_AVAILABILITY, BRAND_PRICE);
            brand.Update(BRAND_NAME, availability);

            //Assert:
            Assert.That(brand.Availability, Is.EqualTo(availability));
        }
    }
}
