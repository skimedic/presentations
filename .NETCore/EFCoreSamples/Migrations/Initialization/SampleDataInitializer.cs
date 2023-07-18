using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Migrations.EFStructures;
using Migrations.Models.Base;

namespace Migrations.Initialization;

public static class SampleDataInitializer
{
    public static void DropAndCreateDatabase(ApplicationDbContext context)
    {
        context.Database.EnsureDeleted();
        //This doesn't run the migrations, so SQL objects will be missing
        //DON'T USE THIS => context.Database.EnsureCreated();
        context.Database.Migrate();
    }

    public static void InitializeData(ApplicationDbContext context)
    {
        DropAndCreateDatabase(context);
        SeedData(context);
    }

    public static void ClearDatabase(ApplicationDbContext context)
    {
        context.Database.Migrate();
        ClearData(context);
        SeedData(context);
    }

    internal static void ClearData(ApplicationDbContext context)
    {
        var entities = new[] {"Order", "Customer", "Make", "Car", "CreditRisk"};
        foreach (var entityName in entities)
        {
            var entity = context.Model.FindEntityType($"AutoLotDal.Models.Entities.{entityName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
        }
    }

    internal static void ResetIdentity(ApplicationDbContext context)
    {
        foreach (var entity in context.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 1);");
            //context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED);");
        }
    }

    internal static void ResetIdentityWorker(ApplicationDbContext context, IEnumerable<IEntityType> entities)
    {
        foreach (var entity in entities)
        {
            var tableName = context.Model.FindEntityType(entity.GetTableName());
            var schemaName = context.Model.FindEntityType(entity.GetSchema());
            context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 1);");
            //context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED);");
        }
    }

    internal static void SeedData(ApplicationDbContext context)
    {
        try
        {
            ProcessInsert(context, context.Customers, SampleData.Customers);
            ProcessInsert(context, context.Makes, SampleData.Makes);
            ProcessInsert(context, context.Cars, SampleData.Inventory);
            ProcessInsert(context, context.Orders, SampleData.Orders);
            ProcessInsert(context, context.CreditRisks, SampleData.CreditRisks);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private static void ProcessInsert<TEntity>(
        ApplicationDbContext context, DbSet<TEntity> table, List<TEntity> records) where TEntity : BaseEntity
    {
        if (!table.Any())
        {
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
}