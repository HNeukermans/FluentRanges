using System;

namespace FluentRanges
{
    //public class Range<T> where T : struct, IFormattable, IEquatable<T>
    //{
    //    /// <summary>
    //    /// Creates an instance of type IntRange given a lower and upper bound
    //    /// </summary>
    //    /// <param name="lower">The lower bound of the range</param>
    //    /// <param name="upper">The upper bound of the range</param>
    //    public RangeBase(T lower, T upper)
    //    {
    //        if (lower > upper) throw new ArgumentOutOfRangeException("Failed to create instance of type IntRange. Argument 'startsAt' can not occur after 'endsat'");
    //        Lower = lower;
    //        Upper = upper;
    //    }

    //    public T Lower { get; }
    //    public T Upper { get; }
    //    public T Width => Upper - Lower;

    //    /// <summary>
    //    ///     Evaluates if a given value is higher then the upper bound
    //    /// </summary>
    //    /// <param name="value"></param>
    //    /// <returns></returns>
    //    public bool IsGreaterThen(int value)
    //    {
    //        return value > Upper;
    //    }

    //    /// <summary>
    //    ///     Evaluates if a given value is lower then the lower bound
    //    /// </summary>
    //    /// <param name="value"></param>
    //    /// <returns></returns>
    //    public bool IsSmallerThen(int value)
    //    {
    //        return value < Lower;
    //    }

    //    /// <summary>
    //    ///     Evaluates if a given value is in range
    //    /// </summary>
    //    /// <param name="value"></param>
    //    /// <returns></returns>
    //    public bool IsInRange(int value)
    //    {
    //        return value >= Lower && value <= Upper;
    //    }
    //}
}