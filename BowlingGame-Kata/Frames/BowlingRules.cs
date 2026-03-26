namespace BowlingGame_Kata.Frames
{
    public static class BowlingRules
    {
        public const int MaxPins = 10;

        public static bool IsStrike(FrameState s) =>
            s.HasFirst && s.First == MaxPins;

        public static bool IsSpare(FrameState s) =>
            s.HasSecond && s.First + s.Second == MaxPins;
    }
}
