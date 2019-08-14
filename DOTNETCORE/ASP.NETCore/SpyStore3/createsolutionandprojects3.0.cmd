rem VS 2019 16.3 Preview
dotnet new globaljson --sdk-version 3.0.100-preview8-013656
rem create the solution
dotnet new sln -n SpyStore.Hol
rem create the ASP.NET Core Web App project and add it to the solution
dotnet new mvc -n SpyStore.Hol.Mvc -au none --no-https  -o .\SpyStore.Hol.Mvc
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Mvc
rem create the Data Access Layer class library, and add to the solution
dotnet new classlib -n SpyStore.Hol.Dal -o .\SpyStore.Hol.Dal -f netcoreapp3.0
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Dal
rem create the class library for the Models and add it to the solution
dotnet new classlib -n SpyStore.Hol.Models -o .\SpyStore.Hol.Models -f netcoreapp3.0
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Models
rem create the Data Access Layer XUnit project and add it to the solution
dotnet new xunit -n SpyStore.Hol.Dal.Tests -o .\SpyStore.Hol.Dal.Tests
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Dal.Tests

dotnet add SpyStore.Hol.Mvc reference SpyStore.Hol.Models
dotnet add SpyStore.Hol.Mvc reference SpyStore.Hol.Dal

dotnet add SpyStore.Hol.Dal reference SpyStore.Hol.Models

dotnet add SpyStore.Hol.Dal.Tests reference SpyStore.Hol.Models
dotnet add SpyStore.Hol.Dal.Tests reference SpyStore.Hol.Dal

dotnet add SpyStore.Hol.Mvc package Microsoft.EntityFrameworkCore.SqlServer -v 3.0.0-preview8.19405.11
dotnet add SpyStore.Hol.Mvc package AutoMapper
dotnet add SpyStore.Hol.Dal package System.Text.Json -v 4.6.0-preview8.19405.3
dotnet add SpyStore.Hol.Mvc package LigerShark.WebOptimizer.Core
dotnet add SpyStore.Hol.Mvc package LigerShark.WebOptimizer.sass -v 1.0.34-beta
dotnet add SpyStore.Hol.Mvc package Microsoft.Web.LibraryManager.Build

dotnet add SpyStore.Hol.Dal package Microsoft.EntityFrameworkCore.SqlServer -v 3.0.0-preview8.19405.11
dotnet add SpyStore.Hol.Dal package Microsoft.EntityFrameworkCore.Design -v 3.0.0-preview8.19405.11
dotnet add SpyStore.Hol.Dal package System.Text.Json -v 4.6.0-preview8.19405.3
dotnet add SpyStore.Hol.Dal package Microsoft.EntityFrameworkCore.Tools -v 3.0.0-preview8.19405.11

dotnet add SpyStore.Hol.Models package Microsoft.EntityFrameworkCore.Abstractions -v 3.0.0-preview8.19405.11
dotnet add SpyStore.Hol.Models package AutoMapper
dotnet add SpyStore.Hol.Dal package System.Text.Json -v 4.6.0-preview8.19405.3

dotnet add SpyStore.Hol.Dal.Tests package Microsoft.EntityFrameworkCore.SqlServer -v 3.0.0-preview8.19405.11



