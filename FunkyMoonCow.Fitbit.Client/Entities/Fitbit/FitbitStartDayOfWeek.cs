
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies the start day of a week.
  /// </summary>
  public sealed class FitbitStartDayOfWeek
  {
    /// <summary>
    /// Stores the day.
    /// </summary>
    private readonly string day;

    /// <summary>
    /// Sunday.
    /// </summary>
    public static readonly FitbitStartDayOfWeek Sunday = new FitbitStartDayOfWeek("Sunday");

    /// <summary>
    /// Monday.
    /// </summary>
    public static readonly FitbitStartDayOfWeek Monday = new FitbitStartDayOfWeek("Monday");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitStartDayOfWeek"/> class.
    /// </summary>
    /// <param name="day">The day.</param>
    private FitbitStartDayOfWeek(string day)
    {
      this.day = day;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitStartDayOfWeek"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.day;
    }
  }
}