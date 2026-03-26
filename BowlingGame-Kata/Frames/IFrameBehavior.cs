using BowlingGame_Kata.Rolls;

namespace BowlingGame_Kata.Frames
{
    public interface IFrameBehavior
    {
        int RemainingPins(FrameState state);
        int RemainingRolls(FrameState state);
        bool IsClosed(FrameState state);

        void Validate(FrameState state, Roll roll);
    }
}
