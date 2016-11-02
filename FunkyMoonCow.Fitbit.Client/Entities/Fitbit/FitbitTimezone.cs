
namespace FunkyMoonCow.Fitbit
{
  /// <summary>
  /// Specifies a timezone.
  /// </summary>
  public sealed class FitbitTimezone
  {
    /// <summary>
    /// Stores the timezone.
    /// </summary>
    private readonly string timezone;

    /// <summary>
    /// Pacific/Midway.
    /// </summary>
    public static readonly FitbitTimezone PacificMidway = new FitbitTimezone("Pacific/Midway");

    /// <summary>
    /// Pacific/Pago_Pago.
    /// </summary>
    public static readonly FitbitTimezone PacificPagoPago =
      new FitbitTimezone("Pacific/Pago_Pago");

    /// <summary>
    /// Pacific/Honolulu.
    /// </summary>
    public static readonly FitbitTimezone PacificHonolulu = new FitbitTimezone("Pacific/Honolulu");

    /// <summary>
    /// America/Anchorage.
    /// </summary>
    public static readonly FitbitTimezone AmericaAnchorage =
      new FitbitTimezone("America/Anchorage");

    /// <summary>
    /// America/Phoenix.
    /// </summary>
    public static readonly FitbitTimezone AmericaPhoenix = new FitbitTimezone("America/Phoenix");

    /// <summary>
    /// America/Chihuahua.
    /// </summary>
    public static readonly FitbitTimezone AmericaChihuahua =
      new FitbitTimezone("America/Chihuahua");

    /// <summary>
    /// America/Dawson.
    /// </summary>
    public static readonly FitbitTimezone AmericaDawson = new FitbitTimezone("America/Dawson");

    /// <summary>
    /// America/Mazatlan.
    /// </summary>
    public static readonly FitbitTimezone AmericaMazatlan = new FitbitTimezone("America/Mazatlan");

    /// <summary>
    /// America/Los_Angeles.
    /// </summary>
    public static readonly FitbitTimezone AmericaLosAngeles =
      new FitbitTimezone("America/Los_Angeles");

    /// <summary>
    /// America/Tijuana.
    /// </summary>
    public static readonly FitbitTimezone AmericaTijuana = new FitbitTimezone("America/Tijuana");

    /// <summary>
    /// America/Vancouver.
    /// </summary>
    public static readonly FitbitTimezone AmericaVancouver =
      new FitbitTimezone("America/Vancouver");

    /// <summary>
    /// America/Bahia_Banderas.
    /// </summary>
    public static readonly FitbitTimezone AmericaBahiaBanderas =
      new FitbitTimezone("America/Bahia_Banderas");

    /// <summary>
    /// America/Boise.
    /// </summary>
    public static readonly FitbitTimezone AmericaBoise = new FitbitTimezone("America/Boise");

    /// <summary>
    /// America/Guatemala.
    /// </summary>
    public static readonly FitbitTimezone AmericaGuatemala =
      new FitbitTimezone("America/Guatemala");

    /// <summary>
    /// America/Costa_Rica.
    /// </summary>
    public static readonly FitbitTimezone AmericaCostaRica =
      new FitbitTimezone("America/Costa_Rica");

    /// <summary>
    /// America/Edmonton.
    /// </summary>
    public static readonly FitbitTimezone AmericaEdmonton = new FitbitTimezone("America/Edmonton");

    /// <summary>
    /// America/Mexico_City.
    /// </summary>
    public static readonly FitbitTimezone AmericaMexicoCity =
      new FitbitTimezone("America/Mexico_City");

    /// <summary>
    /// America/Monterrey.
    /// </summary>
    public static readonly FitbitTimezone AmericaMonterrey =
      new FitbitTimezone("America/Monterrey");

    /// <summary>
    /// America/Denver.
    /// </summary>
    public static readonly FitbitTimezone AmericaDenver = new FitbitTimezone("America/Denver");

    /// <summary>
    /// America/Regina.
    /// </summary>
    public static readonly FitbitTimezone AmericaRegina = new FitbitTimezone("America/Regina");

    /// <summary>
    /// America/Atikokan.
    /// </summary>
    public static readonly FitbitTimezone AmericaAtikokan = new FitbitTimezone("America/Atikokan");

