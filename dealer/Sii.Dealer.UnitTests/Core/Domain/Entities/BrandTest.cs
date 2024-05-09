using System;
using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;


namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    [TestFixture]
    public class BrandTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Brand_With_Code_Equal_Null_Or_Empty(string code)
        {
            //Arrange : 
            const string BRAND_CODE = "BC01";
            const bool BRAND_AVAILABILITY = true;
            const decimal BRAND_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Brand(BRAND_CODE, code, BRAND_AVAILABILITY, BRAND_PRICE));
        }

        [Test]
        [TestCase("BC0")]
        public void Should_Throw_ArgumentException_When_Creating_Brand_With_Code_That_Has_Less_Than_4_Characters(string code)
        {
            //Arrange : 
            const string BRAND_NAME = "BrandName";
            const bool BRAND_AVAILABILITY = true;
            const decimal BRAND_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Brand(code, BRAND_NAME, BRAND_AVAILABILITY, BRAND_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Brand_With_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string BRAND_CODE = "BC01";
            const bool BRAND_AVAILABILITY = true;
            const decimal BRAND_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Brand(BRAND_CODE, name, BRAND_AVAILABILITY, BRAND_PRICE));
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Changing_Brand_Name_To_Null_Or_Empty_Value(string name)
        {
            //Arrange :
            const string BRAND_CODE = "BC01";
            const string BRAND_NAME = "BrandName";
            const bool BRAND_AVAILABILITY = true;
            const decimal BRAND_PRICE = 2000;

            //Act :
            Brand brand = new Brand(BRAND_CODE, BRAND_NAME, BRAND_AVAILABILITY, BRAND_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => brand.Update(name, BRAND_AVAILABILITY));
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
