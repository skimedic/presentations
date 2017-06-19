// Copyright Information
// =============================
// BehavioralPatterns - ISubject.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System.Collections.Generic;

namespace BehavioralPatterns.Observer.A_FromScratch
{
    /*
     Defines a 1:MANY dependency between objects so that when one object changes state
     all of the dependents are notified and updated automatically
     */
    public interface ISubject
    {
        void RegisterObserver(ICustomObserver customObserver);
        void UnregisterObserver(ICustomObserver customObserver);
        void NotifyObservers(GameResult result);
    }

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

        public void UnregisterObserver(ICustomObserver customObserver)
        {
            Observers.Remove(customObserver);
        }

        public void NotifyObservers(GameResult result)
        {
            Observers.ForEach(x=>x.Update(result));
        }
    }

}
