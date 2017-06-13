using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehavioralPatterns.Observer.A_FromScratch;
using Xunit;

namespace BehavioralPatternsTests.Observer.A_FromScratch
{
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
            Assert.Equal(1,observer1.Results.Count);
            Assert.Equal(1,observer2.Results.Count);
            Assert.Same(gameResult,observer1.Results[0]);
            Assert.Same(gameResult,observer2.Results[0]);
            subject.UnregisterObserver(observer1);
            subject.UnregisterObserver(observer2);
            Assert.Equal(0,subject.Observers.Count);
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
            subject.UnregisterObserver(observer2);
            //subject.UnregisterObserver(observer1);
            Assert.Equal(1,subject.Observers.Count);
        }
    }
}
