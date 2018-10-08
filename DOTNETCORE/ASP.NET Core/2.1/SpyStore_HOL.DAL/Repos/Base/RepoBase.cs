using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore_HOL.DAL.EfStructures;
using SpyStore_HOL.Models.Entities.Base;

namespace SpyStore_HOL.DAL.Repos.Base
{
    public abstract class RepoBase<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        private readonly bool _disposeContext;
        protected readonly DbSet<T> Table;
        public StoreContext Context { get; }

        protected RepoBase(StoreContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }
        protected RepoBase() : this(new StoreContextFactory().CreateDbContext(new string[0]))
        {
            //This constructor is used for testing
            _disposeContext = true;
        }
        public int Count => Table.Count();
        public T Find(int id) => Table.Find(id);
        public virtual IList<T> GetAll() => Table.ToList();
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
            return Context.ChangeTracker.Entries<T>().Select((EntityEntry e) => (T)e.Entity).FirstOrDefault(x => x.Id == id);
        }
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
            Context.Entry(new T { Id = id, TimeStamp = timeStamp }).State = EntityState.Deleted;
            return persist ? SaveChanges() : 0;
        }
        public int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //A concurrency error occurred and should be handled intelligently
                Console.WriteLine(ex);
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                //DbResiliency retry limit exceeded and should be handled intelligently
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                //A general exception occurred and should be handled intelligently
                Console.WriteLine(ex);
                throw;
            }
        }
        public void Dispose()
        {
            if (_disposeContext)
            {
                Context.Dispose();
            }
        }


    }
}