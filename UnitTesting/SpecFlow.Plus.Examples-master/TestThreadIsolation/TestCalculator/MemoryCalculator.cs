namespace TestCalculator
{
    public class MemoryCalculator : ICalculator
    {
        private readonly int[] _numbers = new int[2];
        private int _index;
        public int Result { get; private set; }

        public void EnterNumber(int number)
        {
            _numbers[_index] = number;
            _index = (_index + 1) % 2;
        }

        public void Add()
        {
            Result = _numbers[0] + _numbers[1];
        }

        public void Clear()
        {
            _numbers[0] = 0;
            _numbers[1] = 0;
            _index = 0;
            Result = 0;
        }
    }
}