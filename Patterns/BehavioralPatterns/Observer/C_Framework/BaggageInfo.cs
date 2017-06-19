// Copyright Information
// =============================
// BehavioralPatterns - BaggageInfo.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
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