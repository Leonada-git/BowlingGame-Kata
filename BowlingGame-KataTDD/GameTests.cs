using BowlingGame_Kata;
using BowlingGame_Kata.Frames;
using FluentAssertions;


namespace BowlingGame_KataTDD
{
    public class GameTests
    {
        Game sut = new(new GameFrames(new FrameFactory()));

        [Fact]
        public void Score_is_zero_upon_creation()
        {
            sut.Score().Should().Be(0);
        }

        [Fact]
        public void Throws_when_number_of_pins_is_negative()
        {
            var action = () => sut.Roll(-1);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Negative numbers are not allowed.");
        }

        [Fact]
        public void Throws_when_number_of_pins_exceeds_ten()
        {
            var action = () => sut.Roll(11);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Cannot exceed 10.");
        }

        [Fact]
        public void Score_is_one_when_roll_knocks_one_pin()
        {
            sut.Roll(1);

            sut.Score().Should().Be(1);
        }

        [Fact]
        public void Score_is_the_number_of_pins_knocked_down()
        {
            sut.Roll(5);

            sut.Score().Should().Be(5);
        }

        [Fact]
        public void Score_accumulates_when_multiple_rolls_are_made()
        {
            sut.Roll(1);
            sut.Roll(1);

            sut.Score().Should().Be(2);
        }

    }
}
