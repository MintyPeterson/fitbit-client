
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a user.
  /// </summary>
  public sealed class FitbitUser
  {
    /// <summary>
    /// Stores the unit.
    /// </summary>
    private readonly string identifier;

    /// <summary>
    /// Current logged in user.
    /// </summary>
    public static readonly FitbitUser Current = new FitbitUser("-");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitUser"/> class.
    /// </summary>
    /// <param name="identifier">The identifier.</param>
    private FitbitUser(string identifier)
    {
      this.identifier = identifier;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitUser"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.identifier;
    }
  }
}