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
  /// <see cref="FitbitClient.GetActivityTimeSeries(GetActivityTimeSeriesFitbitRequest)"/>.
  /// </summary>
  public class GetActivityTimeSeriesFitbitResponse : FitbitResponse
  {
    /// <summary>
    /// Gets the <see cref="IEnumerable{ActivityTimeSeriesFitbitResponseLog}"/>.
    /// </summary>
    public IEnumerable<GetActivityTimeSeriesFitbitResponseLog> Log { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="GetActivityTimeSeriesFitbitResponse"/>
    /// class.
    /// </summary>
    public GetActivityTimeSeriesFitbitResponse(HttpStatusCode statusCode, JObject response)
      : base(statusCode, response)
    {
      this.Log = Enumerable.Empty<GetActivityTimeSeriesFitbitResponseLog>();

      if (!this.Errors.Any())
      {
        // Attempt to process the response.
        this.ParseResponse();
      }
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

      if (this.Response.First == null || this.Response.First.First == null)
      {
        this.AddUnexpectedInvalidResponseError();

        return;
      }

      var schema = JSchema.Parse(Resources.GetActivityTimeSeriesSchema);

      if (!this.Response.First.First.IsValid(schema))
      {
        this.AddUnexpectedInvalidResponseError();

        return;
      }

      dynamic response = this.Response.First.First;

      var log = new List<GetActivityTimeSeriesFitbitResponseLog>();
      {
        foreach (var result in response)
        {
          log.Add(
            new GetActivityTimeSeriesFitbitResponseLog
            {
              Date = result.dateTime,
              Value = result.value
            }
          );
        }
      }

      // Trim the start of the log (where the value is 0).
      // The FitBit API returns a log of data with a 0 value when
      // maximum is specified?
      var firstWithValue = log.FindIndex(l => l.Value != 0);

      if (firstWithValue != -1)
      {
        log.RemoveRange(0, firstWithValue);
      }

      this.Log = log;
    }
  }

  /// <summary>
  /// Represents a log in a <see cref="GetActivityTimeSeriesFitbitResponse"/>.
  /// </summary>
  public class GetActivityTimeSeriesFitbitResponseLog
  {
    /// <summary>
    /// Gets or sets the <see cref="DateTime.Date"/>.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public long Value { get; set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="GetActivityTimeSeriesFitbitResponseLog"/>
    /// class.
    /// </summary>
    public GetActivityTimeSeriesFitbitResponseLog()
    {
    }
  }
}