using System.Collections.Generic;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides a base class for Fitbit API requests.
  /// </summary>
  public abstract class FitbitRequest
  {
    /// <summary>
    /// Gets a value indicating if the calling method should
    /// attempt to supress the token refresh on 401 errors.
    /// </summary>
    public bool SupressTokenRefresh { get; set; }

    /// <summary>
    /// Gets the HTTP action (verb) for this request.
    /// </summary>
    public virtual FitbitRequestAction Action
    {
      get
      {
        return FitbitRequestAction.Get;
      }
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitRequest"/> class.
    /// </summary>
    public FitbitRequest()
    {
    }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    /// <returns>The URI.</returns>
    public abstract string GetUri();

    /// <summary>
    /// Gets the headers.
    /// </summary>
    /// <returns>A <see cref="IEnumerable{FitbitRequestHeader}"/></returns>
    public abstract IEnumerable<FitbitRequestHeader> GetHeaders();
  }
}