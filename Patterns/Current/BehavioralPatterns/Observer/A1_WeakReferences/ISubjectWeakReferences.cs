// Copyright Information
// =============================
// BehavioralPatterns - ISubjectWeakReferences.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
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
        internal readonly List<WeakReference<ICustomObserver>> Observers = 
            new List<WeakReference<ICustomObserver>>();

        public void AddGameResult(GameResult result)
        {
            NotifyObservers(result);
        }
        public void UnregisterObserver(WeakReference<ICustomObserver> observer)
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
                    UnregisterObserver(itm);
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

}
