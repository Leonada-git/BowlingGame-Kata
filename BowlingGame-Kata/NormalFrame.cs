namespace BowlingGame_Kata
{
    public class NormalFrame : Frame
    {
        const int MaxRolls = 2;

        private int TotalPins => RollsInternal.Sum();

        public bool IsStrike => HasFirstRoll && IsStrikeRoll(First);

        public bool IsSpare => HasSecondRoll && IsSpareRoll(First, Second);

        public override bool IsClosed => IsStrike || RollsInternal.Count == MaxRolls;

        public override int RemainingPins => IsClosed ? 0 : MaxPins - TotalPins;
        public override int RemainingRolls => HasBonusRoll() ? 0 : MaxRolls - RollsInternal.Count;

        protected override bool HasBonusRoll() => IsStrike || IsSpare;

    }
}