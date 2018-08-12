namespace TestCalculator
{
    public interface ICalculator
    {
        int Result { get; }

        void EnterNumber(int number);
        void Add();
        void Clear();
    }
}