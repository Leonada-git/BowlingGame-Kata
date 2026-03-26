namespace BowlingGame_Kata
{
    public abstract class Frame
    {
        protected const int MaxPins = 10;

        private readonly List<int> _rolls = new();

        protected IReadOnlyList<int> RollsInternal => _rolls;

        protected bool HasFirstRoll => _rolls.Count >= 1;
        protected bool HasSecondRoll => _rolls.Count >= 2;
        protected int First
        {
            get
            {
                if (!HasFirstRoll)
                    throw new InvalidOperationException("First roll not available.");
                return _rolls[0];
            }
        }

        protected int Second
        {
            get
            {
                if (!HasSecondRoll)
                    throw new InvalidOperationException("Second roll not available.");
                return _rolls[1];
            }
        }

        public abstract int RemainingPins { get; }
        public abstract int RemainingRolls { get; }

        public abstract bool IsClosed { get; }

        public IReadOnlyList<int> Rolls => _rolls.AsReadOnly();

        protected bool IsStrikeRoll(int pins) => pins == MaxPins;

        protected bool IsSpareRoll(int first, int second) => first + second == MaxPins;

        protected abstract bool HasBonusRoll();

        public virtual void AddRoll(int pins)
        {
            ValidateRoll(pins);

            _rolls.Add(pins);
        }

        protected virtual void ValidateRoll(int pins)
        {
            if (IsClosed)
                throw new InvalidOperationException("Cannot roll in a closed frame.");

            if (pins < 0 || pins > MaxPins)
                throw new ArgumentException("Invalid number of pins.");

            if (pins > RemainingPins)
                throw new ArgumentException("Cannot knock down more pins than remaining.");
        }
    }
}
