using System;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a <see cref="DateTime"/> range.
  /// </summary>
  public class DateTimeRange
  {
    /// <summary>
    /// Gets the start <see cref="DateTime"/>.
    /// </summary>
    public DateTime Start { get; private set; }

    /// <summary>
    /// Gets the end <see cref="DateTime"/>.
    /// </summary>
    public DateTime End { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="DateTimeRange"/> class.
    /// </summary>
    /// <param name="start">The start <see cref="DateTime"/>.</param>
    /// <param name="end">The end <see cref="DateTime"/>.</param>
    public DateTimeRange(DateTime start, DateTime end)
    {
      this.Start = start;
      this.End = end;
    }
  }
}
