using System;
using System.Resources;

namespace FluentRanges
{
    public class IntRange : IEquatable<IntRange>
    {
        /// <summary>
        /// Creates an instance of type IntRange given a lower and upper bound
        /// </summary>
        /// <param name="lower">The lower bound of the range</param>
        /// <param name="upper">The upper bound of the range</param>
        public IntRange(int lower, int upper)
        {
            if (lower > upper) throw new ArgumentOutOfRangeException("Failed to create instance of type IntRange.Lower bound can not be greater then Upper bound.");
            Lower = lower;
            Upper = upper;
        }

        public int Lower { get; }
        public int Upper { get; }

        public int Width => Upper - Lower;

        /// <summary>
        ///     Evaluates if a given value is greater then the upper bound
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsGreaterThen(int value)
        {
            return value > Upper;
        }

        /// <summary>
        ///     Evaluates if a given value is smaller then the lower bound
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsSmallerThen(int value)
        {
            return value < Lower;
        }
        
        /// <summary>
        ///     Evaluates if a given value is in range
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsInRange(int value)
        {
            return value >= Lower && value <= Upper;
        }

        /// <summary>
        ///     Evaluates if a given range intersect/overlaps the current range instance
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool Intersects(IntRange range)
        {
            if (range == null) throw new ArgumentNullException(nameof(range));
            return range.Upper > Lower && range.Lower < Upper;
        }

        /// <summary>
        ///     Given a range calculates the intersect with the current range instance.
        ///     Returns null in case the given range does not intersect.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public IntRange Intersection(IntRange range)
        {
            if (range == null) throw new ArgumentNullException(nameof(range));
            if (!Intersects(range)) return null;
            var highestLow = Math.Max(Lower, range.Lower);
            var lowestHigh = Math.Min(Upper, range.Upper);
            return new IntRange(highestLow, lowestHigh);
        }

        public bool Equals(IntRange other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Lower == other.Lower && Upper == other.Upper;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IntRange) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Lower * 397) ^ Upper;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Lower)}: {Lower}, {nameof(Upper)}: {Upper}, {nameof(Width)}: {Width}";
        }
    }
}