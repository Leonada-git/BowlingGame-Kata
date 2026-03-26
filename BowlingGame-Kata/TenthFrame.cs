
namespace BowlingGame_Kata
{
    public class TenthFrame : Frame
    {
        const int MaxRollsWithoutBonus = 2;
        private const int MaxRollsWithBonus = 3;

        private int MaxAllowedRolls => HasBonusRoll()
            ? MaxRollsWithBonus
            : MaxRollsWithoutBonus;

        public override bool IsClosed =>
            HasReachedMaxRolls() ||
            HasNoBonusAfterTwoRolls();

        private bool HasNoBonusAfterTwoRolls()
        {
            return RollsInternal.Count == MaxRollsWithoutBonus && !IsStrikeRoll(First) && !IsSpareRoll(First, Second);
        }

        private bool HasReachedMaxRolls()
        {
            return RollsInternal.Count == MaxRollsWithBonus;
        }

        public override int RemainingPins => CalculateRemainingPins();

        private int CalculateRemainingPins()
        {
            return RollsInternal.Count switch
            {
                0 => RemainingAfterZeroRolls(),

                1 => RemainingAfterFirstRoll(),

                2 => RemainingAfterSecondRoll(),

                3 => 0,
                _ => throw new InvalidOperationException("Invalid number of rolls in tenth frame.")
            };
        }

        private int RemainingAfterZeroRolls() => MaxPins;

        private int RemainingAfterFirstRoll()
        {
            return IsStrikeRoll(First) ? MaxPins : MaxPins - First;
        }

        private int RemainingAfterSecondRoll()
        {
            return HasBonusRoll() ? MaxPins : 0;
        }

        protected override bool HasBonusRoll() =>
            (HasFirstRoll && IsStrikeRoll(First)) ||
            (HasSecondRoll && IsSpareRoll(First, Second));

        public override int RemainingRolls => MaxAllowedRolls - RollsInternal.Count;

    }
}
