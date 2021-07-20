using System;

namespace SpheroCalculator
{
    class Controller
    {

        static void Main(string[] args)
        {
            UserInputData data = IOController.GetUserData();

            Spherometr spherometr;
            if (data.Spherometr == TypeOfSpherometr.Big)
            {
                spherometr = new SpherometrBig(data.RingNumber);
            } else {
                spherometr = new SpherometrSmall(data.RingNumber);
            }
            double ring = spherometr.GetRingRadius();
            double ball = spherometr.GetBallRadius();
            double measure = data.UserMeasureData;

            double result;

            if (data.Calculation == TypeOfCalculation.Height && data.Surface == TypeOfSurface.Concave)
            {
                result = Calculator.ConcaveHeight(measure, ring, ball);
            }
            else if (data.Calculation == TypeOfCalculation.Height && data.Surface == TypeOfSurface.Convex)
            {
                result = Calculator.ConvexHeight(measure, ring, ball);
            }
            else if (data.Calculation == TypeOfCalculation.Radius && data.Surface == TypeOfSurface.Concave)
            {
                result = Calculator.ConcaveRadius(measure, ring, ball);
            }
            else if (data.Calculation == TypeOfCalculation.Radius && data.Surface == TypeOfSurface.Convex)
            {
                result = Calculator.ConvexRadius(measure, ring, ball);
            }
            else
            {
                throw new Exception("Нет таких параметров вычислений");
            }

            IOController.PrintResult(result);
        }
    }
}
