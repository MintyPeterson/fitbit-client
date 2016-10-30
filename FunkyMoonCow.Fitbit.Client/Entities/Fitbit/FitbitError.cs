namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Represents a Fitbit error.
  /// </summary>
  public class FitbitError
  {
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    public FitbitErrorType ErrorType { get; private set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitError"/> class.
    /// </summary>
    public FitbitError(FitbitErrorType errorType, string message)
    {
      this.ErrorType = errorType;
      this.Message = message;
    }
  }

  /// <summary>
  /// Specifies a <see cref="FitbitError"/> type.
  /// </summary>
  public enum FitbitErrorType
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
}
