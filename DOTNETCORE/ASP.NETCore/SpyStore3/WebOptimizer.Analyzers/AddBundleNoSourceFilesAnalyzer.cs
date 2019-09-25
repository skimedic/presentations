using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace WebOptimizer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AddBundleNoSourceFilesAnalyzer : AssetPipelineBaseAnalyzer
    {
        private static readonly DiagnosticDescriptor _descriptor = Descriptors.SourcesFilesMustBeSpecified;
        public AddBundleNoSourceFilesAnalyzer()
            : base(_descriptor, "AddBundle")
        { }

        protected override void Analyze(SyntaxNodeAnalysisContext context, InvocationExpressionSyntax invocation, IMethodSymbol method)
        {
            SeparatedSyntaxList<ArgumentSyntax> arguments = invocation.ArgumentList.Arguments;

            if (method.Parameters.Length == 3 && arguments.Count == 2)
            {
                context.ReportDiagnostic(Diagnostic.Create(_descriptor, invocation.GetLocation()));
            }
            else if (method.Parameters.Length == 3 && arguments.Count >= 3)
            {
                foreach (ArgumentSyntax arg in arguments.Skip(2))
                {
                    Optional<object> value = context.SemanticModel.GetConstantValue(arg.Expression);

                    if (value.HasValue && (value.Value == null || string.IsNullOrWhiteSpace(value.Value?.ToString())))
                    {
                        context.ReportDiagnostic(Diagnostic.Create(_descriptor, arg.GetLocation()));
                    }
                }
            }
        }
    }
}
