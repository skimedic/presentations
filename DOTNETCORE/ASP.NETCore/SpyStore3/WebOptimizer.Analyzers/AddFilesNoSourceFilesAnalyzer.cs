using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace WebOptimizer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AddFilesNoSourceFilesAnalyzer : AssetPipelineBaseAnalyzer
    {
        private static readonly DiagnosticDescriptor _descriptor = Descriptors.SourcesFilesMustBeSpecified;
        public AddFilesNoSourceFilesAnalyzer()
            : base(_descriptor, "AddFiles")
        { }

        protected override void Analyze(SyntaxNodeAnalysisContext context, InvocationExpressionSyntax invocation, IMethodSymbol method)
        {
            SeparatedSyntaxList<ArgumentSyntax> arguments = invocation.ArgumentList.Arguments;

            if (arguments.Count == 1)
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    _descriptor,
                    invocation.GetLocation(),
                    method.Name));
            }
            else if (method.Parameters.Length == 2 && arguments.Count >= 2)
            {
                foreach (ArgumentSyntax arg in arguments.Skip(1))
                {
                    Optional<object> value = context.SemanticModel.GetConstantValue(arg.Expression);

                    if (value.HasValue && (value.Value == null || string.IsNullOrWhiteSpace(value.Value.ToString())))
                    {
                        context.ReportDiagnostic(Diagnostic.Create(_descriptor, arg.GetLocation()));
                    }
                }
            }
        }
    }
}
