using BowlingGame_Kata.Rolls;

namespace BowlingGame_Kata.Frames
{
    public class TenthFrameBehavior : IFrameBehavior
    {
        const int MaxPins = 10;
        const int MaxRollsWithoutBonus = 2;
        const int MaxRollsWithBonus = 3;

        public bool IsClosed(FrameState state) =>
            HasReachedMaxRolls(state) ||
            HasNoBonusAfterTwoRolls(state);

        private bool HasNoBonusAfterTwoRolls(FrameState state)
        {
            return state.HasSecond && !BowlingRules.IsSpare(state) && !IsStrikeRoll(state.First) && !IsStrikeRoll(state.Second);
        }

        private bool IsStrikeRoll(int pins) => pins == MaxPins;

        private bool HasReachedMaxRolls(FrameState state)
        {
            return state.Count == MaxRollsWithBonus;
        }

        public int RemainingPins(FrameState state) => CalculateRemainingPins(state);

        private int CalculateRemainingPins(FrameState state)
        {
            return state.Count switch
            {
                0 => RemainingAfterZeroRolls(),

                1 => RemainingAfterFirstRoll(state),

                2 => RemainingAfterSecondRoll(state),

                3 => 0,
                _ => throw new InvalidOperationException("Invalid number of rolls in tenth frame.")
            };
        }

        private int RemainingAfterZeroRolls() => MaxPins;

        private int RemainingAfterFirstRoll(FrameState state)
        {
            return BowlingRules.IsStrike(state) ? MaxPins : MaxPins - state.First;
        }

        private int RemainingAfterSecondRoll(FrameState state)
        {
            return HasBonusRoll(state) ? MaxPins : 0;
        }

        private bool HasBonusRoll(FrameState state) =>
         BowlingRules.IsStrike(state) || BowlingRules.IsSpare(state);

        public int RemainingRolls(FrameState state) =>
            MaxAllowedRolls(state) - state.Count;

        private int MaxAllowedRolls(FrameState state) => HasBonusRoll(state)
           ? MaxRollsWithBonus
           : MaxRollsWithoutBonus;

        public void Validate(FrameState state, Roll roll)
        {
            if (IsClosed(state))
                throw new InvalidOperationException("Cannot roll in a closed frame.");

            if (roll.Pins > RemainingPins(state))
                throw new ArgumentException("Cannot knock down more pins than remaining.");
        }

    }
}
