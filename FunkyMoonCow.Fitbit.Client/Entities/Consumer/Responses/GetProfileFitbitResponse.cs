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
  /// <see cref="FitbitClient.GetProfile(GetProfileFitbitRequest)"/>.
  /// </summary>
  public class GetProfileFitbitResponse : FitbitResponse
  {
    /// <summary>
    /// Gets or sets the <see cref="GetProfileFitbitResponseUser"/>.
    /// </summary>
    public GetProfileFitbitResponseUser User { get; set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="GetProfileFitbitResponse"/> class.
    /// </summary>
    public GetProfileFitbitResponse(HttpStatusCode statusCode, JObject response)
      : base(statusCode, response)
    {
      this.User = new GetProfileFitbitResponseUser();

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

      var schema = JSchema.Parse(Resources.GetProfileSchema);

      if (!this.Response.IsValid(schema))
      {
        this.AddUnexpectedInvalidResponseError();

        return;
      }

      dynamic response = this.Response;

      if (response.user != null)
      {
        this.User.Age = response.user.age;
        this.User.SmallAvatarUrl = response.user.avatar;
        this.User.LargeAvatarUrl = response.user.avatar150;
        this.User.AverageDailySteps = response.user.averageDailySteps;
        this.User.TimeDisplayFormat = response.user.clockTimeDisplayFormat;
        this.User.IsCorporate = response.user.corporate;
        this.User.IsCorporateAdministrator = response.user.corporateAdmin;
        this.User.DateOfBirth = response.user.dateOfBirth;
        this.User.DisplayName = response.user.displayName;
        this.User.DistanceUnit = response.user.distanceUnit;
        this.User.EncodedId = response.user.encodedId;
        this.User.FoodLocale = response.user.foodsLocale;
        this.User.FullName = response.user.fullName;
        this.User.Gender = response.user.gender;
        this.User.GlucoseUnit = response.user.glucoseUnit;
        this.User.Height = response.user.height;
        this.User.HeightUnit = response.user.heightUnit;
        this.User.Locale = response.user.locale;
        this.User.MemberSinceDate = response.user.memberSince;
        this.User.Nickname = response.user.nickname;
        this.User.OffsetFromUtcInMilliseconds = response.user.offsetFromUTCMillis;
        this.User.StartDayOfWeek = response.user.startDayOfWeek;
        this.User.StrideLengthWhenRunning = response.user.strideLengthRunning;
        this.User.StrideLengthWhenRunningType = response.user.strideLengthRunningType;
        this.User.StrideLengthWhenWalking = response.user.strideLengthWalking;
        this.User.StrideLengthWhenWalkingType = response.user.strideLengthWalkingType;
        this.User.SwimUnit = response.user.swimUnit;
        this.User.TimeZone = response.user.timezone;
        this.User.WaterUnit = response.user.waterUnit;
        this.User.WaterUnitName = response.user.waterUnitName;
        this.User.Weight = response.user.weight;
        this.User.WeightUnit = response.user.weightUnit;

        if (response.user.topBadges != null)
        {
          var badges = new List<GetProfileFitbitResponseUserBadge>();
          {
            foreach (var badge in response.user.topBadges)
            {
              badges.Add(
                new GetProfileFitbitResponseUserBadge
                {
                  GradientEndColour = badge.badgeGradientEndColor,
                  GradientStartColour = badge.badgeGradientStartColor,
                  BadgeType = badge.badgeType,
                  Category = badge.category,
                  DateMostRecentlyAchieved = badge.dateTime,
                  Description = badge.description,
                  CongratulationsMessage = badge.earnedMessage,
                  EncodedId = badge.encodedId,
                  MediumImageUrl = badge.image100px,
                  LargeImageUrl = badge.image125px,
                  ExtraLargeImageUrl = badge.image300px,
                  ExtraSmallImageUrl = badge.image50px,
                  SmallImageUrl = badge.image75px,
                  LongDescription = badge.marketingDescription,
                  MotivationalMessage = badge.mobileDescription,
                  Name = badge.name,
                  JumboImageUrl = badge.shareImage640px,
                  SocialMediaMessage = badge.shareText,
                  ShortDescription = badge.shortDescription,
                  ShortName = badge.shortName,
                  NumberOfTimesAchieved = badge.timesAchieved,
                  Unit = badge.unit,
                  Value = badge.value
                }
              );
            }
          }

          this.User.TopBadges = badges;
        }
      }
    }
  }

  /// <summary>
  /// Represents a user in a <see cref="GetProfileFitbitResponse"/>.
  /// </summary>
  public class GetProfileFitbitResponseUser
  {
    /// <summary>
    /// Gets or sets the age.
    /// </summary>
    public int? Age { get; set; }

    /// <summary>
    /// Gets or sets the small (100px) avatar URL.
    /// </summary>
    public string SmallAvatarUrl { get; set; }

    /// <summary>
    /// Gets or sets the large (150px) avatar URL.
    /// </summary>
    public string LargeAvatarUrl { get; set; }

    /// <summary>
    /// Gets or sets the average daily steps.
    /// </summary>
    public string AverageDailySteps { get; set; }

    /// <summary>
    /// Gets or sets the time display format.
    /// </summary>
    public string TimeDisplayFormat { get; set; }

    /// <summary>
    /// Gets or sets a value indicating if the profile is a corporate account or not.
    /// </summary>
    public bool? IsCorporate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating if the profile is a corporate administrator account or
    /// not.
    /// </summary>
    public bool? IsCorporateAdministrator { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="DateTime.Date"/> of birth.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the display name.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the distance unit.
    /// </summary>
    public string DistanceUnit { get; set; }

    /// <summary>
    /// Gets or sets the encoded identifier.
    /// </summary>
    public string EncodedId { get; set; }

    /// <summary>
    /// Gets or sets the food locale.
    /// </summary>
    public string FoodLocale { get; set; }

    /// <summary>
    /// Gets or sets the full name.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Gets or sets the gender.
    /// </summary>
    public string Gender { get; set; }

    /// <summary>
    /// Gets or sets the glucose unit.
    /// </summary>
    public string GlucoseUnit { get; set; }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    public float? Height { get; set; }

    /// <summary>
    /// Gets or sets the height unit.
    /// </summary>
    public string HeightUnit { get; set; }

    /// <summary>
    /// Gets or sets the locale.
    /// </summary>
    public string Locale { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="DateTime.Date"/> the user has been a memeber since.
    /// </summary>
    public DateTime? MemberSinceDate { get; set; }

    /// <summary>
    /// Gets or sets the nickname.
    /// </summary>
    public string Nickname { get; set; }

    /// <summary>
    /// Gets or sets the offset from UTI in milliseconds.
    /// </summary>
    public long? OffsetFromUtcInMilliseconds { get; set; }

    /// <summary>
    /// Gets or sets the start day of the week.
    /// </summary>
    public string StartDayOfWeek { get; set; }

    /// <summary>
    /// Gets or sets the stride length when running.
    /// </summary>
    public float? StrideLengthWhenRunning { get; set; }

    /// <summary>
    /// Gets or sets the stride length when running type.
    /// </summary>
    public string StrideLengthWhenRunningType { get; set; }

    /// <summary>
    /// Gets or sets the stride length when walking.
    /// </summary>
    public float? StrideLengthWhenWalking { get; set; }

    /// <summary>
    /// Gets or sets the stride length when walking type.
    /// </summary>
    public string StrideLengthWhenWalkingType { get; set; }

    /// <summary>
    /// Gets or sets the swim unit.
    /// </summary>
    public string SwimUnit { get; set; }

    /// <summary>
    /// Gets or sets the time zone.
    /// </summary>
    public string TimeZone { get; set; }

    /// <summary>
    /// Gets or sets the water unit.
    /// </summary>
    public string WaterUnit { get; set; }

    /// <summary>
    /// Gets or sets the water unit name.
    /// </summary>
    public string WaterUnitName { get; set; }

    /// <summary>
    /// Gets or sets the weight.
    /// </summary>
    public float? Weight { get; set; }

    /// <summary>
    /// Gets or sets the weight unit.
    /// </summary>
    public string WeightUnit { get; set; }

    /// <summary>
    /// Gets the <see cref="IEnumerable{GetProfileFitbitResponseUserBadge}"/>.
    /// </summary>
    public IEnumerable<GetProfileFitbitResponseUserBadge> TopBadges { get; set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="GetProfileFitbitResponseUser"/> class.
    /// </summary>
    public GetProfileFitbitResponseUser()
    {
      this.TopBadges = Enumerable.Empty<GetProfileFitbitResponseUserBadge>();
    }
  }

  /// <summary>
  /// Represents a badge in a <see cref="GetProfileFitbitResponseUser"/>.
  /// </summary>
  public class GetProfileFitbitResponseUserBadge
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
    /// Initialises a new instance of the <see cref="GetProfileFitbitResponseUserBadge"/> class.
    /// </summary>
    public GetProfileFitbitResponseUserBadge()
    {
    }
  }
}