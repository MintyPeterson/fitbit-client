
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a unit system for weight.
  /// </summary>
  public sealed class FitbitWeightUnit
  {
    /// <summary>
    /// Stores the unit.
    /// </summary>
    private readonly string unit;

    /// <summary>
    /// United Kingdom.
    /// </summary>
    public static readonly FitbitWeightUnit UnitedKingdom = new FitbitWeightUnit("en_GB");

    /// <summary>
    /// United States.
    /// </summary>
    public static readonly FitbitWeightUnit UnitedStates = new FitbitWeightUnit("en_US");

    /// <summary>
    /// Metric.
    /// </summary>
    public static readonly FitbitWeightUnit Metric = new FitbitWeightUnit("any");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitWeightUnit"/> class.
    /// </summary>
    /// <param name="unit">The unit.</param>
    private FitbitWeightUnit(string unit)
    {
      this.unit = unit;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitWeightUnit"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.unit;
    }
  }
}