using System;
using FluentAssertions;
using Xunit;

namespace FluentRanges.Tests
{
    public class IntRangeTests
    {

        public IntRangeTests()
        {
        }

        [Fact]
        public void When_Lower_Is_Greater_Then_Upper_Constructor_Should_Throw()
        {
            Action a = () => new IntRange(lower: 55, upper: 50);
            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Width_Should_Be_Difference_Between_Bounds()
        {
            var d = new IntRange(10, 50);
            d.Width.Should().Be(40);
        }

        [Fact]
        public void Should_BeEqual()
        {
            var d1 = new IntRange(10,50);
            var d2 = new IntRange(10,50);
            var d3 = new IntRange(20,50);
            d1.Equals(d2).Should().BeTrue();
            d1.Equals(d3).Should().BeFalse();
        }


        [Fact]
        public void When_Lower_And_Upper_Are_Equal_Width_Is_Zero()
        {
            var d = new IntRange(10,10);
            d.Width.Should().Be(0);
        }
       
        [Fact]
        public void Should_Be_Greater_Then()
        {
            var d = new IntRange(10, 50);
            d.IsGreaterThen(60).Should().BeTrue();
        }

        [Fact]
        public void Should_Be_Lesser_Then()
        {
            var d = new IntRange(10, 50);
            d.IsSmallerThen(5).Should().BeTrue();
        }

        [Fact]
        public void Should_Intersect()
        {
            var d = new IntRange(10, 50);

            d.Intersects(new IntRange(10, 50)).Should().BeTrue();
            d.Intersects(new IntRange(20, 40)).Should().BeTrue();
            d.Intersects(new IntRange(40,100)).Should().BeTrue(); 
            d.Intersects(new IntRange(0,10)).Should().BeFalse(); // adjacent does not intersect
            d.Intersects(new IntRange(60,100)).Should().BeFalse();
            d.Intersects(new IntRange(0,20)).Should().BeTrue();
        }

        [Fact]
        public void Should_Intersection()
        {
            var d = new IntRange(10, 50);

            d.Intersection(new IntRange(10, 50)).Should().Be(new IntRange(10, 50));
            d.Intersection(new IntRange(20, 40)).Should().Be(new IntRange(20, 40));
            d.Intersection(new IntRange(40, 100)).Should().Be(new IntRange(40, 50));
            d.Intersection(new IntRange(0, 10)).Should().Be(null); // adjacent does not intersect
            d.Intersection(new IntRange(60, 100)).Should().Be(null);
            d.Intersection(new IntRange(0, 20)).Should().Be(new IntRange(10, 20));
        }


        [Fact]
        public void Should_Be_In_Range()
        {
            var d = new IntRange(10,50);
            d.IsInRange(10).Should().BeTrue();
            d.IsInRange(50).Should().BeTrue();
            d.IsInRange(25).Should().BeTrue();
            d.IsInRange(5).Should().BeFalse();
            d.IsInRange(60).Should().BeFalse();
        }
    }
}