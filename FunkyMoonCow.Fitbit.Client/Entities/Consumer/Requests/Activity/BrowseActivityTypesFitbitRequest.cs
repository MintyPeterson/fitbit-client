using System.Collections.Generic;
using System.Linq;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides a <see cref="FitbitRequest"/> for getting a tree of all valid public activities
  /// from the activities catalog.
  /// </summary>
  public class BrowseActivityTypesFitbitRequest : FitbitRequest
  {
    /// <summary>
    /// Intialises a new instance of the <see cref="BrowseActivityTypesFitbitRequest"/> class.
    /// </summary>
    public BrowseActivityTypesFitbitRequest()
    {
    }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    /// <returns>The URI.</returns>
    public override string GetUri()
    {
      return "/1/activities.json";
    }

    /// <summary>
    /// Gets the headers.
    /// </summary>
    /// <returns>A <see cref="IEnumerable{FitbitRequestHeader}"/></returns>
    public override IEnumerable<FitbitRequestHeader> GetHeaders()
    {
      return Enumerable.Empty<FitbitRequestHeader>();
    }
  }
}