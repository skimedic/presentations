// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - HideInProductionFilter.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Swagger.HideEndpoints;

public class HideInProductionFilter(IWebHostEnvironment env) : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        if (env.IsProduction() || env.IsStaging())
        {
            var toRemove = context.ApiDescriptions
                .Where(desc =>
                    desc.CustomAttributes().OfType<HideEndpointInProductionAttribute>().Any())
                .Select(desc => "/" + desc.RelativePath.TrimEnd('/'))
                .ToList();

            foreach (var path in toRemove)
            {
                swaggerDoc.Paths.Remove(path);
            }
        }
    }
}