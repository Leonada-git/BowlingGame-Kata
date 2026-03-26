using BowlingGame_Kata;
using BowlingGame_Kata.Frames;
using FluentAssertions;

namespace BowlingGame_KataTDD
{
    public class GameFramesTests
    {
        GameFrames sut = new(new FrameFactory());

        [Fact]
        public void Has_ten_frames_upon_creation()
        {
            sut.RemainingFrames.Should().Be(10);
        }

        [Fact]
        public void Has_two_rolls_upon_creation()
        {
            sut.RemainingRolls.Should().Be(2);
        }

        [Fact]
        public void Has_ten_remaining_pins_upon_creation()
        {
            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Advances_frame_when_current_frame_is_closed()
        {
            sut.Roll(1);
            sut.Roll(1);

            sut.RemainingFrames.Should().Be(9);
        }

        [Fact]
        public void Advances_frame_after_strike()
        {
            sut.Roll(10);

            sut.RemainingFrames.Should().Be(9);
        }

        [Fact]
        public void Does_not_advance_frame_when_frame_is_not_closed()
        {
            sut.Roll(1);

            sut.RemainingRolls.Should().Be(1);
            sut.RemainingFrames.Should().Be(10);
        }

        [Fact]
        public void Tracks_multiple_closed_frames()
        {
            RollFrames(3);

            sut.RemainingFrames.Should().Be(7);
        }

        [Fact]
        public void Tracks_ten_completed_frames()
        {
            RollFrames(10);

            sut.RemainingFrames.Should().Be(0);
            sut.RemainingRolls.Should().Be(0);
            sut.RemainingPins.Should().Be(0);
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
        public void Throws_when_roll_is_made_after_ten_frames_are_completed()
        {
            RollFrames(10);

            var action = () => sut.Roll(1);

            action.Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot exceed 10 frames.");
        }

        [Fact]
        public void Strike_in_thenth_frame_give_two_bonus_rolls()
        {
            RollFrames(9);

            sut.Roll(10);

            sut.RemainingRolls.Should().Be(2);
            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Spare_in_thenth_frame_give_a_bonus_roll()
        {
            RollFrames(9);
            sut.Roll(1);

            sut.Roll(9);

            sut.RemainingRolls.Should().Be(1);
            sut.RemainingPins.Should().Be(10);
        }

    }
}
