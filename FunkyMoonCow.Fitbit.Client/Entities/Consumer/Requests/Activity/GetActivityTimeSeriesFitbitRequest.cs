using System;
using System.Collections.Generic;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides a <see cref="FitbitRequest"/> for getting an activity time series.
  /// </summary>
  public class GetActivityTimeSeriesFitbitRequest : FitbitRequest
  {
    /// <summary>
    /// Gets or sets the <see cref="ActivityTimeSeriesResource"/>.
    /// </summary>
    public GetActivityTimeSeriesResource Resource { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="ActivityTimeSeriesPeriod"/>.
    /// </summary>
    public GetActivityTimeSeriesPeriod Period { get; set; }

    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the start <see cref="DateTime.Date"/>.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end <see cref="DateTime.Date"/>.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FitbitUnit"/>.
    /// </summary>
    public FitbitUnit Units { get; set; }

    /// <summary>
    /// Intialises a new instance of the <see cref="GetActivityTimeSeriesFitbitRequest"/>
    /// class.
    /// </summary>
    public GetActivityTimeSeriesFitbitRequest()
    {
      this.UserId = FitbitUser.Current.ToString();
    }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    /// <returns>The URI.</returns>
    public override string GetUri()
    {
      if (this.Resource == GetActivityTimeSeriesResource.None)
      {
        throw new InvalidOperationException("You must specify an activity time series resource.");
      }

      if (!this.EndDate.HasValue && this.Period == GetActivityTimeSeriesPeriod.None)
      {
        throw new InvalidOperationException("You must specify either an end date or a period.");
      }

      var resource = new Dictionary<GetActivityTimeSeriesResource, String>();
      {
        resource.Add(
          GetActivityTimeSeriesResource.ActivityCalories,
          "activities/activityCalories"
        );

        resource.Add(
          GetActivityTimeSeriesResource.Calories,
          "activities/calories"
        );

        resource.Add(
          GetActivityTimeSeriesResource.CaloriesBasalMetabolicRate,
          "activities/caloriesBMR"
        );

        resource.Add(
          GetActivityTimeSeriesResource.Distance,
          "activities/distance"
        );

        resource.Add(
          GetActivityTimeSeriesResource.Elevation,
          "activities/elevation"
        );

        resource.Add(
          GetActivityTimeSeriesResource.Floors,
          "activities/floors"
        );

        resource.Add(
          GetActivityTimeSeriesResource.MinutesFairlyActive,
          "activities/minutesFairlyActive"
        );

        resource.Add(
          GetActivityTimeSeriesResource.MinutesLightlyActive,
          "activities/minutesLightlyActive"
        );

        resource.Add(
          GetActivityTimeSeriesResource.MinutesSedentary,
          "activities/minutesSedentary"
        );

        resource.Add(
          GetActivityTimeSeriesResource.MinutesVeryActive,
          "activities/minutesVeryActive"
        );

        resource.Add(
          GetActivityTimeSeriesResource.Steps,
          "activities/steps"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerActivityCalories,
          "activities/tracker/activityCalories"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerCalories,
          "activities/tracker/calories"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerDistance,
          "activities/tracker/distance"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerElevation,
          "activities/tracker/elevation"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerFloors,
          "activities/tracker/floors"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerMinutesFairlyActive,
          "activities/tracker/minutesFairlyActive"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerMinutesLightlyActive,
          "activities/tracker/minutesLightlyActive"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerMinutesSedentary,
          "activities/tracker/minutesSedentary"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerMinutesVeryActive,
          "activities/tracker/minutesVeryActive"
        );

        resource.Add(
          GetActivityTimeSeriesResource.TrackerSteps,
          "activities/tracker/steps"
        );
      }

      var period = new Dictionary<GetActivityTimeSeriesPeriod, String>();
      {
        period.Add(
          GetActivityTimeSeriesPeriod.Maximum,
          "max"
        );

        period.Add(
          GetActivityTimeSeriesPeriod.OneDay,
          "1d"
        );

        period.Add(
          GetActivityTimeSeriesPeriod.OneMonth,
          "1m"
        );

        period.Add(
          GetActivityTimeSeriesPeriod.OneWeek,
          "1w"
        );

        period.Add(
          GetActivityTimeSeriesPeriod.OneYear,
          "1y"
        );

        period.Add(
          GetActivityTimeSeriesPeriod.SevenDays,
          "7d"
        );

        period.Add(
          GetActivityTimeSeriesPeriod.SixMonths,
          "6m"
        );

        period.Add(
          GetActivityTimeSeriesPeriod.ThirtyDays,
          "30d"
        );

        period.Add(
          GetActivityTimeSeriesPeriod.ThreeMonths,
          "3m"
        );
      }

      if (this.EndDate.HasValue)
      {
        return
          string.Format(
            "/1/user/{0}/{1}/date/{2}/{3}.json",
            this.UserId,
            resource[this.Resource],
            this.StartDate.ToString("yyyy-MM-dd"),
            this.EndDate.Value.ToString("yyyy-MM-dd")
          );
      }
      else
      {
        return
          string.Format(
            "/1/user/{0}/{1}/date/{2}/{3}.json",
            this.UserId,
            resource[this.Resource],
            this.StartDate.ToString("yyyy-MM-dd"),
            period[this.Period]
          );
      }
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

  /// <summary>
  /// Specifies an activity time series resource path.
  /// </summary>
  public enum GetActivityTimeSeriesResource
  {
    None,
    Calories,
    CaloriesBasalMetabolicRate,
    Steps,
    Distance,
    Floors,
    Elevation,
    MinutesSedentary,
    MinutesLightlyActive,
    MinutesFairlyActive,
    MinutesVeryActive,
    ActivityCalories,
    TrackerCalories,
    TrackerSteps,
    TrackerDistance,
    TrackerFloors,
    TrackerElevation,
    TrackerMinutesSedentary,
    TrackerMinutesLightlyActive,
    TrackerMinutesFairlyActive,
    TrackerMinutesVeryActive,
    TrackerActivityCalories
  }

  /// <summary>
  /// Specifies an activity time series period.
  /// </summary>
  public enum GetActivityTimeSeriesPeriod
  {
    None,
    OneDay,
    SevenDays,
    ThirtyDays,
    OneWeek,
    OneMonth,
    ThreeMonths,
    SixMonths,
    OneYear,
    Maximum
  }
}