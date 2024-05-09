using NUnit.Framework;
using Sii.Dealer.Core.Domain.Entities;
using System;

namespace Sii.Dealer.UnitTests.Core.Domain.Entities
{
    [TestFixture]
    public class InteriorTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Interior_With_Code_Equal_Null_Or_Empty(string code)
        {
            //Arrange : 
            const string INTERIOR_CODE = "IC01";
            const bool INTERIOR_AVAILABILITY = true;
            const decimal INTERIOR_PRICE = 2000;

            //Act :

            //Assert
            Assert.Throws<ArgumentException>(() => new Brand(INTERIOR_CODE, code, INTERIOR_AVAILABILITY, INTERIOR_PRICE));
        }

        [Test]
        [TestCase("IC0")]
        public void Should_Throw_ArgumentException_When_Creating_Interior_With_Code_That_Has_Less_Than_4_Characters(string code)
        {
            //Arrange : 
            const string INTERIOR_NAME = "InteriorName";
            const bool INTERIOR_AVAILABILITY = true;
            const decimal INTERIOR_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Interior(code, INTERIOR_NAME, INTERIOR_AVAILABILITY, INTERIOR_PRICE));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Creating_Interior_With_Name_Equal_Null_Or_Empty(string name)
        {
            //Arrange : 
            const string INTERIOR_CODE = "IC01";
            const bool INTERIOR_AVAILABILITY = true;
            const decimal INTERIOR_PRICE = 2000;

            //Act :

            //Assert:
            Assert.Throws<ArgumentException>(() => new Interior(INTERIOR_CODE, name, INTERIOR_AVAILABILITY, INTERIOR_PRICE));
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Should_Throw_ArgumentException_When_Changing_Interior_Name_To_Null_Or_Empty_Value(string name)
        {
            //Arrange :
            const string INTERIOR_CODE = "IC01";
            const string INTERIOR_NAME = "InteriorName";
            const bool INTERIOR_AVAILABILITY = true;
            const decimal INTERIOR_PRICE = 2000;

            //Act :
            Interior interior = new (INTERIOR_CODE, INTERIOR_NAME, INTERIOR_AVAILABILITY, INTERIOR_PRICE);

            //Assert:
            Assert.Throws<ArgumentException>(() => interior.Update(name, INTERIOR_AVAILABILITY));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Should_Update_Interior_Availabiliy(bool availability)
        {
            //Arrange :
            const string INTERIOR_CODE = "IC01";
            const string INTERIOR_NAME = "InteriorName";
            const bool INTERIOR_AVAILABILITY = true;
            const decimal MODEL_PRICE = 2000;

            //Act :
            Interior interior = new (INTERIOR_CODE, INTERIOR_NAME, INTERIOR_AVAILABILITY, MODEL_PRICE);
            interior.Update(INTERIOR_NAME, availability);

            //Assert:
            Assert.That(interior.Availability, Is.EqualTo(availability));
        }
    }
}
