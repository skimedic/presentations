using System;
using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AutoLot.Dal.Initialization
{
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

        public static void ClearAndReseedDatabase(ApplicationDbContext context)
        {
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }

        internal static void ClearData(ApplicationDbContext context)
        {
            var entities = new[] { 
                typeof(Order).FullName, 
                typeof(Customer).FullName, 
                typeof(Make).FullName, 
                typeof(Car).FullName, 
                typeof(CreditRisk).FullName 
            };
            foreach (var entityName in entities)
            {
                var entity = context.Model.FindEntityType(entityName);
                var tableName = entity.GetTableName();
                var schemaName = entity.GetSchema();
                context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
                context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 1);");
            }
        }

        internal static void ResetIdentity(ApplicationDbContext context)
        {
            foreach (var entity in context.Model.GetEntityTypes())
            {
                if (entity.FindPrimaryKey()==null)
                {
                    continue;
                }
                var tableName = entity.GetTableName();
                var schemaName = entity.GetSchema();
                context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 1);");
            }
        }

        internal static void SeedData(ApplicationDbContext context)
        {
            ProcessInsert(context, context.Customers, SampleData.Customers);
            ProcessInsert(context, context.Makes, SampleData.Makes);
            ProcessInsert(context, context.Cars, SampleData.Inventory);
            ProcessInsert(context, context.Orders, SampleData.Orders);
            ProcessInsert(context, context.CreditRisks, SampleData.CreditRisks);

            static void ProcessInsert<TEntity>(
                ApplicationDbContext context, DbSet<TEntity> table, List<TEntity> records) where TEntity : BaseEntity
            {
                //Check if any records exist
                if (!table.Any())
                {
                    //Create an execution strategy 
                    IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
                    strategy.Execute(() =>
                    {
                        //Open an explicit transaction
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
    }
}