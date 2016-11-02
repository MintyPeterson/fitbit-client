
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a state.
  /// </summary>
  public sealed class FitbitState
  {
    /// <summary>
    /// Stores the state.
    /// </summary>
    private readonly string state;

    /// <summary>
    /// Alabama.
    /// </summary>
    public static readonly FitbitState Alabama = new FitbitState("AL");

    /// <summary>
    /// Alaska.
    /// </summary>
    public static readonly FitbitState Alaska = new FitbitState("AK");

    /// <summary>
    /// Arizona.
    /// </summary>
    public static readonly FitbitState Arizona = new FitbitState("AZ");

    /// <summary>
    /// Arkansas.
    /// </summary>
    public static readonly FitbitState Arkansas = new FitbitState("AR");

    /// <summary>
    /// California.
    /// </summary>
    public static readonly FitbitState California = new FitbitState("CA");

    /// <summary>
    /// Colorado.
    /// </summary>
    public static readonly FitbitState Colorado = new FitbitState("CO");

    /// <summary>
    /// Connecticut.
    /// </summary>
    public static readonly FitbitState Connecticut = new FitbitState("CT");

    /// <summary>
    /// Delaware.
    /// </summary>
    public static readonly FitbitState Delaware = new FitbitState("DE");

    /// <summary>
    /// Florida.
    /// </summary>
    public static readonly FitbitState Florida = new FitbitState("FL");

    /// <summary>
    /// Georgia.
    /// </summary>
    public static readonly FitbitState Georgia = new FitbitState("GA");

    /// <summary>
    /// Hawaii.
    /// </summary>
    public static readonly FitbitState Hawaii = new FitbitState("HI");

    /// <summary>
    /// Idaho.
    /// </summary>
    public static readonly FitbitState Idaho = new FitbitState("ID");

    /// <summary>
    /// Illinois.
    /// </summary>
    public static readonly FitbitState Illinois = new FitbitState("IL");

    /// <summary>
    /// Indiana.
    /// </summary>
    public static readonly FitbitState Indiana = new FitbitState("IN");

    /// <summary>
    /// Iowa.
    /// </summary>
    public static readonly FitbitState Iowa = new FitbitState("IA");

    /// <summary>
    /// Kansas.
    /// </summary>
    public static readonly FitbitState Kansas = new FitbitState("KS");

    /// <summary>
    /// Kentucky.
    /// </summary>
    public static readonly FitbitState Kentucky = new FitbitState("KY");

    /// <summary>
    /// Louisiana.
    /// </summary>
    public static readonly FitbitState Louisiana = new FitbitState("LA");

    /// <summary>
    /// Maine.
    /// </summary>
    public static readonly FitbitState Maine = new FitbitState("ME");

    /// <summary>
    /// Maryland.
    /// </summary>
    public static readonly FitbitState Maryland = new FitbitState("MD");

    /// <summary>
    /// Massachusetts.
    /// </summary>
    public static readonly FitbitState Massachusetts = new FitbitState("MA");

    /// <summary>
    /// Michigan.
    /// </summary>
    public static readonly FitbitState Michigan = new FitbitState("MI");

    /// <summary>
    /// Minnesota.
    /// </summary>
    public static readonly FitbitState Minnesota = new FitbitState("MN");

    /// <summary>
    /// Mississippi.
    /// </summary>
    public static readonly FitbitState Mississippi = new FitbitState("MS");

    /// <summary>
    /// Missouri.
    /// </summary>
    public static readonly FitbitState Missouri = new FitbitState("MO");

    /// <summary>
    /// Montana.
    /// </summary>
    public static readonly FitbitState Montana = new FitbitState("MT");

    /// <summary>
    /// Nebraska.
    /// </summary>
    public static readonly FitbitState Nebraska = new FitbitState("NE");

    /// <summary>
    /// Nevada.
    /// </summary>
    public static readonly FitbitState Nevada = new FitbitState("NV");

    /// <summary>
    /// New Hampshire.
    /// </summary>
    public static readonly FitbitState NewHampshire = new FitbitState("NH");

    /// <summary>
    /// New Jersey.
    /// </summary>
    public static readonly FitbitState NewJersey = new FitbitState("NJ");

    /// <summary>
    /// New Mexico.
    /// </summary>
    public static readonly FitbitState NewMexico = new FitbitState("NM");

    /// <summary>
    /// New York.
    /// </summary>
    public static readonly FitbitState NewYork = new FitbitState("NY");

    /// <summary>
    /// North Carolina.
    /// </summary>
    public static readonly FitbitState NorthCarolina = new FitbitState("NC");

    /// <summary>
    /// North Dakota.
    /// </summary>
    public static readonly FitbitState NorthDakota = new FitbitState("ND");

    /// <summary>
    /// Ohio.
    /// </summary>
    public static readonly FitbitState Ohio = new FitbitState("OH");

    /// <summary>
    /// Oklahoma.
    /// </summary>
    public static readonly FitbitState Oklahoma = new FitbitState("OK");

    /// <summary>
    /// Oregon.
    /// </summary>
    public static readonly FitbitState Oregon = new FitbitState("OR");

    /// <summary>
    /// Pennsylvania.
    /// </summary>
    public static readonly FitbitState Pennsylvania = new FitbitState("PA");

    /// <summary>
    /// Rhode Island.
    /// </summary>
    public static readonly FitbitState RhodeIsland = new FitbitState("RI");

    /// <summary>
    /// South Carolina.
    /// </summary>
    public static readonly FitbitState SouthCarolina = new FitbitState("SC");

    /// <summary>
    /// South Dakota.
    /// </summary>
    public static readonly FitbitState SouthDakota = new FitbitState("SD");

    /// <summary>
    /// Tennessee.
    /// </summary>
    public static readonly FitbitState Tennessee = new FitbitState("TN");

    /// <summary>
    /// Texas.
    /// </summary>
    public static readonly FitbitState Texas = new FitbitState("TX");

    /// <summary>
    /// Utah.
    /// </summary>
    public static readonly FitbitState Utah = new FitbitState("UT");

    /// <summary>
    /// Vermont.
    /// </summary>
    public static readonly FitbitState Vermont = new FitbitState("VT");

    /// <summary>
    /// Virginia.
    /// </summary>
    public static readonly FitbitState Virginia = new FitbitState("VA");

    /// <summary>
    /// Washington.
    /// </summary>
    public static readonly FitbitState Washington = new FitbitState("WA");

    /// <summary>
    /// West Virginia.
    /// </summary>
    public static readonly FitbitState WestVirginia = new FitbitState("WV");

    /// <summary>
    /// Wisconsin.
    /// </summary>
    public static readonly FitbitState Wisconsin = new FitbitState("WI");

    /// <summary>
    /// Wyoming.
    /// </summary>
    public static readonly FitbitState Wyoming = new FitbitState("WY");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitState"/> class.
    /// </summary>
    /// <param name="state">The state.</param>
    private FitbitState(string state)
    {
      this.state = state;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="StateInfo"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.state;
    }
  }
}