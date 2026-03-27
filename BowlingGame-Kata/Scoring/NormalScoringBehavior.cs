using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public class NormalScoringBehavior : IScoringBehavior
    {
        public int CalculateScore(FrameContext context)
        {
            return context.Current.Score;
        }
    }
}
