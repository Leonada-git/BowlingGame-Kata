using BowlingGame_Kata;
using FluentAssertions;

namespace BowlingGame_KataTDD
{
    public class GameFramesTests
    {
        GameFrames sut = new();

        [Fact]
        public void Has_ten_frames_upon_creation()
        {
            sut.FramesLeft().Should().Be(10);
        }

        [Fact]
        public void Has_ten_remaining_pins_upon_creation()
        {
            sut.RemainingPins.Should().Be(10);
        }

        [Fact]
        public void Advances_frame_when_current_frame_is_completed()
        {
            sut.Roll(1);
            sut.Roll(1);

            sut.Roll(1);

            sut.FramesLeft().Should().Be(9);
            sut.RemainingPins.Should().Be(9);
        }

        [Fact]
        public void Advances_frame_after_strike()
        {
            sut.Roll(10);

            sut.FramesLeft().Should().Be(9);
        }

        [Fact]
        public void Does_not_advance_frame_when_frame_is_not_completed()
        {
            sut.Roll(1);

            sut.FramesLeft().Should().Be(10);
        }

        [Fact]
        public void Tracks_multiple_completed_frames()
        {
            RollFrames(3);

            sut.FramesLeft().Should().Be(7);
        }

        [Fact]
        public void Tracks_ten_completed_frames()
        {
            RollFrames(10);

            sut.FramesLeft().Should().Be(0);
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
        public void Throws_when_roll_is_made_after_ten_strikes_are_completed()
        {
            RollStrikes(10);

            var action = () => sut.Roll(1);

            action.Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot exceed 10 frames.");
        }

        private void RollStrikes(int pins)
        {
            for (int i = 0; i < pins; i++)
            {
                sut.Roll(10);
            }
        }

    }
}
