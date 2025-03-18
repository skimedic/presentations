To run this sample, you need to create the database. 

In package manage console or a console window, navigate to the AutoLot.Dal directory then run the following command:


dotnet ef database update

this will create the database using (localdb)\MSSqlLocalDb. If you need to use a different connection string,
you must update the value in:
AutoLot.Dal.EfStructures.ApplicationDbContextFactory.cs
and appsettings.development.json in the AutoLot.Web project.