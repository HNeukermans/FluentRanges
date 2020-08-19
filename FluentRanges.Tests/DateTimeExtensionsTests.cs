using System;
using FluentAssertions;
using FluentRanges.Extensions;
using Xunit;

namespace FluentRanges.Tests
{
    public class DateTimeExtensionsTests
    {
        public DateTimeExtensionsTests()
        {
            Now24HRange = new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(1));
        }
        
        public DateTimeRange Now24HRange { get; set; }

        [Fact]
        public void HappenedXxx_With_NullArgument_Should_Throw()
        {
            Action a = () => DateTime.Now.AddDays(2).HappenedAfter(null);
            a.Should().Throw<ArgumentException>();
            a = () => DateTime.Now.AddDays(2).HappenedBefore(null);
            a.Should().Throw<ArgumentException>();
            a = () => DateTime.Now.AddDays(2).HappenedDuring(null);
            a.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void HappenedXXX_Should_Be_True()
        {
            DateTime.Now.AddHours(2).HappenedDuring(Now24HRange).Should().BeTrue();
            DateTime.Now.AddDays(2).HappenedAfter(Now24HRange).Should().BeTrue();
            DateTime.Now.AddHours(-2).HappenedBefore(Now24HRange).Should().BeTrue();
        }

        [Fact]
        public void HappenedXXX_Should_Be_False()
        {
            DateTime.Now.AddDays(2).HappenedDuring(Now24HRange).Should().BeFalse();
            DateTime.Now.AddHours(-2).HappenedDuring(Now24HRange).Should().BeFalse();

            DateTime.Now.AddDays(2).HappenedBefore(Now24HRange).Should().BeFalse();
            DateTime.Now.AddHours(2).HappenedBefore(Now24HRange).Should().BeFalse();

            DateTime.Now.AddDays(-1).HappenedAfter(Now24HRange).Should().BeFalse();
            DateTime.Now.AddHours(2).HappenedAfter(Now24HRange).Should().BeFalse();
        }
    }
}