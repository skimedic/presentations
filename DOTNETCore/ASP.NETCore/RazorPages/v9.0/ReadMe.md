# Description:
This is the sample for for Phil Japikse's ASP.NET Core 9 Razor Pages demo

## Create the database
To run this sample, you need to create the database. 

1. Open the solution in Visual Studio 2022 or later.
2. In package manage console or a console window, navigate to the AutoLot.Dal directory.
3. Run the following command:
```
dotnet ef database update
```

This will create the database using **(localdb)\MSSqlLocalDb**. If you need to use a different connection string,
you must update the value in **ApplicationDbContextFactory.cs** (Autolot.Dal project EfStructures directory):
```c#
var connectionString = @"server=(localdb)\MsSqlLocalDb;Database=AutoLot;Integrated Security=true;";
```
And in the appsettings.development.json file in the AutoLot.Web project.
```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=(localdb)\\MSSqlLocalDb;Database=AutoLot;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```
