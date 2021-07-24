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
        public void TestConvexHeight(double radius, double height)
        {
            double calcHeight = Calculator.ConvexHeight(radius, ring, ball);
            Assert.AreEqual(height, calcHeight);
        }
    }
}