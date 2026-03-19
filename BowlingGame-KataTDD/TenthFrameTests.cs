using BowlingGame_Kata;
using FluentAssertions;

namespace BowlingGame_KataTDD
{
    public class TenthFrameTests
    {
        TenthFrame sut = new();

        [Fact]
        public void Have_ten_pins_upon_creation()
        {
            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Is_closed_when_two_rolls_are_made()
        {
            sut.AddRoll(1);

            sut.AddRoll(1);

            sut.IsClosed.Should().BeTrue();
        }

        [Fact]
        public void Strike_does_not_close_frame()
        {
            sut.AddRoll(10);

            sut.IsClosed.Should().BeFalse();
        }

        [Fact]
        public void Strike_allows_second_roll()
        {
            sut.AddRoll(10);

            var action = () => sut.AddRoll(1);

            action.Should().NotThrow();
        }

        [Fact]
        public void Strike_in_tenth_frame_allows_third_roll()
        {
            sut.AddRoll(10);
            sut.AddRoll(1);

            var action = () => sut.AddRoll(1);

            action.Should().NotThrow();
        }

        [Fact]
        public void Resets_pins_for_the_third_roll()
        {
            sut.AddRoll(10);

            sut.AddRoll(1);

            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Handles_consecutive_strikes()
        {
            sut.AddRoll(10);

            sut.AddRoll(10);

            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Allows_third_roll_after_two_strikes()
        {
            sut.AddRoll(10);
            sut.AddRoll(10);

            var action = () => sut.AddRoll(10);

            action.Should().NotThrow();
        }

        [Fact]
        public void Closes_after_three_rolls_when_strike()
        {
            sut.AddRoll(10);
            sut.AddRoll(1);

            sut.AddRoll(1);

            sut.IsClosed.Should().BeTrue();
        }

        [Fact]
        public void Remaining_pins_after_three_strikes()
        {
            sut.AddRoll(10);
            sut.AddRoll(10);

            sut.AddRoll(10);

            sut.RemainingPins.Should().Be(0);
        }

        [Fact]
        public void Resets_pins_after_strike()
        {
            sut.AddRoll(10);

            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Allows_full_pins_after_spare()
        {
            sut.AddRoll(1);

            sut.AddRoll(9);

            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Spare_in_tenth_frame_allows_third_roll()
        {
            sut.AddRoll(1);

            sut.AddRoll(9);

            var action = () => sut.AddRoll(1);

            action.Should().NotThrow();
        }

        [Fact]
        public void Closes_after_third_roll_when_spare()
        {
            sut.AddRoll(1);
            sut.AddRoll(9);

            sut.AddRoll(1);

            sut.IsClosed.Should().BeTrue();
        }

        [Fact]
        public void Closes_after_third_strike_roll_when_spare()
        {
            sut.AddRoll(1);
            sut.AddRoll(9);

            sut.AddRoll(10);

            sut.IsClosed.Should().BeTrue();
        }

        [Fact]
        public void Closes_after_two_rolls_when_not_strike_or_spare()
        {
            sut.AddRoll(1);

            sut.AddRoll(1);

            sut.IsClosed.Should().BeTrue();

        }

        [Fact]
        public void Remaining_pins_after_two_rolls_when_not_strike_or_spare()
        {
            sut.AddRoll(1);

            sut.AddRoll(1);

            sut.RemainingPins.Should().Be(0);
        }

    }
}
