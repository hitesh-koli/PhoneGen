using NUnit.Framework;
using System;
using PhoneGen.AppLogic;
using System.Collections.Generic;

namespace PhoneGen.Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void phoneGenTestCaseEmptyValue()
        {
            List<string> retPhoneList = PhoneNumberGenerator.GeneratePhoneNumber(string.Empty);
            

            Assert.IsTrue(retPhoneList == null, "Empty String results in a null.");

        }

        [Test]
        public void phoneGenTestWith7Value()
        {
            List<string> retPhoneList = PhoneNumberGenerator.GeneratePhoneNumber("1234567");
            Assert.IsTrue(retPhoneList.Count == 972, "Given input 1234567 give 972 values back");
        }

        [Test]
        public void phoneGenTestWith10Value()
        {
            List<string> retPhoneList = PhoneNumberGenerator.GeneratePhoneNumber("1234567890");
            Assert.IsTrue(retPhoneList.Count == 11664, "Given input 1234567890 give 11664 values back");
        }

        [Test]
        public void phoneGenTestWithInvalidInput()
        {
            List<string> retPhoneList = PhoneNumberGenerator.GeneratePhoneNumber("123abc7890");
            Assert.IsTrue(retPhoneList == null, "Given input 123abc7890 gives null values back");
        }
    }
}
