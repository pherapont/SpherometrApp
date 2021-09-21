using NUnit.Framework;
using SpheroCalculatorLib;

namespace SpherometrTests
{
    [TestFixture]
    public class SpherometrBig_Ring2_Tests
    {
        Spherometr spherometr;
        double ring;
        double ball;

        [SetUp]
        public void SetUp()
        {
            spherometr = new SpherometrBig(2);
            ring = spherometr.GetRingRadius();
            ball = spherometr.GetBallRadius();
        }

        [TestCase(280, 10.344)]
        public void TestConcaveHeight(double radius, double height)
        {
            double calcHeight = Calculator.ConcaveHeight(radius, ring, ball);
            Assert.AreEqual(height, calcHeight);
        }

        
        public void TestConvexHeight(double radius, double height)
        {
            double calcHeight = Calculator.ConvexHeight(radius, ring, ball);
            Assert.AreEqual(height, calcHeight);
        }
    }
}