// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Dal - SampleDataInitializer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/03
// ==================================

namespace AutoLot.Dal.Initialization;

public static class SampleDataInitializer
{
    internal static void ClearData(ApplicationDbContext context)
    {
        var entities = new[]
        {
            typeof(CarDriver).FullName,
            typeof(Driver).FullName,
            typeof(Radio).FullName,
            typeof(Car).FullName,
            typeof(Make).FullName,
        };
        foreach (var entityName in entities)
        {
            var entity = context.Model.FindEntityType(entityName);
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
#pragma warning disable EF1002 // Risk of vulnerability to SQL injection.
            context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
            context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 1);");
#pragma warning restore EF1002 // Risk of vulnerability to SQL injection.
        }
    }

    internal static void SeedData(ApplicationDbContext context)
    {
        ProcessInsert(context, context.Makes, SampleData.Makes);
        ProcessInsert(context, context.Drivers, SampleData.Drivers);
        ProcessInsert(context, context.Cars, SampleData.Inventory);
        ProcessInsert(context, context.Radios, SampleData.Radios);
        ProcessInsert(context, context.CarsToDrivers, SampleData.CarsAndDrivers);

        static void ProcessInsert<TEntity>( 
            ApplicationDbContext context,
            DbSet<TEntity> table, 
            List<TEntity> records) where TEntity : BaseEntity
        {
            if (table.Any())
            {
                return;
            }
            IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using var transaction = context.Database.BeginTransaction();
                try
                {
                    var metaData = context.Model.FindEntityType(typeof(TEntity).FullName);
#pragma warning disable EF1002 // Risk of vulnerability to SQL injection.
                    context.Database.ExecuteSqlRaw(
                        $"SET IDENTITY_INSERT {metaData.GetSchema()}.{metaData.GetTableName()} ON");
                    table.AddRange(records);
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw(
                        $"SET IDENTITY_INSERT {metaData.GetSchema()}.{metaData.GetTableName()} OFF");
#pragma warning restore EF1002 // Risk of vulnerability to SQL injection.
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            });
        }
    }

    public static void ClearAndReseedDatabase(ApplicationDbContext context)
    {
        ClearData(context);
        SeedData(context);
    }
}