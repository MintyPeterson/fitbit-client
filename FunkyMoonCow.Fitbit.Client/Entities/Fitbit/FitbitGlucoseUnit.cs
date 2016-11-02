
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a unit system for glucose.
  /// </summary>
  public sealed class FitbitGlucoseUnit
  {
    /// <summary>
    /// Stores the unit.
    /// </summary>
    private readonly string unit;

    /// <summary>
    /// United States.
    /// </summary>
    public static readonly FitbitGlucoseUnit UnitedStates = new FitbitGlucoseUnit("en_US");

    /// <summary>
    /// Metric.
    /// </summary>
    public static readonly FitbitGlucoseUnit Metric = new FitbitGlucoseUnit("any");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitGlucoseUnit"/> class.
    /// </summary>
    /// <param name="unit">The unit.</param>
    private FitbitGlucoseUnit(string unit)
    {
      this.unit = unit;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitGlucoseUnit"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.unit;
    }
  }
}