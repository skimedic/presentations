// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - RadioStation.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace BehaviorPatterns.Observer.A_FromScratch.Observers;

public class RadioStation : ICustomObserver
{
    public void Update(GameResult result)
    {
        Results.Add(result);
    }
    public List<GameResult> Results { get; set; } = new List<GameResult>();
}