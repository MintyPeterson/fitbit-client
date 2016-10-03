using Newtonsoft.Json.Linq;
using System.Net;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Represents a response from the Fitbit API.
  /// </summary>
  public class FitbitApiResponse
  {
    /// <summary>
    /// Gets or sets the <see cref="StatusCode"/>.
    /// </summary>
    public HttpStatusCode StatusCode { get; private set; }

    /// <summary>
    /// Gets the raw response from the API.
    /// </summary>
    public string RawResponse { get; private set; }

    /// <summary>
    /// Gets the <see cref="JObject"/> response from the API.
    /// </summary>
    public JObject Response { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitApiResponse"/>.
    /// </summary>
    public FitbitApiResponse(HttpStatusCode statusCode, string rawResponse)
    {
      this.StatusCode = statusCode;
      this.RawResponse = rawResponse;

      try
      {
        this.Response = JObject.Parse(rawResponse);
      }
      catch
      {
        // We don't care if the result can't be parsed.
        // If the API isn't returning valid JSON something else is wrong.
      }
    }
  }
}