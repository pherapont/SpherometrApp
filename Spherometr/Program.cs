using SpheroCalculatorLib;

namespace SpheroCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ISpherometrUserInput userInput = new CommandLineInterface();
            Controller.GetAndCalculate(userInput);
        }
    }
}
