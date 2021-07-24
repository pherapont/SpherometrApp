using SpheroCalculatorLib;

namespace SpheroCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ISpherometrUserInput CLI = new CommandLineInterface();
            CLI.GetUserParametrs();
            CLI.CalculateAndPrint();
        }
    }
}
