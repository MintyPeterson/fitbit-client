using System;
using System.Collections.Generic;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides a <see cref="FitbitRequest"/> for
  /// <see cref="FitbitClient.AddSubscription(AddSubscriptionFitbitRequest)"/>.
  /// </summary>
  public class AddSubscriptionFitbitRequest : FitbitRequest
  {
    /// <summary>
    /// Gets or sets the collection path.
    /// </summary>
    public AddSubscriptionCollectionPath CollectionPath { get; set; }

    /// <summary>
    /// Gets or sets the subscription identifier.
    /// </summary>
    public string SubscriptionId { get; set; }

    /// <summary>
    /// Gets or sets the subscriber identifier.
    /// </summary>
    public string SubscriberId { get; set; }

    /// <summary>
    /// Gets the HTTP action (verb) for this request.
    /// </summary>
    public override FitbitRequestAction Action
    {
      get
      {
        return FitbitRequestAction.Post;
      }
    }

    /// <summary>
    /// Intialises a new instance of the <see cref="AddSubscriptionFitbitRequest"/> class.
    /// </summary>
    public AddSubscriptionFitbitRequest()
    {
    }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    /// <returns>The endpoint URI.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="IFitbitRequest"/>
    /// does not contain the required properties.</exception>
    public override string GetUri()
    {
      if (string.IsNullOrWhiteSpace(this.SubscriptionId))
      {
        throw new InvalidOperationException("You must specify a subscription ID.");
      }

      var collectionPath = new Dictionary<AddSubscriptionCollectionPath, String>();
      {
        collectionPath.Add(
          AddSubscriptionCollectionPath.All,
          String.Empty
        );

        collectionPath.Add(
          AddSubscriptionCollectionPath.Activities,
          "activities/"
        );

        collectionPath.Add(
          AddSubscriptionCollectionPath.Body,
          "body/"
        );

        collectionPath.Add(
          AddSubscriptionCollectionPath.Foods,
          "foods/"
        );

        collectionPath.Add(
          AddSubscriptionCollectionPath.Sleep,
          "sleep/"
        );
      }

      return
        string.Format(
          "/1/user/-/{0}apiSubscriptions/{1}.json",
          collectionPath[this.CollectionPath],
          this.SubscriptionId
        );
    }

    /// <summary>
    /// Gets the headers.
    /// </summary>
    /// <returns>A <see cref="IEnumerable{FitbitRequestHeader}"/></returns>
    public override IEnumerable<FitbitRequestHeader> GetHeaders()
    {
      var headers = new List<FitbitRequestHeader>();

      if (!string.IsNullOrWhiteSpace(this.SubscriberId))
      {
        headers.Add(
          new FitbitRequestHeader(
            "X-Fitbit-Subscriber-Id",
            this.SubscriberId
          )
        );
      }

      return headers;
    }
  }

  /// <summary>
  /// Specifies an add subscription collection path.
  /// </summary>
  public enum AddSubscriptionCollectionPath
  {
    All,
    Activities,
    Body,
    Foods,
    Sleep
  }
}