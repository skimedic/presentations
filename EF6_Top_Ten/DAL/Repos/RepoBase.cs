#region copyright
// // Copyright Information
// // ==============================
// // DAL - RepoBase.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Exceptions;
using DAL.Models;

namespace DAL.Repos
{
    public abstract class RepoBase<T> : IDisposable where T : EntityBase
    {
        protected readonly StoreContext Db = new StoreContext(true);
        protected DbSet<T> Table;

        protected RepoBase(bool useLazyLoading)
        {
            Context.Configuration.LazyLoadingEnabled = useLazyLoading;
        }

        public StoreContext Context => Db;

        public string GetTableName()
        {
            var objectContext = ((IObjectContextAdapter)Db).ObjectContext;
            string sql = objectContext.CreateObjectSet<T>().ToTraceString();
            return new Regex("FROM (?<table>.*) AS").Match(sql).Groups["table"]?.Value;
        }
        public T GetOne(int? id) => Table.Find(id);

        public async Task<T> GetOneAsync(int? id) => await Table.FindAsync(id);
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
            catch (RetryLimitExceededException ex)
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
            catch (RetryLimitExceededException ex)
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