    /// <summary>
    /// America/Bogota.
    /// </summary>
    public static readonly FitbitTimezone AmericaBogota = new FitbitTimezone("America/Bogota");

    /// <summary>
    /// America/Cancun.
    /// </summary>
    public static readonly FitbitTimezone AmericaCancun = new FitbitTimezone("America/Cancun");

    /// <summary>
    /// America/Chicago.
    /// </summary>
    public static readonly FitbitTimezone AmericaChicago = new FitbitTimezone("America/Chicago");

    /// <summary>
    /// America/Jamaica.
    /// </summary>
    public static readonly FitbitTimezone AmericaJamaica = new FitbitTimezone("America/Jamaica");

    /// <summary>
    /// America/Lima.
    /// </summary>
    public static readonly FitbitTimezone AmericaLima = new FitbitTimezone("America/Lima");

    /// <summary>
    /// America/Panama.
    /// </summary>
    public static readonly FitbitTimezone AmericaPanama = new FitbitTimezone("America/Panama");

    /// <summary>
    /// America/Guayaquil.
    /// </summary>
    public static readonly FitbitTimezone AmericaGuayaquil =
      new FitbitTimezone("America/Guayaquil");

    /// <summary>
    /// America/Winnipeg.
    /// </summary>
    public static readonly FitbitTimezone AmericaWinnipeg = new FitbitTimezone("America/Winnipeg");

    /// <summary>
    /// America/Caracas.
    /// </summary>
    public static readonly FitbitTimezone AmericaCaracas = new FitbitTimezone("America/Caracas");

    /// <summary>
    /// America/Detroit.
    /// </summary>
    public static readonly FitbitTimezone AmericaDetroit = new FitbitTimezone("America/Detroit");

    /// <summary>
    /// America/New_York.
    /// </summary>
    public static readonly FitbitTimezone AmericaNewYork = new FitbitTimezone("America/New_York");

    /// <summary>
    /// America/Guyana.
    /// </summary>
    public static readonly FitbitTimezone AmericaGuyana = new FitbitTimezone("America/Guyana");

    /// <summary>
    /// America/Havana.
    /// </summary>
    public static readonly FitbitTimezone AmericaHavana = new FitbitTimezone("America/Havana");

    /// <summary>
    /// America/Indiana/Indianapolis.
    /// </summary>
    public static readonly FitbitTimezone AmericaIndianaIndianapolis =
      new FitbitTimezone("America/Indiana/Indianapolis");

    /// <summary>
    /// America/La_Paz.
    /// </summary>
    public static readonly FitbitTimezone AmericaLaPaz = new FitbitTimezone("America/La_Paz");

    /// <summary>
    /// America/Manaus.
    /// </summary>
    public static readonly FitbitTimezone AmericaManaus = new FitbitTimezone("America/Manaus");

    /// <summary>
    /// America/Montreal.
    /// </summary>
    public static readonly FitbitTimezone AmericaMontreal = new FitbitTimezone("America/Montreal");

    /// <summary>
    /// America/Puerto_Rico.
    /// </summary>
    public static readonly FitbitTimezone AmericaPuertoRico =
      new FitbitTimezone("America/Puerto_Rico");

    /// <summary>
    /// America/Santo_Domingo.
    /// </summary>
    public static readonly FitbitTimezone AmericaSantoDomingo =
      new FitbitTimezone("America/Santo_Domingo");

    /// <summary>
    /// America/Toronto.
    /// </summary>
    public static readonly FitbitTimezone AmericaToronto = new FitbitTimezone("America/Toronto");

    /// <summary>
    /// America/Asuncion.
    /// </summary>
    public static readonly FitbitTimezone AmericaAsuncion = new FitbitTimezone("America/Asuncion");

    /// <summary>
    /// America/Halifax.
    /// </summary>
    public static readonly FitbitTimezone AmericaHalifax = new FitbitTimezone("America/Halifax");

    /// <summary>
    /// Atlantic/Bermuda.
    /// </summary>
    public static readonly FitbitTimezone AtlanticBermuda = new FitbitTimezone("Atlantic/Bermuda");

