// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - ICustomObserver.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace BehaviorPatterns.Observer.A_FromScratch.Observers;

public interface ICustomObserver
{
    void Update(GameResult result);
    List<GameResult> Results { get; set; }

}