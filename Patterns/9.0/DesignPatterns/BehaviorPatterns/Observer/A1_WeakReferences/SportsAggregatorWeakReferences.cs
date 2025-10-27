// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - SportsAggregatorWeakReferences.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

using BehaviorPatterns.Observer.A_FromScratch;
using BehaviorPatterns.Observer.A_FromScratch.Observers;

namespace BehaviorPatterns.Observer.A1_WeakReferences;

public class SportsAggregatorWeakReferences : ISubjectWeakReferences
{
    internal readonly List<WeakReference<ICustomObserver>> Observers = 
        new List<WeakReference<ICustomObserver>>();

    public void AddGameResult(GameResult result)
    {
        NotifyObservers(result);
    }
    public void UnRegisterObserver(WeakReference<ICustomObserver> observer)
    {
        Observers.Remove(observer);
    }

    public WeakReference<ICustomObserver> RegisterObserver(ICustomObserver customObserver)
    {
        var weakReference = new WeakReference<ICustomObserver>(customObserver);
        Observers.Add(weakReference);
        return weakReference;
    }

    public void NotifyObservers(GameResult result)
    {
        foreach (var itm in Observers.ToArray())
        {
            itm.TryGetTarget(out ICustomObserver obs);
            if (obs == null)
            {
                UnRegisterObserver(itm);
            }
            else
            {
                obs.Update(result);
            }
        }
        //Observers.ForEach(x =>
        //{
        //    x.TryGetTarget(out ICustomObserver obs);
        //    if (obs == null)
        //    {
        //        UnregisterObserver(x);
        //    }
        //    else
        //    {
        //        obs.Update(result);
        //    }
        //});
    }
}