    /// <summary>
    /// America/Argentina/Buenos_Aires.
    /// </summary>
    public static readonly FitbitTimezone AmericaArgentinaBuenosAires =
      new FitbitTimezone("America/Argentina/Buenos_Aires");

    /// <summary>
    /// America/Campo_Grande.
    /// </summary>
    public static readonly FitbitTimezone AmericaCampoGrande =
      new FitbitTimezone("America/Campo_Grande");

    /// <summary>
    /// America/Argentina/Cordoba.
    /// </summary>
    public static readonly FitbitTimezone AmericaArgentinaCordoba =
      new FitbitTimezone("America/Argentina/Cordoba");

    /// <summary>
    /// America/Fortaleza.
    /// </summary>
    public static readonly FitbitTimezone AmericaFortaleza =
      new FitbitTimezone("America/Fortaleza");

    /// <summary>
    /// America/Godthab.
    /// </summary>
    public static readonly FitbitTimezone AmericaGodthab = new FitbitTimezone("America/Godthab");

    /// <summary>
    /// America/Argentina/Mendoza.
    /// </summary>
    public static readonly FitbitTimezone AmericaArgentinaMendoza =
      new FitbitTimezone("America/Argentina/Mendoza");

    /// <summary>
    /// America/Santiago.
    /// </summary>
    public static readonly FitbitTimezone AmericaSantiago = new FitbitTimezone("America/Santiago");

    /// <summary>
    /// America/St_Johns.
    /// </summary>
    public static readonly FitbitTimezone AmericaStJohns = new FitbitTimezone("America/St_Johns");

    /// <summary>
    /// Atlantic/South_Georgia.
    /// </summary>
    public static readonly FitbitTimezone AtlanticSouthGeorgia =
      new FitbitTimezone("Atlantic/South_Georgia");

    /// <summary>
    /// America/Montevideo.
    /// </summary>
    public static readonly FitbitTimezone AmericaMontevideo =
      new FitbitTimezone("America/Montevideo");

    /// <summary>
    /// America/Sao_Paulo.
    /// </summary>
    public static readonly FitbitTimezone AmericaSaoPaulo =
      new FitbitTimezone("America/Sao_Paulo");

    /// <summary>
    /// Atlantic/Azores.
    /// </summary>
    public static readonly FitbitTimezone AtlanticAzores = new FitbitTimezone("Atlantic/Azores");

    /// <summary>
    /// Atlantic/Cape_Verde.
    /// </summary>
    public static readonly FitbitTimezone AtlanticCapeVerde =
      new FitbitTimezone("Atlantic/Cape_Verde");

    /// <summary>
    /// Africa/Casablanca.
    /// </summary>
    public static readonly FitbitTimezone AfricaCasablanca =
      new FitbitTimezone("Africa/Casablanca");

    /// <summary>
    /// Africa/Abidjan.
    /// </summary>
    public static readonly FitbitTimezone AfricaAbidjan = new FitbitTimezone("Africa/Abidjan");

    /// <summary>
    /// Europe/Dublin.
    /// </summary>
    public static readonly FitbitTimezone EuropeDublin = new FitbitTimezone("Europe/Dublin");

    /// <summary>
    /// Europe/Lisbon.
    /// </summary>
    public static readonly FitbitTimezone EuropeLisbon = new FitbitTimezone("Europe/Lisbon");

    /// <summary>
    /// Europe/London.
    /// </summary>
    public static readonly FitbitTimezone EuropeLondon = new FitbitTimezone("Europe/London");

    /// <summary>
    /// Atlantic/Reykjavik.
    /// </summary>
    public static readonly FitbitTimezone AtlanticReykjavik =
      new FitbitTimezone("Atlantic/Reykjavik");

    /// <summary>
    /// Etc/UTC.
    /// </summary>
    public static readonly FitbitTimezone EtcUtc = new FitbitTimezone("Etc/UTC");

    /// <summary>
    /// Europe/Amsterdam.
    /// </summary>
    public static readonly FitbitTimezone EuropeAmsterdam = new FitbitTimezone("Europe/Amsterdam");

    /// <summary>
    /// Europe/Belgrade.
    /// </summary>
    public static readonly FitbitTimezone EuropeBelgrade = new FitbitTimezone("Europe/Belgrade");

