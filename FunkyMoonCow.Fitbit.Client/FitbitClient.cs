using FunkyMoonCow.Fitbit.Properties;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides a client for the Fitbit API.
  /// </summary>
  public class FitbitClient
  {
    /// <summary>
    /// Specifies the <see cref="ClaimsIdentity"/> access token type.
    /// </summary>
    public static string AccessTokenClaimType = "urn:token:fitbit:accesstoken";

    /// <summary>
    /// Specifies the <see cref="ClaimsIdentity"/> refresh token type.
    /// </summary>
    public static string RefreshTokenClaimType = "urn:token:fitbit:refreshtoken";

    /// <summary>
    /// Stores the base address for the API.
    /// </summary>
    private readonly string apiBaseAddress;

    /// <summary>
    /// Stores the client ID.
    /// </summary>
    private readonly string clientId;

    /// <summary>
    /// Stores the client secret.
    /// </summary>
    private readonly string clientSecret;

    /// <summary>
    /// Stores the user.
    /// </summary>
    private ClaimsIdentity user;

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitClient"/> class.
    /// </summary>
    /// <param name="user">The user <see cref="ClaimsIdentity"/>.</param>
    public FitbitClient(ClaimsIdentity user)
    {
      if(user == null)
      {
        throw new ArgumentNullException("user");
      }

      this.user = user;

      // Get the application settings.
      {
        this.apiBaseAddress = ConfigurationManager.AppSettings["FitbitApiBaseAddress"];

        if (string.IsNullOrWhiteSpace(this.apiBaseAddress))
        {
          throw new ConfigurationErrorsException(
            "The Fitbit API base address setting is not set."
          );
        }

        this.clientId = ConfigurationManager.AppSettings["FitbitClientId"];

        if(string.IsNullOrWhiteSpace(this.clientId))
        {
          throw new ConfigurationErrorsException(
            "The Fitbit client ID application setting is not set."
          );
        }

        this.clientSecret = ConfigurationManager.AppSettings["FitbitClientSecret"];

        if (string.IsNullOrWhiteSpace(this.clientId))
        {
          throw new ConfigurationErrorsException(
            "The Fitbit client secret application setting is not set."
          );
        }
      }

      // Check the identity contains the correct claims.
      {
        var claims =
          new string[]
          {
            FitbitClient.AccessTokenClaimType,
            FitbitClient.RefreshTokenClaimType
          };

        foreach (var claim in claims)
        {
          if (!user.HasClaim(c => c.Type == claim))
          {
            throw new ArgumentException(string.Format("The {0} claim is missing.", claim));
          }
        }
      }
    }

    /// <summary>
    /// Gets a <see cref="FitbitApiResponse"/> for a given <see cref="IFitbitRequest"/>.
    /// </summary>
    /// <param name="request">A <see cref="IFitbitRequest"/>.</param>
    /// <remarks>The <see cref="IFitbitRequest"/> will not be validated.</remarks>
    public FitbitApiResponse GetFitbitApiResponse(IFitbitRequest request)
    {
      if (request == null)
      {
        throw new ArgumentNullException("request");
      }

      return this.MakeRequest(request);
    }

    /// <summary>
    /// Gets food or water time series data in the specified range for a given resource.
    /// </summary>
    /// <param name="request">A <see cref="GetFoodOrWaterTimeSeriesFitbitRequest"/>.</param>
    /// <returns>A <see cref="GetFoodOrWaterTimeSeriesFitbitResponse"/>.</returns>
    public GetFoodOrWaterTimeSeriesFitbitResponse GetFoodOrWaterTimeSeries(
      GetFoodOrWaterTimeSeriesFitbitRequest request)
    {
      if (request == null)
      {
        throw new ArgumentNullException("request");
      }

      if (request.Resource == GetFoodOrWaterTimeSeriesResource.None)
      {
        throw new ArgumentException("You must specify a food or water resource.");
      }

      if (!request.EndDate.HasValue && request.Period == GetFoodOrWaterTimeSeriesPeriod.None)
      {
        throw new ArgumentException("You must specify either an end date or a period.");
      }

      if (string.IsNullOrWhiteSpace(request.UserId))
      {
        request.UserId = FitbitUser.Current.ToString();
      }

      var response = this.MakeRequest(request);

      return new GetFoodOrWaterTimeSeriesFitbitResponse(
        response.StatusCode,
        response.Response
      );
    }

    /// <summary>
    /// Adds a notification subscription.
    /// </summary>
    /// <param name="request">A <see cref="AddSubscriptionFitbitRequest"/>.</param>
    /// <returns>A <see cref="AddSubscriptionFitbitResponse"/>.</returns>
    public AddSubscriptionFitbitResponse AddSubscription(AddSubscriptionFitbitRequest request)
    {
      if (request == null)
      {
        throw new ArgumentNullException("request");
      }

      if (string.IsNullOrWhiteSpace(request.SubscriptionId))
      {
        throw new ArgumentException("You must specify a subscription ID.");
      }

      var response = this.MakeRequest(request);

      return new AddSubscriptionFitbitResponse(
        response.StatusCode,
        response.Response
      );
    }

    /// <summary>
    /// Gets activity time series data in the specified range for a given resource.
    /// </summary>
    /// <param name="request">A <see cref="GetActivityTimeSeriesFitbitRequest"/>.</param>
    /// <returns>A <see cref="GetActivityTimeSeriesFitbitResponse"/>.</returns>
    public GetActivityTimeSeriesFitbitResponse GetActivityTimeSeries(
      GetActivityTimeSeriesFitbitRequest request)
    {
      if (request == null)
      {
        throw new ArgumentNullException("request");
      }

      if (request.Resource == GetActivityTimeSeriesResource.None)
      {
        throw new ArgumentException("You must specify an activity resource.");
      }

      if (!request.EndDate.HasValue && request.Period == GetActivityTimeSeriesPeriod.None)
      {
        throw new ArgumentException("You must specify either an end date or a period.");
      }

      if (string.IsNullOrWhiteSpace(request.UserId))
      {
        request.UserId = FitbitUser.Current.ToString();
      }

      var response = this.MakeRequest(request);

      return new GetActivityTimeSeriesFitbitResponse(
        response.StatusCode,
        response.Response
      );
    }

    /// <summary>
    /// Gets a summary and list of a user's activities and activity log
    /// entries for a given day.
    /// </summary>
    /// <param name="request">A <see cref="GetDailyActivitySummaryFitbitRequest"/>.</param>
    /// <returns>A <see cref="GetDailyActivitySummaryFitbitResponse"/>.</returns>
    public GetDailyActivitySummaryFitbitResponse GetDailyActivitySummary(
      GetDailyActivitySummaryFitbitRequest request)
    {
      if (request == null)
      {
        throw new ArgumentNullException("request");
      }

      if (string.IsNullOrWhiteSpace(request.UserId))
      {
        request.UserId = FitbitUser.Current.ToString();
      }

      var response = this.MakeRequest(request);

      return new GetDailyActivitySummaryFitbitResponse(
        response.StatusCode,
        response.Response
      );
    }

    /// <summary>
    ///  Gets the intraday time series for a given resource.
    /// </summary>
    public void GetActivityIntradayTimeSeries()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    ///  Creates a log entry for an activity or user's private custom activity.
    /// </summary>
    public void LogActivity()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a user's activity log entry with the given ID
    /// </summary>
    public void DeleteActivityLog()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of a user's activity log entries before or after a given day.
    /// </summary>
    public void GetActivityLogsList()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the details of a user's location and heart rate data during a logged exercise
    /// activity.
    /// </summary>
    public void GetActivityTcx()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Get a tree of all valid Fitbit public activities from the activities catalog as well as
    /// private custom activities.
    /// </summary>
    public void BrowseActivityTypes()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the details of a specific activity in the Fitbit activities database.
    /// </summary>
    public void GetActivityType()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of a user's frequent activities.
    /// </summary>
    public void GetFrequentActivities()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of a user's recent activities types logged with some details of the last
    /// activity log of that type.
    /// </summary>
    public void GetRecentActivityTypes()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of a user's favorite activities.
    /// </summary>
    public void GetFavoriteActivities()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Adds the activity with the given ID to user's list of favorite activities.
    /// </summary>
    public void AddFavoriteActivity()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Removes the activity with the given ID from a user's list of favorite activities.
    /// </summary>
    public void DeleteFavoriteActivity()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a user's current daily or weekly activity goals.
    /// </summary>
    public void GetActivityGoals()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates or updates a user's daily activity goals.
    /// </summary>
    public void UpdateActivityGoals()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the user's activity statistics. Activity statistics includes lifetime and best
    /// achievement values.
    /// </summary>
    public void GetLifetimeStats()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of all user's body fat log entries for a given day.
    /// </summary>
    public void GetBodyFatLogs()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a log entry for body fat.
    /// </summary>
    public void LogBodyFat()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a user's body fat log entry with the given ID.
    /// </summary>
    public void DeleteBodyFatLog()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets body time series data in the specified range for a given resource.
    /// </summary>
    public void GetBodyTimeSeries()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a user's current body fat percentage or weight goal.
    /// </summary>
    public void GetBodyGoals()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates or updates user's fat percentage goal.
    /// </summary>
    public void UpdateBodyFatGoal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates or updates user's fat or weight goal.
    /// </summary>
    public void UpdateWeightGoal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of all user's body weight log entries for a given day.
    /// </summary>
    public void GetWeightLogs()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates log entry for a body weight.
    /// </summary>
    public void LogWeight()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a user's body weight log entry with the given ID.
    /// </summary>
    public void DeleteWeightLog()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of the Fitbit devices connected to a user's account.
    /// </summary>
    public void GetDevices()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of the set alarms connected to a user's account.
    /// </summary>
    public void GetAlarms()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Adds the alarm settings to a given ID for a given device.
    /// </summary>
    public void AddAlarm()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the alarm entry with a given ID for a given device.
    /// </summary>
    public void UpdateAlarm()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the user's device alarm entry with the given ID for a given device.
    /// </summary>
    public void DeleteAlarm()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the food locales that the user may choose to search, log, and create food in.
    /// </summary>
    public void GetFoodLocales()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a user's current daily calorie consumption goal and/or food plan.
    /// </summary>
    public void GetFoodGoals()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a summary and list of a user's food log entries for a given day.
    /// </summary>
    public void GetFoodLogs()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a summary and list of a user's water log entries for a given day.
    /// </summary>
    public void GetWaterLogs()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a user's current daily water consumption goal.
    /// </summary>
    public void GetWaterGoal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Changes the quantity or calories consumed for a user's food log entry with the given ID.
    /// </summary>
    public void EditFoodLog()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a log entry for water.
    /// </summary>
    public void LogWater()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates or creates a user's daily calorie consumption goal or food plan.
    /// </summary>
    public void UpdateFoodGoal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates or creates a user's daily calorie consumption goal or food plan.
    /// </summary>
    public void UpdateWaterGoal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a user's food log entry with the given ID.
    /// </summary>
    public void DeleteFoodLog()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a user's food log entry with the given ID.
    /// </summary>
    public void UpdateWaterLog()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a user's water log entry with the given ID.
    /// </summary>
    public void DeleteWaterLog()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of a user's favorite foods.
    /// </summary>
    public void GetFavoriteFoods()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of a user's frequent foods.
    /// </summary>
    public void GetFrequentFoods()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of a user's recent foods.
    /// </summary>
    public void GetRecentFoods()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a food with the given ID to the user's list of favorite foods.
    /// </summary>
    public void AddFavoriteFood()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a food with the given ID to the user's list of favorite foods.
    /// </summary>
    public void DeleteFavoriteFood()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of meals created by user in his or her food log.
    /// </summary>
    public void GetMeals()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a meal with the given food.
    /// </summary>
    public void CreateMeal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a meal for a user given the meal ID.
    /// </summary>
    public void GetMeal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Replaces an existing meal.
    /// </summary>
    public void EditMeal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a user's meal with the given meal ID.
    /// </summary>
    public void DeleteMeal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a new private food for a user.
    /// </summary>
    public void CreateFood()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes custom food for a user.
    /// </summary>
    public void DeleteCustomFood()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the details of a specific food in the Fitbit food database or a private food the
    /// authorized user has entered.
    /// </summary>
    public void GetFood()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of all valid Fitbit food units.
    /// </summary>
    public void GetFoodUnits()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of public foods from Fitbit foods database and private foods the user created.
    /// </summary>
    public void SearchFoods()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets data of a user's friends.
    /// </summary>
    public void GetFriends()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the user's friends leaderboard.
    /// </summary>
    public void GetFriendsLeaderboard()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates an invitation to become friends with the authorized user.
    /// </summary>
    public void InviteFriend()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of invitations to become friends with a user.
    /// </summary>
    public void GetFriendInvitations()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Accepts or rejects an invitation to become friends with inviting user.
    /// </summary>
    public void RespondToFriendInvitation()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the heart rate time series data in the specified range.
    /// </summary>
    public void GetHeartRateTimeSeries()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the heart rate intraday time series for a given resource.
    /// </summary>
    public void GetHeartRateIntradayTimeSeries()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a summary and list of a user's sleep log entries as well as minute by minute sleep
    /// entry data for a given day.
    /// </summary>
    public void GetSleepLogs()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a user's current sleep goal.
    /// </summary>
    public void GetSleepGoal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates or updates a user's sleep goal.
    /// </summary>
    public void UpdateSleepGoal()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets sleep time series data in the specified range for a given resource.
    /// </summary>
    public void GetSleepTimeSeries()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a log entry for a sleep event.
    /// </summary>
    public void LogSleep()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a user's sleep log entry.
    /// </summary>
    public void DeleteSleepLog()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a subscription for a user.
    /// </summary>
    public void DeleteSubscription()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a list of a user's subscriptions for your application.
    /// </summary>
    public void GetSubscriptions()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a user's profile.
    /// </summary>
    public void GetProfile()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a user's profile.
    /// </summary>
    public void UpdateProfile()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a user's badges.
    /// </summary>
    /// <param name="request">A <see cref="GetBadgesFitbitRequest"/>.</param>
    /// <returns>A <see cref="GetBadgesFitbitResponse"/>.</returns>
    public GetBadgesFitbitResponse GetBadges(GetBadgesFitbitRequest request)
    {
      if (request == null)
      {
        throw new ArgumentNullException("request");
      }

      if (string.IsNullOrWhiteSpace(request.UserId))
      {
        request.UserId = FitbitUser.Current.ToString();
      }

      var response = this.MakeRequest(request);

      return new GetBadgesFitbitResponse(response.StatusCode, response.Response);
    }

    /// <summary>
    /// Makes a request to the Fitbit API.
    /// </summary>
    /// <param name="request">An <see cref="IFitbitRequest"/>.</param>
    /// <returns>An <see cref="FitbitApiResponse"/>.</returns>
    private FitbitApiResponse MakeRequest(IFitbitRequest request)
    {
      var accessToken = string.Empty;

      if (this.user != null)
      {
        accessToken = this.user.TryGetClaimValue(FitbitClient.AccessTokenClaimType);
      }

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(this.apiBaseAddress);

        client.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue("Bearer", accessToken);

        foreach(var header in request.GetHeaders())
        {
          client.DefaultRequestHeaders.TryAddWithoutValidation(header.Name, header.Value);
        }

        HttpResponseMessage result;

        if (request.Action == FitbitRequestAction.Get)
        {
          result = client.GetAsync(request.GetUri()).Result;
        }
        else if (request.Action == FitbitRequestAction.Post)
        {
          result = client.PostAsync(request.GetUri(), null).Result;
        }
        else
        {
          throw new ArgumentOutOfRangeException("request.Action");
        }

        var response =
          new FitbitApiResponse(result.StatusCode, result.Content.ReadAsStringAsync().Result);

        // The access token probably needs refreshing. If this is
        // the first attempt then try the refresh token.
        if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
          if (!request.SupressTokenRefresh)
          {
            // Only try to get a refresh token once...
            request.SupressTokenRefresh = true;

            if (this.TryRefreshAccessToken(out response))
            {
              return this.MakeRequest(request);
            }
          }
        }

        return response;
      }
    }

    /// <summary>
    /// Attempts to refresh the access token.
    /// </summary>
    /// <param name="response">The <see cref="FitbitApiResponse"/>.</param>
    /// <returns>If successful, true. Otherwise, false.</returns>
    private bool TryRefreshAccessToken(out FitbitApiResponse response)
    {
      var refreshToken = string.Empty;

      if (this.user != null)
      {
        refreshToken = this.user.TryGetClaimValue(FitbitClient.RefreshTokenClaimType);
      }

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(this.apiBaseAddress);

        client.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue(
            "Basic",
            Encoding.UTF8.EncodeBase64(
              string.Format("{0}:{1}", this.clientId, this.clientSecret)
            )
          );

        // Build the request.
        var request = new HttpRequestMessage(HttpMethod.Post, "/oauth2/token");
        {
          var parameters = new List<KeyValuePair<String, String>>();
          {
            parameters.Add(
              new KeyValuePair<String, String>("grant_type", "refresh_token")
            );

            parameters.Add(
              new KeyValuePair<String, String>("refresh_token", refreshToken)
            );
          }

          request.Content = new FormUrlEncodedContent(parameters);
        }

        var result =
          client.SendAsync(request).Result;

        response =
          new FitbitApiResponse(result.StatusCode, result.Content.ReadAsStringAsync().Result);

        if (response.StatusCode == HttpStatusCode.OK)
        {
          if (response.Response != null)
          {
            var schema = JSchema.Parse(Resources.RefreshAccessTokenSchema);

            if (response.Response.IsValid(schema))
            {
              dynamic data = response.Response;

              this.user.AddOrUpdateClaim(
                FitbitClient.AccessTokenClaimType,
                (string)data.access_token
              );

              this.user.AddOrUpdateClaim(
                FitbitClient.RefreshTokenClaimType,
                (string)data.refresh_token
              );

              return true;
            }
          }
        }

        return false;
      }
    }
  }
}