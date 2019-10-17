using TechTalk.SpecFlow;
using Xunit;

namespace Bowling.Specflow.Drivers
{
    public class BowlingDriver
    {
        private Game _game;

        public void NewGame()
        {
            _game = new Game();
        }

        public void Roll(int pins, int rollCont)
        {
            for (int i = 0; i < rollCont; i++)
            {
                _game.Roll(pins);
            }
        }

        public void Roll(int pins1, int pins2, int rollCount)
        {
            for (int i = 0; i < rollCount; i++)
            {
                _game.Roll(pins1);
                _game.Roll(pins2);
            }
        }

        public void RollSeries(string series)
        {
            foreach (string roll in series.Trim().Split(','))
            {
                _game.Roll(int.Parse(roll));
            }
        }

        public void RollSeries(Table rolls)
        {
            foreach (var row in rolls.Rows)
            {
                _game.Roll(int.Parse(row["Pins"]));
            }
        }

        public void CheckScore(int expected)
        {
            Assert.Equal(expected, _game.Score);
        }
    }
}
