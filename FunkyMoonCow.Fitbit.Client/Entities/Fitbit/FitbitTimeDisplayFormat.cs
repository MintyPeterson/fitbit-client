
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a time display format.
  /// </summary>
  public sealed class FitbitTimeDisplayFormat
  {
    /// <summary>
    /// Stores the format.
    /// </summary>
    private readonly string format;

    /// <summary>
    /// 12-hour.
    /// </summary>
    public static readonly FitbitTimeDisplayFormat T12Hour = new FitbitTimeDisplayFormat("12hour");

    /// <summary>
    /// 24-hour.
    /// </summary>
    public static readonly FitbitTimeDisplayFormat T24Hour = new FitbitTimeDisplayFormat("24hour");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitTimeDisplayFormat"/> class.
    /// </summary>
    /// <param name="format">The format.</param>
    private FitbitTimeDisplayFormat(string format)
    {
      this.format = format;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitTimeDisplayFormat"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.format;
    }
  }
}