using System;

namespace BehavioralPatterns.Observer.A_FromScratch
{
    public class GameResult
    {
        public string WinningTeam { get; set; }
        public string LosingTeam { get; set; }
        public int WinningScore { get; set; }
        public int LosingScore { get; set; }
        public DateTime GameDate { get; set; }
    }
}