    /// <summary>
    /// Europe/Berlin.
    /// </summary>
    public static readonly FitbitTimezone EuropeBerlin = new FitbitTimezone("Europe/Berlin");

    /// <summary>
    /// Europe/Bratislava.
    /// </summary>
    public static readonly FitbitTimezone EuropeBratislava =
      new FitbitTimezone("Europe/Bratislava");

    /// <summary>
    /// Europe/Brussels.
    /// </summary>
    public static readonly FitbitTimezone EuropeBrussels = new FitbitTimezone("Europe/Brussels");

    /// <summary>
    /// Europe/Budapest.
    /// </summary>
    public static readonly FitbitTimezone EuropeBudapest = new FitbitTimezone("Europe/Budapest");

    /// <summary>
    /// Europe/Copenhagen.
    /// </summary>
    public static readonly FitbitTimezone EuropeCopenhagen =
      new FitbitTimezone("Europe/Copenhagen");

    /// <summary>
    /// Europe/Ljubljana.
    /// </summary>
    public static readonly FitbitTimezone EuropeLjubljana = new FitbitTimezone("Europe/Ljubljana");

    /// <summary>
    /// Europe/Luxembourg.
    /// </summary>
    public static readonly FitbitTimezone EuropeLuxembourg =
      new FitbitTimezone("Europe/Luxembourg");

    /// <summary>
    /// Europe/Madrid.
    /// </summary>
    public static readonly FitbitTimezone EuropeMadrid = new FitbitTimezone("Europe/Madrid");

    /// <summary>
    /// Europe/Oslo.
    /// </summary>
    public static readonly FitbitTimezone EuropeOslo = new FitbitTimezone("Europe/Oslo");

    /// <summary>
    /// Europe/Paris.
    /// </summary>
    public static readonly FitbitTimezone EuropeParis = new FitbitTimezone("Europe/Paris");

    /// <summary>
    /// Europe/Prague.
    /// </summary>
    public static readonly FitbitTimezone EuropePrague = new FitbitTimezone("Europe/Prague");

    /// <summary>
    /// Europe/Rome.
    /// </summary>
    public static readonly FitbitTimezone EuropeRome = new FitbitTimezone("Europe/Rome");

    /// <summary>
    /// Europe/Sarajevo.
    /// </summary>
    public static readonly FitbitTimezone EuropeSarajevo = new FitbitTimezone("Europe/Sarajevo");

    /// <summary>
    /// Europe/Skopje.
    /// </summary>
    public static readonly FitbitTimezone EuropeSkopje = new FitbitTimezone("Europe/Skopje");

    /// <summary>
    /// Europe/Stockholm.
    /// </summary>
    public static readonly FitbitTimezone EuropeStockholm = new FitbitTimezone("Europe/Stockholm");

    /// <summary>
    /// Europe/Tirane.
    /// </summary>
    public static readonly FitbitTimezone EuropeTirane = new FitbitTimezone("Europe/Tirane");

    /// <summary>
    /// Europe/Vienna.
    /// </summary>
    public static readonly FitbitTimezone EuropeVienna = new FitbitTimezone("Europe/Vienna");

    /// <summary>
    /// Europe/Warsaw.
    /// </summary>
    public static readonly FitbitTimezone EuropeWarsaw = new FitbitTimezone("Europe/Warsaw");

    /// <summary>
    /// Africa/Lagos.
    /// </summary>
    public static readonly FitbitTimezone AfricaLagos = new FitbitTimezone("Africa/Lagos");

    /// <summary>
    /// Europe/Zagreb.
    /// </summary>
    public static readonly FitbitTimezone EuropeZagreb = new FitbitTimezone("Europe/Zagreb");

    /// <summary>
    /// Europe/Zurich.
    /// </summary>
    public static readonly FitbitTimezone EuropeZurich = new FitbitTimezone("Europe/Zurich");

    /// <summary>
    /// Europe/Athens.
    /// </summary>
    public static readonly FitbitTimezone EuropeAthens = new FitbitTimezone("Europe/Athens");

    /// <summary>
    /// Asia/Beirut.
    /// </summary>
    public static readonly FitbitTimezone AsiaBeirut = new FitbitTimezone("Asia/Beirut");

