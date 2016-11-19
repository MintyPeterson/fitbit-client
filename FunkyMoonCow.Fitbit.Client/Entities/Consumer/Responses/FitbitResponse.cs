using FunkyMoonCow.Fitbit.Properties;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Represents a response from the client.
  /// </summary>
  public class FitbitResponse : IFitbitResponse
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
    /// Gets the <see cref="IEnumerable{FitbitError}"/>.
    /// </summary>
    public IEnumerable<FitbitError> Errors { get; set; }

    /// <summary>
    /// Gets a value indicating if the <see cref="FitbitResponse"/>
    /// has any errors.
    /// </summary>
    public bool HasErrors
    {
      get
      {
        return this.Errors.Any();
      }
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitResponse"/> class.
    /// </summary>
    /// <param name="statusCode">The <see cref="HttpStatusCode"/>.</param>
    /// <param name="response">The raw response.</param>
    public FitbitResponse(HttpStatusCode statusCode, string rawResponse)
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

      // Attempt to process any error messages.
      this.ParseErrors();
    }

    /// <summary>
    /// Attempts to parse the <see cref="FitbitResponse.Response"/> for errors.
    /// </summary>
    private void ParseErrors()
    {
      var errors = new List<FitbitError>();

      if (this.Response != null)
      {
        var schema = JSchema.Parse(Resources.ErrorSchema);

        if (this.Response.IsValid(schema))
        {
          // Map the error type.
          var map = new Dictionary<String, FitbitErrorType>();
          {
            map.Add("expired_token", FitbitErrorType.ExpiredToken);
            map.Add("insufficient_permissions", FitbitErrorType.InsufficientPermissions);
            map.Add("insufficient_scope", FitbitErrorType.InsufficientScope);
            map.Add("invalid_grant", FitbitErrorType.InvalidGrant);
            map.Add("invalid_request", FitbitErrorType.InvalidRequest);
            map.Add("invalid_scope", FitbitErrorType.InvalidScope);
            map.Add("invalid_token", FitbitErrorType.InvalidToken);
            map.Add("not_found", FitbitErrorType.NotFound);
            map.Add("request", FitbitErrorType.Request);
            map.Add("unauthorized_client", FitbitErrorType.UnauthorizedClient);
            map.Add("unsupported_grant_type", FitbitErrorType.UnsupportedGrantType);
            map.Add("unsupported_response_type", FitbitErrorType.UnsupportedResponseType);
          }

          dynamic response = this.Response;

          foreach (var error in response.errors)
          {
            var errorType =
              map
                .Where(
                  m => m.Key == (string)error.errorType
                )
                .Select(
                  m => m.Value
                )
                .FirstOrDefault();

            errors.Add(new FitbitError(errorType, error.message.ToString()));
          }
        }
      }
      else
      {
        errors.Add(
          new FitbitError(
            FitbitErrorType.UnexpectedResponse,
            "The response could not be parsed as JSON."
          )
        );
      }

      this.Errors = errors;
    }
  }
}