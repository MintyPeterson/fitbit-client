using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides a <see cref="FitbitRequest"/> for updating a user's profile.
  /// </summary>
  public class UpdateProfileFitbitRequest : FitbitRequest
  {
    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitUnit"/>.
    /// </summary>
    public FitbitUnit Units { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitGender"/>.
    /// </summary>
    public FitbitGender Gender { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="DateTime"/> of birth.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the height (in the units specified by
    /// <see cref="UpdateProfileFitbitRequest.Units"/>).
    /// </summary>
    public float? Height { get; set; }

    /// <summary>
    /// Gets or sets the about me description.
    /// </summary>
    public string AboutMeDescription { get; set; }

    /// <summary>
    /// Gets or sets the full name.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitCountry"/>.
    /// </summary>
    public FitbitCountry Country { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitState"/>.
    /// </summary>
    public FitbitState State { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the walking stride length  (in the units specified by
    /// <see cref="UpdateProfileFitbitRequest.Units"/>).
    /// </summary>
    public float? WalkingStrideLength { get; set; }

    /// <summary>
    /// Gets or sets the running stride length  (in the units specified by
    /// <see cref="UpdateProfileFitbitRequest.Units"/>).
    /// </summary>
    public float? RunningStrideLength { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitWeightUnit"/>.
    /// </summary>
    public FitbitWeightUnit WeightUnit { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitHeightUnit"/>.
    /// </summary>
    public FitbitHeightUnit HeightUnit { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitWaterUnit"/>.
    /// </summary>
    public FitbitWaterUnit WaterUnit { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitGlucoseUnit"/>.
    /// </summary>
    public FitbitGlucoseUnit GlucoseUnit { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitTimezone"/>.
    /// </summary>
    public FitbitTimezone Timezone { get; set; }

    /// <summary>
    /// Gets or sets the food <see cref="FitbitLocale"/>.
    /// </summary>
    public FitbitLocale FoodLocale { get; set; }

    /// <summary>
    /// Gets or sets the web site <see cref="FitbitLocale"/>.
    /// </summary>
    public FitbitLocale WebSiteLocale { get; set; }

    /// <summary>
    /// Gets or sets the web site locale <see cref="FitbitLanguage"/>.
    /// </summary>
    public FitbitLanguage WebSiteLocaleLanguage { get; set; }

    /// <summary>
    /// Gets or sets the locale <see cref="FitbitCountry"/>.
    /// </summary>
    public FitbitCountry WebSiteLocaleCountry { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitStartDayOfWeek"/>.
    /// </summary>
    public FitbitStartDayOfWeek StartDayOfWeek { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitTimeDisplayFormat"/>.
    /// </summary>
    public FitbitTimeDisplayFormat TimeDisplayFormat { get; set; }

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
    /// Initialises a new instance of the <see cref="UpdateProfileFitbitRequest"/> class.
    /// </summary>
    public UpdateProfileFitbitRequest()
    {
      this.UserId = FitbitUser.Current.ToString();
    }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    /// <returns>The URI.</returns>
    public override string GetUri()
    {
      if (string.IsNullOrWhiteSpace(this.UserId))
      {
        throw new InvalidOperationException("You must specify a user ID.");
      }

      var uri = new StringBuilder();
      {
        uri.AppendFormat("/1/user/{0}/profile.json?", this.UserId);
      }

      // Add the parameters.
      foreach (var parameter in this.GetParameters())
      {
        uri.AppendFormat("{0}={1}&", parameter.Name, parameter.Value);
      }

      return uri.ToString();
    }

    /// <summary>
    /// Gets the parameters.
    /// </summary>
    /// <returns>A <see cref="FitbitRequestParameter"/>.</returns>
    private IEnumerable<FitbitRequestParameter> GetParameters()
    {
      var parameters = new List<FitbitRequestParameter>();

      if (this.Gender != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "gender",
            this.Gender.ToString()
          )
        );
      }

      if (this.DateOfBirth.HasValue)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "birthday",
            this.DateOfBirth?.ToString("yyy-MM-dd")
          )
        );
      }

      if (this.Height.HasValue)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "height",
            this.Height?.ToString("0.00")
          )
        );
      }

      if (this.AboutMeDescription != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "aboutMe",
            this.AboutMeDescription
          )
        );
      }

      if (this.FullName != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "fullname",
            this.FullName
          )
        );
      }

      if (this.Country != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "country",
            this.Country.ToString()
          )
        );
      }

      if (this.State != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "state",
            this.State.ToString()
          )
        );
      }

      if (this.City != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "city",
            this.City
          )
        );
      }

      if (this.WalkingStrideLength.HasValue)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "strideLengthWalking",
            this.Height?.ToString("0.00")
          )
        );
      }

      if (this.RunningStrideLength.HasValue)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "strideLengthRunning",
            this.Height?.ToString("0.00")
          )
        );
      }

      if (this.WeightUnit != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "weightUnit",
            this.WeightUnit.ToString()
          )
        );
      }

      if (this.HeightUnit != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "heightUnit",
            this.HeightUnit.ToString()
          )
        );
      }

      if (this.WaterUnit != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "waterUnit",
            this.WaterUnit.ToString()
          )
        );
      }

      if (this.GlucoseUnit != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "glucoseUnit",
            this.GlucoseUnit.ToString()
          )
        );
      }

      if (this.Timezone != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "timezone",
            this.Timezone.ToString()
          )
        );
      }

      if (this.FoodLocale != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "foodsLocale",
            this.FoodLocale.ToString()
          )
        );
      }

      if (this.WebSiteLocale != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "locale",
            this.WebSiteLocale.ToString()
          )
        );
      }

      if (this.WebSiteLocaleLanguage != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "localeLang",
            this.WebSiteLocaleLanguage.ToString()
          )
        );
      }

      if (this.WebSiteLocaleCountry != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "localeCountry",
            this.WebSiteLocaleCountry.ToString()
          )
        );
      }

      if (this.StartDayOfWeek != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "startDayOfWeek",
            this.StartDayOfWeek.ToString()
          )
        );
      }

      if (this.TimeDisplayFormat != null)
      {
        parameters.Add(
          new FitbitRequestParameter(
            "clockTimeDisplayFormat",
            this.TimeDisplayFormat.ToString()
          )
        );
      }

      return parameters;
    }

    /// <summary>
    /// Gets the headers.
    /// </summary>
    /// <returns>A <see cref="IEnumerable{FitbitRequestHeader}"/></returns>
    public override IEnumerable<FitbitRequestHeader> GetHeaders()
    {
      var headers = new List<FitbitRequestHeader>();

      if (this.Units != null)
      {
        headers.Add(
          new FitbitRequestHeader(
            "Accept-Language",
            this.Units.ToString()
          )
        );
      }

      return headers;
    }
  }
}
