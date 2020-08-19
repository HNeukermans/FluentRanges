using System;
using FluentAssertions;
using FluentRanges.Extensions;
using Xunit;

namespace FluentRanges.Tests
{
    public class DateTimeOffsetExtensionsTests
    {
        public DateTimeOffsetExtensionsTests()
        {
            Now24HRange = new DateTimeOffsetRange(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(1));
        }

        public DateTimeOffsetRange Now24HRange { get; set; }

        [Fact]
        public void HappenedXxx_With_NullArgument_Should_Throw()
        {
            Action a = () => DateTimeOffset.Now.AddDays(2).HappenedAfter(null);
            a.Should().Throw<ArgumentException>();
            a = () => DateTimeOffset.Now.AddDays(2).HappenedBefore(null);
            a.Should().Throw<ArgumentException>();
            a = () => DateTimeOffset.Now.AddDays(2).HappenedDuring(null);
            a.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void HappenXXX_Should_Be_True()
        {
            DateTimeOffset.Now.AddHours(2).HappenedDuring(Now24HRange).Should().BeTrue();
            DateTimeOffset.Now.AddDays(2).HappenedAfter(Now24HRange).Should().BeTrue();
            DateTimeOffset.Now.AddHours(-2).HappenedBefore(Now24HRange).Should().BeTrue();
        }

        [Fact]
        public void HappenXXX_Should_Be_False()
        {
            DateTimeOffset.Now.AddDays(2).HappenedDuring(Now24HRange).Should().BeFalse();
            DateTimeOffset.Now.AddHours(-2).HappenedDuring(Now24HRange).Should().BeFalse();

            DateTimeOffset.Now.AddDays(2).HappenedBefore(Now24HRange).Should().BeFalse();
            DateTimeOffset.Now.AddHours(2).HappenedBefore(Now24HRange).Should().BeFalse();

            DateTimeOffset.Now.AddDays(-1).HappenedAfter(Now24HRange).Should().BeFalse();
            DateTimeOffset.Now.AddHours(2).HappenedAfter(Now24HRange).Should().BeFalse();
        }
    }
}