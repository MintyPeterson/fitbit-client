using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;

namespace FunkyMoonCow.Fitbit.Tests
{
  /// <summary>
  /// Provides a test class for <see cref="FitbitClient"/>.
  /// </summary>
  [TestClass]
  public class FitbitClientUnitTest
  {
    /// <summary>
    /// Tests creating an instance of <see cref="FitbitClient"/>.
    /// </summary>
    [TestMethod]
    public void TestInstantiation()
    {
      FitbitClient client = null;

      try
      {
        client = new FitbitClient(null);

        // Should throw an ArgumentNullException for missing identity.
        Assert.Fail("ArgumentNullException should have been thrown.");
      }
      catch (ArgumentNullException)
      {
      }

      try
      {
        client = new FitbitClient(new ClaimsIdentity());

        // Should throw an ArgumentException for missing properies.
        Assert.Fail("ArgumentException should have been thrown.");
      }
      catch (ArgumentException)
      {
      }

      client = this.CreateFitbitClientInstance();

      // Everything should be fine.
      Assert.IsInstanceOfType(
        client,
        typeof(FitbitClient),
        "The FitbitClient was not instantiated."
      );
    }

    /// <summary>
    /// Tests <see cref="FitbitClient.AddSubscription"/>.
    /// </summary>
    [TestMethod]
    public void TestAddSubscription()
    {
      string json;

      // Method not allowed status.
      {
        var response = new AddSubscriptionFitbitResponse(HttpStatusCode.MethodNotAllowed, null);

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.MethodNotAllowed
            )
          );
      }

