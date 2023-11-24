rem create the solution
dotnet new sln -n Japikse_VersioningAPIs
rem create the class library for the Models and add it to the solution

dotnet new webapi -lang c# -n BareMinimum -au none -o .\BareMinimum -f net6.0
dotnet sln Japikse_VersioningAPIs.sln add BareMinimum

dotnet add BareMinimum package Swashbuckle.AspNetCore
dotnet add BareMinimum package Swashbuckle.AspNetCore.Annotations
dotnet add BareMinimum package Swashbuckle.AspNetCore.Swagger
dotnet add BareMinimum package Swashbuckle.AspNetCore.SwaggerGen
dotnet add BareMinimum package Swashbuckle.AspNetCore.SwaggerUI
dotnet add BareMinimum package Microsoft.VisualStudio.Web.CodeGeneration.Design --prerelease 
dotnet add BareMinimum package System.Text.Json --prerelease 
dotnet add BareMinimum package Microsoft.AspNetCore.Mvc.Versioning --prerelease
dotnet add BareMinimum package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer --prerelease

dotnet new webapi -lang c# -n FolderVersioning -au none -o .\FolderVersioning -f net6.0
dotnet sln Japikse_VersioningAPIs.sln add FolderVersioning

dotnet add FolderVersioning package Swashbuckle.AspNetCore
dotnet add FolderVersioning package Swashbuckle.AspNetCore.Annotations
dotnet add FolderVersioning package Swashbuckle.AspNetCore.Swagger
dotnet add FolderVersioning package Swashbuckle.AspNetCore.SwaggerGen
dotnet add FolderVersioning package Swashbuckle.AspNetCore.SwaggerUI
dotnet add FolderVersioning package Microsoft.VisualStudio.Web.CodeGeneration.Design --prerelease 
dotnet add FolderVersioning package System.Text.Json --prerelease 
dotnet add FolderVersioning package Microsoft.AspNetCore.Mvc.Versioning --prerelease
dotnet add FolderVersioning package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer --prerelease

dotnet new webapi -lang c# -n FullSwaggerSupport -au none -o .\FullSwaggerSupport -f net6.0
dotnet sln Japikse_VersioningAPIs.sln add FullSwaggerSupport

dotnet add FullSwaggerSupport package Swashbuckle.AspNetCore
dotnet add FullSwaggerSupport package Swashbuckle.AspNetCore.Annotations
dotnet add FullSwaggerSupport package Swashbuckle.AspNetCore.Swagger
dotnet add FullSwaggerSupport package Swashbuckle.AspNetCore.SwaggerGen
dotnet add FullSwaggerSupport package Swashbuckle.AspNetCore.SwaggerUI
dotnet add FullSwaggerSupport package Microsoft.VisualStudio.Web.CodeGeneration.Design --prerelease 
dotnet add FullSwaggerSupport package System.Text.Json --prerelease 
dotnet add FullSwaggerSupport package Microsoft.AspNetCore.Mvc.Versioning --prerelease
dotnet add FullSwaggerSupport package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer --prerelease

pause
