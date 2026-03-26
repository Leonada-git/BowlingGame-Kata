namespace BowlingGame_Kata.Rolls
{
    public sealed class Roll
    {
        public int Pins { get; }

        public Roll(int pins)
        {
            if (pins < 0 || pins > 10)
                throw new ArgumentException("Invalid pins.");

            Pins = pins;
        }
    }
}
