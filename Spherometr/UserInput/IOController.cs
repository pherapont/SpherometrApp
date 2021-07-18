using System;

namespace SpheroCalculator
{
    class IOController
    {
        static internal UserInputData GetUserData()
        {
            CLI.PrintMessage("Приложение для расчета параметров сферической поверхности");

            UserInputData inputData = new UserInputData();

            inputData.Surface = (TypeOfSurface)CLI.GetSurfaceType();

            inputData.Calculation = (TypeOfCalculation)CLI.GetCalculationType();

            inputData.Spherometr = (TypeOfSpherometr)CLI.GetSpherometrType();

            string rings = "";
            if (inputData.Spherometr == TypeOfSpherometr.Big)
            {
                foreach (RingsOfBigSpherometr ring in Enum.GetValues(typeof(RingsOfBigSpherometr)))
                {
                    rings += (int)ring + " ";
                }
            }
            else
            {
                foreach (RingsOfSmallSpherometr ring in Enum.GetValues(typeof(RingsOfSmallSpherometr)))
                {
                    rings += (int)ring + " ";
                }
            }

            inputData.RingNumber = CLI.GetRingNumber(rings);

            inputData.UserMeasureData = CLI.GetUserMeasure();

            return inputData;
        }

        static internal void PrintResult(double result)
        {
            CLI.PrintMessage($"Результат вычислений: {result:f3}мм.");
        }
    }
}
