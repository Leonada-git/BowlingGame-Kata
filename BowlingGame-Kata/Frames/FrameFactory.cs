
namespace BowlingGame_Kata.Frames
{
    public class FrameFactory : IFrameFactory
    {
        const int TotalFrames = 10;
        const int LastFrameIndex = TotalFrames - 1;

        public Frame Create(int index)
        {
            return index < LastFrameIndex
                ? new NormalFrame()
                : new TenthFrame();
        }
    }
}
