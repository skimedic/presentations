// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatternsTests - ObserverFromScratchTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace BehaviorPatternsTests.Observer.A_FromScratch;

[Collection("Observer")]
public class ObserverFromScratchTests
{
    [Fact]
    public void ShouldNotifyObserversOfGameResult()
    {
        var subject = new SportsAggregator();
        var observer1 = new NewsPaper();
        var observer2 = new RadioStation();
        subject.RegisterObserver(observer1);
        subject.RegisterObserver(observer2);
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
        Assert.Same(gameResult,observer1.Results[0]);
        Assert.Same(gameResult,observer2.Results[0]);
        subject.UnRegisterObserver(observer1);
        subject.UnRegisterObserver(observer2);
        Assert.Empty(subject.Observers);
    }
    [Fact]
    public void DoesntHandleNullObjectsCorrectly()
    {
        var subject = new SportsAggregator();
        var observer1 = new NewsPaper();
        var observer2 = new RadioStation();
        subject.RegisterObserver(observer1);
        subject.RegisterObserver(observer2);
        observer1 = null;
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
        subject.UnRegisterObserver(observer2);
        //subject.UnregisterObserver(observer1);
        Assert.Single(subject.Observers);
    }
}