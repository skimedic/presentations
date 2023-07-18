// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - ISubjectWeakReferences.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace BehaviorPatterns.Observer.A1_WeakReferences;

//NOTE: This is not a production implementation of weak references.  This is just a demo
//example used to get you started on the weak reference journey.
public interface ISubjectWeakReferences
{
    WeakReference<ICustomObserver> RegisterObserver(ICustomObserver customObserver);
    void UnRegisterObserver(WeakReference<ICustomObserver> observer);
    void NotifyObservers(GameResult result);
}