namespace Example
{
    public class Calculator
    {
        public int FirstNumber { set; private get; }
        public int SecondNumber { set; private get; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
    }
}
