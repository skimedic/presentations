dotnet new globaljson --sdk-version 7.0.100 --roll-forward feature
dotnet new nugetconfig 

rem create the solution
dotnet new sln -n AutoLot
rem create the class library for the Models and add it to the solution
dotnet new classlib -lang c# -n AutoLot.Models -o .\AutoLot.Models -f net7.0 
dotnet sln AutoLot.sln add AutoLot.Models

dotnet add AutoLot.Models package Microsoft.EntityFrameworkCore 
dotnet add AutoLot.Models package Microsoft.EntityFrameworkCore.SqlServer 
dotnet add AutoLot.Models package System.Text.Json 
dotnet add AutoLot.Models package Microsoft.VisualStudio.Threading.Analyzers

rem create the Data Access Layer class library, and add to the solution
dotnet new classlib -lang c# -n AutoLot.Dal -o .\AutoLot.Dal -f net7.0 
dotnet sln AutoLot.sln add AutoLot.Dal
dotnet add AutoLot.Dal reference AutoLot.Models

dotnet add AutoLot.Dal package Microsoft.EntityFrameworkCore 
dotnet add AutoLot.Dal package Microsoft.EntityFrameworkCore.Design 
dotnet add AutoLot.Dal package Microsoft.EntityFrameworkCore.SqlServer 
dotnet add AutoLot.Dal package Microsoft.EntityFrameworkCore.Tools 
dotnet add AutoLot.Dal package Microsoft.VisualStudio.Threading.Analyzers

rem create the class library for the application services and add it to the solution
dotnet new classlib -lang c# -n AutoLot.Services -o .\AutoLot.Services -f net7.0
dotnet sln AutoLot.sln add AutoLot.Services
dotnet add AutoLot.Services reference AutoLot.Models
dotnet add AutoLot.Services reference AutoLot.Dal

dotnet add AutoLot.Services package Microsoft.VisualStudio.Threading.Analyzers 
dotnet add AutoLot.Services package Microsoft.Extensions.Hosting.Abstractions  
dotnet add AutoLot.Services package Microsoft.Extensions.Options  
dotnet add AutoLot.Services package Serilog.AspNetCore
dotnet add AutoLot.Services package Serilog.Enrichers.Environment
dotnet add AutoLot.Services package Serilog.Settings.Configuration
dotnet add AutoLot.Services package Serilog.Sinks.Console
dotnet add AutoLot.Services package Serilog.Sinks.File
dotnet add AutoLot.Services package Serilog.Sinks.MSSqlServer
dotnet add AutoLot.Services package System.Text.Json  

rem create the Data Access Layer XUnit project and add it to the solution
dotnet new xunit -lang c# -n AutoLot.Dal.Tests -o .\AutoLot.Dal.Tests -f net7.0
dotnet sln AutoLot.sln add AutoLot.Dal.Tests
dotnet add AutoLot.Dal.Tests reference AutoLot.Dal
dotnet add AutoLot.Dal.Tests reference AutoLot.Models

dotnet add AutoLot.Dal.Tests package Microsoft.EntityFrameworkCore 
dotnet add AutoLot.Dal.Tests package Microsoft.EntityFrameworkCore.Design 
dotnet add AutoLot.Dal.Tests package Microsoft.EntityFrameworkCore.SqlServer 
dotnet add AutoLot.Dal.Tests package Microsoft.Extensions.Configuration.Json
dotnet add AutoLot.Dal.Tests package Microsoft.NET.Test.Sdk 
dotnet add AutoLot.Dal.Tests package Microsoft.VisualStudio.Threading.Analyzers

rem create the ASP.NET Core Web App (MVC) project and add it to the solution
dotnet new mvc -lang c# -n AutoLot.Mvc -au none -o .\AutoLot.Mvc -f net7.0
dotnet sln AutoLot.sln add AutoLot.Mvc
dotnet add AutoLot.Mvc reference AutoLot.Models
dotnet add AutoLot.Mvc reference AutoLot.Dal
dotnet add AutoLot.Mvc reference AutoLot.Services

rem add packages
dotnet add AutoLot.Mvc package AutoMapper
dotnet add AutoLot.Mvc package System.Text.Json  
dotnet add AutoLot.Mvc package LigerShark.WebOptimizer.Core
dotnet add AutoLot.Mvc package Microsoft.Web.LibraryManager.Build
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore  
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore.Design  
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore.SqlServer  
dotnet add AutoLot.Mvc package Microsoft.VisualStudio.Web.CodeGeneration.Design  
dotnet add AutoLot.Mvc package Microsoft.VisualStudio.Threading.Analyzers 

rem create the ASP.NET Core RESTful Service project, add it to the solution
dotnet new webapi -lang c# -n AutoLot.Api -au none -o .\AutoLot.Api -f net7.0
dotnet sln AutoLot.sln add AutoLot.Api
rem add project references
dotnet add AutoLot.Api reference AutoLot.Dal
dotnet add AutoLot.Api reference AutoLot.Models
dotnet add AutoLot.Api reference AutoLot.Services

rem add packages
dotnet add AutoLot.Api package AutoMapper
dotnet add AutoLot.Api package Microsoft.AspNetCore.Mvc.Versioning 
dotnet add AutoLot.Api package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
dotnet add AutoLot.Api package Microsoft.EntityFrameworkCore.SqlServer 
dotnet add AutoLot.Api package Microsoft.EntityFrameworkCore.Design  
dotnet add AutoLot.Api package Microsoft.VisualStudio.Threading.Analyzers
dotnet add AutoLot.Api package Microsoft.VisualStudio.Web.CodeGeneration.Design 
dotnet add AutoLot.Api package Swashbuckle.AspNetCore
dotnet add AutoLot.Api package Swashbuckle.AspNetCore.Annotations
dotnet add AutoLot.Api package Swashbuckle.AspNetCore.Swagger
dotnet add AutoLot.Api package Swashbuckle.AspNetCore.SwaggerGen
dotnet add AutoLot.Api package Swashbuckle.AspNetCore.SwaggerUI
dotnet add AutoLot.Api package System.Text.Json  
pause
