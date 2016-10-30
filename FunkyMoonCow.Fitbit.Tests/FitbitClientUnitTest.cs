using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
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
  }
}
