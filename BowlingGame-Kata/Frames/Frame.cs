using BowlingGame_Kata.Common;
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

        public int Score => Rolls.Sum(r => r.Pins);

        public int SumStrikeBonusRolls => Rolls.Take(2).Sum(r => r.Pins);

        public int FirstRoll => _state.First;

        public int SecondRoll => _state.Second;

        public bool HasSecondRoll => _state.HasSecond;

        public bool NeedsExtraRollFromNextFrame => !HasSecondRoll;

        public int RemainingRolls => _behavior.RemainingRolls(_state);

        public int RemainingPins => _behavior.RemainingPins(_state);

        public RollType RollType =>
            BowlingRules.IsStrike(_state) ? RollType.Strike :
            BowlingRules.IsSpare(_state) ? RollType.Spare :
            RollType.Normal;

        public bool IsClosed => _behavior.IsClosed(_state);

        public void AddRoll(int pins)
        {
            var roll = new Roll(pins);

            _behavior.Validate(_state, roll);
            _state.Add(roll);
        }



    }
}
