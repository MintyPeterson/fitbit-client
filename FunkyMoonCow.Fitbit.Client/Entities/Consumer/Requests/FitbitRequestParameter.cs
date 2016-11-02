
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Represents a parameter that is sent as part of a <see cref="FitbitRequestAction.Post"/>
  /// <see cref="FitbitRequest"/>.
  /// </summary>
  internal class FitbitRequestParameter
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
    /// Initialises a new instance of the <see cref="FitbitRequestParameter"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    public FitbitRequestParameter(string name, string value)
    {
      this.Name = name;
      this.Value = value;
    }
  }
}