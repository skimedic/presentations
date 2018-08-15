using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EFCoreSamples.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreSamples.Repos
{
    public class RepoBase<T> : IRepo<T> where T : class,new()
    {
        protected RepoBase(BloggingContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }

        public BloggingContext Context { get; private set; }

        protected readonly DbSet<T> Table;

        public void Dispose()
        {
        }

        public T Find(int id) => Table.Find(id);

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

        public virtual int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            //HACK: IRL these need to be handled
            catch (DbUpdateConcurrencyException)
            {
                //This happens when there is a concurrency error
                throw;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (RetryLimitExceededException)
            {
                //This happens when transient error occurs and retries are exhausted
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}