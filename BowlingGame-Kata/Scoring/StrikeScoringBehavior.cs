using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public class StrikeScoringBehavior : ScoringBehaviorBase
    {

        protected override int CalculateBonus(FrameContext context)
        {
            var next = context.Next ?? throw new InvalidOperationException("Next frame is required.");

            int bonus = next.SumStrikeBonusRolls;

            if (next.NeedsExtraRollFromNextFrame && context.HasNextNext)
            {
                bonus += context.NextNext!.FirstRoll;
            }

            return bonus;
        }

    }
}
