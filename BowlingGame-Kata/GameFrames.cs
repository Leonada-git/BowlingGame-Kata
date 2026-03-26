using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata
{
    public class GameFrames : IGameFrames
    {
        const int TotalFrames = 10;

        IFrameFactory _frameFactory;
        private readonly List<Frame> _frames = new();

        public IReadOnlyList<Frame> Frames => _frames.AsReadOnly();

        public GameFrames(IFrameFactory frameFactory)
        {
            _frameFactory = frameFactory ?? throw new ArgumentNullException(nameof(frameFactory));
        }

        public int RemainingPins => GetCurrentFrame().RemainingPins;
        public int RemainingRolls => GetCurrentFrame().RemainingRolls;

        public int RemainingFrames => TotalFrames - _frames.Count(f => f.IsClosed);

        private Frame GetCurrentFrame()
        {
            EnsureFrameExists();

            return _frames.Last();
        }

        private bool HasOpenFrame()
        {
            return _frames.LastOrDefault()?.IsClosed == false;
        }

        private void EnsureFrameExists()
        {
            if (!HasOpenFrame() && _frames.Count < TotalFrames)
            {
                _frames.Add(CreateNextFrame());
            }
        }

        private Frame CreateNextFrame()
        {
            return _frameFactory.Create(_frames.Count);
        }

        public void Roll(int pins)
        {
            if (_frames.Count == TotalFrames && _frames.Last().IsClosed)
                throw new InvalidOperationException("Cannot exceed 10 frames.");

            GetCurrentFrame().AddRoll(pins);
        }

    }
}
