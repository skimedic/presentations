using System;
using System.Collections.Generic;
using BehavioralPatterns.Observer.A_FromScratch;

namespace BehavioralPatterns.Observer.A1_WeakReferences
{
    //NOTE: This is not a production implementation of weak references.  This is just a demo
    //example used to get you started on the weak reference journey.
    public interface ISubjectWeakReferences
    {
        WeakReference<ICustomObserver> RegisterObserver(ICustomObserver customObserver);
        void UnregisterObserver(WeakReference<ICustomObserver> observer);
        void NotifyObservers(GameResult result);
    }

    public class SportsAggregatorWeakReferences : ISubjectWeakReferences
    {
        private readonly List<WeakReference<ICustomObserver>> _observers = 
            new List<WeakReference<ICustomObserver>>();

        public void AddGameResult(GameResult result)
        {
            NotifyObservers(result);
        }
        public void UnregisterObserver(WeakReference<ICustomObserver> observer)
        {
            _observers.Remove(observer);
        }

        WeakReference<ICustomObserver> ISubjectWeakReferences.RegisterObserver(ICustomObserver customObserver)
        {
            var weakReference = new WeakReference<ICustomObserver>(customObserver);
            _observers.Add(weakReference);
            return weakReference;
        }

        public void NotifyObservers(GameResult result)
        {
            _observers.ForEach(x =>
            {
                x.TryGetTarget(out ICustomObserver obs);
                obs?.Update(result);
            });
        }
    }

}
