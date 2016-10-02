using System.Collections.Generic;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides an interface for Fitbit API requests.
  /// </summary>
  public interface IFitbitRequest
  {
    /// <summary>
    /// Gets a value indicating if the calling method should
    /// attempt to supress the token refresh on 401 errors.
    /// </summary>
    bool SupressTokenRefresh { get; set; }

    /// <summary>
    /// Gets the HTTP action (verb) for this request.
    /// </summary>
    FitbitRequestAction Action { get; }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    /// <returns>The URI.</returns>
    string GetUri();

    /// <summary>
    /// Gets the headers.
    /// </summary>
    /// <returns>A <see cref="IEnumerable{FitbitRequestHeader}"/></returns>
    IEnumerable<FitbitRequestHeader> GetHeaders();
  }
}
