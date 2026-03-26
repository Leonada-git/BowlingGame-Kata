using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public class NormalScoringBehavior : IScoringBehavior
    {
        Frame _frame;

        public NormalScoringBehavior(Frame frame)
        {
            _frame = frame ?? throw new ArgumentNullException(nameof(frame));
        }

        public int CalculateScore(IReadOnlyList<Frame> frames, int i)
        {
            return _frame.Rolls.Sum(r => r.Pins);
        }
    }
}
