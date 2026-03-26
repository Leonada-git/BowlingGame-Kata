namespace BowlingGame_Kata
{
    public interface IGameFrames
    {
        public int RemainingPins { get; }
        public int RemainingRolls { get; }
        int RemainingFrames { get; }

        void Roll(int pins);
    }
}