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
