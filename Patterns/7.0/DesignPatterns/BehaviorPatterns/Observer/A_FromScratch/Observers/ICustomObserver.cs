// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - ICustomObserver.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace BehaviorPatterns.Observer.A_FromScratch.Observers;

public interface ICustomObserver
{
    void Update(GameResult result);
    List<GameResult> Results { get; set; }

}