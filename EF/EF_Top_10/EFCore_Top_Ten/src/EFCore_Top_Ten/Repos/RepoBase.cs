#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - RepoBase.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EFCore_Top_Ten.EF;
using EFCore_Top_Ten.Exceptions;
using EFCore_Top_Ten.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace EFCore_Top_Ten.Repos
{
    public abstract class RepoBase<T> : IDisposable where T : EntityBase
    {
        protected readonly StoreContext Db = new StoreContext();
        protected DbSet<T> Table;

        public StoreContext Context => Db;

        public static string GetTableName(StoreContext context)
        {
            var metaData = context.Model.FindEntityType(typeof(T).FullName).SqlServer();
            return $"{metaData.Schema}.{metaData.TableName}";
        }
        public T Find(int? id)
        {
            var entity =
                Context.ChangeTracker.Entries<T>()
                    .Select((EntityEntry e) => (T)e.Entity)
                    .FirstOrDefault(x => x.Id == id);
            return entity ?? GetOne(id);
        }

        public T GetOne(int? id)
        {
            //return Table.SingleOrDefault(x => x.Id == id);
            var list = Table.Where(x => x.Id == id).ToList();
            switch (list.Count)
            {
                case 0:
                    return null;
                case 1:
                    return list[0];
            }
            throw new Exception("Too many results");

        }
        public async Task<T> GetOneAsync(int? id)
        {
            //return Table.SingleOrDefault(x => x.Id == id);
            var list = await Table.Where(x => x.Id == id).ToListAsync();
            switch (list.Count)
            {
                case 0:
                    return null;
                case 1:
                    return list[0];
            }
            throw new Exception("Too many results");

        }
        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }

        public async Task<int> AddAsync(T entity)
        {
            Table.Add(entity);
            return await SaveChangesAsync();
        }

        public int AddRange(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }

        public Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
            return SaveChangesAsync();
        }

        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public async Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return await SaveChangesAsync();
        }

        internal int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //handle appropriately
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                //handle appropriately
                throw ex;
            }
            catch (Exception ex)
            {
                //handle appropriately
                throw ex;
            }
        }
        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //handle appropriately
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                //handle appropriately
                throw ex;
            }
            catch (Exception ex)
            {
                //handle appropriately
                throw ex;
            }
        }

        bool _disposed = false;
        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }

            Db.Dispose();
            _disposed = true;
        }


    }
}
