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

        public IReadOnlyList<Roll> Rolls => _state.Rolls;

        public int RemainingPins => _behavior.RemainingPins(_state);
        public int RemainingRolls => _behavior.RemainingRolls(_state);
        public bool IsClosed => _behavior.IsClosed(_state);
        public bool IsStrike => _behavior.IsStrike(_state);
        public bool IsSpare => _behavior.IsSpare(_state);

        public void AddRoll(int pins)
        {
            var roll = new Roll(pins);

            _behavior.Validate(_state, roll);
            _state.Add(roll);
        }
    }
}
