using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStoreDAL.EfStructures;
using SpyStoreModels.Models.Base;

namespace SpyStoreDAL.Repos.RepoBase
{
    public abstract class RepoBase<T> : IRepo<T> where T : EntityBase, new()
    {
        protected readonly ApplicationDbContext Db;
        private readonly bool _disposeContext;
        private IDbContextTransaction _transaction;
        protected DbSet<T> Table;
        public ApplicationDbContext Context => Db;
        //TODO: This changed in 2.0
        protected RepoBase(DbContextOptions<ApplicationDbContext> options) 
            : this(new ApplicationDbContext(options))
        {
            _disposeContext = true;
        }
        protected RepoBase(ApplicationDbContext context)
        {
            Db = context;
            Table = Db.Set<T>();
        }
        public int Count => Table.Count();

        public virtual int Add(T entity, bool persist = true)
        {
            Table.Add(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int AddRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.AddRange(entities);
            return persist ? SaveChanges() : 0;
        }
        public virtual int Update(T entity, bool persist = true)
        {
            Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int UpdateRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.UpdateRange(entities);
            return persist ? SaveChanges() : 0;
        }
        public virtual int Delete(T entity, bool persist = true)
        {
            Table.Remove(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int DeleteRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.RemoveRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //A concurrency error occurred
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
            }
            //TODO: This was added back in 1.1
            catch (RetryLimitExceededException ex)
            {
                //DbResiliency retry limit exceeded
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
                //-2146232060
                //throw new Exception($"{ex.HResult}");
            }
        }

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction(IsolationLevel.RepeatableRead);
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }

        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }
            if (_disposeContext)
            {
                Db.Dispose();
            }
            _disposed = true;
        }

    }
}