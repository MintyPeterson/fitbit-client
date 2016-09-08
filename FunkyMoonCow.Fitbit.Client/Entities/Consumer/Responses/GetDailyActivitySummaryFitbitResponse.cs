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
  /// <see cref="FitbitClient.GetDailyActivitySummary(GetDailyActivitySummaryFitbitRequest)"/>.
  /// </summary>
  public class GetDailyActivitySummaryFitbitResponse : FitbitResponse
  {
    /// <summary>
    /// Gets the <see cref="IEnumerable{DailyActivitySummaryFitbitResponseSummaryActivity}"/>.
    /// </summary>
    public IEnumerable<GetDailyActivitySummaryFitbitResponseSummaryActivity> Activities
      { get; private set; }

    /// <summary>
    /// Gets the <see cref="GetDailyActivitySummaryFitbitResponseGoal"/>.
    /// </summary>
    public GetDailyActivitySummaryFitbitResponseGoal Goals { get; private set; }

    /// <summary>
    /// Gets the <see cref="GetDailyActivitySummaryFitbitResponseSummary"/>.
    /// </summary>
    public GetDailyActivitySummaryFitbitResponseSummary Summary { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="GetDailyActivitySummaryFitbitResponse"/>
    /// class.
    /// </summary>
    public GetDailyActivitySummaryFitbitResponse(HttpStatusCode statusCode, JObject response)
      : base(statusCode, response)
    {
      // Don't allow the responses to be null (even if there are errors).
      this.Goals = new GetDailyActivitySummaryFitbitResponseGoal();
      this.Summary = new GetDailyActivitySummaryFitbitResponseSummary();

      this.Activities = Enumerable.Empty<GetDailyActivitySummaryFitbitResponseSummaryActivity>();

      // Attempt to process an activity summary response.
      this.ParseResponse();
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

      var schema = JSchema.Parse(Resources.GetDailyActivitySummarySchema);

      if (!this.Response.IsValid(schema))
      {
        this.AddUnexpectedInvalidResponseError();

        return;
      }

      dynamic response = this.Response;

      // Activites.
      {
        var activities =
          new List<GetDailyActivitySummaryFitbitResponseSummaryActivity>();
        {
          foreach (var result in response.activities)
          {
            var activity =
              new GetDailyActivitySummaryFitbitResponseSummaryActivity();
            {
              activity.ActivityId = result.activityId;
              activity.ActivityParentId = result.activityParentId;
              activity.Calories = result.calories;
              activity.Description = result.description;
              activity.Distance = result.distance;
              activity.Duration = result.duration;
              activity.HasStartTime = result.hasStartTime;
              activity.IsFavorite = result.isFavorite;
              activity.LogId = result.logId;
              activity.Name = result.name;
              activity.StartTime = result.startTime;
              activity.Steps = result.steps;
            }

            activities.Add(activity);
          }
        }

        this.Activities = activities;
      }

      // Goals.
      {
        this.Goals.CaloriesOut = response.goals.caloriesOut;
        this.Goals.Distance = response.goals.distance;
        this.Goals.Floors= response.goals.floors;
        this.Goals.Steps = response.goals.steps;
      }

      // Summary.
      {
        this.Summary.ActivityCalories = response.summary.activityCalories;
        this.Summary.CaloriesBasalMetabolicRate = response.summary.caloriesBMR;
        this.Summary.CaloriesOut = response.summary.caloriesOut;
        this.Summary.Elevation = response.summary.elevation;
        this.Summary.FairlyActiveMinutes = response.summary.fairlyActiveMinutes;
        this.Summary.Floors = response.summary.floors;
        this.Summary.LightlyActiveMinutes = response.summary.lightlyActiveMinutes;
        this.Summary.MarginalCalories = response.summary.marginalCalories;
        this.Summary.SedentaryMinutes = response.summary.sedentaryMinutes;
        this.Summary.Steps = response.summary.steps;
        this.Summary.VeryActiveMinutes = response.summary.veryActiveMinutes;

        // Distances.
        var distances =
          new List<GetDailyActivitySummaryFitbitResponseSummaryDistance>();
        {
          foreach (var result in response.summary.distances)
          {
            var distance =
              new GetDailyActivitySummaryFitbitResponseSummaryDistance();
            {
              distance.Activity = result.activity;
              distance.Distance = result.distance;
            }

            distances.Add(distance);
          }
        }

        this.Summary.Distances = distances;
      }
    }
  }

  /// <summary>
  /// Represents the goals in a <see cref="GetDailyActivitySummaryFitbitResponse"/>.
  /// </summary>
  public class GetDailyActivitySummaryFitbitResponseGoal
  {
    /// <summary>
    /// Gets or sets the calories out goal.
    /// </summary>
    public long? CaloriesOut { get; set; }

    /// <summary>
    /// Gets or sets the distance goal.
    /// </summary>
    public float? Distance { get; set; }

    /// <summary>
    /// Gets or sets the floor goal.
    /// </summary>
    public long? Floors { get; set; }

    /// <summary>
    /// Gets or sets the steps goal.
    /// </summary>
    public long? Steps { get; set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="GetDailyActivitySummaryFitbitResponseGoal"/>
    /// class.
    /// </summary>
    public GetDailyActivitySummaryFitbitResponseGoal()
    {
    }
  }

  /// <summary>
  /// Represents a metric summary in a <see cref="GetDailyActivitySummaryFitbitResponse"/>.
  /// </summary>
  public class GetDailyActivitySummaryFitbitResponseSummary
  {
    /// <summary>
    /// Gets or sets the number of calories spent during
    /// activites.
    /// </summary>
    public long? ActivityCalories { get; set; }

    /// <summary>
    /// Gets or sets the number of calories spent during
    /// basal metabolism.
    /// </summary>
    public long? CaloriesBasalMetabolicRate { get; set; }

    /// <summary>
    /// Gets or sets the total number of calories spent.
    /// </summary>
    public long? CaloriesOut { get; set; }

    /// <summary>
    /// Gets or sets the elevation climbed.
    /// </summary>
    public float? Elevation { get; set; }

    /// <summary>
    /// Gets or sets the number of fairly active minutes.
    /// </summary>
    public long? FairlyActiveMinutes { get; set; }

    /// <summary>
    /// Gets or sets the number of floors climbed.
    /// </summary>
    public long? Floors { get; set; }

    /// <summary>
    /// Gets or sets the number of lightly active minutes.
    /// </summary>
    public long? LightlyActiveMinutes { get; set; }

    /// <summary>
    /// Gets or sets the number of marginal calories spent (?).
    /// </summary>
    public long? MarginalCalories { get; set; }

    /// <summary>
    /// Gets or sets the number of sedentary minutes.
    /// </summary>
    public long? SedentaryMinutes { get; set; }

    /// <summary>
    /// Gets or sets the number of steps.
    /// </summary>
    public long? Steps { get; set; }

    /// <summary>
    /// Gets or sets the number of very active minutes.
    /// </summary>
    public long? VeryActiveMinutes { get; set; }

    /// <summary>
    /// Gets or sets the
    /// <see cref="IEnumerable{DailyActivitySummaryFitbitResponseSummaryDistance}"/>.
    /// </summary>
    public IEnumerable<GetDailyActivitySummaryFitbitResponseSummaryDistance> Distances
      { get; set; }

    /// <summary>
    /// Initialises a new instance of the
    /// <see cref="GetDailyActivitySummaryFitbitResponseSummary"/> class.
    /// </summary>
    public GetDailyActivitySummaryFitbitResponseSummary()
    {
      this.Distances =
        Enumerable.Empty<GetDailyActivitySummaryFitbitResponseSummaryDistance>();
    }
  }

  /// <summary>
  /// Represents a distance in a <see cref="GetDailyActivitySummaryFitbitResponseSummary"/>.
  /// </summary>
  public class GetDailyActivitySummaryFitbitResponseSummaryDistance
  {
    /// <summary>
    /// Gets or sets the activity.
    /// </summary>
    public string Activity { get; set; }

    /// <summary>
    /// Gets or sets the distance.
    /// </summary>
    public float? Distance { get; set; }

    /// <summary>
    /// Initialises a new instance of the
    /// <see cref="GetDailyActivitySummaryFitbitResponseSummaryDistance"/> class.
    /// </summary>
    public GetDailyActivitySummaryFitbitResponseSummaryDistance()
    {
    }
  }

  /// <summary>
  /// Represents an activity in a <see cref="GetDailyActivitySummaryFitbitResponse"/>.
  /// </summary>
  public class GetDailyActivitySummaryFitbitResponseSummaryActivity
  {
    /// <summary>
    /// Gets or sets the activity identification number.
    /// </summary>
    public long? ActivityId { get; set; }

    /// <summary>
    /// Gets or sets the parent activity identification number.
    /// </summary>
    public long? ActivityParentId { get; set; }

    /// <summary>
    /// Gets or sets the number of calories spent.
    /// </summary>
    public long? Calories { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the distance travelled.
    /// </summary>
    public float? Distance { get; set; }

    /// <summary>
    /// Gets or sets the duration.
    /// </summary>
    public long? Duration { get; set; }

    /// <summary>
    /// Gets or sets a value indicating if there is a
    /// <see cref="GetDailyActivitySummaryFitbitResponseSummaryActivity.StartTime"/>
    /// or not.
    /// </summary>
    public bool? HasStartTime { get; set; }

    /// <summary>
    /// Gets or sets a value indicating if this activity
    /// is a favourite or not.
    /// </summary>
    public bool? IsFavorite { get; set; }

    /// <summary>
    /// Gets or sets the log identification number.
    /// </summary>
    public long? LogId { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the start <see cref="TimeSpan"/>.
    /// </summary>
    public TimeSpan? StartTime { get; set; }

    /// <summary>
    /// Gets or sets the number of steps.
    /// </summary>
    public long? Steps { get; set; }

    /// <summary>
    /// Initialises a new instance of the
    /// <see cref="GetDailyActivitySummaryFitbitResponseSummaryActivity"/> class.
    /// </summary>
    public GetDailyActivitySummaryFitbitResponseSummaryActivity()
    {
    }
  }
}