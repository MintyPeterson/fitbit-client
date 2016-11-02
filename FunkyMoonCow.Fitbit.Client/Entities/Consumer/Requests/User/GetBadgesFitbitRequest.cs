using System.Collections.Generic;

namespace FunkyMoonCow.Fitbit
{
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
    /// Intialises a new instance of the <see cref="GetBadgesFitbitRequest"/> class.
    /// </summary>
    public GetBadgesFitbitRequest()
    {
      this.UserId = FitbitUser.Current.ToString();
    }

    /// <summary>
    /// Gets the endpoint URI.
    /// </summary>
    /// <returns>The URI.</returns>
    public override string GetUri()
    {
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