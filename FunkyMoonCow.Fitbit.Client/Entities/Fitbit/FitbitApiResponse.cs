using Newtonsoft.Json.Linq;
using System.Net;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Represents a response from the Fitbit API.
  /// </summary>
  internal class FitbitApiResponse
  {
    /// <summary>
    /// Gets or sets the <see cref="StatusCode"/>.
    /// </summary>
    public HttpStatusCode StatusCode { get; private set; }

    /// <summary>
    /// Gets the <see cref="JObject"/> response from the API.
    /// </summary>
    public JObject Response { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitApiResponse"/>.
    /// </summary>
    public FitbitApiResponse(HttpStatusCode statusCode, JObject response)
    {
      this.StatusCode = statusCode;
      this.Response = response;
    }
  }
}