using System;

namespace SpheroCalculator
{
    enum TypeOfSurface { Concave = 1, Convex };
    enum TypeOfCalculation { Height = 1, Radius };
    enum TypeOfSpherometr { Big = 1, Small };
    enum RingsOfBigSpherometr { Ring1 = 1, Ring2, Ring3, Ring4 };
    enum RingsOfSmallSpherometr { Ring1 = 1, Ring2, Ring3, Ring4, Ring5, Ring7 = 7 };

    class UserInputData
    {
        public TypeOfSurface Surface { get; set; }
        public TypeOfCalculation Calculation { get; set; }
        public TypeOfSpherometr Spherometr { get; set; }
        public int RingNumber { get; set; }
        public double UserMeasureData { get; set; }
    }
}
