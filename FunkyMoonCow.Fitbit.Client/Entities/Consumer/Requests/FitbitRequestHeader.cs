namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Represents a header that is sent as part of a <see cref="FitbitRequest"/>.
  /// </summary>
  public class FitbitRequestHeader
  {
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitRequestHeader"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    public FitbitRequestHeader(string name, string value)
    {
      this.Name = name;
      this.Value = value;
    }
  }
}