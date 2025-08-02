dotnet new globaljson --sdk-version 8.0.100 --roll-forward feature
dotnet new nugetconfig 

dotnet new sln -n DesignPatterns

dotnet new classlib -lang c# -n BehaviorPatterns -o .\BehaviorPatterns -f net8.0 
dotnet sln DesignPatterns.sln add BehaviorPatterns
dotnet add BehaviorPatterns package Microsoft.VisualStudio.Threading.Analyzers

dotnet new xunit3 -lang c# -n BehaviorPatternsTests -o .\BehaviorPatternsTests -f net8.0
dotnet sln DesignPatterns.sln add BehaviorPatternsTests
dotnet add BehaviorPatternsTests package Microsoft.NET.Test.Sdk 
dotnet add BehaviorPatternsTests package Microsoft.VisualStudio.Threading.Analyzers
dotnet add BehaviorPatternsTests reference BehaviorPatterns

dotnet new classlib -lang c# -n CreationPatterns -o .\CreationPatterns -f net8.0 
dotnet sln DesignPatterns.sln add CreationPatterns
dotnet add CreationPatterns package Microsoft.VisualStudio.Threading.Analyzers

dotnet new xunit3 -lang c# -n CreationPatternsTests -o .\CreationPatternsTests -f net8.0
dotnet sln DesignPatterns.sln add CreationPatternsTests
dotnet add CreationPatternsTests package Microsoft.NET.Test.Sdk 
dotnet add CreationPatternsTests package Microsoft.VisualStudio.Threading.Analyzers
dotnet add CreationPatternsTests reference CreationPatterns

dotnet new classlib -lang c# -n StructuralPatterns -o .\StructuralPatterns -f net8.0 
dotnet sln DesignPatterns.sln add StructuralPatterns
dotnet add StructuralPatterns package Microsoft.VisualStudio.Threading.Analyzers

dotnet new xunit3 -lang c# -n StructuralPatternsTests -o .\StructuralPatternsTests -f net8.0
dotnet sln DesignPatterns.sln add StructuralPatternsTests
dotnet add StructuralPatternsTests package Microsoft.NET.Test.Sdk 
dotnet add StructuralPatternsTests package Microsoft.VisualStudio.Threading.Analyzers
dotnet add StructuralPatternsTests reference StructuralPatterns

pause
