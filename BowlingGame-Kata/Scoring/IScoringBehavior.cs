using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public interface IScoringBehavior
    {
        int CalculateScore(FrameContext frameContext);
    }
}
