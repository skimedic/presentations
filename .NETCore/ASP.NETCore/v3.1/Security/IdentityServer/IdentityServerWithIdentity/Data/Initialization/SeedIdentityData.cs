using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerWithIdentity.Data.Initialization
{
    public static class SeedIdentityData
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                //serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                //context.Database.Migrate();
                var clients = context.Clients.ToList();
                context.Clients.RemoveRange(clients);
                context.SaveChanges();
                var rawSqlString = $"DBCC CHECKIDENT (\"dbo.Clients\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ClientCorsOrigins\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ClientGrantTypes\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ClientRedirectUris\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ClientClaims\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ClientScopes\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ClientProperties\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ClientSecrets\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ClientPostLogoutRedirectUris\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ClientIdPRestrictions\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                var resources = context.IdentityResources.ToList();
                context.IdentityResources.RemoveRange(resources);
                context.SaveChanges();
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.IdentityResources\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.IdentityClaims\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.GetIdentityResources())
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                var apiResoruces = context.ApiResources.ToList();
                context.ApiResources.RemoveRange(apiResoruces);
                context.SaveChanges();
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ApiResources\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ApiClaims\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ApiScopes\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ApiScopeClaims\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                rawSqlString = $"DBCC CHECKIDENT (\"dbo.ApiSecrets\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.GetApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
