using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public interface IScoringBehavior
    {
        int CalculateScore(IReadOnlyList<Frame> frames, int index);
    }
}
