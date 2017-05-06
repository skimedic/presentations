using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore_HOL.DAL.EF;
using SpyStore_HOL.Models.Entities.Base;

namespace SpyStore_HOL.DAL.Repos.Base
{
    public abstract class RepoBase<T> : IDisposable, IRepo<T> 
        where T : EntityBase, new()
    {
        protected readonly StoreContext Db;
        private readonly bool _disposeContext;
        private IDbContextTransaction _transaction;
        protected DbSet<T> Table;
        public StoreContext Context => Db;

        protected RepoBase() : this(new StoreContext())
        {
            _disposeContext = true;
        }
        protected RepoBase(DbContextOptions<StoreContext> options) 
            : this(new StoreContext(options))
        {
            _disposeContext = true;
        }
        protected RepoBase(StoreContext context)
        {
            Db = context;
            Table = Db.Set<T>();
        }

        public int Count => Table.Count();
        public bool HasChanges => Db.ChangeTracker.HasChanges();

        public bool Any() => Table.Any();
        public bool Any(Expression<Func<T, bool>> where) => Table.Any(@where);

        public virtual IEnumerable<T> GetAll() => Table;
        public IEnumerable<T> GetAll<TIncludeField>(Expression<Func<T, TIncludeField>> include)
            => Table.Include(include);
        public IEnumerable<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending)
            => ascending ? Table.OrderBy(orderBy) : Table.OrderByDescending(orderBy);
        public IEnumerable<T> GetAll<TIncludeField, TSortField>(
            Expression<Func<T, TIncludeField>> include, Expression<Func<T, TSortField>> orderBy, bool ascending)
            => ascending ? Table.Include(include).OrderBy(orderBy) : Table.Include(include).OrderByDescending(orderBy);

        public T First() => Table.FirstOrDefault();
        public T First(Expression<Func<T, bool>> where) => Table.FirstOrDefault(where);
        public T First<TIncludeField>(Expression<Func<T, bool>> where, Expression<Func<T, TIncludeField>> include) 
            => Table.Where(where).Include(include).FirstOrDefault();

        //return Table.SingleOrDefault(x => x.Id == id) mixed mode evaluation;
        public T Find(int id) => Table.Find(id);

        public T Find(Expression<Func<T, bool>> where) 
            => Table.Where(where).FirstOrDefault();

        public T Find<TIncludeField>(Expression<Func<T, bool>> where, 
            Expression<Func<T, TIncludeField>> include) 
            => Table.Where(@where).Include(include).FirstOrDefault();

        public IEnumerable<T> GetSome(Expression<Func<T, bool>> where) 
            => Table.Where(where);

        public IEnumerable<T> GetSome<TIncludeField>(Expression<Func<T, bool>> where, 
            Expression<Func<T, TIncludeField>> include) 
            => Table.Where(where).Include(include);

        public IEnumerable<T> GetSome<TSortField>(
            Expression<Func<T, bool>> where, Expression<Func<T, TSortField>> orderBy, bool ascending)
            => ascending ? Table.Where(where).OrderBy(orderBy) : Table.Where(where).OrderByDescending(orderBy);

        public IEnumerable<T> GetSome<TIncludeField, TSortField>(
            Expression<Func<T, bool>> where, Expression<Func<T, TIncludeField>> include,
            Expression<Func<T, TSortField>> orderBy, bool ascending)
            => ascending ?
                Table.Where(where).OrderBy(orderBy).Include(include) :
                Table.Where(where).OrderByDescending(orderBy).Include(include);

        public IEnumerable<T> FromSql(string sqlString)
            => Table.FromSql(sqlString);

        public virtual IEnumerable<T> GetRange(int skip, int take)
            => GetRange(Table, skip, take);
        public IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take)
            => query.Skip(skip).Take(take);

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

        internal T GetEntryFromChangeTracker(int? id)
        {
            return Db.ChangeTracker.Entries<T>()
                .Select((EntityEntry e) => (T)e.Entity)
                    .FirstOrDefault(x => x.Id == id);
        }

        //TODO: Check For Cascade Delete
        public int Delete(int id, byte[] timeStamp, bool persist = true)
        {
            var entry = GetEntryFromChangeTracker(id);
            if (entry != null)
            {
                if (timeStamp != null && entry.TimeStamp.SequenceEqual(timeStamp))
                {
                    return Delete(entry, persist);
                }
                throw new Exception("Unable to delete due to concurrency violation.");
            }
            Db.Entry(new T { Id = id, TimeStamp = timeStamp }).State = EntityState.Deleted;
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