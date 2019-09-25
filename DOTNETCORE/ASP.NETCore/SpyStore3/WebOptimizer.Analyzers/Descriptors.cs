using Microsoft.CodeAnalysis;

namespace WebOptimizer.Analyzers
{
    internal static class Descriptors
    {
        public static DiagnosticDescriptor SourcesFilesMustBeSpecified => Generate(1000,
            "Specify at least one source files. Source files can not be null or empty.",
            "Specify at least one source files. Source files can not be null or empty.");

        public static DiagnosticDescriptor GlobbingRoutesNotAllowed => Generate(1001,
            "Globbing pattern is not allowed when specifying a route for a bundle.",
            "\"{0}\" is invalid as a route for a bundle.");

        public static DiagnosticDescriptor ContentTypeWrongFormat => Generate(1002,
            "The content type is not a valid content type.",
            "\"{0}\" is not a valid content type.");

        public static DiagnosticDescriptor InvalidPath => Generate(1003,
            "Source file paths must not start with \"../\"",
            "\"{0}\" is not a valid path. Don't use paths starting with \"../\" but instead set the UseContentRoot setting to true.");

        private static DiagnosticDescriptor Generate(int id, string title, string messageFormat, DiagnosticSeverity severity = DiagnosticSeverity.Warning)
        {
            return new DiagnosticDescriptor(
               id: $"WO{id}",
               title: title,
               messageFormat: messageFormat,
               category: "Usage",
               defaultSeverity: severity,
               isEnabledByDefault: true);
        }
    }
}