    /// <summary>
    /// Europe/Bucharest.
    /// </summary>
    public static readonly FitbitTimezone EuropeBucharest = new FitbitTimezone("Europe/Bucharest");

    /// <summary>
    /// Africa/Cairo.
    /// </summary>
    public static readonly FitbitTimezone AfricaCairo = new FitbitTimezone("Africa/Cairo");

    /// <summary>
    /// Africa/Maputo.
    /// </summary>
    public static readonly FitbitTimezone AfricaMaputo = new FitbitTimezone("Africa/Maputo");

    /// <summary>
    /// Europe/Helsinki.
    /// </summary>
    public static readonly FitbitTimezone EuropeHelsinki = new FitbitTimezone("Europe/Helsinki");

    /// <summary>
    /// Europe/Istanbul.
    /// </summary>
    public static readonly FitbitTimezone EuropeIstanbul = new FitbitTimezone("Europe/Istanbul");

    /// <summary>
    /// Africa/Johannesburg.
    /// </summary>
    public static readonly FitbitTimezone AfricaJohannesburg =
      new FitbitTimezone("Africa/Johannesburg");

    /// <summary>
    /// Europe/Kaliningrad.
    /// </summary>
    public static readonly FitbitTimezone EuropeKaliningrad =
      new FitbitTimezone("Europe/Kaliningrad");

    /// <summary>
    /// Europe/Kiev.
    /// </summary>
    public static readonly FitbitTimezone EuropeKiev = new FitbitTimezone("Europe/Kiev");

    /// <summary>
    /// Europe/Riga.
    /// </summary>
    public static readonly FitbitTimezone EuropeRiga = new FitbitTimezone("Europe/Riga");

    /// <summary>
    /// Europe/Sofia.
    /// </summary>
    public static readonly FitbitTimezone EuropeSofia = new FitbitTimezone("Europe/Sofia");

    /// <summary>
    /// Europe/Tallinn.
    /// </summary>
    public static readonly FitbitTimezone EuropeTallinn = new FitbitTimezone("Europe/Tallinn");

    /// <summary>
    /// Asia/Jerusalem.
    /// </summary>
    public static readonly FitbitTimezone AsiaJerusalem = new FitbitTimezone("Asia/Jerusalem");

    /// <summary>
    /// Africa/Tripoli.
    /// </summary>
    public static readonly FitbitTimezone AfricaTripoli = new FitbitTimezone("Africa/Tripoli");

    /// <summary>
    /// Europe/Vilnius.
    /// </summary>
    public static readonly FitbitTimezone EuropeVilnius = new FitbitTimezone("Europe/Vilnius");

    /// <summary>
    /// Africa/Windhoek.
    /// </summary>
    public static readonly FitbitTimezone AfricaWindhoek = new FitbitTimezone("Africa/Windhoek");

    /// <summary>
    /// Africa/Addis_Ababa.
    /// </summary>
    public static readonly FitbitTimezone AfricaAddisAbaba =
      new FitbitTimezone("Africa/Addis_Ababa");

    /// <summary>
    /// Indian/Antananarivo.
    /// </summary>
    public static readonly FitbitTimezone IndianAntananarivo =
      new FitbitTimezone("Indian/Antananarivo");

    /// <summary>
    /// Asia/Baghdad.
    /// </summary>
    public static readonly FitbitTimezone AsiaBaghdad = new FitbitTimezone("Asia/Baghdad");

    /// <summary>
    /// Asia/Kuwait.
    /// </summary>
    public static readonly FitbitTimezone AsiaKuwait = new FitbitTimezone("Asia/Kuwait");

    /// <summary>
    /// Europe/Minsk.
    /// </summary>
    public static readonly FitbitTimezone EuropeMinsk = new FitbitTimezone("Europe/Minsk");

    /// <summary>
    /// Europe/Moscow.
    /// </summary>
    public static readonly FitbitTimezone EuropeMoscow = new FitbitTimezone("Europe/Moscow");

    /// <summary>
    /// Africa/Nairobi.
    /// </summary>
    public static readonly FitbitTimezone AfricaNairobi = new FitbitTimezone("Africa/Nairobi");

