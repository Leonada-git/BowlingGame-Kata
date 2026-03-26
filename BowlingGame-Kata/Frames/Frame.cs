using BowlingGame_Kata.Rolls;

namespace BowlingGame_Kata.Frames
{
    public class Frame
    {
        private readonly FrameState _state = new();
        private readonly IFrameBehavior _behavior;

        public Frame(IFrameBehavior behavior)
        {
            _behavior = behavior ?? throw new ArgumentNullException(nameof(behavior));
        }

        public Roll Roll(int index) => _state.GetRoll(index);

        public int RemainingRolls => _behavior.RemainingRolls(_state);
        public int RemainingPins => _behavior.RemainingPins(_state);
        public bool IsStrike => BowlingRules.IsStrike(_state);
        public bool IsSpare => BowlingRules.IsSpare(_state);
        public bool IsClosed => _behavior.IsClosed(_state);

        public void AddRoll(int pins)
        {
            var roll = new Roll(pins);

            _behavior.Validate(_state, roll);
            _state.Add(roll);
        }
    }
}
