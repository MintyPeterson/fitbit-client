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
  /// Provides a <see cref="FitbitResponse"/> for
  /// <see cref="FitbitClient.GetBadges(GetBadgesFitbitRequest)"/>.
  /// </summary>
  public class GetBadgesFitbitResponse : FitbitResponse
  {
    /// <summary>
    /// Gets the <see cref="IEnumerable{GetBadgesFitbitResponseBadge}"/>.
    /// </summary>
    public IEnumerable<GetBadgesFitbitResponseBadge> Badges { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="GetBadgesFitbitResponse"/> class.
    /// </summary>
    public GetBadgesFitbitResponse(HttpStatusCode statusCode, JObject response)
      : base(statusCode, response)
    {
      this.Badges = Enumerable.Empty<GetBadgesFitbitResponseBadge>();

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
      if (this.StatusCode != HttpStatusCode.OK || this.Response == null)
      {
        this.AddUnexpectedInvalidResponseError();

        return;
      }

      if (this.Response.First == null || this.Response.First.First == null)
      {
        this.AddUnexpectedInvalidResponseError();

        return;
      }

      var schema = JSchema.Parse(Resources.GetBadgesSchema);

      if (!this.Response.IsValid(schema))
      {
        this.AddUnexpectedInvalidResponseError();

        return;
      }

      dynamic response = this.Response.First.First;

      var badges = new List<GetBadgesFitbitResponseBadge>();
      {
        foreach (var result in response)
        {
          badges.Add(
            new GetBadgesFitbitResponseBadge
            {
              BadgeType = result.badgeType,
              DateMostRecentlyAchieved = result.dateTime,
              NumberOfTimesAchieved = result.timesAchieved,
              LargeImageUrl = result.image75px,
              SmallImageUrl = result.image50px,
              Unit = result.unit,
              Value = result.value
            }
          );
        }
      }

      this.Badges = badges;
    }
  }

  /// <summary>
  /// Represents a badge in a <see cref="GetBadgesFitbitResponse"/>.
  /// </summary>
  public class GetBadgesFitbitResponseBadge
  {
    /// <summary>
    /// Gets or sets the badge type.
    /// </summary>
    public string BadgeType { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="DateTime.Date"/> the badge was most recently achieved.
    /// </summary>
    public DateTime DateMostRecentlyAchieved { get; set; }

    /// <summary>
    /// Gets or sets the small image URL.
    /// </summary>
    public string SmallImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the large image URL.
    /// </summary>
    public string LargeImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the number of times the badge has been achived.
    /// </summary>
    public int NumberOfTimesAchieved { get; set; }

    /// <summary>
    /// Gets or sets the unit.
    /// </summary>
    public string Unit { get; set; }

    /// <summary>
    /// Get or sets the value.
    /// </summary>
    public float Value { get; set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="GetBadgesFitbitResponseBadge"/> class.
    /// </summary>
    public GetBadgesFitbitResponseBadge()
    {
    }
  }
}