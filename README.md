## A .NET FITBIT® client
A C# client for the FITBIT® API.
### Authentication
Before using the client, you must authenticate against the FITBIT® API using OAUTH 2.0. You can do this using OWIN and the `Owin.Security.Providers.Fitbit` authentication provider. For an implementation guide, please see https://github.com/TerribleDev/OwinOAuthProviders.
### Usage
The client expects the FITBIT® API access and refresh tokens to be passed as part of a `ClaimsIdentity` object, which will be updated as the tokens change. The claim types can be found in `FitbitClient.AccessTokenClaimType` and `FitbitClient.RefreshTokenClaimType`.
```cs
var identity = new ClaimsIdentity();
{
  identity.AddClaim(new Claim(FitbitClient.AccessTokenClaimType, "AccessToken"));
  identity.AddClaim(new Claim(FitbitClient.RefreshTokenClaimType, "RefreshToken"));
}

var client = new FitbitClient(identity);
```
Once the client has been instantiated, you can send a request to the FITBIT® API using `GetResponse`. The `GetResponse` method takes a single `IFitbitRequest` parameter, which defines the action type, resource, and headers. You can create a concrete object for the desired API resource by inheriting from `FitbitRequest`.
```cs
/// <summary>
/// Provides a <see cref="FitbitRequest"/> for getting a user's badges.
/// </summary>
public class GetBadgesFitbitRequest : FitbitRequest
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
  /// Gets the HTTP action (verb) for this request.
  /// </summary>
  public override FitbitRequestAction Action
  {
    get
    {
      return FitbitRequestAction.Get;
    }
  }
    
  /// <summary>
  /// Intialises a new instance of the <see cref="GetBadgesFitbitRequest"/> class.
  /// </summary>
  public GetBadgesFitbitRequest()
  {
  }

  /// <summary>
  /// Gets the endpoint URI.
  /// </summary>
  /// <returns>The URI.</returns>
  public override string GetUri()
  {
    if (string.IsNullOrWhiteSpace(this.UserId))
    {
      this.UserId = FitbitUser.Current.ToString();
    }

    return string.Format("/1/user/{0}/badges.json", this.UserId);
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
      headers.Add(new FitbitRequestHeader("Accept-Language", this.Units.ToString()));
    }

    return headers;
  }
}
```
Finally, you can use this class to perform the request.
```cs
FitbitResponse response = client.GetResponse(new GetBadgesFitbitRequest());
```
The `FitbitResponse` will contain a number of properties representing the status and content of the response.

| Property      | Description                                          |
|---------------|------------------------------------------------------|
| `StatusCode`  | The HTTP status code.                                |
| `RawResponse` | The response as a `string`.                          |
| `Response`    | The response as a `JToken`.                          |
| `Errors`      | An `IEnumerable` collection of errors.               |
| `HasErrors`   | A value indicating if any errors have been returned. |