    /// <summary>
    /// Asia/Riyadh.
    /// </summary>
    public static readonly FitbitTimezone AsiaRiyadh = new FitbitTimezone("Asia/Riyadh");

    /// <summary>
    /// Asia/Tehran.
    /// </summary>
    public static readonly FitbitTimezone AsiaTehran = new FitbitTimezone("Asia/Tehran");

    /// <summary>
    /// Asia/Baku.
    /// </summary>
    public static readonly FitbitTimezone AsiaBaku = new FitbitTimezone("Asia/Baku");

    /// <summary>
    /// Asia/Dubai.
    /// </summary>
    public static readonly FitbitTimezone AsiaDubai = new FitbitTimezone("Asia/Dubai");

    /// <summary>
    /// Asia/Muscat.
    /// </summary>
    public static readonly FitbitTimezone AsiaMuscat = new FitbitTimezone("Asia/Muscat");

    /// <summary>
    /// Indian/Mauritius.
    /// </summary>
    public static readonly FitbitTimezone IndianMauritius = new FitbitTimezone("Indian/Mauritius");

    /// <summary>
    /// Europe/Samara.
    /// </summary>
    public static readonly FitbitTimezone EuropeSamara = new FitbitTimezone("Europe/Samara");

    /// <summary>
    /// Asia/Tbilisi.
    /// </summary>
    public static readonly FitbitTimezone AsiaTbilisi = new FitbitTimezone("Asia/Tbilisi");

    /// <summary>
    /// Asia/Yerevan.
    /// </summary>
    public static readonly FitbitTimezone AsiaYerevan = new FitbitTimezone("Asia/Yerevan");

    /// <summary>
    /// Asia/Kabul.
    /// </summary>
    public static readonly FitbitTimezone AsiaKabul = new FitbitTimezone("Asia/Kabul");

    /// <summary>
    /// Asia/Ashgabat.
    /// </summary>
    public static readonly FitbitTimezone AsiaAshgabat = new FitbitTimezone("Asia/Ashgabat");

    /// <summary>
    /// Asia/Dushanbe.
    /// </summary>
    public static readonly FitbitTimezone AsiaDushanbe = new FitbitTimezone("Asia/Dushanbe");

    /// <summary>
    /// Asia/Yekaterinburg.
    /// </summary>
    public static readonly FitbitTimezone AsiaYekaterinburg =
      new FitbitTimezone("Asia/Yekaterinburg");

    /// <summary>
    /// Asia/Karachi.
    /// </summary>
    public static readonly FitbitTimezone AsiaKarachi = new FitbitTimezone("Asia/Karachi");

    /// <summary>
    /// Asia/Tashkent.
    /// </summary>
    public static readonly FitbitTimezone AsiaTashkent = new FitbitTimezone("Asia/Tashkent");

    /// <summary>
    /// Asia/Colombo.
    /// </summary>
    public static readonly FitbitTimezone AsiaColombo = new FitbitTimezone("Asia/Colombo");

    /// <summary>
    /// Asia/Kolkata.
    /// </summary>
    public static readonly FitbitTimezone AsiaKolkata = new FitbitTimezone("Asia/Kolkata");

    /// <summary>
    /// Asia/Kathmandu.
    /// </summary>
    public static readonly FitbitTimezone AsiaKathmandu = new FitbitTimezone("Asia/Kathmandu");

    /// <summary>
    /// Asia/Almaty.
    /// </summary>
    public static readonly FitbitTimezone AsiaAlmaty = new FitbitTimezone("Asia/Almaty");

    /// <summary>
    /// Asia/Bishkek.
    /// </summary>
    public static readonly FitbitTimezone AsiaBishkek = new FitbitTimezone("Asia/Bishkek");

    /// <summary>
    /// Asia/Dhaka.
    /// </summary>
    public static readonly FitbitTimezone AsiaDhaka = new FitbitTimezone("Asia/Dhaka");

    /// <summary>
    /// Asia/Novosibirsk.
    /// </summary>
    public static readonly FitbitTimezone AsiaNovosibirsk = new FitbitTimezone("Asia/Novosibirsk");

    /// <summary>
    /// Asia/Urumqi.
    /// </summary>
    public static readonly FitbitTimezone AsiaUrumqi = new FitbitTimezone("Asia/Urumqi");

