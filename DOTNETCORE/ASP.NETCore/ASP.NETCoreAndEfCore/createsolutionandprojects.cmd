dotnet new globaljson --sdk-version 3.1.100

rem create the solution
dotnet new sln -n SpyStore.Hol
rem create the ASP.NET Core Web App project and add it to the solution
dotnet new mvc -n SpyStore.Hol.Mvc -au none -o .\SpyStore.Hol.Mvc
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Mvc
rem create the Data Access Layer class library, and add to the solution
dotnet new classlib -n SpyStore.Hol.Dal -o .\SpyStore.Hol.Dal -f netcoreapp3.1
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Dal
rem create the class library for the Models and add it to the solution
dotnet new classlib -n SpyStore.Hol.Models -o .\SpyStore.Hol.Models -f netcoreapp3.1
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Models
rem create the Data Access Layer XUnit project and add it to the solution
dotnet new xunit -n SpyStore.Hol.Dal.Tests -o .\SpyStore.Hol.Dal.Tests
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Dal.Tests
rem create the XUnit project for the Service and add it to the solution
dotnet new xunit -n SpyStore.Hol.Service.Tests -o .\SpyStore.Hol.Service.Tests 
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Service.Tests
rem create the ASP.NET Core RESTful Service project, add it to the solution
rem NOTE THE NEXT TWO LINES MUST BE ON ONE LINE IN THE COMMAND FILE
dotnet new webapi -n SpyStore.Hol.Service -au none -o .\SpyStore.Hol.Service 
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Service

dotnet add SpyStore.Hol.Mvc reference SpyStore.Hol.Models

dotnet add SpyStore.Hol.Dal reference SpyStore.Hol.Models

dotnet add SpyStore.Hol.Dal.tests reference SpyStore.Hol.Models
dotnet add SpyStore.Hol.Dal.tests reference SpyStore.Hol.Dal

dotnet add SpyStore.Hol.Service reference SpyStore.Hol.Dal
dotnet add SpyStore.Hol.Service reference SpyStore.Hol.Models

dotnet add SpyStore.Hol.Service.Tests reference SpyStore.Hol.Models
dotnet add SpyStore.Hol.Service.Tests reference SpyStore.Hol.Dal

dotnet add SpyStore.Hol.Service package AutoMapper
dotnet add SpyStore.Hol.Service package System.Text.Json
dotnet add SpyStore.Hol.Service package Swashbuckle.AspNetCore.Annotations
dotnet add SpyStore.Hol.Service package Swashbuckle.AspNetCore.Swagger
dotnet add SpyStore.Hol.Service package Swashbuckle.AspNetCore.SwaggerGen
dotnet add SpyStore.Hol.Service package Swashbuckle.AspNetCore.SwaggerUI
dotnet add SpyStore.Hol.Service package Microsoft.VisualStudio.Azure.Containers.Tools.Targets -v 1.9.10
dotnet add SpyStore.Hol.Service package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 3.1.1
dotnet add SpyStore.Hol.Service package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.1

dotnet add SpyStore.Hol.Mvc package AutoMapper
dotnet add SpyStore.Hol.Mvc package System.Text.Json
dotnet add SpyStore.Hol.Mvc package LigerShark.WebOptimizer.Core -v 3.0.250
dotnet add SpyStore.Hol.Mvc package Microsoft.Web.LibraryManager.Build

dotnet add SpyStore.Hol.Dal package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.1
dotnet add SpyStore.Hol.Dal package Microsoft.EntityFrameworkCore.Design -v 3.1.1
dotnet add SpyStore.Hol.Dal package System.Text.Json
dotnet add SpyStore.Hol.Dal package Microsoft.EntityFrameworkCore.Tools -v 3.1.1

dotnet add SpyStore.Hol.Models package Microsoft.EntityFrameworkCore.Abstractions -v 3.1.1
dotnet add SpyStore.Hol.Models package AutoMapper
dotnet add SpyStore.Hol.Models package System.Text.Json 

dotnet add SpyStore.Hol.Dal.Tests package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.1

dotnet add SpyStore.Hol.Service.Tests package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.1


