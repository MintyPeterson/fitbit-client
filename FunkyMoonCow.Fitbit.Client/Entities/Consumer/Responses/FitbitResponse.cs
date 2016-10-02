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
  /// Provides a base class for consumer responses.
  /// </summary>
  public abstract class FitbitResponse : IFitbitResponse
  {
    /// <summary>
    /// Gets or sets the <see cref="StatusCode"/>.
    /// </summary>
    protected HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="JObject"/> response from the API.
    /// </summary>
    protected JObject Response { get; set; }

    /// <summary>
    /// Gets the <see cref="IEnumerable{FitbitResponseError}"/>.
    /// </summary>
    public IEnumerable<FitbitResponseError> Errors { get; set; }

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
    /// <param name="response">The <see cref="JObject"/> response.</param>
    public FitbitResponse(HttpStatusCode statusCode, JObject response)
    {
      this.StatusCode = statusCode;
      this.Response = response;

      // Attempt to process any error messages.
      this.ParseResponse();
    }

    /// <summary>
    /// Adds an unexpected invalid response error to <see cref="FitbitResponse.Errors"/>.
    /// </summary>
    protected void AddUnexpectedInvalidResponseError()
    {
      var errors = this.Errors.ToList();

      errors.Add(
        new FitbitResponseError
        {
          ErrorType = FitbitResponseErrorType.Unexpected,
          Message = "The API did not return a valid response."
        }
      );

      this.Errors = errors;
    }

    /// <summary>
    /// Attempts to parse the <see cref="FitbitResponse.Response"/>.
    /// </summary>
    private void ParseResponse()
    {
      var errors = new List<FitbitResponseError>();

      // Add any generic errors.
      if (this.Response != null)
      {
        var schema = JSchema.Parse(Resources.ErrorSchema);

        if (this.Response.IsValid(schema))
        {
          // Map the error type.
          var map = new Dictionary<String, FitbitResponseErrorType>();
          {
            map.Add("expired_token", FitbitResponseErrorType.ExpiredToken);
            map.Add("insufficient_permissions", FitbitResponseErrorType.InsufficientPermissions);
            map.Add("insufficient_scope", FitbitResponseErrorType.InsufficientScope);
            map.Add("invalid_grant", FitbitResponseErrorType.InvalidGrant);
            map.Add("invalid_request", FitbitResponseErrorType.InvalidRequest);
            map.Add("invalid_scope", FitbitResponseErrorType.InvalidScope);
            map.Add("invalid_token", FitbitResponseErrorType.InvalidToken);
            map.Add("not_found", FitbitResponseErrorType.NotFound);
            map.Add("request", FitbitResponseErrorType.Request);
            map.Add("unauthorized_client", FitbitResponseErrorType.UnauthorizedClient);
            map.Add("unsupported_grant_type", FitbitResponseErrorType.UnsupportedGrantType);
            map.Add("unsupported_response_type", FitbitResponseErrorType.UnsupportedResponseType);
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

            errors.Add(
              new FitbitResponseError
              {
                ErrorType = errorType,
                Message = error.message
              }
            );
          }
        }
      }

      this.Errors = errors;
    }
  }

  /// <summary>
  /// Specifies a <see cref="FitbitResponseError"/> type.
  /// </summary>
  public enum FitbitResponseErrorType
  {
    /// <summary>
    /// Unexpected.
    /// </summary>
    Unexpected = 0,

    /// <summary>
    /// Expired token.
    /// </summary>
    ExpiredToken,

    /// <summary>
    /// Insufficient permissions.
    /// </summary>
    InsufficientPermissions,

    /// <summary>
    /// Insufficient scope.
    /// </summary>
    InsufficientScope,

    /// <summary>
    /// Invalid grant
    /// </summary>
    InvalidGrant,

    /// <summary>
    /// Invalid request.
    /// </summary>
    InvalidRequest,

    /// <summary>
    /// Invalid scope.
    /// </summary>
    InvalidScope,

    /// <summary>
    /// Invalid token.
    /// </summary>
    InvalidToken,

    /// <summary>
    /// Not found.
    /// </summary>
    NotFound,

    /// <summary>
    /// Request.
    /// </summary>
    Request,

    /// <summary>
    /// Unauthorized client.
    /// </summary>
    UnauthorizedClient,

    /// <summary>
    /// Unsupported grant type.
    /// </summary>
    UnsupportedGrantType,

    /// <summary>
    /// Unsupported response type.
    /// </summary>
    UnsupportedResponseType,

    /// <summary>
    /// Method not allowed.
    /// </summary>
    MethodNotAllowed,

    /// <summary>
    /// Conflict.
    /// </summary>
    Conflict
  }

  /// <summary>
  /// Represents a Fitbit error response.
  /// </summary>
  public class FitbitResponseError
  {
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    public FitbitResponseErrorType ErrorType { get; set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitResponseError"/> class.
    /// </summary>
    public FitbitResponseError()
    {
    }
  }
}