// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - SwaggerVersionDescription.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Api.Swagger.Models;

public class SwaggerVersionDescription
{
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
}