    /// <summary>
    /// Asia/Rangoon.
    /// </summary>
    public static readonly FitbitTimezone AsiaRangoon = new FitbitTimezone("Asia/Rangoon");

    /// <summary>
    /// Asia/Bangkok.
    /// </summary>
    public static readonly FitbitTimezone AsiaBangkok = new FitbitTimezone("Asia/Bangkok");

    /// <summary>
    /// Asia/Ho_Chi_Minh.
    /// </summary>
    public static readonly FitbitTimezone AsiaHoChiMinh = new FitbitTimezone("Asia/Ho_Chi_Minh");

    /// <summary>
    /// Asia/Jakarta.
    /// </summary>
    public static readonly FitbitTimezone AsiaJakarta = new FitbitTimezone("Asia/Jakarta");

    /// <summary>
    /// Asia/Krasnoyarsk.
    /// </summary>
    public static readonly FitbitTimezone AsiaKrasnoyarsk = new FitbitTimezone("Asia/Krasnoyarsk");

    /// <summary>
    /// Asia/Chongqing.
    /// </summary>
    public static readonly FitbitTimezone AsiaChongqing = new FitbitTimezone("Asia/Chongqing");

    /// <summary>
    /// Asia/Hong_Kong.
    /// </summary>
    public static readonly FitbitTimezone AsiaHongKong = new FitbitTimezone("Asia/Hong_Kong");

    /// <summary>
    /// Asia/Irkutsk.
    /// </summary>
    public static readonly FitbitTimezone AsiaIrkutsk = new FitbitTimezone("Asia/Irkutsk");

    /// <summary>
    /// Asia/Kuala_Lumpur.
    /// </summary>
    public static readonly FitbitTimezone AsiaKualaLumpur =
      new FitbitTimezone("Asia/Kuala_Lumpur");

    /// <summary>
    /// Asia/Macau.
    /// </summary>
    public static readonly FitbitTimezone AsiaMacau = new FitbitTimezone("Asia/Macau");

    /// <summary>
    /// Asia/Manila.
    /// </summary>
    public static readonly FitbitTimezone AsiaManila = new FitbitTimezone("Asia/Manila");

    /// <summary>
    /// Australia/Perth.
    /// </summary>
    public static readonly FitbitTimezone AustraliaPerth = new FitbitTimezone("Australia/Perth");

    /// <summary>
    /// Asia/Shanghai.
    /// </summary>
    public static readonly FitbitTimezone AsiaShanghai = new FitbitTimezone("Asia/Shanghai");

    /// <summary>
    /// Asia/Singapore.
    /// </summary>
    public static readonly FitbitTimezone AsiaSingapore = new FitbitTimezone("Asia/Singapore");

    /// <summary>
    /// Asia/Taipei.
    /// </summary>
    public static readonly FitbitTimezone AsiaTaipei = new FitbitTimezone("Asia/Taipei");

    /// <summary>
    /// Asia/Ulaanbaatar.
    /// </summary>
    public static readonly FitbitTimezone AsiaUlaanbaatar = new FitbitTimezone("Asia/Ulaanbaatar");

    /// <summary>
    /// Australia/Eucla.
    /// </summary>
    public static readonly FitbitTimezone AustraliaEucla = new FitbitTimezone("Australia/Eucla");

    /// <summary>
    /// Asia/Dili.
    /// </summary>
    public static readonly FitbitTimezone AsiaDili = new FitbitTimezone("Asia/Dili");

    /// <summary>
    /// Pacific/Palau.
    /// </summary>
    public static readonly FitbitTimezone PacificPalau = new FitbitTimezone("Pacific/Palau");

    /// <summary>
    /// Asia/Pyongyang.
    /// </summary>
    public static readonly FitbitTimezone AsiaPyongyang = new FitbitTimezone("Asia/Pyongyang");

    /// <summary>
    /// Asia/Seoul.
    /// </summary>
    public static readonly FitbitTimezone AsiaSeoul = new FitbitTimezone("Asia/Seoul");

    /// <summary>
    /// Asia/Tokyo.
    /// </summary>
    public static readonly FitbitTimezone AsiaTokyo = new FitbitTimezone("Asia/Tokyo");

