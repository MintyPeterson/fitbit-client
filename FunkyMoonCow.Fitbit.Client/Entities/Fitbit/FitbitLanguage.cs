
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a language.
  /// </summary>
  public sealed class FitbitLanguage
  {
    /// <summary>
    /// Stores the language.
    /// </summary>
    private readonly string language;

    /// <summary>
    /// English.
    /// </summary>
    public static readonly FitbitLanguage English = new FitbitLanguage("en");

    /// <summary>
    /// French.
    /// </summary>
    public static readonly FitbitLanguage French = new FitbitLanguage("fr");

    /// <summary>
    /// German.
    /// </summary>
    public static readonly FitbitLanguage German = new FitbitLanguage("de");

    /// <summary>
    /// Spanish.
    /// </summary>
    public static readonly FitbitLanguage Spanish = new FitbitLanguage("es");

    /// <summary>
    /// Japanese.
    /// </summary>
    public static readonly FitbitLanguage Japanese = new FitbitLanguage("ja");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitLanguage"/> class.
    /// </summary>
    /// <param name="language">The language.</param>
    private FitbitLanguage(string language)
    {
      this.language = language;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitLanguage"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.language;
    }
  }
}