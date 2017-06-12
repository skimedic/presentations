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
        private readonly List<ICustomObserver> _observers = new List<ICustomObserver>();

        public void AddGameResult(GameResult result)
        {
            NotifyObservers(result);
        }
        public void RegisterObserver(ICustomObserver customObserver)
        {
            _observers.Add(customObserver);
        }

        public void UnregisterObserver(ICustomObserver customObserver)
        {
            _observers.Remove(customObserver);
        }

        public void NotifyObservers(GameResult result)
        {
            _observers.ForEach(x=>x.Update(result));
        }
    }

}
