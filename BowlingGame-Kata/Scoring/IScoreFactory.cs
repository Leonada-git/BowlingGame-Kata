using BowlingGame_Kata.Frames;

namespace BowlingGame_Kata.Scoring
{
    public interface IScoreFactory
    {
        IScoringBehavior Create(Frame frame);
    }
}
