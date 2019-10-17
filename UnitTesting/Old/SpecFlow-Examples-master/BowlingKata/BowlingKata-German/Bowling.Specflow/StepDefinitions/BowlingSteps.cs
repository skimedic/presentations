using System;
using Bowling.Specflow.Drivers;
using TechTalk.SpecFlow;

namespace Bowling.Specflow.StepDefinitions
{
    [Binding]
    public class BowlingSteps
    {
        private readonly BowlingDriver _driver;

        public BowlingSteps(BowlingDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        [Given(@"eine neue Bowling-Partie")]
        public void GivenANewBowlingGame()
        {
            _driver.NewGame();
        }

        [When(@"alle meine Kugeln in der Seitenrinne landen")]
        public void WhenAllOfMyBallsAreLandingInTheGutter()
        {
            _driver.Roll(0, 20);
        }

        [When(@"ich nur Strikes werfe")]
        public void WhenAllOfMyRollsAreStrikes()
        {
            _driver.Roll(10, 12);
        }

        [Then(@"soll meine Punktzahl (\d+) sein")]
        public void ThenMyTotalScoreShouldBe(int score)
        {
            _driver.CheckScore(score);
        }

        [When(@"ich (\d+) werfe")]
        public void WhenIRoll(int pins)
        {
            _driver.Roll(pins, 1);
        }

        [When(@"ich (\d+) und (\d+) werfe")]
        public void WhenIRoll(int pins1, int pins2)
        {
            _driver.Roll(pins1, pins2, 1);
        }

        [When(@"ich (\d+) mal (\d+) und (\d+) werfe")]
        public void WhenIRollSeveralTimes2(int rollCount, int pins1, int pins2)
        {
            _driver.Roll(pins1, pins2, rollCount);
        }

        [When(@"ich folgende Serie werfe:(.*)")]
        public void WhenIRollTheFollowingSeries(string series)
        {
            _driver.RollSeries(series);
        }

        [When(@"ich werfe")]
        public void WhenIRoll(Table rolls)
        {
            _driver.RollSeries(rolls);
        }
    }
}
