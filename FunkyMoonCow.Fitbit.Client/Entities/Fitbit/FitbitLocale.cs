
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a locale/language.
  /// </summary>
  public sealed class FitbitLocale
  {
    /// <summary>
    /// Stores the locale.
    /// </summary>
    private readonly string locale;

    /// <summary>
    /// Australia.
    /// </summary>
    public static readonly FitbitLocale Australia = new FitbitLocale("en_AU");

    /// <summary>
    /// France.
    /// </summary>
    public static readonly FitbitLocale France = new FitbitLocale("fr_FR");

    /// <summary>
    /// Germany.
    /// </summary>
    public static readonly FitbitLocale Germany = new FitbitLocale("de_DE");

    /// <summary>
    /// Japan.
    /// </summary>
    public static readonly FitbitLocale Japan = new FitbitLocale("ja_JP");

    /// <summary>
    /// New Zealand.
    /// </summary>
    public static readonly FitbitLocale NewZealand = new FitbitLocale("en_NZ");

    /// <summary>
    /// Spain.
    /// </summary>
    public static readonly FitbitLocale Spain = new FitbitLocale("es_ES");

    /// <summary>
    /// United Kingdom.
    /// </summary>
    public static readonly FitbitLocale UnitedKingdom = new FitbitLocale("en_GB");

    /// <summary>
    /// United States.
    /// </summary>
    public static readonly FitbitLocale UnitedStates = new FitbitLocale("en_US");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitLocale"/> class.
    /// </summary>
    /// <param name="locale">The locale.</param>
    private FitbitLocale(string locale)
    {
      this.locale = locale;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitLocale"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.locale;
    }
  }
}