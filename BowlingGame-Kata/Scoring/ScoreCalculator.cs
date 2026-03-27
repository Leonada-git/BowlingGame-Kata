using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public class ScoreCalculator : IScoreCalculator
    {
        int totaleScore;
        readonly IScoreFactory _scoreFactory;
        List<IScoringBehavior> _scores = new();


        public ScoreCalculator(IScoreFactory scoreFactory)
        {
            _scoreFactory = scoreFactory ?? throw new ArgumentNullException(nameof(scoreFactory));
        }

        public int CalculateTotalScore(IGameFrames gameFrames)
        {
            var frames = gameFrames.Frames;
            if (frames.Count == 0)
            {
                return totaleScore;
            }

            CreateScores(frames);
            CalculateScores(frames);
            return totaleScore;
        }

        private void CalculateScores(IReadOnlyList<Frame> frames)
        {
            for (var i = 0; i < _scores.Count; i++)
            {
                var frameContext = new FrameContext(frames, i);
                totaleScore += _scores[i].CalculateScore(frameContext);
            }
        }

        private void CreateScores(IReadOnlyList<Frame> frames)
        {
            foreach (var frame in frames)
            {
                var score = CreateScores(frame);
                _scores.Add(score);
            }
        }

        private IScoringBehavior CreateScores(Frame frame)
        {
            return _scoreFactory.Create(frame);
        }

    }
}
