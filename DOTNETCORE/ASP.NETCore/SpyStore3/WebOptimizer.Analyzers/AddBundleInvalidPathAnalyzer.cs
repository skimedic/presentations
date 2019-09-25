using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace WebOptimizer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AddBundleInvalidPathAnalyzer : AssetPipelineBaseAnalyzer
    {
        private static readonly DiagnosticDescriptor _descriptor = Descriptors.InvalidPath;
        public AddBundleInvalidPathAnalyzer()
            : base(_descriptor, "AddBundle", "AddFiles", "AddCssBundle", "AddJavaScriptBundle", "AddHtmlBundle")
        { }

        protected override void Analyze(SyntaxNodeAnalysisContext context, InvocationExpressionSyntax invocation, IMethodSymbol method)
        {
            SeparatedSyntaxList<ArgumentSyntax> arguments = invocation.ArgumentList.Arguments;

            int skipCount = method.Name == "AddBundle" ? 2 : 1;

            if (method.Parameters.Length > skipCount)
            {
                foreach (ArgumentSyntax arg in arguments.Skip(1))
                {
                    Optional<object> value = context.SemanticModel.GetConstantValue(arg.Expression);

                    if (value.HasValue && value.Value is string path && path.StartsWith("../"))
                    {
                        context.ReportDiagnostic(Diagnostic.Create(_descriptor, arg.GetLocation(), path));
                    }
                }
            }
        }
    }
}
