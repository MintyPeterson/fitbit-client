using System;
using System.Collections.Generic;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides a <see cref="FitbitRequest"/> for getting food or water time series.
  /// </summary>
  public class GetFoodOrWaterTimeSeriesFitbitRequest : FitbitRequest
  {
    /// <summary>
    /// Gets or sets the <see cref="GetFoodOrWaterTimeSeriesResource"/>.
    /// </summary>
    public GetFoodOrWaterTimeSeriesResource Resource { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="GetFoodOrWaterTimeSeriesPeriod"/>.
    /// </summary>
    public GetFoodOrWaterTimeSeriesPeriod Period { get; set; }

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
    /// Intialises a new instance of the <see cref="GetFoodOrWaterTimeSeriesFitbitRequest"/>
    /// class.
    /// </summary>
    public GetFoodOrWaterTimeSeriesFitbitRequest()
    {
      this.UserId = FitbitUser.Current.ToString();
    }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    /// <returns>The URI.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="IFitbitRequest"/>
    /// does not contain the required properties.</exception>
    public override string GetUri()
    {
      if (this.Resource == GetFoodOrWaterTimeSeriesResource.None)
      {
        throw new InvalidOperationException("You must specify a food or water resource.");
      }

      if (!this.EndDate.HasValue && this.Period == GetFoodOrWaterTimeSeriesPeriod.None)
      {
        throw new InvalidOperationException("You must specify either an end date or a period.");
      }

      var resource = new Dictionary<GetFoodOrWaterTimeSeriesResource, String>();
      {
        resource.Add(
          GetFoodOrWaterTimeSeriesResource.CaloriesIn,
          "foods/log/caloriesIn "
        );

        resource.Add(
          GetFoodOrWaterTimeSeriesResource.Water,
          "foods/log/water"
        );
      }

      var period = new Dictionary<GetFoodOrWaterTimeSeriesPeriod, String>();
      {
        period.Add(
          GetFoodOrWaterTimeSeriesPeriod.Maximum,
          "max"
        );

        period.Add(
          GetFoodOrWaterTimeSeriesPeriod.OneDay,
          "1d"
        );

        period.Add(
          GetFoodOrWaterTimeSeriesPeriod.OneMonth,
          "1m"
        );

        period.Add(
          GetFoodOrWaterTimeSeriesPeriod.OneWeek,
          "1w"
        );

        period.Add(
          GetFoodOrWaterTimeSeriesPeriod.OneYear,
          "1y"
        );

        period.Add(
          GetFoodOrWaterTimeSeriesPeriod.SevenDays,
          "7d"
        );

        period.Add(
          GetFoodOrWaterTimeSeriesPeriod.SixMonths,
          "6m"
        );

        period.Add(
          GetFoodOrWaterTimeSeriesPeriod.ThirtyDays,
          "30d"
        );

        period.Add(
          GetFoodOrWaterTimeSeriesPeriod.ThreeMonths,
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
  /// Specifies a food or water time series resource path.
  /// </summary>
  public enum GetFoodOrWaterTimeSeriesResource
  {
    None,
    CaloriesIn,
    Water
  }

  /// <summary>
  /// Specifies a food or water time series period.
  /// </summary>
  public enum GetFoodOrWaterTimeSeriesPeriod
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