using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public class SpareScoringBehavior : IScoringBehavior
    {
        Frame _frame;

        int totaleScore;

        public SpareScoringBehavior(Frame frame)
        {
            _frame = frame ?? throw new ArgumentNullException(nameof(frame));
        }

        public int CalculateScore(IReadOnlyList<Frame> frames, int i)
        {
            totaleScore = _frame.Rolls.Sum(r => r.Pins);
            CalculateBonus(frames, i);
            return totaleScore;
        }

        private void CalculateBonus(IReadOnlyList<Frame> frames, int index)
        {
            if (IsNextRollExists(frames, index))
            {
                totaleScore += frames[index + 1].FirstRoll;
            }
        }

        private bool IsNextRollExists(IReadOnlyList<Frame> frames, int index)
        {
            return frames.Count() >= index + 2;
        }
    }
}
