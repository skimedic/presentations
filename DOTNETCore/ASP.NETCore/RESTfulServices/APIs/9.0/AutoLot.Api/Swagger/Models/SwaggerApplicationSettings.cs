// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - SwaggerApplicationSettings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Swagger.Models;

public class SwaggerApplicationSettings
{
    public string Title { get; set; }
    public List<SwaggerVersionDescription> Descriptions { get; set; } = [];
    public string ContactName { get; set; }
    public string ContactEmail { get; set; }

    public class SwaggerVersionDescription
    {
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}