// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - SportsAggregator.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace BehaviorPatterns.Observer.A_FromScratch.Subjects;

public class SportsAggregator : ISubject
{
    internal readonly List<ICustomObserver> Observers = new List<ICustomObserver>();

    public void AddGameResult(GameResult result)
    {
        NotifyObservers(result);
    }
    public void RegisterObserver(ICustomObserver customObserver)
    {
        Observers.Add(customObserver);
    }

    public void UnRegisterObserver(ICustomObserver customObserver)
    {
        Observers.Remove(customObserver);
    }

    public void NotifyObservers(GameResult result)
    {
        Observers.ForEach(x => x.Update(result));
    }
}