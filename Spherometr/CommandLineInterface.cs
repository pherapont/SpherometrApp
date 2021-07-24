using System;
using SpheroCalculatorLib;

namespace SpheroCalculator
{
    public class CommandLineInterface : ISpherometrUserInput
    {
        UserInputData userParametrs = new UserInputData();
        public UserInputData GetUserParametrs()
        {
            GetSurfaceType();
            GetCalculationType();
            GetSpherometrType();
            GetRingNumber();
            GetUserMeasure();
            return userParametrs;
        }
        public void CalculateAndPrint()
        {
            double result = Controller.GetAndCalculate(userParametrs);
            PrintMessage(result.ToString());
        }
        private void GetSurfaceType()
        {
            userParametrs.Surface = (TypeOfSurface)GetBinaryInput("поверхности", "Вогнутая", "Выпуклая");
        }
        private void GetCalculationType()
        {
            userParametrs.Calculation = (TypeOfCalculation)GetBinaryInput("вычисления", "Стрелка", "Радиус");
        }
        private void GetSpherometrType()
        {
            userParametrs.Spherometr = (TypeOfSpherometr)GetBinaryInput("сферометра", "Большой", "Малый");
        }
        private void GetRingNumber()
        {
            string rings = "";
            if (userParametrs.Spherometr == TypeOfSpherometr.Big)
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
            Console.ForegroundColor = ConsoleColor.Green;

            string line1 = "======================";
            string line2 = "Определите номер кольца сферометра:";
            PrintLines(line1, line2, rings);

            int ringNumber;
            Console.CursorLeft = 5;
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (!Int32.TryParse(Console.ReadLine(), out ringNumber) || !rings.Contains(ringNumber.ToString()))
            {
                Console.CursorLeft = 5;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод. Введите правильный номер кольца.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.CursorLeft = 5;
            }
            userParametrs.RingNumber = ringNumber;
        }
        private void GetUserMeasure()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string line1 = "======================";
            string line2 = "Введите данные измерений сферометра:";
            string line3 = "(дробная часть отделяется запятой)";
            PrintLines(line1, line2, line3);

            double userData;
            Console.CursorLeft = 5;
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (!Double.TryParse(Console.ReadLine(), out userData) )
            {
                Console.CursorLeft = 5;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод. Введите числовое значение (дробная часть отделяется запятой).");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.CursorLeft = 5;
            }
            userParametrs.UserMeasureData = userData;
        }
        private void PrintMessage(string mes)
        {
            Console.WriteLine();
            Console.CursorLeft = (Console.BufferWidth - mes.Length) / 2;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(mes.ToUpper());
            Console.WriteLine();
            Console.ResetColor();
        }
        private static int GetBinaryInput(string inputType, string type1, string type2)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string line1 = "======================";
            string line2 = $"Определите тип {inputType}:";
            string line3 = $"{type1} - 1";
            string line4 = $"{type2} - 2";
            PrintLines(line1, line2, line3, line4);

            int ans;
            Console.CursorLeft = 5;
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (!Int32.TryParse(Console.ReadLine(), out ans) || (ans < 1) || (ans > 2))
            {
                Console.CursorLeft = 5;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод. Введите 1 или 2.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.CursorLeft = 5;
            }
            return ans;
        }
        private static void PrintLines(params string[] mes)
        {
            foreach (string line in mes)
            {
                Console.CursorLeft = 5;
                Console.WriteLine(line);
            }
        }
    }
}
