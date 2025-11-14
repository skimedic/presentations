// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatternsTests - WeakReferencesTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

using BehaviorPatterns.Observer.A1_WeakReferences;

namespace BehaviorPatternsTests.Observer.A1_WeakReferences;

[Collection("Observer")]
public class WeakReferencesTests
{
    [Fact]
    public void ShouldNotifyObserversOfGameResult()
    {
        var subject = new SportsAggregatorWeakReferences();
        var observer1 = new NewsPaper();
        var observer2 = new RadioStation();
        var wr1 = subject.RegisterObserver(observer1);
        var wr2 = subject.RegisterObserver(observer2);
        var gameResult = new GameResult
        {
            GameDate = DateTime.Now,
            LosingScore = 1,
            LosingTeam = "Chicago Cubs",
            WinningScore = 5,
            WinningTeam = "Cincinnati Reds"
        };
        subject.AddGameResult(gameResult);
        Assert.Single(observer1.Results);
        Assert.Single(observer2.Results);
        Assert.Same(gameResult, observer1.Results[0]);
        Assert.Same(gameResult, observer2.Results[0]);
        subject.UnRegisterObserver(wr1);
        subject.UnRegisterObserver(wr2);
        Assert.Empty(subject.Observers);
    }
    [Fact(Skip="On hold")]
    public void ShouldHandleNullObjectsCorrectly()
    {
        var subject = new SportsAggregatorWeakReferences();
        var observer1 = new NewsPaper();
        var observer2 = new RadioStation();
        var wr1 = subject.RegisterObserver(observer1);
        var wr2 = subject.RegisterObserver(observer2);
        observer1 = null;
        //Demo code. don't do this in real life
        GC.Collect();
        GC.WaitForPendingFinalizers();
        var gameResult = new GameResult
        {
            GameDate = DateTime.Now,
            LosingScore = 1,
            LosingTeam = "Chicago Cubs",
            WinningScore = 5,
            WinningTeam = "Cincinnati Reds"
        };
        subject.AddGameResult(gameResult);
        //No longer need this line...
        //subject.UnRegisterObserver(wr1);
        foreach (var foo in subject.Observers)
        {
            foo?.TryGetTarget(out var observer);
        }
        subject.UnRegisterObserver(wr2);
        Assert.Empty(subject.Observers);
    }
}