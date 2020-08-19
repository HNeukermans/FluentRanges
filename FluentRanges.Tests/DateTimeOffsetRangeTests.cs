using System;
using FluentAssertions;
using Xunit;

namespace FluentRanges.Tests
{
    public class DateTimeOffsetRangeTests
    {
        protected DateTimeOffset Now;

        public DateTimeOffsetRangeTests()
        {
            Now = DateTime.Now;
            OneDayAfterNow = Now.AddDays(1);
            OneDayBeforeNow = Now.AddDays(-1);
        }

        public DateTimeOffset OneDayAfterNow { get; set; }
        public DateTimeOffset OneDayBeforeNow { get; set; }

        [Fact]
        public void When_Start_Occurs_After_End_Constructor_Should_Throw()
        {
            Action a = () => new DateTimeOffsetRange(startsAt: Now.Add(TimeSpan.FromSeconds(1)), endsAt: Now);
            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void When_Duration_IsNegative_Constructor_Should_Throw()
        {
            Action a = () => new DateTimeOffsetRange(Now.Add(TimeSpan.FromSeconds(1)), duration: TimeSpan.FromMinutes(-1));
            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Construct()
        {
            var d = new DateTimeOffsetRange(Now, Now.AddDays(1));
            d.Duration.Should().BeCloseTo(TimeSpan.FromDays(1), TimeSpan.FromMilliseconds(1));
        }

        [Fact]
        public void When_Start_Occurs_At_End_Should_Construct()
        {
            var d = new DateTimeOffsetRange(startsAt: Now, endsAt: Now);
            d.Duration.Should().Be(TimeSpan.Zero);
        }

        [Fact]
        public void When_Duration_Is_Positive_Should_Construct()
        {
            var d = new DateTimeOffsetRange(Now, duration: TimeSpan.FromDays(1));
            d.Duration.Should().BeCloseTo(TimeSpan.FromDays(1), TimeSpan.FromMilliseconds(1));
        }

        [Fact]
        public void Should_Have_Duration()
        {
            var d = new DateTimeOffsetRange(Now, OneDayAfterNow);
            d.Duration.Should().Be(TimeSpan.FromDays(1));
        }

        [Fact]
        public void Should_Happen_After_Range()
        {
            var d = new DateTimeOffsetRange(Now, OneDayAfterNow);
            d.HappenedAfter(OneDayAfterNow.AddHours(1)).Should().BeTrue();
        }

        [Fact]
        public void Should_Happen_Before_Range()
        {
            var d = new DateTimeOffsetRange(Now, OneDayAfterNow);
            d.HappenedBefore(OneDayBeforeNow).Should().BeTrue();
        }

        [Fact]
        public void Should_BeEqual()
        {
            var d1 = new DateTimeOffsetRange(Now, Now.AddDays(1));
            var d2 = new DateTimeOffsetRange(Now, Now.AddDays(1));
            var d3 = new DateTimeOffsetRange(Now, Now.AddDays(2));
            d1.Equals(d2).Should().BeTrue();
            d1.Equals(d3).Should().BeFalse();
        }

        [Fact]
        public void Should_Happen_During()
        {
            var d = new DateTimeOffsetRange(Now, OneDayAfterNow);
            d.HappenedDuring(Now.AddHours(1)).Should().BeTrue();
            d.HappenedDuring(Now).Should().BeTrue(); // date at begin of range is included
            d.HappenedDuring(OneDayAfterNow).Should().BeTrue(); // date at end of range is included
        }

        [Fact]
        public void Should_Intersect()
        {
            var d = new DateTimeOffsetRange(Now, OneDayAfterNow);

            d.Intersects(new DateTimeOffsetRange(Now, OneDayAfterNow)).Should().BeTrue();
            d.Intersects(new DateTimeOffsetRange(Now.AddHours(-1), OneDayAfterNow.AddHours(-1))).Should().BeTrue();
            d.Intersects(new DateTimeOffsetRange(Now.AddHours(1), OneDayAfterNow.AddHours(1))).Should().BeTrue();
        }

        [Fact]
        public void Should_Intersection()
        {
            var d = new DateTimeOffsetRange(Now, OneDayAfterNow);

            d.Intersection(new DateTimeOffsetRange(Now, OneDayAfterNow)).Should().Be(new DateTimeOffsetRange(Now, OneDayAfterNow));
            d.Intersection(new DateTimeOffsetRange(Now.AddHours(1), OneDayAfterNow.AddHours(-1))).Should().Be(new DateTimeOffsetRange(Now.AddHours(1), OneDayAfterNow.AddHours(-1)));
            d.Intersection(new DateTimeOffsetRange(Now.AddHours(-1), OneDayAfterNow.AddHours(1))).Should().Be(new DateTimeOffsetRange(Now, OneDayAfterNow));
        }
    }
}