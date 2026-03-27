using BowlingGame_Kata.Common;
using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public class ScoreFactory : IScoreFactory
    {
        public IScoringBehavior Create(Frame frame)
        {
            return frame.RollType switch
            {
                RollType.Normal => new NormalScoringBehavior(),
                RollType.Strike => new StrikeScoringBehavior(),
                RollType.Spare => new SpareScoringBehavior(),
                _ => throw new InvalidOperationException("Unknown roll type")
            };
        }
    }
}
