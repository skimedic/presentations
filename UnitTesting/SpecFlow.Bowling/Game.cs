namespace Bowling.Specflow
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score
        {
            get
            {
                int score = 0;
                int frameIndex = 0;
                for (int frame = 0; frame < 10; frame++)
                {
                    if (isStrike(frameIndex))
                    {
                        score += 10 + strikeBonus(frameIndex);
                        frameIndex++;
                    }
                    else if (isSpare(frameIndex))
                    {
                        score += 10 + spareBonus(frameIndex);
                        frameIndex += 2;
                    }
                    else
                    {
                        score += sumOfBallsInFrame(frameIndex);
                        frameIndex += 2;
                    }
                }
                return score;
            }
        }

        private bool isStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private int sumOfBallsInFrame(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int spareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private int strikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        private bool isSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }
    }
}
