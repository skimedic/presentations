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
            _driver = driver;
        }

        [Given(@"a new bowling game")]
        public void GivenANewBowlingGame()
        {
            _driver.NewGame();
        }

        [When(@"all of my balls are landing in the gutter")]
        public void WhenAllOfMyBallsAreLandingInTheGutter()
        {
            _driver.Roll(0, 20);
        }

        [When(@"all of my rolls are strikes")]
        public void WhenAllOfMyRollsAreStrikes()
        {
            _driver.Roll(10, 12);
        }

        [Then(@"my total score should be (\d+)")]
        public void ThenMyTotalScoreShouldBe(int score)
        {
            _driver.CheckScore(score);
        }

        [When(@"I roll (\d+)")]
        public void WhenIRoll(int pins)
        {
            _driver.Roll(pins, 1);
        }

        [When(@"I roll (\d+) and (\d+)")]
        public void WhenIRoll(int pins1, int pins2)
        {
            _driver.Roll(pins1, pins2, 1);
        }

        [When(@"I roll (\d+) times (\d+) and (\d+)")]
        public void WhenIRollSeveralTimes2(int rollCount, int pins1, int pins2)
        {
            _driver.Roll(pins1, pins2, rollCount);
        }

        [When(@"I roll the following series:(.*)")]
        public void WhenIRollTheFollowingSeries(string series)
        {
            _driver.RollSeries(series);
        }

        [When(@"I roll")]
        public void WhenIRoll(Table rolls)
        {
            _driver.RollSeries(rolls);
        }
    }
}
