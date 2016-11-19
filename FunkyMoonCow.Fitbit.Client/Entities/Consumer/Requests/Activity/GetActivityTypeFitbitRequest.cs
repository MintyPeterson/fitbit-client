using System;
using System.Collections.Generic;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides a <see cref="FitbitRequest"/> for getting the details of a specific activity.
  /// </summary>
  public class GetActivityTypeFitbitRequest : FitbitRequest
  {
    /// <summary>
    /// Gets or sets the activity identification number.
    /// </summary>
    public long? ActivityId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitLocale"/>.
    /// </summary>
    public FitbitLocale Locale { get; set; }

    /// <summary>
    /// Intialises a new instance of the <see cref="GetActivityTypeFitbitRequest"/> class.
    /// </summary>
    public GetActivityTypeFitbitRequest()
    {
    }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    /// <returns>The URI.</returns>
    public override string GetUri()
    {
      if (!this.ActivityId.HasValue)
      {
        throw new InvalidOperationException("You must specify an activity ID.");
      }

      return string.Format("/1/activities/{0}.json", this.ActivityId);
    }

    /// <summary>
    /// Gets the headers.
    /// </summary>
    /// <returns>A <see cref="IEnumerable{FitbitRequestHeader}"/></returns>
    public override IEnumerable<FitbitRequestHeader> GetHeaders()
    {
      var headers = new List<FitbitRequestHeader>();

      if (this.Locale != null)
      {
        headers.Add(
          new FitbitRequestHeader(
            "Accept-Locale",
            this.Locale.ToString()
          )
        );
      }

      return headers;
    }
  }
}