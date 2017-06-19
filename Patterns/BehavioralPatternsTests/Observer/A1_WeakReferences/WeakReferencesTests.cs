// Copyright Information
// =============================
// BehavioralPatternsTests - WeakReferencesTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System;
using BehavioralPatterns.Observer.A1_WeakReferences;
using BehavioralPatterns.Observer.A_FromScratch;
using Xunit;

namespace BehavioralPatternsTests.Observer.A1_WeakReferences
{
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
            Assert.Equal(1, observer1.Results.Count);
            Assert.Equal(1, observer2.Results.Count);
            Assert.Same(gameResult, observer1.Results[0]);
            Assert.Same(gameResult, observer2.Results[0]);
            subject.UnregisterObserver(wr1);
            subject.UnregisterObserver(wr2);
            Assert.Equal(0, subject.Observers.Count);
        }
        [Fact]
        public void ShouldHandleNullObjectsCorrectly()
        {
            var subject = new SportsAggregatorWeakReferences();
            var observer1 = new NewsPaper();
            var observer2 = new RadioStation();
            var wr1 = subject.RegisterObserver(observer1);
            var wr2 = subject.RegisterObserver(observer2);
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
            //No longer need this line...
            //subject.UnregisterObserver(wr1);
            subject.UnregisterObserver(wr2);
            Assert.Equal(0, subject.Observers.Count);
        }
    }
}
