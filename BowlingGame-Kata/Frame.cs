namespace BowlingGame_Kata
{
    public abstract class Frame
    {
        protected const int MaxPins = 10;

        protected readonly List<int> _rolls = new();
        protected int? First => _rolls.Count > 0 ? _rolls[0] : null;
        protected int? Second => _rolls.Count > 1 ? _rolls[1] : null;
        public abstract int RemainingPins { get; }

        public abstract bool IsClosed { get; }

        protected bool IsStrikeRoll(int? pins) => pins == MaxPins;

        protected bool IsSpareRoll(int? first, int? second) => first + second == MaxPins;

        public IReadOnlyList<int> Rolls => _rolls.AsReadOnly();

        public virtual void AddRoll(int pins)
        {
            if (IsClosed)
                throw new InvalidOperationException("Cannot roll in a closed frame.");

            if (pins < 0 || pins > MaxPins)
                throw new ArgumentException("Invalid number of pins.");

            if (pins > RemainingPins)
                throw new ArgumentException("Cannot knock down more pins than remaining.");

            _rolls.Add(pins);
        }
    }
}
