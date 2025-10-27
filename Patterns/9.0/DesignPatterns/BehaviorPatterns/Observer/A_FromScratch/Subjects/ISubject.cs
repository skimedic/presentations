// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - ISubject.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace BehaviorPatterns.Observer.A_FromScratch.Subjects;

/*
 Defines a 1:MANY dependency between objects so that when one object changes state
 all of the dependents are notified and updated automatically
 */
public interface ISubject
{
    void RegisterObserver(ICustomObserver customObserver);
    void UnRegisterObserver(ICustomObserver customObserver);
    void NotifyObservers(GameResult result);
}