      // Conflict status.
      {
        var response = new AddSubscriptionFitbitResponse(HttpStatusCode.Conflict, null);

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Conflict
            )
          );
      }

      // Valid responses.
      json = this.LoadResponse("Valid.AddSubscriptionResponse.json");
      {
        var validStatusCodes = new HttpStatusCode[] { HttpStatusCode.OK, HttpStatusCode.Created };

        foreach (var statusCode in validStatusCodes)
        {
          var response = new AddSubscriptionFitbitResponse(statusCode, JObject.Parse(json));

          Assert.AreEqual("activities", response.CollectionType);
          Assert.AreEqual("22PT4L", response.OwnerId);
          Assert.AreEqual("user", response.OwnerType);
          Assert.AreEqual("3", response.SubscriberId);
          Assert.AreEqual("123", response.SubscriptionId);
        }
      }

      // Missing response.
      {
        var response = new AddSubscriptionFitbitResponse(HttpStatusCode.Created, null);

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }

      // Invalid response.
      json = this.LoadResponse("Invalid.AddSubscriptionResponse.json");
      {
        var response =
          new AddSubscriptionFitbitResponse(HttpStatusCode.Created, JObject.Parse(json));

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }
    }

    /// <summary>
    /// Tests <see cref="FitbitClient.GetActivityTimeSeries"/>.
    /// </summary>
    [TestMethod]
    public void TestGetActivityTimeSeries()
    {
      string json;

      // Invalid status.
      {
        var response = new GetActivityTimeSeriesFitbitResponse(HttpStatusCode.BadRequest, null);

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }

      // Valid response.
      json = this.LoadResponse("Valid.GetActivityTimeSeriesResponse.json");
      {
        var response =
          new GetActivityTimeSeriesFitbitResponse(HttpStatusCode.OK, JObject.Parse(json));

        Assert.AreEqual(response.Log.Count(), 3);

        var expected =
          new GetActivityTimeSeriesFitbitResponseLog[]
          {
            new GetActivityTimeSeriesFitbitResponseLog()
            {
              Date = new DateTime(2011, 04, 27),
              Value = 5490
            },
            new GetActivityTimeSeriesFitbitResponseLog()
            {
              Date = new DateTime(2011, 04, 28),
              Value = 2344
            },
            new GetActivityTimeSeriesFitbitResponseLog()
            {
              Date = new DateTime(2011, 04, 29),
              Value = 2779
            }
          };

        var actual = response.Log.ToList();

        for (int i = 0; i < expected.Length; i++)
        {
          Assert.AreEqual(expected[i].Date, actual[i].Date);
          Assert.AreEqual(expected[i].Value, actual[i].Value);
        }
      }

      // Missing response.
      {
        var response = new GetActivityTimeSeriesFitbitResponse(HttpStatusCode.OK, null);

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }

      // Invalid response.
      json = this.LoadResponse("Invalid.GetActivityTimeSeriesResponse.json");
      {
        var response =
          new GetActivityTimeSeriesFitbitResponse(HttpStatusCode.OK, JObject.Parse(json));

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }
    }

    /// <summary>
    /// Tests <see cref="FitbitClient.GetDailyActivitySummary"/>.
    /// </summary>
    [TestMethod]
    public void TestGetDailyActivitySummary()
    {
      string json;

      // Invalid status.
      {
        var response = new GetDailyActivitySummaryFitbitResponse(HttpStatusCode.BadRequest, null);

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }

      // Valid response.
      json = this.LoadResponse("Valid.GetDailyActivitySummaryResponse.json");
      {
        var response =
          new GetDailyActivitySummaryFitbitResponse(HttpStatusCode.OK, JObject.Parse(json));

        // Activities.
        {
          Assert.AreEqual(response.Activities.Count(), 1);

          var actual = response.Activities.First();

          Assert.AreEqual(51007, actual.ActivityId);
          Assert.AreEqual(90019, actual.ActivityParentId);
          Assert.AreEqual(230, actual.Calories);
          Assert.AreEqual("7mph", actual.Description);
          Assert.AreEqual(2.04f, actual.Distance);
          Assert.AreEqual(1097053, actual.Duration);
          Assert.AreEqual(true, actual.HasStartTime);
          Assert.AreEqual(true, actual.IsFavorite);
          Assert.AreEqual(1154701, actual.LogId);
          Assert.AreEqual("Treadmill, 0% Incline", actual.Name);
          Assert.AreEqual(new TimeSpan(0, 25, 0), actual.StartTime);
          Assert.AreEqual(3783, actual.Steps);
        }

        // Goals.
        {
          Assert.AreEqual(2826, response.Goals.CaloriesOut);
          Assert.AreEqual(8.05f, response.Goals.Distance);
          Assert.AreEqual(150, response.Goals.Floors);
          Assert.AreEqual(10000, response.Goals.Steps);
        }

        // Summary.
        {
          Assert.AreEqual(230, response.Summary.ActivityCalories);
          Assert.AreEqual(1913, response.Summary.CaloriesBasalMetabolicRate);
          Assert.AreEqual(2143, response.Summary.CaloriesOut);
          Assert.AreEqual(48.77f, response.Summary.Elevation);
          Assert.AreEqual(0, response.Summary.FairlyActiveMinutes);
          Assert.AreEqual(16, response.Summary.Floors);
          Assert.AreEqual(0, response.Summary.LightlyActiveMinutes);
          Assert.AreEqual(200, response.Summary.MarginalCalories);
          Assert.AreEqual(1166, response.Summary.SedentaryMinutes);
          Assert.AreEqual(0, response.Summary.Steps);
          Assert.AreEqual(0, response.Summary.VeryActiveMinutes);
        }

        // Distances.
        {
          Assert.AreEqual(3, response.Summary.Distances.Count());

          var expected =
            new GetDailyActivitySummaryFitbitResponseSummaryDistance[]
            {
              new GetDailyActivitySummaryFitbitResponseSummaryDistance()
              {
                Activity = "tracker",
                Distance = 1.32f
              },
              new GetDailyActivitySummaryFitbitResponseSummaryDistance()
              {
                Activity = "loggedActivities",
                Distance = 0.6f
              },
              new GetDailyActivitySummaryFitbitResponseSummaryDistance()
              {
                Activity = "total",
                Distance = 1.92f
              }
            };

          var actual = response.Summary.Distances.ToList();

          for (int i = 0; i < expected.Length; i++)
          {
            Assert.AreEqual(expected[i].Activity, actual[i].Activity);
            Assert.AreEqual(expected[i].Distance, actual[i].Distance);
          }
        }
      }

      // Missing response.
      {
        var response = new GetDailyActivitySummaryFitbitResponse(HttpStatusCode.OK, null);

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }

      // Invalid response.
      json = this.LoadResponse("Invalid.GetActivityTimeSeriesResponse.json");
      {
        var response =
          new GetDailyActivitySummaryFitbitResponse(HttpStatusCode.OK, JObject.Parse(json));

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }
    }

    /// <summary>
    /// Tests <see cref="FitbitClient.GetFoodOrWaterTimeSeries"/>.
    /// </summary>
    [TestMethod]
    public void TestGetFoodOrWaterTimeSeries()
    {
      string json;

      // Invalid status.
      {
        var response = new GetFoodOrWaterTimeSeriesFitbitResponse(HttpStatusCode.BadRequest, null);

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }

      // Valid response.
      json = this.LoadResponse("Valid.GetFoodOrWaterTimeSeriesResponse.json");
      {
        var response =
          new GetFoodOrWaterTimeSeriesFitbitResponse(HttpStatusCode.OK, JObject.Parse(json));

        Assert.AreEqual(response.Log.Count(), 3);

        var expected =
          new GetFoodOrWaterTimeSeriesFitbitResponseLog[]
          {
            new GetFoodOrWaterTimeSeriesFitbitResponseLog()
            {
              Date = new DateTime(2011, 04, 27),
              Value = 5490
            },
            new GetFoodOrWaterTimeSeriesFitbitResponseLog()
            {
              Date = new DateTime(2011, 04, 28),
              Value = 2344
            },
            new GetFoodOrWaterTimeSeriesFitbitResponseLog()
            {
              Date = new DateTime(2011, 04, 29),
              Value = 2779
            }
          };

        var actual = response.Log.ToList();

        for (int i = 0; i < expected.Length; i++)
        {
          Assert.AreEqual(expected[i].Date, actual[i].Date);
          Assert.AreEqual(expected[i].Value, actual[i].Value);
        }
      }

      // Missing response.
      {
        var response = new GetActivityTimeSeriesFitbitResponse(HttpStatusCode.OK, null);

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }

      // Invalid response.
      json = this.LoadResponse("Invalid.GetActivityTimeSeriesResponse.json");
      {
        var response =
          new GetActivityTimeSeriesFitbitResponse(HttpStatusCode.OK, JObject.Parse(json));

        Assert.IsTrue(
          response.Errors
            .Any(
              e => e.ErrorType == FitbitResponseErrorType.Unexpected
            )
          );
      }
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetActivityIntradayTimeSeries"/>.
    /// </summary>
    [TestMethod]
    public void GetActivityIntradayTimeSeries()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.LogActivity"/>.
    /// </summary>
    [TestMethod]
    public void LogActivity()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteActivityLog"/>.
    /// </summary>
    [TestMethod]
    public void DeleteActivityLog()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetActivityLogsList"/>.
    /// </summary>
    [TestMethod]
    public void GetActivityLogsList()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetActivityTcx"/>.
    /// </summary>
    [TestMethod]
    public void GetActivityTcx()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.BrowseActivityTypes"/>.
    /// </summary>
    [TestMethod]
    public void BrowseActivityTypes()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetActivityType"/>.
    /// </summary>
    [TestMethod]
    public void GetActivityType()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFrequentActivities"/>.
    /// </summary>
    [TestMethod]
    public void GetFrequentActivities()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetRecentActivityTypes"/>.
    /// </summary>
    [TestMethod]
    public void GetRecentActivityTypes()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFavoriteActivities"/>.
    /// </summary>
    [TestMethod]
    public void GetFavoriteActivities()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.AddFavoriteActivity"/>.
    /// </summary>
    [TestMethod]
    public void AddFavoriteActivity()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteFavoriteActivity"/>.
    /// </summary>
    [TestMethod]
    public void DeleteFavoriteActivity()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetActivityGoals"/>.
    /// </summary>
    [TestMethod]
    public void GetActivityGoals()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.UpdateActivityGoals"/>.
    /// </summary>
    [TestMethod]
    public void UpdateActivityGoals()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetLifetimeStats"/>.
    /// </summary>
    [TestMethod]
    public void GetLifetimeStats()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetBodyFatLogs"/>.
    /// </summary>
    [TestMethod]
    public void GetBodyFatLogs()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.LogBodyFat"/>.
    /// </summary>
    [TestMethod]
    public void LogBodyFat()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteBodyFatLog"/>.
    /// </summary>
    [TestMethod]
    public void DeleteBodyFatLog()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetBodyTimeSeries"/>.
    /// </summary>
    [TestMethod]
    public void GetBodyTimeSeries()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetBodyGoals"/>.
    /// </summary>
    [TestMethod]
    public void GetBodyGoals()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.UpdateBodyFatGoal"/>.
    /// </summary>
    [TestMethod]
    public void UpdateBodyFatGoal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.UpdateWeightGoal"/>.
    /// </summary>
    [TestMethod]
    public void UpdateWeightGoal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetWeightLogs"/>.
    /// </summary>
    [TestMethod]
    public void GetWeightLogs()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.LogWeight"/>.
    /// </summary>
    [TestMethod]
    public void LogWeight()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteWeightLog"/>.
    /// </summary>
    [TestMethod]
    public void DeleteWeightLog()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetDevices"/>.
    /// </summary>
    [TestMethod]
    public void GetDevices()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetAlarms"/>.
    /// </summary>
    [TestMethod]
    public void GetAlarms()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.AddAlarm"/>.
    /// </summary>
    [TestMethod]
    public void AddAlarm()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.UpdateAlarm"/>.
    /// </summary>
    [TestMethod]
    public void UpdateAlarm()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteAlarm"/>.
    /// </summary>
    [TestMethod]
    public void DeleteAlarm()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFoodLocales"/>.
    /// </summary>
    [TestMethod]
    public void GetFoodLocales()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFoodGoals"/>.
    /// </summary>
    [TestMethod]
    public void GetFoodGoals()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFoodLogs"/>.
    /// </summary>
    [TestMethod]
    public void GetFoodLogs()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetWaterLogs"/>.
    /// </summary>
    [TestMethod]
    public void GetWaterLogs()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetWaterGoal"/>.
    /// </summary>
    [TestMethod]
    public void GetWaterGoal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.EditFoodLog"/>.
    /// </summary>
    [TestMethod]
    public void EditFoodLog()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.LogWater"/>.
    /// </summary>
    [TestMethod]
    public void LogWater()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.UpdateFoodGoal"/>.
    /// </summary>
    [TestMethod]
    public void UpdateFoodGoal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.UpdateWaterGoal"/>.
    /// </summary>
    [TestMethod]
    public void UpdateWaterGoal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteFoodLog"/>.
    /// </summary>
    [TestMethod]
    public void DeleteFoodLog()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.UpdateWaterLog"/>.
    /// </summary>
    [TestMethod]
    public void UpdateWaterLog()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.NotImplementedException"/>.
    /// </summary>
    [TestMethod]
    public void DeleteWaterLog()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFavoriteFoods"/>.
    /// </summary>
    [TestMethod]
    public void GetFavoriteFoods()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFrequentFoods"/>.
    /// </summary>
    [TestMethod]
    public void GetFrequentFoods()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetRecentFoods"/>.
    /// </summary>
    [TestMethod]
    public void GetRecentFoods()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.AddFavoriteFood"/>.
    /// </summary>
    [TestMethod]
    public void AddFavoriteFood()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteFavoriteFood"/>.
    /// </summary>
    [TestMethod]
    public void DeleteFavoriteFood()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetMeals"/>.
    /// </summary>
    [TestMethod]
    public void GetMeals()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.CreateMeal"/>.
    /// </summary>
    [TestMethod]
    public void CreateMeal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetMeal"/>.
    /// </summary>
    [TestMethod]
    public void GetMeal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.EditMeal"/>.
    /// </summary>
    [TestMethod]
    public void EditMeal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteMeal"/>.
    /// </summary>
    [TestMethod]
    public void DeleteMeal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.CreateFood"/>.
    /// </summary>
    [TestMethod]
    public void CreateFood()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteCustomFood"/>.
    /// </summary>
    [TestMethod]
    public void DeleteCustomFood()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFood"/>.
    /// </summary>
    [TestMethod]
    public void GetFood()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFoodUnits"/>.
    /// </summary>
    [TestMethod]
    public void GetFoodUnits()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.SearchFoods"/>.
    /// </summary>
    [TestMethod]
    public void SearchFoods()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFriends"/>.
    /// </summary>
    [TestMethod]
    public void GetFriends()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFriendsLeaderboard"/>.
    /// </summary>
    [TestMethod]
    public void GetFriendsLeaderboard()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.InviteFriend"/>.
    /// </summary>
    [TestMethod]
    public void InviteFriend()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetFriendInvitations"/>.
    /// </summary>
    [TestMethod]
    public void GetFriendInvitations()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.RespondToFriendInvitation"/>.
    /// </summary>
    [TestMethod]
    public void RespondToFriendInvitation()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetHeartRateTimeSeries"/>.
    /// </summary>
    [TestMethod]
    public void GetHeartRateTimeSeries()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetHeartRateIntradayTimeSeries"/>.
    /// </summary>
    [TestMethod]
    public void GetHeartRateIntradayTimeSeries()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetSleepLogs"/>.
    /// </summary>
    [TestMethod]
    public void GetSleepLogs()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetSleepGoal"/>.
    /// </summary>
    [TestMethod]
    public void GetSleepGoal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.UpdateSleepGoal"/>.
    /// </summary>
    [TestMethod]
    public void UpdateSleepGoal()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetSleepTimeSeries"/>.
    /// </summary>
    [TestMethod]
    public void GetSleepTimeSeries()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.LogSleep"/>.
    /// </summary>
    [TestMethod]
    public void LogSleep()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteSleepLog"/>.
    /// </summary>
    [TestMethod]
    public void DeleteSleepLog()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.DeleteSubscription"/>.
    /// </summary>
    [TestMethod]
    public void DeleteSubscription()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetSubscriptions"/>.
    /// </summary>
    [TestMethod]
    public void GetSubscriptions()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetProfile"/>.
    /// </summary>
    [TestMethod]
    public void GetProfile()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.UpdateProfile"/>.
    /// </summary>
    [TestMethod]
    public void UpdateProfile()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    ///  Tests <see cref="FitbitClient.GetBadges"/>.
    /// </summary>
    [TestMethod]
    public void GetBadges()
    {
      Assert.Inconclusive("Not implemented");
    }

    /// <summary>
    /// Creates a valid <see cref="FitbitClient"/> instance.
    /// </summary>
    /// <returns>A <see cref="FitbitClient"/>.</returns>
    private FitbitClient CreateFitbitClientInstance()
    {
      var identity = new ClaimsIdentity();
      {
        identity.AddClaim(new Claim(FitbitClient.AccessTokenClaimType, string.Empty));
        identity.AddClaim(new Claim(FitbitClient.RefreshTokenClaimType, string.Empty));
      }

      return new FitbitClient(identity);
    }

    /// <summary>
    /// Loads a JSON response from file (embedded resource).
    /// </summary>
    /// <param name="fileName">A file name.</param>
    /// <returns>A JSON response.</returns>
    private string LoadResponse(string fileName)
    {
      var resource = string.Format("FunkyMoonCow.Fitbit.Tests.Responses.{0}", fileName);

      using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
      {
        if (stream != null)
        {
          using (var reader = new StreamReader(stream))
          {
            return reader.ReadToEnd();
          }
        }
      }

      throw new FileNotFoundException("The test file was not found.");
    }
  }
}
