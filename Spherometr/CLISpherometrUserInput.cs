using System;
using SpheroCalculatorLib;

namespace SpheroCalculator
{
    public class CLISpherometrUserInput : ISpherometrUserInput
    {
        public int GetSurfaceType()
        {
            return GetBinaryInput("поверхности", "Вогнутая", "Выпуклая");
        }
        public int GetCalculationType()
        {
            return GetBinaryInput("вычисления", "Стрелка", "Радиус");
        }
        public int GetSpherometrType()
        {
            return GetBinaryInput("сферометра", "Большой", "Малый"); ;
        }
        public int GetRingNumber(string rings)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string line1 = "======================";
            string line2 = "Определите номер кольца большого сферометра:";
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
            return ringNumber;
        }
        public double GetUserMeasure()
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
            return userData;
        }
        public void PrintMessage(string mes)
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
