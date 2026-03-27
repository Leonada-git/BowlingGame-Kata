using BowlingGame_Kata;
using BowlingGame_Kata.Frames;
using BowlingGame_Kata.Scoring;
using FluentAssertions;


namespace BowlingGame_KataTDD
{
    public class GameTests
    {
        Game sut = new(new GameFrames(new FrameFactory()), new ScoreCalculator(new ScoreFactory()));

        [Fact]
        public void Score_is_zero_upon_creation()
        {
            sut.Score().Should().Be(0);
        }

        [Fact]
        public void Throws_when_rolls_negative_number_of_pins()
        {
            var action = () => sut.Roll(-1);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Negative numbers are not allowed.");
        }

        [Fact]
        public void Throws_when_rolls_past_ten_pins()
        {
            var action = () => sut.Roll(11);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Cannot exceed 10.");
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        [InlineData(7, 7)]
        public void Score_is_the_number_of_pins_knocked_down(int pins, int expectedScore)
        {
            sut.Roll(pins);

            sut.Score().Should().Be(expectedScore);
        }

        [Fact]
        public void Score_accumulates_when_multiple_rolls_are_made()
        {
            sut.Roll(1);
            sut.Roll(1);

            sut.Roll(1);

            sut.Score().Should().Be(3);
        }

        [Fact]
        public void Stirke_score_is_ten_plus_next_two_rolls()
        {
            sut.Roll(10);
            sut.Roll(1);

            sut.Roll(1);

            sut.Score().Should().Be(14);
        }

        [Fact]
        public void Strike_score_is_ten_plus_next_two_rolls_if_exists()
        {
            sut.Roll(10);

            sut.Roll(1);

            sut.Score().Should().Be(12);
        }

        [Fact]
        public void Spare_score_is_ten_plus_next_roll()
        {
            sut.Roll(1);
            sut.Roll(9);

            sut.Roll(1);

            sut.Score().Should().Be(12);
        }

        [Fact]
        public void Spare_score_is_ten_plus_next_roll_if_exists()
        {
            sut.Roll(1);

            sut.Roll(9);

            sut.Score().Should().Be(10);
        }

        [Fact]
        public void Tracks_multiple_frames()
        {
            RollFrames(3);

            sut.Score().Should().Be(6);
        }

        private void RollFrames(int roll)
        {
            for (int i = 0; i < roll; i++)
            {
                sut.Roll(1);
                sut.Roll(1);
            }
        }

        [Fact]
        public void Tracks_multiple_Strike_frames()
        {
            RollStrikes(3);

            sut.Score().Should().Be(60);
        }

        private void RollStrikes(int roll)
        {
            for (int i = 0; i < roll; i++)
            {
                sut.Roll(10);
            }
        }

        [Fact]
        public void Tracks_multiple_Spare_frames()
        {
            RollSpares(3);

            sut.Score().Should().Be(32);
        }

        private void RollSpares(int roll)
        {
            for (int i = 0; i < roll; i++)
            {
                sut.Roll(1);
                sut.Roll(9);
            }
        }

        [Fact]
        public void Score_of_prefect_game_is_300()
        {
            RollStrikes(12);

            sut.Score().Should().Be(300);
        }

        [Fact]
        public void Full_game_of_spares_scores_110()
        {
            RollSpares(10);

            sut.Roll(1);

            sut.Score().Should().Be(110);
        }
    }
}
