
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a unit system for water.
  /// </summary>
  public sealed class FitbitWaterUnit
  {
    /// <summary>
    /// Stores the unit.
    /// </summary>
    private readonly string unit;

    /// <summary>
    /// United States.
    /// </summary>
    public static readonly FitbitWaterUnit UnitedStates = new FitbitWaterUnit("en_US");

    /// <summary>
    /// Metric.
    /// </summary>
    public static readonly FitbitWaterUnit Metric = new FitbitWaterUnit("any");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitWaterUnit"/> class.
    /// </summary>
    /// <param name="unit">The unit.</param>
    private FitbitWaterUnit(string unit)
    {
      this.unit = unit;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitWaterUnit"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.unit;
    }
  }
}