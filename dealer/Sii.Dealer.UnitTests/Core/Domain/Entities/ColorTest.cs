using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;
using System;

namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    public class ColorTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Brand_With_Code_Equal_Null_Or_Empty(string code)
        {
            //Arrange : 
            const string COLOR_CODE = "CO01";
            const bool COLOR_AVAILABILITY = true;
            const decimal COLOR_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Color(COLOR_CODE, code, COLOR_AVAILABILITY, COLOR_PRICE));
        }

        [Test]
        [TestCase("CO0")]
        public void Should_Throw_ArgumentException_When_Creating_Color_With_Code_That_Has_Less_Than_4_Characters(string code)
        {
            //Arrange : 
            const string COLOR_NAME = "ColorName";
            const bool COLOR_AVAILABILITY = true;
            const decimal COLOR_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Color(code, COLOR_NAME, COLOR_AVAILABILITY, COLOR_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Color_With_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string COLOR_CODE = "CO01";
            const bool COLOR_AVAILABILITY = true;
            const decimal COLOR_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Color(COLOR_CODE, name, COLOR_AVAILABILITY, COLOR_PRICE));
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Changing_Color_Name_To_Null_Or_Empty_Value(string name)
        {
            //Arrange :
            const string COLOR_CODE = "CO01";
            const string COLOR_NAME = "ColorName";
            const bool COLOR_AVAILABILITY = true;
            const decimal COLOR_PRICE = 2000;

            //Act :
            Color color = new (COLOR_CODE, COLOR_NAME, COLOR_AVAILABILITY, COLOR_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => color.Update(name, COLOR_AVAILABILITY));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Update_Color_Availabiliy(bool availability)
        {
            //Arrange :
            const string COLOR_CODE = "BC01";
            const string COLOR_NAME = "BrandName";
            const bool COLOR_AVAILABILITY = true;
            const decimal COLOR_PRICE = 2000;

            //Act :
            Color color = new (COLOR_CODE, COLOR_NAME, COLOR_AVAILABILITY, COLOR_PRICE);
            color.Update(COLOR_NAME, availability);

            //Assert:
            Assert.That(color.Availability, Is.EqualTo(availability));
        }
    }
}
