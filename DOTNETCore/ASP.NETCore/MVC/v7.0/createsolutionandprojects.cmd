dotnet new globaljson --sdk-version 7.0.100 --roll-forward feature
dotnet new nugetconfig 

rem create the solution
dotnet new sln -n AutoLot
rem create the class library for the Models and add it to the solution
dotnet new classlib -lang c# -n AutoLot.Models -o .\AutoLot.Models -f net7.0 
dotnet sln AutoLot.sln add AutoLot.Models

dotnet add AutoLot.Models package Microsoft.EntityFrameworkCore.SqlServer -v [7.0.*,8.0)
dotnet add AutoLot.Models package System.Text.Json -v [7.0.*,8.0)
dotnet add AutoLot.Models package Microsoft.VisualStudio.Threading.Analyzers -v [17.7.*,)

rem create the Data Access Layer class library, and add to the solution
dotnet new classlib -lang c# -n AutoLot.Dal -o .\AutoLot.Dal -f net7.0 
dotnet sln AutoLot.sln add AutoLot.Dal
dotnet add AutoLot.Dal reference AutoLot.Models

dotnet add AutoLot.Dal package Microsoft.EntityFrameworkCore.SqlServer -v [7.0.*,8.0)
dotnet add AutoLot.Dal package Microsoft.EntityFrameworkCore.Design -v [7.0.*,8.0)
dotnet add AutoLot.Dal package Microsoft.VisualStudio.Threading.Analyzers -v [17.7.*,)

rem create the class library for the application services and add it to the solution
dotnet new classlib -lang c# -n AutoLot.Services -o .\AutoLot.Services -f net7.0
dotnet sln AutoLot.sln add AutoLot.Services
dotnet add AutoLot.Services reference AutoLot.Models
dotnet add AutoLot.Services reference AutoLot.Dal

dotnet add AutoLot.Services package Microsoft.VisualStudio.Threading.Analyzers -v [17.7.*,)
dotnet add AutoLot.Services package Microsoft.Extensions.Hosting.Abstractions  -v [7.0.*,8.0)
dotnet add AutoLot.Services package Microsoft.Extensions.Options  -v [7.0.*,8.0)
dotnet add AutoLot.Services package Serilog.AspNetCore -v [7.0.*,8.0)
dotnet add AutoLot.Services package Serilog.Enrichers.Environment  -v [2.3.*,3.0)
dotnet add AutoLot.Services package Serilog.Settings.Configuration  -v [7.0.*,8.0)
dotnet add AutoLot.Services package Serilog.Sinks.Console -v [4.1.*,5.0)
dotnet add AutoLot.Services package Serilog.Sinks.File -v [5.0.*,6)
dotnet add AutoLot.Services package Serilog.Sinks.MSSqlServer -v [6.3.*,7.0)
dotnet add AutoLot.Services package System.Text.Json -v [7.0.*,8.0)

rem create the Data Access Layer XUnit project and add it to the solution
dotnet new xunit -lang c# -n AutoLot.Dal.Tests -o .\AutoLot.Dal.Tests -f net7.0
dotnet sln AutoLot.sln add AutoLot.Dal.Tests
dotnet add AutoLot.Dal.Tests reference AutoLot.Dal
dotnet add AutoLot.Dal.Tests reference AutoLot.Models
dotnet add AutoLot.Dal.Tests package Microsoft.EntityFrameworkCore.SqlServer -v [7.0.*,8.0)
dotnet add AutoLot.Dal.Tests package Microsoft.EntityFrameworkCore.Design -v [7.0.*,8.0)
dotnet add AutoLot.Dal.Tests package Microsoft.Extensions.Configuration.Json -v [7.0.*,8.0)
dotnet add AutoLot.Dal.Tests package Microsoft.NET.Test.Sdk  -v [17.7.*,)
dotnet add AutoLot.Dal.Tests package Microsoft.VisualStudio.Threading.Analyzers -v [17.7.*,)
dotnet add AutoLot.Dal.Tests package xunit -v [2.5.*,3.0)
dotnet add AutoLot.Dal.Tests package xunit.runner.visualstudio -v [2.5.*,3.0)
dotnet add AutoLot.Dal.Tests package coverlet.collector -v [6.0.*,7.0)

rem create the ASP.NET Core Web App (MVC) project and add it to the solution
dotnet new mvc -lang c# -n AutoLot.Mvc -au none -o .\AutoLot.Mvc -f net7.0
dotnet sln AutoLot.sln add AutoLot.Mvc
dotnet add AutoLot.Mvc reference AutoLot.Models
dotnet add AutoLot.Mvc reference AutoLot.Dal
dotnet add AutoLot.Mvc reference AutoLot.Services

rem add packages
dotnet add AutoLot.Mvc package AutoMapper -v [12.0.*,13.0)
dotnet add AutoLot.Mvc package System.Text.Json -v [7.0.*,8.0) 
dotnet add AutoLot.Mvc package LigerShark.WebOptimizer.Core -v [3.0.*,4)
dotnet add AutoLot.Mvc package Microsoft.Web.LibraryManager.Build -v [2.1.*,3.0)
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore.SqlServer -v [7.0.*,8.0)
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore.Design -v [7.0.*,8.0)
dotnet add AutoLot.Mvc package Microsoft.VisualStudio.Web.CodeGeneration.Design -v [7.0.*,8.0)
dotnet add AutoLot.Mvc package Microsoft.VisualStudio.Threading.Analyzers -v [17.7.*,)
pause
