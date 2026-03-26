using BowlingGame_Kata.Frames;
using FluentAssertions;

namespace BowlingGame_KataTDD
{
    public class TenthFrameTests
    {
        Frame sut = new(new TenthFrameBehavior());

        [Fact]
        public void Has_two_rolls_upon_creation()
        {
            sut.RemainingRolls.Should().Be(2);
        }

        [Fact]
        public void Has_ten_pins_upon_creation()
        {
            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Remaining_rolls_is_one_after_a_roll_is_made()
        {
            sut.AddRoll(1);

            sut.RemainingRolls.Should().Be(1);
        }

        [Fact]
        public void Remaining_rolls_is_zero_after_two_rolls_are_made()
        {
            sut.AddRoll(1);

            sut.AddRoll(1);

            sut.RemainingRolls.Should().Be(0);
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
        public void Strike_gives_two_bonus_rolls()
        {
            sut.AddRoll(10);

            sut.RemainingRolls.Should().Be(2);
        }

        [Fact]
        public void Strike_allows_second_roll()
        {
            sut.AddRoll(10);

            var action = () => sut.AddRoll(1);

            action.Should().NotThrow();
        }

        [Fact]
        public void Strike_allows_third_roll()
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

            var action = () => sut.AddRoll(1);

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
        public void Remaining_rolls_after_third_roll_when_strike()
        {
            sut.AddRoll(10);
            sut.AddRoll(9);

            sut.AddRoll(1);

            sut.RemainingRolls.Should().Be(0);
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
        public void Resets_pins_after_spare()
        {
            sut.AddRoll(1);

            sut.AddRoll(9);

            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Spare_gives_a_bonus_roll()
        {
            sut.AddRoll(1);

            sut.AddRoll(9);

            sut.RemainingRolls.Should().Be(1);
        }

        [Fact]
        public void Spare_allows_third_roll()
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
        public void Remaining_rolls_after_third_roll_when_spare()
        {
            sut.AddRoll(1);
            sut.AddRoll(9);

            sut.AddRoll(1);

            sut.RemainingRolls.Should().Be(0);
        }

        [Fact]
        public void Remaining_pins_after_third_roll_when_spare()
        {
            sut.AddRoll(1);
            sut.AddRoll(9);

            sut.AddRoll(1);

            sut.RemainingPins.Should().Be(0);
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
        public void Remaining_rolls_after_two_rolls_when_not_strike_or_spare()
        {
            sut.AddRoll(1);

            sut.AddRoll(1);

            sut.RemainingRolls.Should().Be(0);
        }

        [Fact]
        public void Remaining_pins_after_two_rolls_when_not_strike_or_spare()
        {
            sut.AddRoll(1);

            sut.AddRoll(1);

            sut.RemainingPins.Should().Be(0);
        }

        [Fact]
        public void Throws_when_roll_after_frame_is_closed()
        {
            sut.AddRoll(1);
            sut.AddRoll(1);

            var action = () => sut.AddRoll(1);

            action.Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot roll in a closed frame.");
        }

        [Fact]
        public void Throws_when_number_of_pins_is_negative()
        {
            var action = () => sut.AddRoll(-1);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Invalid pins.");
        }

        [Fact]
        public void Throws_when_number_of_pins_exceeds_ten()
        {
            var action = () => sut.AddRoll(11);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Invalid pins.");
        }

        [Fact]
        public void Throws_when_number_of_pins_exceeds_remaining_pins()
        {
            sut.AddRoll(1);

            var action = () => sut.AddRoll(10);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Cannot knock down more pins than remaining.");
        }
    }
}
