using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SARDT.Models;

namespace SARDT.Tests
{
    [TestClass]
    public class JamesUnitTest
    {
        [TestMethod]
        public void TestParseMilitaryTime()
        {
            PublicVM testParse = new PublicVM();
            DateTime militaryParse = testParse.ParseMilitaryTime("0600");
            DateTime expectedTime = new DateTime (2016, 05, 06, 06, 00, 0);
            //this method should take 0600 and convert it to 6 am
            Assert.AreEqual(expectedTime.ToString("t"), militaryParse.ToString("t"));
        }

        [TestMethod]
        public void TestCompareDates()
        {
            PublicVM testCompare = new PublicVM();
            DateTime compareDate = new DateTime(2016, 04, 15);
            bool expected = false;
            //if the date is before today the we should get false back from the method
            bool result = testCompare.compareDates(compareDate);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestOutsideSixMonths()
        {
            PublicVM testSix = new PublicVM();
            DateTime outSideSix = new DateTime(2016, 12, 25);
            bool expected = false;
            //test to see if the date is with in 6 mounths if not it should return false
            bool result = testSix.compareDates(outSideSix);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithInSixMonths()
        {
            PublicVM testSix = new PublicVM();
            DateTime inSideSix = new DateTime(2016, 06, 25);
            bool expected = true;
            //test to see if the date is with in 6 mounths if it is should return true
            bool result = testSix.compareDates(inSideSix);

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void TestDayBefore()
        {

            PublicVM testSix = new PublicVM();
            DateTime inSideSix = new DateTime(2016, 05, 8);
            bool expected = false;
            //test to see if the date is before today if it is should return false
            bool result = testSix.compareDates(inSideSix);

            Assert.AreEqual(expected, result);

        }
        

    }
}
