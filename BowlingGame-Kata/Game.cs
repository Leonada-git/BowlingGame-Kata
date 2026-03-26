using BowlingGame_Kata.Scoring;

namespace BowlingGame_Kata
{
    public class Game
    {
        readonly IGameFrames _frames;
        readonly IScoreCalculator _scoreCalculator;

        public Game(IGameFrames frames, IScoreCalculator scoreCalculator)
        {
            _frames = frames ?? throw new ArgumentNullException(nameof(frames));
            _scoreCalculator = scoreCalculator ?? throw new ArgumentNullException(nameof(scoreCalculator));
        }

        public void Roll(int pins)
        {
            if (pins < 0)
                throw new ArgumentException("Negative numbers are not allowed.");
            if (pins > 10)
                throw new ArgumentException("Cannot exceed 10.");

            _frames.Roll(pins);
        }

        public int Score()
        {
            return _scoreCalculator.CalculateTotalScore(_frames);
        }
    }
}