namespace SpheroCalculatorLib
{
    public interface ISpherometrUserInput
    {
        int GetSurfaceType();
        int GetCalculationType();
        int GetSpherometrType();
        int GetRingNumber(string rings);
        double GetUserMeasure();
        void PrintMessage(string str);
    }
}
