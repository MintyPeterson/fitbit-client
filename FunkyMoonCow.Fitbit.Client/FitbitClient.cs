using FunkyMoonCow.Fitbit.Properties;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
    /// Gets a <see cref="FitbitResponse"/> for a given <see cref="IFitbitRequest"/>.
    /// </summary>
    /// <param name="request">A <see cref="IFitbitRequest"/>.</param>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="IFitbitRequest"/>
    /// does not contain the required properties.</exception>
    public FitbitResponse GetResponse(IFitbitRequest request)
    {
      if (request == null)
      {
        throw new ArgumentNullException("request");
      }

      return this.MakeRequest(request);
    }

    /// <summary>
    /// Makes a request to the Fitbit API.
    /// </summary>
    /// <param name="request">An <see cref="IFitbitRequest"/>.</param>
    /// <returns>An <see cref="FitbitResponse"/>.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="IFitbitRequest"/>
    /// does not contain the required properties.</exception>
    private FitbitResponse MakeRequest(IFitbitRequest request)
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
          new FitbitResponse(result.StatusCode, result.Content.ReadAsStringAsync().Result);

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
    /// <param name="response">The <see cref="FitbitResponse"/>.</param>
    /// <returns>If successful, true. Otherwise, false.</returns>
    private bool TryRefreshAccessToken(out FitbitResponse response)
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
          new FitbitResponse(result.StatusCode, result.Content.ReadAsStringAsync().Result);

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