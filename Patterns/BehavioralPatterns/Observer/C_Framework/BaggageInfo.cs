namespace BehavioralPatterns.Observer.C_Framework
{
    public class BaggageInfo
    {
        internal BaggageInfo(int flight, string from, int carousel)
        {
            this.FlightNumber = flight;
            this.From = from;
            this.Carousel = carousel;
        }

        public int FlightNumber { get; }

        public string From { get; }

        public int Carousel { get; }
    }
}