using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace WebOptimizer.Analyzers
{
    public abstract class AssetPipelineBaseAnalyzer : DiagnosticAnalyzer
    {
        private string[] _methodNames;

        public AssetPipelineBaseAnalyzer(DiagnosticDescriptor descriptor, params string[] methodNames)
        {
            SupportedDiagnostics = ImmutableArray.Create(descriptor);
            _methodNames = methodNames;
        }

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(syntaxContext =>
            {
                var invocation = (InvocationExpressionSyntax)syntaxContext.Node;
                SymbolInfo symbolInfo = syntaxContext.SemanticModel.GetSymbolInfo(invocation, syntaxContext.CancellationToken);

                if (symbolInfo.Symbol?.Kind != SymbolKind.Method)
                {
                    return;
                }

                var methodSymbol = (IMethodSymbol)symbolInfo.Symbol;

                // Only ordinary method calls and extension method calls allowed
                if (methodSymbol.MethodKind != MethodKind.Ordinary && methodSymbol.MethodKind != MethodKind.ReducedExtension)
                {
                    return;
                }

                if (methodSymbol.ReceiverType == null ||
                    (!methodSymbol.ReceiverType.Interfaces.Any(i =>
                     i.ContainingNamespace.Name == "WebOptimizer" &&
                     i.Name == "IAssetPipeline") &&
                     methodSymbol.ReceiverType.Name != "IAssetPipeline") ||
                    !_methodNames.Contains(methodSymbol.Name))
                {
                    return;
                }

                Analyze(syntaxContext, invocation, methodSymbol);

            }, SyntaxKind.InvocationExpression);
        }

        protected abstract void Analyze(SyntaxNodeAnalysisContext context, InvocationExpressionSyntax invocation, IMethodSymbol method);
    }
}
