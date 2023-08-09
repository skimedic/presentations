// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - BareMinimum - WeatherForecast.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================

namespace BareMinimum;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
