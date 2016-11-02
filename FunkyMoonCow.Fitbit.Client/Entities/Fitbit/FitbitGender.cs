
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a gender.
  /// </summary>
  public sealed class FitbitGender
  {
    /// <summary>
    /// Stores the gender.
    /// </summary>
    private readonly string gender;

    /// <summary>
    /// Male.
    /// </summary>
    public static readonly FitbitGender Male = new FitbitGender("MALE");

    /// <summary>
    /// Female.
    /// </summary>
    public static readonly FitbitGender Female = new FitbitGender("FEMALE");

    /// <summary>
    /// Unknown.
    /// </summary>
    public static readonly FitbitGender Unknown = new FitbitGender("NA");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitGender"/> class.
    /// </summary>
    /// <param name="gender">The gender.</param>
    private FitbitGender(string gender)
    {
      this.gender = gender;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitGender"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.gender;
    }
  }
}