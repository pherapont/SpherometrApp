using System;
using SpheroCalculatorLib;

namespace SpheroCalculator
{
    class InputController
    {
        ISpherometrUserInput userInput = new CLISpherometrUserInput();

        UserInputData inputData = new UserInputData();
        public UserInputData GetUserData()
        {
            userInput.PrintMessage("Приложение для расчета параметров сферической поверхности");

            inputData.Surface = (TypeOfSurface)userInput.GetSurfaceType();

            inputData.Calculation = (TypeOfCalculation)userInput.GetCalculationType();

            inputData.Spherometr = (TypeOfSpherometr)userInput.GetSpherometrType();

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

            inputData.RingNumber = userInput.GetRingNumber(rings);

            inputData.UserMeasureData = userInput.GetUserMeasure();

            return inputData;
        }

        public void PrintResult(double result)
        {
            userInput.PrintMessage($"Результат вычислений: {result:f3}мм.");
        }
    }
}
