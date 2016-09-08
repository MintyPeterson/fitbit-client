
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a unit system.
  /// </summary>
  public sealed class FitbitUnit
  {
    /// <summary>
    /// Stores the unit.
    /// </summary>
    private readonly string unit;

    /// <summary>
    /// United Kingdom.
    /// </summary>
    public static readonly FitbitUnit UnitedKingdom = new FitbitUnit("en_GB");

    /// <summary>
    /// United States.
    /// </summary>
    public static readonly FitbitUnit UnitedStates = new FitbitUnit("en_US");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitUnit"/> class.
    /// </summary>
    /// <param name="unit">The unit.</param>
    private FitbitUnit(string unit)
    {
      this.unit = unit;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitUnit"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.unit;
    }
  }
}