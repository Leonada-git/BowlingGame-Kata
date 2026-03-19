namespace BowlingGame_Kata
{
    public class GameFrames : IGameFrames
    {
        const int InitialFrames = 10;

        List<NormalFrame> frames;

        public int RemainingPins => CurrentFrame().RemainingPins;

        public GameFrames()
        {
            frames = new();
        }

        private NormalFrame CurrentFrame()
        {
            if (frames.LastOrDefault() is not { IsClosed: false })
            {
                frames.Add(new NormalFrame());
            }

            return frames.Last();
        }

        public int FramesLeft()
        {
            int completedFrames = frames.Count(f => f.IsClosed);
            return InitialFrames - completedFrames;
        }

        public void Roll(int pins)
        {
            if (frames.Count == 10 && frames.Last().IsClosed)
                throw new InvalidOperationException("Cannot exceed 10 frames.");

            CurrentFrame().AddRoll(pins);

        }

    }
}
