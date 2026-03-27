using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public abstract class ScoringBehaviorBase : IScoringBehavior
    {
        public int CalculateScore(FrameContext context)
        {
            var totalScore = context.Current.Score;

            if (ShouldApplyBonus(context))
            {
                totalScore += CalculateBonus(context);
            }

            return totalScore;
        }

        protected virtual bool ShouldApplyBonus(FrameContext context) => context.HasNext;

        protected abstract int CalculateBonus(FrameContext context);
    }
}
