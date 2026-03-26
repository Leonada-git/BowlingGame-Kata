using BowlingGame_Kata.Rolls;

namespace BowlingGame_Kata.Frames
{
    public class FrameState
    {
        private readonly List<Roll> _rolls = new();

        public IReadOnlyList<Roll> Rolls => _rolls.AsReadOnly();

        public int Count => _rolls.Count;

        public bool HasFirst => Count >= 1;
        public bool HasSecond => Count >= 2;

        public int First => HasFirst
            ? _rolls[0].Pins
            : throw new InvalidOperationException("First roll not available.");

        public int Second => HasSecond
            ? _rolls[1].Pins
            : throw new InvalidOperationException("Second roll not available.");

        public int TotalPins => _rolls.Sum(r => r.Pins);

        public void Add(Roll roll) => _rolls.Add(roll);
    }
}
