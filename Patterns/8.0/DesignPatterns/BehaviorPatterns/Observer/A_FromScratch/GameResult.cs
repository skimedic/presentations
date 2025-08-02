// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - GameResult.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace BehaviorPatterns.Observer.A_FromScratch;

public class GameResult
{
    public string WinningTeam { get; set; }
    public string LosingTeam { get; set; }
    public int WinningScore { get; set; }
    public int LosingScore { get; set; }
    public DateTime GameDate { get; set; }
}