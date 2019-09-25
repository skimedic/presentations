namespace WhatsNewInCSharp7.G_Misc
{
    public class NumericImprovementsDemo
    {
        //0b at the beginning = binary number
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;

        //digit separator can occur anywhere in a number,
        //works with int, long, decimal, float, double
        public const int Thousand = 1_000;
        public const long BillionsAndBillions = 100_000_000_000;
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 
            1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
    }
}