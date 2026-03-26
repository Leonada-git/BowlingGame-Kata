using BowlingGame_Kata.Rolls;

namespace BowlingGame_Kata.Frames
{
    public interface IFrameBehavior
    {
        bool IsStrike(FrameState state);
        bool IsSpare(FrameState state);
        int RemainingPins(FrameState state);
        int RemainingRolls(FrameState state);
        bool IsClosed(FrameState state);

        void Validate(FrameState state, Roll roll);
    }
}
