namespace BowlingGame_Kata
{
    public class NormalFrame : Frame
    {
        private int TotalPins => _rolls.Sum();

        public bool IsStrike => _rolls.Count == 1 && IsStrikeRoll(First);

        public bool IsSpare => _rolls.Count == 2 && IsSpareRoll(First, Second);

        public override bool IsClosed => IsStrike || _rolls.Count == 2;

        public override int RemainingPins => MaxPins - TotalPins;
    }
}