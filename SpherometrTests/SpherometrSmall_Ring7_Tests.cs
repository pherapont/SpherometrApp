using NUnit.Framework;
using SpheroCalculatorLib;

namespace SpherometrTests
{
    [TestFixture]
    public class SpherometrSmall_Ring7_Tests
    {
        Spherometr spherometr;
        double ring;
        double ball;

        [SetUp]
        public void SetUp()
        {
            // First ring has number 0 in array of rings
            spherometr = new SpherometrSmall(7);
            ring = spherometr.GetRingRadius();
            ball = spherometr.GetBallRadius();
        }

        [TestCase(71, 0.401)]
        public void TestConcaveHeight(double radius, double height)
        {
            double calcHeight = Calculator.ConcaveHeight(radius, ring, ball);
            Assert.AreEqual(height, calcHeight);
        }

        [TestCase(71, 0.388)]
        [TestCase(31.62, 0.864)]
        public void TestConvexHeight(double radius, double height)
        {
            double calcHeight = Calculator.ConvexHeight(radius, ring, ball);
            Assert.AreEqual(height, calcHeight);
        }

        //[TestCase(71, 0.401)]
        public void TestConcaveRadius(double height, double radius)
        {
            double calcRadius = Calculator.ConcaveRadius(height, ring, ball);
            Assert.AreEqual(radius, calcRadius);
        }

        [TestCase(0.388, 71.1)]
        [TestCase(0.864, 31.6)]
        public void TestConvexRadius(double height, double radius)
        {
            double calcRadius = Calculator.ConvexRadius (height, ring, ball);
            Assert.AreEqual(radius, calcRadius);
        }
    }
}