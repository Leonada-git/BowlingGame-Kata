using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public class SpareScoringBehavior : ScoringBehaviorBase
    {
        protected override int CalculateBonus(FrameContext context)
        {
            var next = context.Next ?? throw new InvalidOperationException("Next frame is required.");

            return next.FirstRoll;

        }
    }
}
