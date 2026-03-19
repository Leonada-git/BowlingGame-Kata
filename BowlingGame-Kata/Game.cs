namespace BowlingGame_Kata
{
    public class Game
    {
        int score;

        IGameFrames frames;

        public Game(IGameFrames frames)
        {
            this.frames = frames;
        }

        public void Roll(int pinKnocked)
        {
            if (pinKnocked < 0)
                throw new ArgumentException("Negative numbers are not allowed.");
            if (pinKnocked > 10)
                throw new ArgumentException("Cannot exceed 10.");

            frames.Roll(pinKnocked);
            score += pinKnocked;
        }

        public int Score()
        {
            return score;
        }
    }
}