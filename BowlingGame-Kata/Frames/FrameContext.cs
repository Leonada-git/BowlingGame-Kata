namespace BowlingGame_Kata.Frames
{
    public class FrameContext
    {
        public Frame Current { get; }
        public Frame? Next { get; }
        public Frame? NextNext { get; }

        public bool HasNext => Next != null;
        public bool HasNextNext => NextNext != null;

        public FrameContext(IReadOnlyList<Frame> frames, int index)
        {
            ThrowIfFramesNull(frames);

            ThrowIfIndexOutOfRange(frames, index);

            Current = frames[index];
            Next = index + 1 < frames.Count ? frames[index + 1] : null;
            NextNext = index + 2 < frames.Count ? frames[index + 2] : null;
        }

        private static void ThrowIfIndexOutOfRange(IReadOnlyList<Frame> frames, int index)
        {

            if (index < 0 || index >= frames.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the frames range.");

        }

        private static void ThrowIfFramesNull(IReadOnlyList<Frame> frames)
        {
            if (frames == null)
                throw new ArgumentNullException(nameof(frames));
        }
    }
}
