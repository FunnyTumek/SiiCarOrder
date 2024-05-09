using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;
using System;

namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    [TestFixture]
    public class ModelTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Model_With_Code_Equal_Null_Or_Empty(string code)
        {
            //Arrange : 
            const string MODEL_CODE = "MC01";
            const bool MODEL_AVAILABILITY = true;
            const decimal BRAND_PRICE = 2000;

            //Act :

            //Assert
            Assert.Throws<ArgumentException>(() => new Brand(MODEL_CODE, code, MODEL_AVAILABILITY, BRAND_PRICE));
        }

        [Test]
        [TestCase("MC0")]
        public void Should_Throw_ArgumentException_When_Creating_Model_With_Code_That_Has_Less_Than_4_Characters(string code)
        {
            //Arrange : 
            const string MODEL_NAME = "ModelName";
            const bool MODEL_AVAILABILITY = true;
            const decimal MODEL_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Model(code, MODEL_NAME, MODEL_AVAILABILITY, MODEL_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Model_With_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string MODEL_CODE = "MC01";
            const bool MODEL_AVAILABILITY = true;
            const decimal MODEL_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Interior(MODEL_CODE, name, MODEL_AVAILABILITY, MODEL_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Changing_Model_Name_To_Null_Or_Empty_Value(string name)
        {
            //Arrange :
            const string MODEL_CODE = "MC01";
            const string MODEL_NAME = "ModelName";
            const bool MODEL_AVAILABILITY = true;
            const decimal MODEL_PRICE = 2000;

            //Act :
            Interior model = new(MODEL_CODE, MODEL_NAME, MODEL_AVAILABILITY, MODEL_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => model.Update(name, MODEL_AVAILABILITY));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Update_Interior_Availabiliy(bool availability)
        {
            //Arrange :
            const string MODEL_CODE = "MC01";
            const string MODEL_NAME = "ModelName";
            const bool MODEL_AVAILABILITY = true;
            const decimal MODEL_PRICE = 2000;

            //Act :
            Interior model = new(MODEL_CODE, MODEL_NAME, MODEL_AVAILABILITY, MODEL_PRICE);
            model.Update(MODEL_NAME, availability);

            //Assert:
            Assert.That(model.Availability, Is.EqualTo(availability));
        }
    }
}
