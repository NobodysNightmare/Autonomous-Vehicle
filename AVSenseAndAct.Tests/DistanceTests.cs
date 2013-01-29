using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutonomousVehicle.SenseAndAct.Distance;

namespace AVSenseAndAct.Tests
{
    [TestClass]
    public class DistanceTests
    {
        [TestMethod]
        public void ConversionTest()
        {
            var distance = Distance.FromMillimeters(2000);
            Assert.AreEqual(2000, distance.InMillimeters);
            Assert.AreEqual(200, distance.InCentimeters);
            Assert.AreEqual(2, distance.InMeters);
        }

        [TestMethod]
        public void InstanciationTest()
        {
            Assert.AreEqual(42, Distance.FromMillimeters(42).InMillimeters);
            Assert.AreEqual(42, Distance.FromCentimeters(4.2).InMillimeters);
            Assert.AreEqual(42, Distance.FromMeters(0.042).InMillimeters);
        }

        [TestMethod]
        public void ComparisonTest()
        {
            var referenceDistance = Distance.FromMillimeters(42);
            Assert.AreEqual(referenceDistance, Distance.FromMillimeters(42));
            Assert.AreEqual(referenceDistance, Distance.FromCentimeters(4.2));
            Assert.AreEqual(referenceDistance, Distance.FromMeters(0.042));

            Assert.AreNotEqual(referenceDistance, Distance.FromMillimeters(43));
            Assert.AreNotEqual(referenceDistance, Distance.FromCentimeters(4.1));
            Assert.AreNotEqual(referenceDistance, Distance.FromMeters(0.42));
        }

        [TestMethod]
        public void ExtensionTest()
        {
            var intValue = 23;
            Assert.AreEqual(Distance.FromMillimeters(intValue), intValue.Millimeters());
            Assert.AreEqual(Distance.FromCentimeters(intValue), intValue.Centimeters());
            Assert.AreEqual(Distance.FromMeters(intValue), intValue.Meters());
        }

        [TestMethod]
        public void AdditionTest()
        {
            var result = 42.Millimeters();
            Assert.AreEqual(result, 20.Millimeters() + 22.Millimeters());
            Assert.AreEqual(result, 32.Millimeters() + 10.Millimeters());
        }

        [TestMethod]
        public void SubtractionTest()
        {
            var result = 42.Millimeters();
            Assert.AreEqual(result, 100.Millimeters() - 58.Millimeters());
            Assert.AreEqual(result, 40.Millimeters() - (-2).Millimeters());
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            var result = 42.Millimeters();
            Assert.AreEqual(result, 2 * 21.Millimeters());
            Assert.AreEqual(result, 21.Millimeters() * 2);
        }

        [TestMethod]
        public void DivisionTest()
        {
            var result = 42.Millimeters();
            Assert.AreEqual(result, 84.Millimeters() / 2);
            Assert.AreEqual(result, 126.Millimeters() / 3);
        }
    }
}
