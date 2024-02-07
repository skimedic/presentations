// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - SampleDataInitializer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/2/4
// ==================================

namespace AutoLot.Dal.Initialization;

public static class SampleDataInitializer
{
    internal static void DropAndCreateDatabase(ApplicationDbContext context)
    {
        context.Database.EnsureDeleted();
        //DON'T USE THIS! EnsureCreated() doesn't run the migrations, so SQL objects will be missing
        //context.Database.EnsureCreated();
        context.Database.Migrate();
    }

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
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextDesignTimeServices(context);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var designTimeModel = serviceProvider.GetService<IModel>();
        foreach (var entityName in entities)
        {
            var entity = context.Model.FindEntityType(entityName);
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
            context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 1);");
            if (entity.IsTemporal())
            {
                var strategy = context.Database.CreateExecutionStrategy();
                strategy.Execute(() =>
                {
                    using var trans = context.Database.BeginTransaction();
                    var designTimeEntity = designTimeModel.FindEntityType(entityName);
                    var historySchema = designTimeEntity.GetHistoryTableSchema();
                    var historyTable = designTimeEntity.GetHistoryTableName();
                    context.Database.ExecuteSqlRaw(
                        $"ALTER TABLE {schemaName}.{tableName} SET (SYSTEM_VERSIONING = OFF)");
                    context.Database.ExecuteSqlRaw($"DELETE FROM {historySchema}.{historyTable}");
                    context.Database.ExecuteSqlRaw(
                        $"ALTER TABLE {schemaName}.{tableName} SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE={historySchema}.{historyTable}))");
                    trans.Commit();
                });
            }
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
                    context.Database.ExecuteSqlRaw(
                        $"SET IDENTITY_INSERT {metaData.GetSchema()}.{metaData.GetTableName()} ON");
                    table.AddRange(records);
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw(
                        $"SET IDENTITY_INSERT {metaData.GetSchema()}.{metaData.GetTableName()} OFF");
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