
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a unit system for height.
  /// </summary>
  public sealed class FitbitHeightUnit
  {
    /// <summary>
    /// Stores the unit.
    /// </summary>
    private readonly string unit;

    /// <summary>
    /// United States.
    /// </summary>
    public static readonly FitbitHeightUnit UnitedStates = new FitbitHeightUnit("en_US");

    /// <summary>
    /// Metric.
    /// </summary>
    public static readonly FitbitHeightUnit Metric = new FitbitHeightUnit("any");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitHeightUnit"/> class.
    /// </summary>
    /// <param name="unit">The unit.</param>
    private FitbitHeightUnit(string unit)
    {
      this.unit = unit;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitHeightUnit"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.unit;
    }
  }
}