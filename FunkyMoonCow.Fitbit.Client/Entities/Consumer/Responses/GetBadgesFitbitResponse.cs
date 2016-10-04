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
              GradientEndColour = result.badgeGradientEndColor,
              GradientStartColour = result.badgeGradientStartColor,
              BadgeType = result.badgeType,
              Category = result.category,
              DateMostRecentlyAchieved = result.dateTime,
              Description = result.description,
              CongratulationsMessage = result.earnedMessage,
              EncodedId = result.encodedId,
              MediumImageUrl = result.image100px,
              LargeImageUrl = result.image125px,
              ExtraLargeImageUrl = result.image300px,
              ExtraSmallImageUrl = result.image50px,
              SmallImageUrl = result.image75px,
              LongDescription = result.marketingDescription,
              MotivationalMessage = result.mobileDescription,
              Name = result.name,
              JumboImageUrl = result.shareImage640px,
              SocialMediaMessage = result.shareMessage,
              ShortDescription = result.shortDescription,
              ShortName = result.shortName,
              NumberOfTimesAchieved = result.timesAchieved,
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
    /// Gets or sets the extra small (50px) image URL.
    /// </summary>
    public string ExtraSmallImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the small (75px) image URL.
    /// </summary>
    public string SmallImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the medium (100px) image URL.
    /// </summary>
    public string MediumImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the large (125px) image URL.
    /// </summary>
    public string LargeImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the extra large (300px) image URL.
    /// </summary>
    public string ExtraLargeImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the jumbo (640px) image URL.
    /// </summary>
    public string JumboImageUrl { get; set; }

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
    /// Gets or sets the gradient end colour.
    /// </summary>
    public string GradientEndColour { get; set; }

    /// <summary>
    /// Gets or sets the gradient start colour.
    /// </summary>
    public string GradientStartColour { get; set; }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the marketing description.
    /// </summary>
    public string LongDescription { get; set; }

    /// <summary>
    /// Gets or sets the short description.
    /// </summary>
    public string ShortDescription { get; set; }

    /// <summary>
    /// Gets or sets the congratulations message.
    /// </summary>
    public string CongratulationsMessage { get; set; }

    /// <summary>
    /// Gets or sets the motivational message. 
    /// </summary>
    public string MotivationalMessage { get; set; }

    /// <summary>
    /// Gets or sets the encoded identification number.
    /// </summary>
    public string EncodedId { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the short name.
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// Gets or sets the social media message.
    /// </summary>
    public string SocialMediaMessage { get; set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="GetBadgesFitbitResponseBadge"/> class.
    /// </summary>
    public GetBadgesFitbitResponseBadge()
    {
    }
  }
}