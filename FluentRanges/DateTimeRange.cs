using System;

namespace FluentRanges
{
    public class DateTimeRange : IEquatable<DateTimeRange>
    {
        /// <summary>
        /// Creates an instance of type DateTimeRange given a start and end date
        /// </summary>
        /// <param name="startsAt">The date at which the range starts</param>
        /// <param name="endsAt">The date at which the range ends</param>
        public DateTimeRange(DateTime startsAt, DateTime endsAt)
        {
            if (startsAt > endsAt) throw new ArgumentOutOfRangeException("Failed to create instance of type DateTimeRange. Argument 'startsAt' can not occur after 'endsat'");
            StartsAt = startsAt;
            EndsAt = endsAt;
        }
        

        /// <summary>
        /// Creates an instance of type DateTimeRange given a start and duration
        /// </summary>
        /// <param name="startsAt">The date at which the range starts</param>
        /// <param name="duration">The duration of the range</param>
        public DateTimeRange(DateTime startsAt, TimeSpan duration)
        {
            if (duration.TotalMilliseconds < 0) throw new ArgumentOutOfRangeException("Failed to create instance of type DateTimeRange. Argument 'duration' can not be negative");

            StartsAt = startsAt;
            EndsAt = startsAt.Add(duration);
        }

        public DateTime StartsAt { get; }
        public DateTime EndsAt { get; }

        public TimeSpan Duration => EndsAt - StartsAt;

        /// <summary>
        ///     Evaluates if a given datetime, did happen after the current period.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool HappenedAfter(DateTime dateTime)
        {
            return dateTime > EndsAt;
        }

        /// <summary>
        ///     Evaluates if a given datetime, did happen before the current period.
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public bool HappenedBefore(DateTime datetime)
        {
            return datetime < StartsAt;
        }

        /// <summary>
        ///     Given a datetime, evaluates if the current period is elapsed
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public bool IsElapsed(DateTime datetime)
        {
            return EndsAt < datetime;
        }

        /// <summary>
        ///     Evaluates if a given datetime, did happen during the current period.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool HappenedDuring(DateTime dateTime)
        {
            return dateTime >= StartsAt && dateTime <= EndsAt;
        }

        /// <summary>
        ///     Evaluates if a given range intersect/overlaps the current range instance
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool Intersects(DateTimeRange range)
        {
            return range.StartsAt >= StartsAt || range.EndsAt <= EndsAt;
        }

        /// <summary>
        ///     Given a range calculates the intersection with the current range instance
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public DateTimeRange Intersection(DateTimeRange range)
        {
            var highestLow = StartsAt > range.StartsAt ? StartsAt : range.StartsAt;
            var lowestHigh = EndsAt < range.EndsAt ? EndsAt : range.EndsAt;
            return new DateTimeRange(highestLow, lowestHigh);
        }

        public bool Equals(DateTimeRange other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return StartsAt.Equals(other.StartsAt) && EndsAt.Equals(other.EndsAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DateTimeRange) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (StartsAt.GetHashCode() * 397) ^ EndsAt.GetHashCode();
            }
        }

        public override string ToString()
        {
            return $"{nameof(StartsAt)}: {StartsAt}, {nameof(EndsAt)}: {EndsAt}, {nameof(Duration)}: {Duration}";
        }
    }
}
