dotnet new globaljson --sdk-version 8.0.100 --roll-forward feature
dotnet new nugetconfig 

dotnet new sln -n Japikse_VersioningDocumentingAPIs
dotnet sln add 

dotnet new webapi -lang c# -n KitchenSink -au none -o .\KitchenSink -f net8.0 --use-controllers
dotnet sln Japikse_VersioningDocumentingAPIs.sln add KitchenSink

dotnet add KitchenSink package Swashbuckle.AspNetCore -v [6.*,7.0)
dotnet add KitchenSink package Swashbuckle.AspNetCore.Annotations -v [6.*,7.0)
dotnet add KitchenSink package Swashbuckle.AspNetCore.Swagger -v [6.*,7.0)
dotnet add KitchenSink package Swashbuckle.AspNetCore.SwaggerGen -v [6.*,7.0)
dotnet add KitchenSink package Swashbuckle.AspNetCore.SwaggerUI -v [6.*,7.0)
dotnet add KitchenSink package Microsoft.VisualStudio.Web.CodeGeneration.Design -v [8.0.*,9.0) 
dotnet add KitchenSink package System.Text.Json -v [8.0.*,9.0)
dotnet add KitchenSink package Asp.Versioning.Mvc -v [8.0.*,9.0)
dotnet add KitchenSink package Asp.Versioning.Mvc.ApiExplorer -v [8.0.*,9.0)

pause
