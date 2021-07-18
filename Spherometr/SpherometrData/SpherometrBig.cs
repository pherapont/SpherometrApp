using System;

namespace SpheroCalculator
{
    public class SpherometrBig : Spherometr
    {
        double[] rings = { 45.0473, 74.9673, 109.9832, 149.982 };

        double[] balls = { 3.158, 3.159, 3.157, 3.160 };

        double ring;
        double ball;

        public SpherometrBig(int ringNumber)
        {
            ring = rings[ringNumber];
            ball = balls[ringNumber];
        }
        public override double GetRingRadius()
        {
            return ring;
        }

        public override double GetBallRadius()
        {
            return ball;
        }
    }
}
