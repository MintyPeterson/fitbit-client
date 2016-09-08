using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Provides extension methods for the <see cref="Encoding"/> class.
  /// </summary>
  public static class Extensions
  {
    /// <summary>
    /// Returns a base64 encoded representation of a <see cref="String"/>.
    /// </summary>
    /// <param name="text">The text to encode.</param>
    /// <returns>A base64 encoded <see cref="String"/>.</returns>
    public static string EncodeBase64(this Encoding encoding, string text)
    {
      if (text == null)
      {
        return null;
      }

      return Convert.ToBase64String(encoding.GetBytes(text));
    }
    
    /// <summary>
    /// Adds or updates a <see cref="Claim"/>.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public static void AddOrUpdateClaim(this ClaimsIdentity identity, string key, string value)
    {
      var existingClaim = identity.FindFirst(key);

      if (existingClaim != null)
      {
        identity.RemoveClaim(existingClaim);
      }

      identity.AddClaim(new Claim(key, value));

      var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
      {
        authenticationManager.AuthenticationResponseGrant =
          new AuthenticationResponseGrant(
            new ClaimsPrincipal(identity),
            new AuthenticationProperties
            {
              IsPersistent = true
            }
          );
      }
    }

    /// <summary>
    /// Attempts to get a <see cref="Claim"/> value.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>A <see cref="Claim"/> value.</returns>
    public static string TryGetClaimValue(this ClaimsIdentity identity, string key)
    {
      var claim = identity.Claims.FirstOrDefault(c => c.Type == key);

      if (claim == null)
      {
        return string.Empty;
      }

      return claim.Value;
    }
  }
}