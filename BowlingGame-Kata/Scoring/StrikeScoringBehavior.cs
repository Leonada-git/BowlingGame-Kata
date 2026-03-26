using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public class StrikeScoringBehavior : IScoringBehavior
    {
        Frame _frame;

        int totaleScore;

        public StrikeScoringBehavior(Frame frame)
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
            if (IsNextFrameExists(frames, index))
            {
                totaleScore += frames[index + 1].Rolls.Take(2).Sum(r => r.Pins);
                if (IsNextFrameHasTwoRolls(frames[index + 1]))
                {
                    return;
                }
                AddBonusFromSecondNextFrame(frames, index);
            }
        }

        private void AddBonusFromSecondNextFrame(IReadOnlyList<Frame> frames, int index)
        {
            if (HasSecondNextFrame(frames, index))
            {
                totaleScore += frames[index + 2].FirstRoll;
            }
        }

        private static bool HasSecondNextFrame(IReadOnlyList<Frame> frames, int index)
        {
            return frames.Count() >= index + 3;
        }

        private bool IsNextFrameExists(IReadOnlyList<Frame> frames, int index)
        {
            return frames.Count() >= index + 2;
        }

        private bool IsNextFrameHasTwoRolls(Frame frame)
        {
            return frame.HasSecondRoll;
        }
    }
}
