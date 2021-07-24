using NUnit.Framework;
using SpheroCalculatorLib;

namespace SpherometrTests
{
    [TestFixture]
    public class SpherometrBig_Ring1_Tests
    {
        Spherometr spherometr;
        double ring;
        double ball;

        [SetUp]
        public void SetUp()
        {
            // First ring has number 0 in array of rings
            spherometr = new SpherometrBig(1);
            ring = spherometr.GetRingRadius();
            ball = spherometr.GetBallRadius();
        }

        [TestCase(100, 11.115)]
        [TestCase(200, 5.224)]
        [TestCase(777.777, 1.311)]
        [TestCase(9535.2, 0.106)]
        public void TestConcaveHeight(double radius, double height)
        {
            double calcHeight = Calculator.ConcaveHeight(radius, ring, ball);
            Assert.AreEqual(height, calcHeight);
        }

        [TestCase(100, 10.355)]
        [TestCase(200, 5.057)]
        [TestCase(777.777, 1.3)]
        [TestCase(9535.2, 0.106)]
        public void TestConvexHeight(double radius, double height)
        {
            double calcHeight = Calculator.ConvexHeight(radius, ring, ball);
            Assert.AreEqual(height, calcHeight);
        }
    }
}