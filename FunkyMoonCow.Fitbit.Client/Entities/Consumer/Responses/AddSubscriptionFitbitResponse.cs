using FunkyMoonCow.Fitbit.Properties;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Linq;
using System.Net;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides a <see cref="FitbitResponse"/> for
  /// <see cref="FitbitClient.AddSubscription(AddSubscriptionFitbitRequest)"/>.
  /// </summary>
  public class AddSubscriptionFitbitResponse : FitbitResponse
  {
    /// <summary>
    /// Gets the collection type.
    /// </summary>
    public string CollectionType { get; private set; }

    /// <summary>
    /// Gets the owner identifier.
    /// </summary>
    public string OwnerId { get; set; }

    /// <summary>
    /// Gets the owner type.
    /// </summary>
    public string OwnerType { get; set; }

    /// <summary>
    /// Gets the subscriber identifier.
    /// </summary>
    public string SubscriberId { get; set; }

    /// <summary>
    /// Gets the subscription identifier.
    /// </summary>
    public string SubscriptionId { get; set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="AddSubscriptionFitbitResponse"/> class.
    /// </summary>
    /// <param name="statusCode">The <see cref="HttpStatusCode"/>.</param>
    /// <param name="response">The <see cref="JObject"/> response.</param>
    public AddSubscriptionFitbitResponse(HttpStatusCode statusCode, JObject response)
      : base(statusCode, response)
    {
      if (!this.Errors.Any())
      {
        // Attempt to process the response.
        this.ParseResponse();
      }
    }

    /// <summary>
    /// Attempts to parse the <see cref="FitbitResponse.Response"/>.
    /// </summary>
    private void ParseResponse()
    {
      var validCodes =
        new HttpStatusCode[]
        {
          HttpStatusCode.OK,
          HttpStatusCode.Created
        };

      if (!validCodes.Contains(this.StatusCode))
      {
        var errors = this.Errors.ToList();

        switch (this.StatusCode)
        {
          case HttpStatusCode.MethodNotAllowed:
            {
              errors.Add(
                new FitbitResponseError
                {
                  ErrorType = FitbitResponseErrorType.MethodNotAllowed,
                  Message = "A GET was attempted on an endpoint where only POST can be used."
                }
              );
            }
            break;

          case HttpStatusCode.Conflict:
            {
              errors.Add(
                new FitbitResponseError
                {
                  ErrorType = FitbitResponseErrorType.Conflict,
                  Message =
                    "The given user is already subscribed to this stream using a different "
                      + "subscription ID, or the subscription ID is already used to "
                      + "identify a subscription to a different stream"
                }
              );
            }
            break;

          default:
            {
              errors.Add(
                new FitbitResponseError
                {
                  ErrorType = FitbitResponseErrorType.Unexpected
                }
              );
            }
            break;
        }

        this.Errors = errors;

        return;
      }

      var schema = JSchema.Parse(Resources.AddSubscriptionSchema);

      if (this.Response == null || !this.Response.IsValid(schema))
      {
        this.AddUnexpectedInvalidResponseError();

        return;
      }

      dynamic response = this.Response;
      {
        this.CollectionType = response.collectionType;
        this.OwnerId = response.ownerId;
        this.OwnerType = response.ownerType;
        this.SubscriberId = response.subscriberId;
        this.SubscriptionId = response.subscriptionId;
      }
    }
  }
}