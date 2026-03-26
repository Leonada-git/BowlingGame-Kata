namespace BowlingGame_Kata.Scoring
{
    public interface IScoreCalculator
    {
        int CalculateTotalScore(IGameFrames frames);
    }
}
