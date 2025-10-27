// Copyright Information
// ==================================
// Japikse_VersioningDocumentingAPIs - KitchenSink - WeatherForecast.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/25
// ==================================

namespace KitchenSink;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}