    /// <summary>
    /// Asia/Yakutsk.
    /// </summary>
    public static readonly FitbitTimezone AsiaYakutsk = new FitbitTimezone("Asia/Yakutsk");

    /// <summary>
    /// Australia/Darwin.
    /// </summary>
    public static readonly FitbitTimezone AustraliaDarwin = new FitbitTimezone("Australia/Darwin");

    /// <summary>
    /// Australia/Brisbane.
    /// </summary>
    public static readonly FitbitTimezone AustraliaBrisbane =
      new FitbitTimezone("Australia/Brisbane");

    /// <summary>
    /// Pacific/Guam.
    /// </summary>
    public static readonly FitbitTimezone PacificGuam = new FitbitTimezone("Pacific/Guam");

    /// <summary>
    /// Pacific/Port_Moresby.
    /// </summary>
    public static readonly FitbitTimezone PacificPortMoresby =
      new FitbitTimezone("Pacific/Port_Moresby");

    /// <summary>
    /// Asia/Vladivostok.
    /// </summary>
    public static readonly FitbitTimezone AsiaVladivostok = new FitbitTimezone("Asia/Vladivostok");

    /// <summary>
    /// Australia/Adelaide.
    /// </summary>
    public static readonly FitbitTimezone AustraliaAdelaide =
      new FitbitTimezone("Australia/Adelaide");

    /// <summary>
    /// Australia/Hobart.
    /// </summary>
    public static readonly FitbitTimezone AustraliaHobart =
      new FitbitTimezone("Australia/Hobart");

    /// <summary>
    /// Australia/Melbourne.
    /// </summary>
    public static readonly FitbitTimezone AustraliaMelbourne =
      new FitbitTimezone("Australia/Melbourne");

    /// <summary>
    /// Pacific/Noumea.
    /// </summary>
    public static readonly FitbitTimezone PacificNoumea = new FitbitTimezone("Pacific/Noumea");

    /// <summary>
    /// Pacific/Pohnpei.
    /// </summary>
    public static readonly FitbitTimezone PacificPohnpei = new FitbitTimezone("Pacific/Pohnpei");

    /// <summary>
    /// Pacific/Guadalcanal.
    /// </summary>
    public static readonly FitbitTimezone PacificGuadalcanal =
      new FitbitTimezone("Pacific/Guadalcanal");

    /// <summary>
    /// Australia/Sydney.
    /// </summary>
    public static readonly FitbitTimezone AustraliaSydney = new FitbitTimezone("Australia/Sydney");

    /// <summary>
    /// Pacific/Fiji.
    /// </summary>
    public static readonly FitbitTimezone PacificFiji = new FitbitTimezone("Pacific/Fiji");

    /// <summary>
    /// Asia/Kamchatka.
    /// </summary>
    public static readonly FitbitTimezone AsiaKamchatka = new FitbitTimezone("Asia/Kamchatka");

    /// <summary>
    /// Pacific/Majuro.
    /// </summary>
    public static readonly FitbitTimezone PacificMajuro = new FitbitTimezone("Pacific/Majuro");

    /// <summary>
    /// Pacific/Auckland.
    /// </summary>
    public static readonly FitbitTimezone PacificAuckland = new FitbitTimezone("Pacific/Auckland");

    /// <summary>
    /// Pacific/Tongatapu.
    /// </summary>
    public static readonly FitbitTimezone PacificTongatapu =
      new FitbitTimezone("Pacific/Tongatapu");

    /// <summary>
    /// Pacific/Apia.
    /// </summary>
    public static readonly FitbitTimezone PacificApia = new FitbitTimezone("Pacific/Apia");

    /// <summary>
    /// Initialises a new instance of the <see cref="FitbitTimezone"/> class.
    /// </summary>
    /// <param name="timezone">The timezone.</param>
    private FitbitTimezone(string timezone)
    {
      this.timezone = timezone;
    }

    /// <summary>
    /// Returns a <see cref="String"/> representation of the <see cref="FitbitTimezone"/>.
    /// </summary>
    /// <returns>A <see cref="String"/>.</returns>
    public override string ToString()
    {
      return this.timezone;
    }
  }
}