using BowlingGame_Kata.Rolls;

namespace BowlingGame_Kata.Frames
{
    public class NormalFrameBehavior : IFrameBehavior
    {
        private const int MaxPins = 10;
        private const int MaxRolls = 2;

        public bool IsClosed(FrameState state)
        {
            return IsStrike(state) || state.Count == MaxRolls;
        }

        public int RemainingPins(FrameState state)
        {
            if (IsClosed(state)) return 0;
            return MaxPins - state.TotalPins;
        }

        public int RemainingRolls(FrameState state)
        {
            if (IsStrike(state) || IsSpare(state)) return 0;
            return MaxRolls - state.Count;
        }

        public void Validate(FrameState state, Roll roll)
        {
            if (IsClosed(state))
                throw new InvalidOperationException("Cannot roll in a closed frame.");

            if (roll.Pins > RemainingPins(state))
                throw new ArgumentException("Cannot knock down more pins than remaining.");
        }

        public bool IsStrike(FrameState s) =>
            s.HasFirst && s.First == MaxPins;

        public bool IsSpare(FrameState s) =>
            s.HasSecond && s.First + s.Second == MaxPins;
    }
}
