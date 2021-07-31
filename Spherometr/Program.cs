using SpheroCalculatorLib;

namespace SpheroCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ISpherometrUserInput CLI = new CommandLineInterface();
            UserInputData inputData = CLI.GetUserParametrs();
            double result = Controller.GetAndCalculate(inputData);
            CLI.PrintResult(result);
        }
    }
}
