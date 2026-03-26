using BowlingGame_Kata;
using FluentAssertions;

namespace BowlingGame_KataTDD
{
    public class NormalFrameTests
    {
        NormalFrame sut = new();

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
        public void Remaining_pins_after_strikes()
        {
            sut.AddRoll(10);

            sut.RemainingPins.Should().Be(0);
        }

        [Fact]
        public void Remaining_pins_after_spare()
        {
            sut.AddRoll(1);

            sut.AddRoll(9);

            sut.RemainingPins.Should().Be(0);
        }

        [Fact]
        public void Remaining_pins_after_two_rolls_when_not_strike_or_spare()
        {
            sut.AddRoll(1);

            sut.AddRoll(1);

            sut.RemainingPins.Should().Be(0);
        }

        [Fact]
        public void Is_spare_when_two_rolls_sum_to_ten()
        {
            sut.AddRoll(1);

            sut.AddRoll(9);

            sut.IsSpare.Should().BeTrue();
        }

        [Fact]
        public void Spare_closes_frame()
        {
            sut.AddRoll(1);

            sut.AddRoll(9);

            sut.IsClosed.Should().BeTrue();
        }

        [Fact]
        public void Remaining_rolls_is_zero_when_spare()
        {
            sut.AddRoll(1);

            sut.AddRoll(9);

            sut.RemainingRolls.Should().Be(0);
        }

        [Fact]
        public void Is_strike_when_ten_pins_are_knocked_down_on_first_roll()
        {
            sut.AddRoll(10);

            sut.IsStrike.Should().BeTrue();
        }

        [Fact]
        public void Remaining_rolls_is_zero_when_strike()
        {
            sut.AddRoll(10);

            sut.RemainingRolls.Should().Be(0);
        }

        [Fact]
        public void Strike_closes_frame()
        {
            sut.AddRoll(10);

            sut.IsClosed.Should().BeTrue();
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
                .WithMessage("Invalid number of pins.");
        }

        [Fact]
        public void Throws_when_number_of_pins_exceeds_ten()
        {
            var action = () => sut.AddRoll(11);

            action.Should().Throw<ArgumentException>()
                .WithMessage("Invalid number of pins.");
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
