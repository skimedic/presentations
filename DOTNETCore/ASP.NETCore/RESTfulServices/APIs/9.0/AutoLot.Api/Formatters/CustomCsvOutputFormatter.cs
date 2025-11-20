// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - CustomCsvOutputFormatter.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

using MediaTypeHeaderValue = Microsoft.Net.Http.Headers.MediaTypeHeaderValue;

namespace AutoLot.Api.Formatters;

public class CustomCsvOutputFormatter : TextOutputFormatter
{
    public CustomCsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
    }

    protected override bool CanWriteType(Type type) => typeof(IEnumerable<object>).IsAssignableFrom(type) || type.IsClass;

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        var type = context.Object.GetType();
        var enumerable = context.Object as IEnumerable<object> ?? [context.Object];

        var props = type.GetGenericArguments().FirstOrDefault()?.GetProperties()
                    ?? type.GetProperties();

        // Header
        buffer.AppendLine(string.Join(",", props.Select(p => p.Name)));

        // Rows
        foreach (var item in enumerable)
        {
            var values = props.Select(p => p.GetValue(item, null)?.ToString()?.Replace(",", " ") ?? "");
            buffer.AppendLine(string.Join(",", values));
        }

        await response.WriteAsync(buffer.ToString());
    }
}