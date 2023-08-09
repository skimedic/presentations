// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - FullSwaggerSupport - SwaggerApplicationSettings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================

namespace FullSwaggerSupport.SwaggerInfrastructure.Models;
public class SwaggerApplicationSettings
{
    public string Title { get; set; }
    public List<SwaggerVersionDescription> Descriptions { get; set; } = new List<SwaggerVersionDescription>();
    public string ContactName { get; set; }
    public string ContactEmail {get; set; }
}