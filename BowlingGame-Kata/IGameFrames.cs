using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata
{
    public interface IGameFrames
    {
        IReadOnlyList<Frame> Frames { get; }
        int RemainingPins { get; }
        int RemainingRolls { get; }
        int RemainingFrames { get; }

        void Roll(int pins);
    }
}