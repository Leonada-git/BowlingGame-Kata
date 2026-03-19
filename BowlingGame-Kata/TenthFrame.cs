
namespace BowlingGame_Kata
{
    public class TenthFrame : Frame
    {

        public override bool IsClosed =>
            HasCompletedThreeRolls() ||
            HasTwoRollsWithoutBonus();

        private bool HasTwoRollsWithoutBonus()
        {
            return _rolls.Count == 2 && !IsStrikeRoll(First) && !IsSpareRoll(First, Second);
        }

        private bool HasCompletedThreeRolls()
        {
            return _rolls.Count == 3;
        }

        public override int RemainingPins
        {
            get
            {
                return _rolls.Count switch
                {
                    0 => MaxPins,

                    1 => RemainingAfterFirstRoll(),

                    2 => RemainingAfterSecondRollWithBonus(),

                    3 => 0,
                    _ => throw new InvalidOperationException("Invalid number of rolls in tenth frame.")
                };
            }
        }

        private int RemainingAfterFirstRoll()
        {
            return IsStrikeRoll(First) ? MaxPins : MaxPins - First.Value;
        }

        private int RemainingAfterSecondRollWithBonus()
        {
            return HasBonusRoll() ? MaxPins : 0;
        }

        private bool HasBonusRoll()
        {
            return IsStrikeRoll(First) || IsSpareRoll(First, Second);
        }
    }
}
