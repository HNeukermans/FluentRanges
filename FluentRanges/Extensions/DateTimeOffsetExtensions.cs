using System;

namespace FluentRanges.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        /// <summary>
        ///     Evaluates if the datetime instance, did happen before the given period.
        /// </summary>
        public static bool HappenedBefore(this DateTimeOffset @this, DateTimeOffsetRange period)
        {
            if (period == null) throw new ArgumentNullException(nameof(period));
            return period.HappenedBefore(@this);
        }

        /// <summary>
        ///     Evaluates if the datetime instance, did happen before the given dateTime.
        /// </summary>
        public static bool HappenedAfter(this DateTimeOffset @this, DateTimeOffsetRange period)
        {
            if (period == null) throw new ArgumentNullException(nameof(period));
            return period.HappenedAfter(@this);
        }

        /// <summary>
        ///     Evaluates if the datetime instance, did happen during the given period.
        /// </summary>
        public static bool HappenedDuring(this DateTimeOffset @this, DateTimeOffsetRange period)
        {
            if (period == null) throw new ArgumentNullException(nameof(period));
            return period.HappenedDuring(@this);
        }
    }
}